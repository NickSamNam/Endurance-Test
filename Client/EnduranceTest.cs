using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Timer = System.Timers.Timer;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

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
            var results = await Task.Run(() =>
            {
                _ergometer.Reset();
                Thread.Sleep(1000);
                _hRs = new List<int>();
                CurrentState = TestState.Warmup;
                _listener.OnStateChanged(CurrentState.ToString());
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
                var warmupTimer = new Timer();
                warmupTimer.Interval = 15000;
                warmupTimer.Elapsed += WarmupTimerElapsed;

                var testTimer = new Timer();
                testTimer.Interval = 15000;
                testTimer.Elapsed += EndTestTimerElapsed;

                var cooldownTimer = new Timer();
                cooldownTimer.Interval = 5000;
                cooldownTimer.Elapsed += CooldownTimerElapsed;

                int power = 0;

                var warmup = false;
                var endtest = false;
                var cooldown = false;
                while (CurrentState != TestState.No)
                {
                    switch (CurrentState)
                    {
                        case TestState.Warmup:
                            if (!warmup)
                            {
                                warmupTimer.Start();
                                warmup = true;
                            }
                            break;
                        case TestState.Test:
                            warmupTimer.Stop();
                            power = _ergometer.RequestedPower;
                            break;
                        case TestState.EndTest:
                            if (!endtest)
                            {
                                testTimer.Start();
                                endtest = true;
                            }
                            break;
                        case TestState.Cooldown:
                            if (!cooldown)
                            {
                                testTimer.Stop();
                                cooldownTimer.Start();
                                cooldown = true;
                            }
                            break;
                    }
                }
                cooldownTimer.Stop();
                stateTimer.Stop();

                if (_hRs.Min() >= 130 && _hRs.Max() <= _patient.MaxHeartRate && _hRs.Max() - _hRs.Min() <= 5)
                {
                    return Tuple.Create(Convert.ToInt32(_hRs.Average()), power);
                }
                return null;
            });

            if (results == null) return null;

            var ergometerLog = _ergometer.Log;
            var vO2Max = Nomogram.CalcVO2Max(_patient, results.Item2, results.Item1);
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
                                {"BirthDate", _patient.Birthdate.ToString("dd-MM-yyyy")}
                            }
                        },
                        {
                            "TestResults", new JObject
                            {
                                {"VO2Max", vO2Max}
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

            _listener.OnStateChanged(CurrentState.ToString());

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