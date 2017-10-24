using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO.Ports;
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
        private void btn_log_Click(object sender, System.EventArgs e)
        {
            var result = LogServer.GetAsync(tb_log.Text);
            if (result == null) {
                MessageBox.Show(this, "Log with that ID doesn't excists!");
                return;
            }

            new Log(JObject.Parse(result.ToString())).Show();
        }

        /// <summary>
        ///   Starts Test
        /// </summary>
        private async void btn_start_Click(object sender, EventArgs e)
        {
            pn_patient.Visible = false;
            pn_test.Visible = true;

            await StartTest(new Patient(
                    tb_first_name.Text,
                    tb_last_name.Text,
                    dtp_birthdate.MinDate,
                    rb_gender_male.Checked
                )
            );
        }

        private async Task StartTest(Patient patient)
        {
            var result = await new EnduranceTest(_ergometer, patient, this).StartAsync();
            if (result["EnduranceTest"] != null)
            {
                var response = await LogServer.PutAsync(result);
                if (response["Error"] != null)
                {
                    var error = response["Error"].ToObject<int>();
                    switch (error)
                    {
                        case 0:
                            MessageBox.Show(this, "Log invalid.", "Saving failed.");
                            return;
                    }
                }
                else if (response["LogID"] != null)
                {
                    MessageBox.Show(this, response["LogID"].ToObject<string>(), "Your LogID.");
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "Test result invalid, please try again.", "Test failed.");
                return;
            }
            MessageBox.Show(this, "An unknown error has occured, please try again.", "Unkown error.");
        }

        public void OnStateChanged(string state)
        {
            lb_state.Invoke(new Action(() => lb_state.Text = state));

            if (state == "NO")
            {
                lb_state.Invoke(new Action(() => lb_state.Text = "Test is done!"));
            }
        }

        public void OnErgometerDataReceived(int rpm, int hr, int power, TimeSpan time)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                lb_rpm.Text = rpm.ToString();
                lb_hr.Text = hr.ToString();
                lb_power.Text = power.ToString();
                lb_time.Text = time.ToString("mm:ss");
            }));
        }
    }
}