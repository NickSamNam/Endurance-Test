using System.Threading.Tasks;

namespace Server
{
    public static class LogHandler
    {
        /// <summary>
        /// Save a log to the appropriate place in the filesystem.
        /// </summary>
        /// <param name="log">The log to save.</param>
        /// <returns>Returns the log's unique id to use when requesting it from storage.</returns>
        public static string SaveLog(string log)
        {
            // TODO create body
            return null;
        }

        /// <summary>
        /// Load a log from storage.
        /// </summary>
        /// <param name="logId">The log's unique identifier.</param>
        /// <returns>Returns the requested log, or null if it doesn't exist.</returns>
        public static string LoadLog(string logId)
        {
            // TODO create body
            return null;
        }
    }
}