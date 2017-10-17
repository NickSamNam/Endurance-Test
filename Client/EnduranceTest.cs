using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Client
{
    public class EnduranceTest
    {
        private Ergometer _ergometer;
        private Patient _patient;

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
            // TODO create body
            return null;
        }
    }
}