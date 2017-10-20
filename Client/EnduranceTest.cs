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
        private Ergometer _ergometer;
        private Patient _patient;

        public TestState TestState { get; set; } = TestState.NO;

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
                TestState = TestState.WARMUP;

                _ergometer.RequestedPower = 50;

                var stateTimer = new Timer();
                stateTimer.Elapsed += new ElapsedEventHandler(ChangeState);
                stateTimer.Interval = 120000;
                stateTimer.Start();

                while(TestState != TestState.NO)
                {
                    switch (TestState)
                    {
                        case TestState.WARMUP:
                            break;
                        case TestState.TEST:
                            break;
                        case TestState.ENDTEST:
                            break;
                        case TestState.COOLDOWN:
                            break;
                    }
                }

                stateTimer.Stop();
            }) .Start();

            return null;
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