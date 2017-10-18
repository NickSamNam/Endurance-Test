using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new FileStream("C:\\Users\\snick\\AppData\\Local\\Endurance Test Log Server\\test", FileMode.Open);
            LogHandler.CopyFromStream(fs, (ulong) fs.Length);
            return;
            const int port = 420;
            Console.CancelKeyPress += OnCancel;
            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Server started\nTime: {0:R}\nEndpoint: {1}\n", DateTime.Now,
                (IPEndPoint) listener.LocalEndpoint);
            while (true)
            {
                var c = listener.AcceptTcpClient();
                var client = new Client(c);
                new Thread(() => client.Accept()).Start();
            }
        }

        /// <summary>
        /// This method is called on cancel key press.
        /// </summary>
        /// <param name="sender">The sender of the cancellation.</param>
        /// <param name="e">The arguments of the cancellation event.</param>
        private static void OnCancel(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Shutting down...");
            Environment.Exit(0);
        }
    }

    internal class Client
    {
        private readonly TcpClient _client;
        private readonly SslStream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="tcpClient">The TCP client connection to associate with this client.</param>
        public Client(TcpClient tcpClient)
        {
            _client = tcpClient;
            _stream = new SslStream(_client.GetStream());
            try
            {
                _stream.AuthenticateAsServer(GetCertificate(), false, SslProtocols.Tls12, false);
            }
            catch (AuthenticationException)
            {
                Close();
            }
            catch (IOException)
            {
                Close();
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == -2146893043)
                {
                    Console.WriteLine("Run server as admin.");
                    Environment.Exit(1);
                }
                else
                    throw;
            }
        }

        /// <summary>
        /// Accept a client's request.
        /// </summary>
        public void Accept()
        {
            if (!_client.Connected) return;
            try
            {
                var sizeBuffer = new byte[8];
                _stream.Read(sizeBuffer, 0, sizeBuffer.Length);
                var messageLength = BitConverter.ToUInt64(sizeBuffer, 0);
                var messageBuffer = new byte[_client.ReceiveBufferSize];
                var messageBuilder = new StringBuilder();
                var requestType = (Request) _stream.ReadByte();
                if (!Enum.IsDefined(typeof(Request), requestType))
                {
                    Close();
                    return;
                }
                switch (requestType)
                {
                    case Request.Get:
                        var read = 0uL;
                        do
                        {
                            read += (uint) _stream.Read(messageBuffer, 0, messageBuffer.Length);
                            messageBuilder.Append(Encoding.ASCII.GetString(messageBuffer));
                        } while (read < messageLength);

                        var request = JObject.Parse(messageBuilder.ToString());
                        {
                            using (var fs = LogHandler.GetLogStream(request["LogID"].ToObject<string>()))
                            {
                                if (fs == null)
                                {
                                    Send(ErrorAsJSON(Error.LogNotFound));
                                    break;
                                }
                                var rl = BitConverter.GetBytes(fs.Length);
                                _stream.Write(rl, 0, rl.Length);
                                fs.CopyTo(_stream);
                            }
                        }
                        break;
                    case Request.Put:
                        var logID = LogHandler.SaveLog(messageBuilder.ToString());
                        Send(logID);
                        break;
                }
            }
            catch (JsonReaderException)
            {
            }
            catch (IOException)
            {
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == -2147467259)
                {
                    Console.WriteLine("Run server as admin.");
                    Environment.Exit(1);
                }
                else
                    throw;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Send a string to the client.
        /// </summary>
        /// <param name="message"></param>
        private void Send(string message)
        {
            var msg = Encoding.ASCII.GetBytes(message);
            var prefix = BitConverter.GetBytes((ulong) msg.Length);
            var buffer = new byte[prefix.Length + msg.Length];
            Buffer.BlockCopy(prefix, 0, buffer, 0, prefix.Length);
            Buffer.BlockCopy(msg, 0, buffer, prefix.Length, msg.Length);
            _stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Close the TCP client connection and network stream.
        /// </summary>
        private void Close()
        {
            _client.Close();
            _stream.Close();
        }

        /// <summary>
        /// Get the SSL certificate from store.
        /// </summary>
        /// <returns>Returns the SSL certificate.</returns>
        private static X509Certificate GetCertificate()
        {
            const string certThumbprint = "5D4E584F97C51BA721CDDC00A17981F7FCC0084E";
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var cert = store.Certificates.Find(X509FindType.FindByThumbprint, certThumbprint, true)[0];
            store.Close();
            if (cert != null) return cert;
            Console.WriteLine("The certificate could not be found.");
            Environment.Exit(1);
            return cert;
        }

        private string ErrorAsJSON(Error error) => $@"{{""Error:{(int) error}}}";

        internal enum Error
        {
            LogNotFound
        }

        internal enum Request
        {
            Put,
            Get
        }
    }
}