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

        public TestState TestState { get; set; } = TestState.No;

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
        public EnduranceTest(Ergometer ergometer, Patient patient)
        {
            _ergometer = ergometer;
            _patient = patient;
        }

        /// <summary>
        ///   Start the endurance test.
        /// </summary>
        /// <returns>Returns the test results.</returns>
        public async Task<JObject> StartAsync()
        {
            var results = await new Task<Tuple<int, int>>(() =>
            {
                _hRs = new List<int>();
                TestState = TestState.Warmup;

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
                var testTimer = new Timer();
                testTimer.Interval = 1500;

                int power = 0;

                while (TestState != TestState.No)
                {
                    switch (TestState)
                    {
                        case TestState.Warmup:
                            testTimer.Start();
                            testTimer.Elapsed += WarmupTimerElapsed;
                            break;
                        case TestState.Test:
                            testTimer.Stop();
                            testTimer = new Timer();
                            testTimer.Interval = 1500;
                            power = _ergometer.RequestedPower;
                            break;
                        case TestState.EndTest:
                            testTimer.Start();
                            testTimer.Elapsed += EndTestTimerElapsed;
                            break;
                        case TestState.Cooldown:
                            testTimer.Stop();
                            _ergometer.RequestedPower = 50;
                            break;
                    }
                }
                stateTimer.Stop();

                if (_hRs.Max() - _hRs.Min() <= 5)
                {
                    double avgHr = 0;
                    foreach (int hr in _hRs)
                    {
                        avgHr += hr;
                    }
                    return Tuple.Create(Convert.ToInt32(avgHr / _hRs.Count), power);
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
                                {"BirthDate", _patient.Birthdate.ToString("dd-MM-yyy")}
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

        private void WarmupTimerElapsed(object source, ElapsedEventArgs e)
        {
            if (_ergometer.HR < 130)
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
            switch (TestState)
            {
                case TestState.Warmup:
                    TestState = TestState.Test;
                    break;
                case TestState.Test:
                    TestState = TestState.EndTest;
                    break;
                case TestState.EndTest:
                    TestState = TestState.Cooldown;
                    break;
                case TestState.Cooldown:
                    TestState = TestState.No;
                    break;
            }
            Debug.WriteLine(TestState.ToString());
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