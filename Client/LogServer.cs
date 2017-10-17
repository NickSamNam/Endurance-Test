using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Client
{
    public static class LogServer
    {
        /// <summary>
        ///   Get a log from the log server.
        /// </summary>
        /// <param name="logId">The log's unique identifier.</param>
        /// <returns>Returns the requested log, or null if it doesn't exist.</returns>
        public static async Task<JObject> GetAsync(int logId)
        {
            // TODO create body
            return null;
        }

        /// <summary>
        ///   Send a log to the log server.
        /// </summary>
        /// <param name="log">The log to send.</param>
        /// <returns>Returns the log's unique id to use when getting it from the server.</returns>
        public static async Task<int> PutAsync(JObject log)
        {
            // TODO create body
            return 0;
        }
    }
}