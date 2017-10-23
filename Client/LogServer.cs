using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client
{
    public static class LogServer
    {
        private const string Host = "localhost";
        private const int Port = 420;

        /// <summary>
        ///   Get a log from the log server.
        /// </summary>
        /// <param name="logId">The log's unique identifier.</param>
        /// <returns>Returns the requested log, or null if it doesn't exist.</returns>
        /// <exception cref="AuthenticationException">The server authentication has failed.</exception>
        public static async Task<JObject> GetAsync(string logId)
        {
            var request = new JObject {{"LogID", logId.ToLower()}};
            var response = await RequestAsync(request.ToString(), Request.Get);
            return response;
        }

        /// <summary>
        ///   Send a log to the log server.
        /// </summary>
        /// <param name="log">The log to send.</param>
        /// <returns>Returns the log's unique id to use when getting it from the server, or an error or empty JSON if the log is invalid.</returns>
        /// <exception cref="AuthenticationException">The server authentication has failed.</exception>
        public static async Task<JObject> PutAsync(JObject log)
        {
            var response = await RequestAsync(log.ToString(), Request.Put);
            return response;
        }

        private static async Task<JObject> RequestAsync(string request, Request requestType)
        {
            var connectionTask = GetConnection();
            var sBuffer = PrepareContent(request, requestType);
            var connection = await connectionTask;
            using (connection.Item1)
            using (var stream = connection.Item2)
            {
                var sendTask = stream.WriteAsync(sBuffer, 0, sBuffer.Length);
                var sizeBuffer = new byte[8];
                await sendTask;
                var sizeTask = stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                await sizeTask;
                var messageLength = BitConverter.ToUInt64(sizeBuffer, 0);
                stream.ReadTimeout = 1000;
                return await ProcessResponseFromStreamAsync(stream);
            }
        }

        private static async Task<Tuple<TcpClient, SslStream>> GetConnection()
        {
            var client = new TcpClient(Host, Port);
            var stream = new SslStream(client.GetStream(), false, ValidateServerCertificate, null);
            await stream.AuthenticateAsClientAsync("LateLobster");
            return Tuple.Create(client, stream);
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslpolicyerrors) => sslpolicyerrors == SslPolicyErrors.None;

        /// <summary>
        /// Turns the content into a byte array and prefixes it with the request type and content length.
        /// </summary>
        /// <param name="content">The content to prepare.</param>
        /// <param name="type">The request type for which the content will be used.</param>
        /// <returns>Returns the prepared content.</returns>
        private static byte[] PrepareContent(string content, Request type)
        {
            var c = Encoding.ASCII.GetBytes(content);
            var l = BitConverter.GetBytes((ulong) c.Length);
            var pc = new byte[l.Length + c.Length + 1];
            Buffer.BlockCopy(l, 0, pc, 0, l.Length);
            pc[8] = (byte) type;
            Buffer.BlockCopy(c, 0, pc, l.Length + 1, c.Length);
            return pc;
        }

        private static async Task<JObject> ProcessResponseFromStreamAsync(Stream stream)
        {
            using (var r = new StreamReader(stream))
            using (var reader = new JsonTextReader(r))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        return (JObject) await JToken.ReadFromAsync(reader);
                    }
                }
                return new JObject();
            }
        }

        internal enum Error
        {
            InvalidLog,
            LogNotFound
        }

        internal enum Request
        {
            Put,
            Get
        }
    }
}