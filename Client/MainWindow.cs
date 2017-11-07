using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainWindow : Form, ITestListener, IErgometerListener
    {
        private Ergometer _ergometer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            pn_patient.Visible = false;
            pn_test.Visible = false;
            foreach (string port in SerialPort.GetPortNames())
            {
                cb_ports.Items.Add(port);
            }

            ch_data.Series["Power"].Points.Clear();
            ch_data.Series["RPM"].Points.Clear();
            ch_data.Series["Heartrate"].Points.Clear();
        }

        /// <summary>
        ///  Creates ergometer
        /// </summary>
        private void bt_connect_Click(object sender, System.EventArgs e)
        {
            try
            {
                _ergometer = new Ergometer(cb_ports.SelectedItem.ToString(), this);
                pn_patient.Visible = true;
                pn_connect.Visible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        ///  Gets log file
        /// </summary>
        private async void btn_log_Click(object sender, System.EventArgs e)
        {
            try
            {
                var result = await LogServer.GetAsync(tb_log.Text);
                if (result["Error"] != null)
                {
                    var error = result["Error"].ToObject<int>();
                    switch (error)
                    {
                        case 1:
                            MessageBox.Show(this, "No log was found with that ID.", "LogID invalid");
                            return;
                    }
                }
                else if (result["EnduranceTest"] != null)
                {
                    new Log(JObject.Parse(result.ToString())).Show();
                    return;
                }
                MessageBox.Show(this, "An unknown error has occured, please try again.", "Unkown error");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10061)
                {
                    MessageBox.Show(this, "Could not connect to the server, please check your connection.",
                        "Connection failed");
                }
            }
        }

        /// <summary>
        ///   Starts Test
        /// </summary>
        private async void btn_start_Click(object sender, EventArgs e)
        {
            pn_patient.Visible = false;
            pn_test.Visible = true;

            MessageBox.Show(this, "You're about to participate in the VO2Max endurance test! \n\n" +
                "Steps to take before starting the test: \n" +
                "\t Get on the Kettler hometrainer \n" +
                "\t Attach the heartrate sensor to your ear \n" +
                "\t press 'OK' to start the test \n\n" +
                "The test begins with 2 minutes of warmup where your ideal cycling power will be determined \n" +
                "During the test the goal is to have a steady heartrate above 130 BPM \n" +
                "Also make sure your RPM stays between 50 and 60", "Start the Test!");

            await StartTest(new Patient(
                    tb_first_name.Text,
                    tb_last_name.Text,
                    dtp_birthdate.Value.Date,
                    rb_gender_male.Checked,
                    (int)nud_weight.Value
                )
            );
        }

        private async Task StartTest(Patient patient)
        {
            try
            {
                var result = await new EnduranceTest(_ergometer, patient, this).StartAsync();
                if (result?["EnduranceTest"] != null)
                {
                    var response = await LogServer.PutAsync(result);
                    if (response["Error"] != null)
                    {
                        var error = response["Error"].ToObject<int>();
                        switch (error)
                        {
                            case 0:
                                MessageBox.Show(this, "Log invalid.", "Saving failed");
                                return;
                        }
                    }
                    else if (response["LogID"] != null)
                    {
                        MessageBox.Show(this, response["LogID"].ToObject<string>(), "Your LogID");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Test result invalid, please try again.", "Test failed");
                    return;
                }
                MessageBox.Show(this, "An unknown error has occured, please try again.", "Unkown error");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10061)
                {
                    MessageBox.Show(this, "Could not connect to the server, please check your connection.",
                        "Connection failed");
                }
            }
        }

        public void OnStateChanged(string state, int time)
        {
            lb_state.Invoke(new Action(() => lb_state.Text = state));
            StartTimer(TimeSpan.FromMilliseconds(time));
            if (state == "NO")
            {
                lb_state.Invoke(new Action(() => lb_state.Text = "Test is done!"));
            }
        }

        private void StartTimer(TimeSpan time) {
            new Thread(() => {
                while (time.TotalSeconds > 0) {
                    time.Subtract(TimeSpan.FromSeconds(1));
                    lb_time_left.Invoke(new Action(() => lb_time_left.Text = time.ToString(@"mm\:ss")));
                    Thread.Sleep(1000);
                }
            }).Start();
        }

        public void OnErgometerDataReceived(int rpm, int hr, int power, int actualpower, TimeSpan time)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                lb_rpm.Text = rpm.ToString();
                lb_hr.Text = hr.ToString();
                lb_power.Text = power.ToString();
                lb_time.Text = time.ToString(@"mm\:ss");
                lb_actual_power.Text = actualpower.ToString();

                UpdateCycleCheck(rpm);
                AddToChart(rpm,hr,power,time);
            }));
        }

        private void UpdateCycleCheck(int rpm) {
            if (rpm < 50)
            {
                lb_cycle_check.Text = "Cycle faster!";
                lb_cycle_check.BackColor = Color.Red;
                lb_rpm_tip.Visible = true;
            }
            else if (rpm > 60)
            {
                lb_cycle_check.Text = "Cycle slower!";
                lb_cycle_check.BackColor = Color.Red;
                lb_rpm_tip.Visible = true;
            }
            else
            {
                lb_cycle_check.Text = "Perfect cycle speed!";
                lb_cycle_check.BackColor = Color.LawnGreen;
                lb_rpm_tip.Visible = false;
            }
        }

        private void AddToChart(int rpm, int hr, int power, TimeSpan time)
        {
            if (Math.Abs(time.TotalSeconds % 5) > 0.1) return;
            ch_data.Series["Power"].Points.AddXY(time.ToString(), power);
            ch_data.Series["Heartrate"].Points.AddXY(time.ToString(), hr);
            ch_data.Series["RPM"].Points.AddXY(time.ToString(), rpm);
        }
    }
}