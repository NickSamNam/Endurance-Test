using System;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client
{
    public partial class Log : Form
    {
        private dynamic _log;

        public Log(dynamic log)
        {
            InitializeComponent();
            _log = log;
        }

        private void Log_Load(object sender, System.EventArgs e)
        {
            lb_name_gender.Text = $"{_log.EnduranceTest.Patient.LastName}, {_log.EnduranceTest.Patient.FirstName}";
            lb_dob_age.Text = $"{_log.EnduranceTest.Patient.BirthDate}";
            lb_absvo2max.Text = $"{Math.Round((double) _log.EnduranceTest.TestResults.VO2MaxAbsolute, 2)}";
            lb_relvo2max.Text = $"{Math.Round((double)_log.EnduranceTest.TestResults.VO2MaxRelative, 2)}";
            lb_hr.Text = $"{_log.EnduranceTest.TestResults.HR}";
            lb_test_power.Text = $"{_log.EnduranceTest.TestResults.Power}";

            lb_steady.Text = $"Yes";
            if (_log.EnduranceTest.TestResults.VO2MaxAbsolute == null)
                lb_steady.Text = $"No";

            var length = _log.EnduranceTest.ErgometerLog.Count;
            var hrs = new int[length];
            var power = new int[length];
            var rpm = new int[length];
            var speed = new double[length];

            for (int i = 0; i < length; i++) {
                var line = _log.EnduranceTest.ErgometerLog[i];
                hrs[i] = line.HR ?? 0;
                power[i] = line.ActualPower ?? 0;
                rpm[i] = line.RPM ?? 0;
                speed[i] = line.Speed ?? 0;
            }

            FillChart(ch_log_hr, hrs);
            FillChart(ch_log_power, power);
            FillChart(ch_log_rpm, rpm);
            FillChart(ch_log_speed, speed);
        }

        private void FillChart(Chart chart, int[] data)
        {
            FillChart(chart, data.Select(x => (double)x).ToArray());
        }

        private void FillChart(Chart chart, double[] data)
        {
            var i = 0;
            foreach (double d in data)
            {
                chart.Series["Series1"].Points.AddXY(i,d);
                i++;
            }
        }
    }
}
