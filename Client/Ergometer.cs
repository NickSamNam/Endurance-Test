using System;
using Newtonsoft.Json.Linq;

namespace Client
{
    public class Ergometer
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Ergometer" /> class.
        /// </summary>
        /// <param name="port">The serial port on which to communicate with the ergometer.</param>
        public Ergometer(int port)
        {
            // TODO create body
        }

        /// <summary>
        ///   Get the log of ergometer values.
        /// </summary>
        public JObject Log { get; }

        /// <summary>
        ///   Get the reported heart rate.
        /// </summary>
        public int HR { get; }

        /// <summary>
        ///   Get the reported cycling rate.
        /// </summary>
        public int RPM { get; }

        /// <summary>
        ///   Get the reported actual power.
        /// </summary>
        public int ActualPower { get; }

        /// <summary>
        ///   Get the reported requested power.
        /// </summary>
        public int RequestedPower { get; set; }

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
            // TODO create body
        }

        /// <summary>
        ///   Close the connection with the ergometer.
        /// </summary>
        public void Close()
        {
            // TODO create body
        }
    }
}