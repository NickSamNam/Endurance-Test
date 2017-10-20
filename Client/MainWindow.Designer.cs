namespace Client
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_ports = new System.Windows.Forms.ComboBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.pn_connect = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pn_test = new System.Windows.Forms.Panel();
            this.lb_time = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.pn_connect.SuspendLayout();
            this.pn_test.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ports
            // 
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(124, 180);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(106, 21);
            this.cb_ports.TabIndex = 0;
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(124, 207);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(106, 23);
            this.bt_connect.TabIndex = 1;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // pn_connect
            // 
            this.pn_connect.Controls.Add(this.label1);
            this.pn_connect.Controls.Add(this.bt_connect);
            this.pn_connect.Controls.Add(this.cb_ports);
            this.pn_connect.Location = new System.Drawing.Point(1, 1);
            this.pn_connect.Name = "pn_connect";
            this.pn_connect.Size = new System.Drawing.Size(358, 432);
            this.pn_connect.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select port to connect:";
            // 
            // pn_test
            // 
            this.pn_test.Controls.Add(this.btn_start);
            this.pn_test.Controls.Add(this.lb_time);
            this.pn_test.Location = new System.Drawing.Point(0, 0);
            this.pn_test.Name = "pn_test";
            this.pn_test.Size = new System.Drawing.Size(358, 432);
            this.pn_test.TabIndex = 3;
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_time.Location = new System.Drawing.Point(149, 103);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(44, 16);
            this.lb_time.TabIndex = 0;
            this.lb_time.Text = "00:00";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(125, 27);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(91, 32);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start Test";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 432);
            this.Controls.Add(this.pn_test);
            this.Controls.Add(this.pn_connect);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.pn_connect.ResumeLayout(false);
            this.pn_connect.PerformLayout();
            this.pn_test.ResumeLayout(false);
            this.pn_test.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_ports;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Panel pn_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pn_test;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_time;
    }
}

