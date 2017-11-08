using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Timer = System.Timers.Timer;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Client.EnduranceTestExceptions;

namespace Client
{
    public class EnduranceTest
    {
        private readonly Ergometer _ergometer;
        private Patient _patient;

        public TestState CurrentState { get; set; } = TestState.No;
        private ITestListener _listener;

        private static readonly double[][] _ageValues =
        {
            new double[] {15, 1.1, 210},
            new double[] {25, 1.0, 200},
            new double[] {35, .87, 190},
            new double[] {40, .83, 180},
            new double[] {45, .78, 170},
            new double[] {50, .75, 160},
            new double[] {55, .71, 150},
            new double[] {60, .68, 150},
            new double[] {65, .65, 150}
        };

        private double[] _values;
        private List<int> _hRs = new List<int>();

        private EnduranceTestException _exceptionInTimer;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EnduranceTest" /> class.
        /// </summary>
        /// <param name="ergometer">The ergometer from which to get measurements.</param>
        /// <param name="patient">The patient who's being tested.</param>
        /// <param name="listener">The listener the test replies to.</param>
        public EnduranceTest(Ergometer ergometer, Patient patient, ITestListener listener)
        {
            _ergometer = ergometer;
            _listener = listener;
            _patient = patient;
        }

        /// <summary>
        ///   Start the endurance test.
        /// </summary>
        /// <returns>Returns the test results.</returns>
        public async Task<JObject> StartAsync()
        {
            int? testPower = null, ssHR = null;
            try
            {
                var results = await Task.Run(() =>
                {
                    _ergometer.Reset();
                    Thread.Sleep(1000);
                    _hRs = new List<int>();
                    CurrentState = TestState.Warmup;
                    _listener.OnStateChanged(CurrentState.ToString(), 120000);
                    _ergometer.RequestedPower = 50;

                    var stateTimer = new Timer();
                    stateTimer.Elapsed += ChangeState;
                    stateTimer.Interval = 120000;
                    stateTimer.Start();

                    double[] prevValue = _ageValues[0];
                    foreach (double[] values in _ageValues)
                    {
                        if (values[0] > _patient.Age)
                            _values = prevValue;
                        prevValue = values;
                    }

                    if (_values == null)
                    {
                        _values = _ageValues[_ageValues.Length - 1];
                    }

                    int[] hRs = new int[8];
                    var pretestTimer = new Timer();
                    pretestTimer.Interval = 15000;
                    pretestTimer.Elapsed += WarmupTimerElapsed;

                    var testTimer = new Timer();
                    testTimer.Interval = 15000;
                    testTimer.Elapsed += EndTestTimerElapsed;

                    var cooldownTimer = new Timer();
                    cooldownTimer.Interval = 5000;
                    cooldownTimer.Elapsed += CooldownTimerElapsed;

                    int power = 0;

                    var test = false;
                    var endtest = false;
                    var cooldown = false;
                    while (CurrentState != TestState.No)
                    {
                        {
                            if (_exceptionInTimer != null)
                                throw _exceptionInTimer;
                            {
                            }
                            switch (CurrentState)
                            {
                                case TestState.Warmup:
                                    break;
                                case TestState.Test:
                                    if (!test)
                                    {
                                        _listener.OnStateChanged(CurrentState.ToString(), 240000);
                                        pretestTimer.Start();
                                        power = _ergometer.RequestedPower;
                                        test = true;
                                    }
                                    break;
                                case TestState.EndTest:
                                    if (!endtest)
                                    {
                                        pretestTimer.Stop();
                                        testTimer.Start();
                                        endtest = true;
                                    }
                                    break;
                                case TestState.Cooldown:
                                    if (!cooldown)
                                    {
                                        _listener.OnStateChanged(CurrentState.ToString(), 60000);
                                        stateTimer.Interval = 60000;
                                        testTimer.Stop();
                                        cooldownTimer.Start();
                                        cooldown = true;
                                    }
                                    break;
                            }
                        }
                    }
                    cooldownTimer.Stop();
                    stateTimer.Stop();
                    _ergometer.Close();

                    return Tuple.Create(Convert.ToInt32(_hRs.Average()), power);
                });
                testPower = results.Item2;
                ssHR = results.Item1;
            }
            catch (MaxHRReachedException)
            {
                new Thread(() => MessageBox.Show("Maximum heartrate exceeded!", "Test failed.")).Start();
            }
            catch (MinHRNotReachedException)
            {
                new Thread(() => MessageBox.Show("Heartrate did not reach 130 BPM", "Test failed.")).Start();
            }
            catch (SteadyStateUnreachableException)
            {
                new Thread(() => MessageBox.Show("Heartrate too irregular.", "Test failed.")).Start();
            }
            var ergometerLog = _ergometer.Log;
            double? vO2MaxAbs = null;
            double? vO2MaxRel = null;
            if (testPower != null && ssHR != null)
            {
                vO2MaxAbs = Nomogram.CalcVO2MaxAbsolute(_patient, (int) testPower, (int) ssHR);
                vO2MaxRel = Nomogram.CalcVO2MaxRelative(_patient, (double) vO2MaxAbs);
            }
            return new JObject
            {
                {
                    "EnduranceTest", new JObject
                    {
                        {
                            "Patient", new JObject
                            {
                                {"FirstName", _patient.FirstName},
                                {"LastName", _patient.LastName},
                                {"BirthDate", _patient.Birthdate.ToString("dd-MM-yyyy")},
                                {"Mass", _patient.Mass}
                            }
                        },
                        {
                            "TestResults", new JObject
                            {
                                {"VO2MaxAbsolute", vO2MaxAbs},
                                {"VO2MaxRelative", vO2MaxRel},
                                {"Power", testPower},
                                {"HR", ssHR}
                            }
                        },
                        {
                            "ErgometerLog", ergometerLog
                        }
                    }
                }
            };
        }

        private void CooldownTimerElapsed(object source, ElapsedEventArgs e)
        {
            _ergometer.RequestedPower -= 25;
        }

        private void WarmupTimerElapsed(object source, ElapsedEventArgs e)
        {
            if (_ergometer.HR < 130 && _ergometer.RPM > 50)
            {
                if (_patient.IsMale)
                    _ergometer.RequestedPower += 50;
                else
                    _ergometer.RequestedPower += 25;
            }
            else if (_ergometer.HR > (_values[2] * 95))
            {
                _ergometer.RequestedPower -= 50;
            }
        }

        private void EndTestTimerElapsed(object source, ElapsedEventArgs e)
        {
            _hRs.Add(_ergometer.HR);
            if (_hRs.Max() > _patient.MaxHeartRate)
            {
                _exceptionInTimer = new MaxHRReachedException();
            }
            else if (_hRs.Min() < 130)
            {
                _exceptionInTimer = new MinHRNotReachedException();
            }
            else if (_hRs.Max() - _hRs.Min() > 5)
            {
                _exceptionInTimer = new SteadyStateUnreachableException();
            }
        }

        /// <summary>
        ///   Change state of test
        /// </summary>
        private void ChangeState(object source, ElapsedEventArgs e)
        {
            switch (CurrentState)
            {
                case TestState.Warmup:
                    CurrentState = TestState.Test;
                    break;
                case TestState.Test:
                    CurrentState = TestState.EndTest;
                    break;
                case TestState.EndTest:
                    CurrentState = TestState.Cooldown;
                    break;
                case TestState.Cooldown:
                    CurrentState = TestState.No;
                    break;
            }

            Debug.WriteLine(CurrentState.ToString());
        }
    }

    public enum TestState
    {
        No,
        Warmup,
        Test,
        EndTest,
        Cooldown
    }
}