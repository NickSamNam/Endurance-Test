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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cb_ports = new System.Windows.Forms.ComboBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.pn_connect = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.btn_log = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pn_patient = new System.Windows.Forms.Panel();
            this.btn_start = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_birthdate = new System.Windows.Forms.DateTimePicker();
            this.rb_gender_female = new System.Windows.Forms.RadioButton();
            this.rb_gender_male = new System.Windows.Forms.RadioButton();
            this.nud_weight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_last_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_first_name = new System.Windows.Forms.TextBox();
            this.pn_test = new System.Windows.Forms.Panel();
            this.lb_rpm_tip = new System.Windows.Forms.Label();
            this.lb_actual_power = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lb_cycle_check = new System.Windows.Forms.Label();
            this.ch_data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lb_time_left = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.lb_power = new System.Windows.Forms.Label();
            this.lb_hr = new System.Windows.Forms.Label();
            this.lb_rpm = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_state = new System.Windows.Forms.Label();
            this.pn_connect.SuspendLayout();
            this.pn_patient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_weight)).BeginInit();
            this.pn_test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_data)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_ports
            // 
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(163, 120);
            this.cb_ports.Margin = new System.Windows.Forms.Padding(4);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(140, 24);
            this.cb_ports.TabIndex = 0;
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(163, 153);
            this.bt_connect.Margin = new System.Windows.Forms.Padding(4);
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
            this.pn_connect.Location = new System.Drawing.Point(0, 0);
            this.pn_connect.Margin = new System.Windows.Forms.Padding(4);
            this.pn_connect.Name = "pn_connect";
            this.pn_connect.Size = new System.Drawing.Size(477, 532);
            this.pn_connect.TabIndex = 2;
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
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(131, 334);
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(206, 22);
            this.tb_log.TabIndex = 2;
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(164, 369);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(140, 28);
            this.btn_log.TabIndex = 3;
            this.btn_log.Text = "Get Log";
            this.btn_log.UseVisualStyleBackColor = true;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
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
            this.pn_patient.Controls.Add(this.tb_first_name);
            this.pn_patient.Controls.Add(this.tb_last_name);
            this.pn_patient.Controls.Add(this.nud_weight);
            this.pn_patient.Controls.Add(this.rb_gender_male);
            this.pn_patient.Controls.Add(this.rb_gender_female);
            this.pn_patient.Controls.Add(this.dtp_birthdate);
            this.pn_patient.Controls.Add(this.btn_start);
            this.pn_patient.Controls.Add(this.label14);
            this.pn_patient.Controls.Add(this.label12);
            this.pn_patient.Controls.Add(this.label4);
            this.pn_patient.Controls.Add(this.label3);
            this.pn_patient.Controls.Add(this.label2);
            this.pn_patient.Location = new System.Drawing.Point(0, 0);
            this.pn_patient.Margin = new System.Windows.Forms.Padding(4);
            this.pn_patient.Name = "pn_patient";
            this.pn_patient.Size = new System.Drawing.Size(477, 532);
            this.pn_patient.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(151, 437);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(179, 39);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "Start Test";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(382, 219);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 17);
            this.label14.TabIndex = 13;
            this.label14.Text = "kg";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(88, 194);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Weight";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 339);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Birthdate";
            // 
            // dtp_birthdate
            // 
            this.dtp_birthdate.Location = new System.Drawing.Point(91, 362);
            this.dtp_birthdate.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_birthdate.Name = "dtp_birthdate";
            this.dtp_birthdate.Size = new System.Drawing.Size(319, 22);
            this.dtp_birthdate.TabIndex = 6;
            // 
            // rb_gender_female
            // 
            this.rb_gender_female.AutoSize = true;
            this.rb_gender_female.Location = new System.Drawing.Point(91, 287);
            this.rb_gender_female.Margin = new System.Windows.Forms.Padding(4);
            this.rb_gender_female.Name = "rb_gender_female";
            this.rb_gender_female.Size = new System.Drawing.Size(75, 21);
            this.rb_gender_female.TabIndex = 5;
            this.rb_gender_female.TabStop = true;
            this.rb_gender_female.Text = "Female";
            this.rb_gender_female.UseVisualStyleBackColor = true;
            // 
            // rb_gender_male
            // 
            this.rb_gender_male.AutoSize = true;
            this.rb_gender_male.Location = new System.Drawing.Point(91, 259);
            this.rb_gender_male.Margin = new System.Windows.Forms.Padding(4);
            this.rb_gender_male.Name = "rb_gender_male";
            this.rb_gender_male.Size = new System.Drawing.Size(59, 21);
            this.rb_gender_male.TabIndex = 4;
            this.rb_gender_male.TabStop = true;
            this.rb_gender_male.Text = "Male";
            this.rb_gender_male.UseVisualStyleBackColor = true;
            // 
            // nud_weight
            // 
            this.nud_weight.Location = new System.Drawing.Point(90, 214);
            this.nud_weight.Name = "nud_weight";
            this.nud_weight.Size = new System.Drawing.Size(282, 22);
            this.nud_weight.TabIndex = 3;
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
            this.tb_last_name.Margin = new System.Windows.Forms.Padding(4);
            this.tb_last_name.Name = "tb_last_name";
            this.tb_last_name.Size = new System.Drawing.Size(319, 22);
            this.tb_last_name.TabIndex = 2;
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
            this.tb_first_name.Margin = new System.Windows.Forms.Padding(4);
            this.tb_first_name.Name = "tb_first_name";
            this.tb_first_name.Size = new System.Drawing.Size(319, 22);
            this.tb_first_name.TabIndex = 1;
            // 
            // pn_test
            // 
            this.pn_test.Controls.Add(this.lb_rpm_tip);
            this.pn_test.Controls.Add(this.lb_actual_power);
            this.pn_test.Controls.Add(this.label13);
            this.pn_test.Controls.Add(this.lb_cycle_check);
            this.pn_test.Controls.Add(this.ch_data);
            this.pn_test.Controls.Add(this.lb_time_left);
            this.pn_test.Controls.Add(this.label10);
            this.pn_test.Controls.Add(this.label6);
            this.pn_test.Controls.Add(this.lb_time);
            this.pn_test.Controls.Add(this.lb_power);
            this.pn_test.Controls.Add(this.lb_hr);
            this.pn_test.Controls.Add(this.lb_rpm);
            this.pn_test.Controls.Add(this.label9);
            this.pn_test.Controls.Add(this.label8);
            this.pn_test.Controls.Add(this.label7);
            this.pn_test.Controls.Add(this.lb_state);
            this.pn_test.Location = new System.Drawing.Point(0, 0);
            this.pn_test.Margin = new System.Windows.Forms.Padding(4);
            this.pn_test.Name = "pn_test";
            this.pn_test.Size = new System.Drawing.Size(477, 532);
            this.pn_test.TabIndex = 11;
            // 
            // lb_rpm_tip
            // 
            this.lb_rpm_tip.AutoSize = true;
            this.lb_rpm_tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rpm_tip.Location = new System.Drawing.Point(37, 341);
            this.lb_rpm_tip.Name = "lb_rpm_tip";
            this.lb_rpm_tip.Size = new System.Drawing.Size(274, 17);
            this.lb_rpm_tip.TabIndex = 19;
            this.lb_rpm_tip.Text = "Try keeping your RPM between 50 and 60";
            this.lb_rpm_tip.Visible = false;
            // 
            // lb_actual_power
            // 
            this.lb_actual_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_actual_power.Location = new System.Drawing.Point(221, 480);
            this.lb_actual_power.Name = "lb_actual_power";
            this.lb_actual_power.Size = new System.Drawing.Size(100, 23);
            this.lb_actual_power.TabIndex = 18;
            this.lb_actual_power.Text = "0";
            this.lb_actual_power.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 480);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "Actual power";
            // 
            // lb_cycle_check
            // 
            this.lb_cycle_check.BackColor = System.Drawing.Color.Red;
            this.lb_cycle_check.ForeColor = System.Drawing.Color.White;
            this.lb_cycle_check.Location = new System.Drawing.Point(27, 318);
            this.lb_cycle_check.Name = "lb_cycle_check";
            this.lb_cycle_check.Size = new System.Drawing.Size(294, 23);
            this.lb_cycle_check.TabIndex = 16;
            this.lb_cycle_check.Text = "Cycle faster!";
            this.lb_cycle_check.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ch_data
            // 
            this.ch_data.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            this.ch_data.ChartAreas.Add(chartArea5);
            legend5.BackColor = System.Drawing.Color.Transparent;
            legend5.Name = "Legend1";
            this.ch_data.Legends.Add(legend5);
            this.ch_data.Location = new System.Drawing.Point(0, 87);
            this.ch_data.Name = "ch_data";
            this.ch_data.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series13.Legend = "Legend1";
            series13.Name = "Power";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series14.Legend = "Legend1";
            series14.Name = "Heartrate";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series15.Legend = "Legend1";
            series15.Name = "RPM";
            this.ch_data.Series.Add(series13);
            this.ch_data.Series.Add(series14);
            this.ch_data.Series.Add(series15);
            this.ch_data.Size = new System.Drawing.Size(477, 212);
            this.ch_data.TabIndex = 14;
            this.ch_data.Text = "chart1";
            // 
            // lb_time_left
            // 
            this.lb_time_left.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_time_left.Location = new System.Drawing.Point(171, 50);
            this.lb_time_left.Name = "lb_time_left";
            this.lb_time_left.Size = new System.Drawing.Size(150, 25);
            this.lb_time_left.TabIndex = 13;
            this.lb_time_left.Text = "0:00";
            this.lb_time_left.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Time left in state:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Current state:";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_time.Location = new System.Drawing.Point(379, 24);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(55, 20);
            this.lb_time.TabIndex = 10;
            this.lb_time.Text = "00:00";
            // 
            // lb_power
            // 
            this.lb_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_power.Location = new System.Drawing.Point(221, 450);
            this.lb_power.Name = "lb_power";
            this.lb_power.Size = new System.Drawing.Size(100, 23);
            this.lb_power.TabIndex = 9;
            this.lb_power.Text = "0";
            this.lb_power.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_hr
            // 
            this.lb_hr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hr.Location = new System.Drawing.Point(221, 419);
            this.lb_hr.Name = "lb_hr";
            this.lb_hr.Size = new System.Drawing.Size(100, 23);
            this.lb_hr.TabIndex = 8;
            this.lb_hr.Text = "0";
            this.lb_hr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_rpm
            // 
            this.lb_rpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rpm.Location = new System.Drawing.Point(221, 391);
            this.lb_rpm.Name = "lb_rpm";
            this.lb_rpm.Size = new System.Drawing.Size(100, 23);
            this.lb_rpm.TabIndex = 7;
            this.lb_rpm.Text = "0";
            this.lb_rpm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 450);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Requested power";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Heartrate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "RPM";
            // 
            // lb_state
            // 
            this.lb_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_state.Location = new System.Drawing.Point(174, 24);
            this.lb_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(147, 17);
            this.lb_state.TabIndex = 2;
            this.lb_state.Text = "state";
            this.lb_state.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 533);
            this.Controls.Add(this.pn_connect);
            this.Controls.Add(this.pn_patient);
            this.Controls.Add(this.pn_test);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.pn_connect.ResumeLayout(false);
            this.pn_connect.PerformLayout();
            this.pn_patient.ResumeLayout(false);
            this.pn_patient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_weight)).EndInit();
            this.pn_test.ResumeLayout(false);
            this.pn_test.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_data)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_power;
        private System.Windows.Forms.Label lb_hr;
        private System.Windows.Forms.Label lb_rpm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_data;
        private System.Windows.Forms.Label lb_time_left;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_cycle_check;
        private System.Windows.Forms.Label lb_actual_power;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nud_weight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_rpm_tip;
    }
}

