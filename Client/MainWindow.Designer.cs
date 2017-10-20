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
            this.btn_start = new System.Windows.Forms.Button();
            this.tb_first_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_last_name = new System.Windows.Forms.TextBox();
            this.rb_gender_male = new System.Windows.Forms.RadioButton();
            this.rb_gender_female = new System.Windows.Forms.RadioButton();
            this.dtp_birthdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pn_test = new System.Windows.Forms.Panel();
            this.lb_state = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.pn_connect.SuspendLayout();
            this.pn_patient.SuspendLayout();
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
            this.pn_connect.Location = new System.Drawing.Point(2, 2);
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
            this.pn_patient.Location = new System.Drawing.Point(1, 1);
            this.pn_patient.Name = "pn_patient";
            this.pn_patient.Size = new System.Drawing.Size(358, 432);
            this.pn_patient.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(113, 308);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(134, 32);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start Test";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // tb_first_name
            // 
            this.tb_first_name.Location = new System.Drawing.Point(68, 69);
            this.tb_first_name.Name = "tb_first_name";
            this.tb_first_name.Size = new System.Drawing.Size(240, 20);
            this.tb_first_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "First name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last name";
            // 
            // tb_last_name
            // 
            this.tb_last_name.Location = new System.Drawing.Point(68, 121);
            this.tb_last_name.Name = "tb_last_name";
            this.tb_last_name.Size = new System.Drawing.Size(240, 20);
            this.tb_last_name.TabIndex = 5;
            // 
            // rb_gender_male
            // 
            this.rb_gender_male.AutoSize = true;
            this.rb_gender_male.Location = new System.Drawing.Point(68, 163);
            this.rb_gender_male.Name = "rb_gender_male";
            this.rb_gender_male.Size = new System.Drawing.Size(48, 17);
            this.rb_gender_male.TabIndex = 7;
            this.rb_gender_male.TabStop = true;
            this.rb_gender_male.Text = "Male";
            this.rb_gender_male.UseVisualStyleBackColor = true;
            // 
            // rb_gender_female
            // 
            this.rb_gender_female.AutoSize = true;
            this.rb_gender_female.Location = new System.Drawing.Point(68, 186);
            this.rb_gender_female.Name = "rb_gender_female";
            this.rb_gender_female.Size = new System.Drawing.Size(59, 17);
            this.rb_gender_female.TabIndex = 8;
            this.rb_gender_female.TabStop = true;
            this.rb_gender_female.Text = "Female";
            this.rb_gender_female.UseVisualStyleBackColor = true;
            // 
            // dtp_birthdate
            // 
            this.dtp_birthdate.Location = new System.Drawing.Point(68, 247);
            this.dtp_birthdate.Name = "dtp_birthdate";
            this.dtp_birthdate.Size = new System.Drawing.Size(240, 20);
            this.dtp_birthdate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Birth date";
            // 
            // pn_test
            // 
            this.pn_test.Controls.Add(this.lb_state);
            this.pn_test.Controls.Add(this.lb_time);
            this.pn_test.Location = new System.Drawing.Point(0, 0);
            this.pn_test.Name = "pn_test";
            this.pn_test.Size = new System.Drawing.Size(358, 432);
            this.pn_test.TabIndex = 11;
            // 
            // lb_state
            // 
            this.lb_state.Location = new System.Drawing.Point(-1, 52);
            this.lb_state.Name = "lb_state";
            this.lb_state.Size = new System.Drawing.Size(359, 23);
            this.lb_state.TabIndex = 2;
            this.lb_state.Text = "State";
            this.lb_state.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb_time
            // 
            this.lb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_time.Location = new System.Drawing.Point(-1, 29);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(359, 23);
            this.lb_time.TabIndex = 0;
            this.lb_time.Text = "00:00";
            this.lb_time.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 432);
            this.Controls.Add(this.pn_test);
            this.Controls.Add(this.pn_patient);
            this.Controls.Add(this.pn_connect);
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
        private System.Windows.Forms.Label lb_time;
    }
}

