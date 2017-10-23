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
            this.pn_patient = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_birthdate = new System.Windows.Forms.DateTimePicker();
            this.rb_gender_female = new System.Windows.Forms.RadioButton();
            this.rb_gender_male = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_last_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_first_name = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.pn_test = new System.Windows.Forms.Panel();
            this.lb_state = new System.Windows.Forms.Label();
            this.btn_log = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pn_connect.SuspendLayout();
            this.pn_patient.SuspendLayout();
            this.pn_test.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ports
            // 
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(163, 120);
            this.cb_ports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(140, 24);
            this.cb_ports.TabIndex = 0;
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(163, 153);
            this.bt_connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(141, 28);
            this.bt_connect.TabIndex = 1;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // pn_connect
            // 
            this.pn_connect.Controls.Add(this.label5);
            this.pn_connect.Controls.Add(this.tb_log);
            this.pn_connect.Controls.Add(this.btn_log);
            this.pn_connect.Controls.Add(this.label1);
            this.pn_connect.Controls.Add(this.bt_connect);
            this.pn_connect.Controls.Add(this.cb_ports);
            this.pn_connect.Location = new System.Drawing.Point(0, 3);
            this.pn_connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_connect.Name = "pn_connect";
            this.pn_connect.Size = new System.Drawing.Size(477, 532);
            this.pn_connect.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select port to connect:";
            // 
            // pn_patient
            // 
            this.pn_patient.Controls.Add(this.label4);
            this.pn_patient.Controls.Add(this.dtp_birthdate);
            this.pn_patient.Controls.Add(this.rb_gender_female);
            this.pn_patient.Controls.Add(this.rb_gender_male);
            this.pn_patient.Controls.Add(this.label3);
            this.pn_patient.Controls.Add(this.tb_last_name);
            this.pn_patient.Controls.Add(this.label2);
            this.pn_patient.Controls.Add(this.tb_first_name);
            this.pn_patient.Controls.Add(this.btn_start);
            this.pn_patient.Location = new System.Drawing.Point(0, 2);
            this.pn_patient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_patient.Name = "pn_patient";
            this.pn_patient.Size = new System.Drawing.Size(477, 532);
            this.pn_patient.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 281);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Birth date";
            // 
            // dtp_birthdate
            // 
            this.dtp_birthdate.Location = new System.Drawing.Point(91, 304);
            this.dtp_birthdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_birthdate.Name = "dtp_birthdate";
            this.dtp_birthdate.Size = new System.Drawing.Size(319, 22);
            this.dtp_birthdate.TabIndex = 9;
            // 
            // rb_gender_female
            // 
            this.rb_gender_female.AutoSize = true;
            this.rb_gender_female.Location = new System.Drawing.Point(91, 229);
            this.rb_gender_female.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_gender_female.Name = "rb_gender_female";
            this.rb_gender_female.Size = new System.Drawing.Size(75, 21);
            this.rb_gender_female.TabIndex = 8;
            this.rb_gender_female.TabStop = true;
            this.rb_gender_female.Text = "Female";
            this.rb_gender_female.UseVisualStyleBackColor = true;
            // 
            // rb_gender_male
            // 
            this.rb_gender_male.AutoSize = true;
            this.rb_gender_male.Location = new System.Drawing.Point(91, 201);
            this.rb_gender_male.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_gender_male.Name = "rb_gender_male";
            this.rb_gender_male.Size = new System.Drawing.Size(59, 21);
            this.rb_gender_male.TabIndex = 7;
            this.rb_gender_male.TabStop = true;
            this.rb_gender_male.Text = "Male";
            this.rb_gender_male.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last name";
            // 
            // tb_last_name
            // 
            this.tb_last_name.Location = new System.Drawing.Point(91, 149);
            this.tb_last_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_last_name.Name = "tb_last_name";
            this.tb_last_name.Size = new System.Drawing.Size(319, 22);
            this.tb_last_name.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "First name";
            // 
            // tb_first_name
            // 
            this.tb_first_name.Location = new System.Drawing.Point(91, 85);
            this.tb_first_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_first_name.Name = "tb_first_name";
            this.tb_first_name.Size = new System.Drawing.Size(319, 22);
            this.tb_first_name.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(151, 379);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(179, 39);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start Test";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pn_test
            // 
            this.pn_test.Controls.Add(this.lb_state);
            this.pn_test.Location = new System.Drawing.Point(0, 1);
            this.pn_test.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_test.Name = "pn_test";
            this.pn_test.Size = new System.Drawing.Size(477, 532);
            this.pn_test.TabIndex = 11;
            // 
            // lb_state
            // 
            this.lb_state.Location = new System.Drawing.Point(-1, 227);
            this.lb_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(479, 28);
            this.lb_state.TabIndex = 2;
            this.lb_state.Text = "Test in progress";
            this.lb_state.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(164, 369);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(140, 28);
            this.btn_log.TabIndex = 4;
            this.btn_log.Text = "Get Log";
            this.btn_log.UseVisualStyleBackColor = true;
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(131, 334);
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(206, 22);
            this.tb_log.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Log ID:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 535);
            this.Controls.Add(this.pn_test);
            this.Controls.Add(this.pn_connect);
            this.Controls.Add(this.pn_patient);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.pn_connect.ResumeLayout(false);
            this.pn_connect.PerformLayout();
            this.pn_patient.ResumeLayout(false);
            this.pn_patient.PerformLayout();
            this.pn_test.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_ports;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Panel pn_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pn_patient;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_first_name;
        private System.Windows.Forms.RadioButton rb_gender_female;
        private System.Windows.Forms.RadioButton rb_gender_male;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_last_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_birthdate;
        private System.Windows.Forms.Panel pn_test;
        private System.Windows.Forms.Label lb_state;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Button btn_log;
    }
}

