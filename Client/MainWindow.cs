using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;

namespace Client
{
    public partial class MainWindow : Form
    {
        private Ergometer _ergometer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
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
                //_ergometer = new Ergometer(cb_ports.SelectedItem.ToString());
                pn_test.Visible = true;
                pn_connect.Visible = false;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        ///   Starts Test
        /// </summary>
        private void btn_start_Click(object sender, EventArgs e)
        {
            var result = new EnduranceTest(_ergometer, new Patient("Test", "Test", new DateTime())).StartAsync(); // TODO: remove Patient
        }
    }
}