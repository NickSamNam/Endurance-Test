using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Timer = System.Timers.Timer;
using System.Timers;
using System.Diagnostics;
using System.Threading;

namespace Client
{
    public class EnduranceTest
    {
        private readonly Ergometer _ergometer;
        private Patient _patient;

        public TestState TestState { get; set; } = TestState.No;

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
            await new Task(() =>
            {
                _ergometer.Reset();
                TestState = TestState.Warmup;

                _ergometer.RequestedPower = 50;

                var stateTimer = new Timer();
                stateTimer.Elapsed += ChangeState;
                stateTimer.Interval = 120000;
                stateTimer.Start();

                while (TestState != TestState.No)
                {
                    switch (TestState)
                    {
                        case TestState.Warmup:
                            break;
                        case TestState.Test:
                            break;
                        case TestState.EndTest:
                            break;
                        case TestState.Cooldown:
                            break;
                    }
                }

                stateTimer.Stop();
            });
            // TODO replace with actual values
            var avgHR = 0;
            var power = 0;

            var ergometerLog = _ergometer.Log;
            var vO2Max = Nomogram.CalcVO2Max(_patient, power, avgHR);
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