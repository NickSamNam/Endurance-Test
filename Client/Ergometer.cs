using System;
using Newtonsoft.Json.Linq;
using System.IO.Ports;
using System.Diagnostics;
using System.Timers;

namespace Client
{
    public interface IErgometerListener {
        void OnErgometerDataReceived(int rpm, int hr, int power, TimeSpan time);
    }

    public class Ergometer
    {
        private readonly SerialPort _serialPort;
        private bool _cmMode;
        private IErgometerListener _listener;

        /// <summary>
        ///   Initializes a new instance of the <see cref="Ergometer" /> class.
        /// </summary>
        /// <param name="port">The serial port on which to communicate with the ergometer.</param>
        public Ergometer(string port, IErgometerListener listener)
        {
            _serialPort = new SerialPort(port, 9600, Parity.None);
            _serialPort.Open();
            _serialPort.DataReceived += OnReceive;

            _listener = listener;
        }

        /// <summary>
        ///   Get the log of ergometer values.
        /// </summary>
        public JArray Log { get; } = new JArray();

        /// <summary>
        ///   Get the reported heart rate.
        /// </summary>
        public int HR { get; private set; }

        /// <summary>
        ///   Get the reported cycling rate.
        /// </summary>
        public int RPM { get; private set; }

        /// <summary>
        ///   Get the reported actual power.
        /// </summary>
        public int ActualPower { get; private set; }

        private int _requestedPower;

        /// <summary>
        ///   Get the reported requested power.
        /// </summary>
        public int RequestedPower
        {
            get => _requestedPower;
            set
            {
                if (value > 400 || value < 25) return;
                _requestedPower = value;
                var _out = $"PW {value}";
                _serialPort.WriteLine(_out);
            }
        }

        /// <summary>
        ///   Get the reported speed.
        /// </summary>
        public decimal Speed { get; set; }

        /// <summary>
        ///   Get the reported distance.
        /// </summary>
        public decimal Distance { get; set; }

        /// <summary>
        ///   Get the reported time.
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        ///   Reset the ergometer.
        /// </summary>
        public void Reset()
        {
            _cmMode = false;
            const string _out = "RS";
            _serialPort.WriteLine(_out);
        }

        public void Status()
        {
            const string _out = "ST";
            _serialPort.WriteLine(_out);
        }

        /// <summary>
        ///   Turns on Command Mode
        /// </summary>
        public void CmMode()
        {
            const string _out = "CM";
            _serialPort.WriteLine(_out);
        }

        /// <summary>
        ///   On data received.
        /// </summary>
        private void OnReceive(object sender, SerialDataReceivedEventArgs args)
        {
            try
            {
                var serialPort = (SerialPort) sender;
                var data = serialPort.ReadLine();

                switch (data.Trim())
                {
                    case "ERROR":
                        Reset();
                        return;
                    case "ACK":
                        CmMode();
                        return;
                    case "RUN":
                        _cmMode = true;
                        AutoUpdate();
                        return;
                }

                try
                {
                    var dataSt = data.Split('\t');

                    if (dataSt.Length != 8)
                        return;

                    HR = int.Parse(dataSt[0]);
                    RPM = int.Parse(dataSt[1]);
                    Speed = decimal.Parse(dataSt[2]) / 10;
                    Distance = decimal.Parse(dataSt[3]) / 10;
//                    RequestedPower = int.Parse(dataSt[4]);
                    Time = TimeSpan.FromSeconds(int.Parse(dataSt[6].Split(':')[0]) * 60 +
                                                int.Parse(dataSt[6].Split(':')[1]));
                    ActualPower = int.Parse(dataSt[7]);

                    _listener.OnErgometerDataReceived(RPM, HR, RequestedPower, Time);

                    if (Log.Last != null && Log.Last["Time"] != null &&
                        Time.TotalSeconds - Log.Last["Time"].ToObject<int>() >= 5)
                    {
                        LogCurrent();    
                    }
                }
                catch (ArgumentNullException ane)
                {
                    Debug.WriteLine(ane.StackTrace);
                }
                catch (FormatException fe)
                {
                    Debug.WriteLine(fe.StackTrace);
                }
            }
            catch (System.IO.IOException ioe)
            {
                Debug.WriteLine(ioe.StackTrace);
            }
        }

        private void AutoUpdate()
        {
            var timer = new Timer(100);
            timer.Elapsed += Status;
            timer.Start();
        }

        private void Status(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (_cmMode)
                {
                    Status();
                }
                else
                {
                    ((Timer) sender).Dispose();
                }
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void LogCurrent()
        {
            Log.Add(new JObject
            {
                {"HR", HR},
                {"RPM", RPM},
                {"ActualPower", ActualPower},
                {"RequestedPower", RequestedPower},
                {"Speed", Speed},
                {"Distance", Distance},
                {"Time", Time.TotalSeconds}
            });
        }

        /// <summary>
        ///   Close the connection with the ergometer.
        /// </summary>
        public void Close()
        {
            _serialPort.Close();
            _serialPort.Dispose();
        }
    }
}