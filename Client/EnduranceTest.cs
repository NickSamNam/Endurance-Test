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
        private Ergometer _ergometer;
        private Patient _patient;

        public TestState TestState { get; set; } = TestState.NO;

        private static readonly double[][] _ageValues = {
            new double[]{15, 1.1,  210},
            new double[]{25, 1.0,  200},
            new double[]{35, .87,  190},
            new double[]{40, .83,  180},
            new double[]{45, .78,  170},
            new double[]{50, .75,  160},
            new double[]{55, .71,  150},
            new double[]{60, .68,  150},
            new double[]{65, .65,  150}
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
            new Thread(() => {
                _hRs = new List<int>();
                TestState = TestState.WARMUP;

                _ergometer.RequestedPower = 50;

                var stateTimer = new Timer();
                stateTimer.Elapsed += new ElapsedEventHandler(ChangeState);
                stateTimer.Interval = 120000;
                stateTimer.Start();

                double[] prevValue = _ageValues[0];
                foreach (double[] values in _ageValues) {
                    if (values[0] > _patient.Age)
                        _values = prevValue;
                    prevValue = values;
                }

                if (_values == null) {
                    _values = _ageValues[_ageValues.Length - 1];
                }

                int[] hRs = new int[8];
                var testTimer = new Timer();
                testTimer.Interval = 1500;
                
                while (TestState != TestState.NO)
                {
                    switch (TestState)
                    {
                        case TestState.WARMUP:
                            testTimer.Start();
                            testTimer.Elapsed += new ElapsedEventHandler(WarmupTimerElapsed);         
                            break;
                        case TestState.TEST:
                            testTimer.Stop();
                            testTimer = new Timer();
                            testTimer.Interval = 1500;
                            break;
                        case TestState.ENDTEST:
                            testTimer.Start();
                            testTimer.Elapsed += new ElapsedEventHandler(EndTestTimerElapsed);
                            break;
                        case TestState.COOLDOWN:
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
                    avgHr /= _hRs.Count;
                }
                else
                {

                }
            }) .Start();

            return null;
        }

        private void WarmupTimerElapsed(object source, ElapsedEventArgs e) {
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
                case TestState.WARMUP: TestState = TestState.TEST;
                    break;
                case TestState.TEST: TestState = TestState.ENDTEST;
                    break;
                case TestState.ENDTEST: TestState = TestState.COOLDOWN;
                    break;
                case TestState.COOLDOWN: TestState = TestState.NO;
                    break;
            }
            Debug.WriteLine(TestState.ToString());
        }
    }

    public enum TestState {
        NO, WARMUP, TEST, ENDTEST, COOLDOWN
    }
            
}