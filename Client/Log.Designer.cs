namespace Client
{
    partial class Log
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine3 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine4 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine5 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine6 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine7 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine8 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lb_name_gender = new System.Windows.Forms.Label();
            this.lb_dob_age = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ch_log_hr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ch_log_rpm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ch_log_power = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ch_log_speed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_absvo2max = new System.Windows.Forms.Label();
            this.lb_relvo2max = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_test_power = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_steady = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_hr = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_hr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_rpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_power)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_speed)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_name_gender
            // 
            this.lb_name_gender.AutoSize = true;
            this.lb_name_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name_gender.Location = new System.Drawing.Point(11, 18);
            this.lb_name_gender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_name_gender.Name = "lb_name_gender";
            this.lb_name_gender.Size = new System.Drawing.Size(153, 13);
            this.lb_name_gender.TabIndex = 0;
            this.lb_name_gender.Text = "van Endhoven, Nick     M";
            // 
            // lb_dob_age
            // 
            this.lb_dob_age.AutoSize = true;
            this.lb_dob_age.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dob_age.Location = new System.Drawing.Point(177, 18);
            this.lb_dob_age.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_dob_age.Name = "lb_dob_age";
            this.lb_dob_age.Size = new System.Drawing.Size(82, 13);
            this.lb_dob_age.TabIndex = 1;
            this.lb_dob_age.Text = "13-08-1995   22";
            // 
            // ch_log_hr
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsMarksNextToAxis = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX2.IsMarksNextToAxis = false;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.LineWidth = 0;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsMarksNextToAxis = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Silver;
            stripLine1.ForeColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.StripLines.Add(stripLine1);
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Silver;
            stripLine2.ForeColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.StripLines.Add(stripLine2);
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.ch_log_hr.ChartAreas.Add(chartArea1);
            this.ch_log_hr.Location = new System.Drawing.Point(9, 68);
            this.ch_log_hr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ch_log_hr.Name = "ch_log_hr";
            this.ch_log_hr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Series1";
            series1.ShadowColor = System.Drawing.Color.Silver;
            series1.ShadowOffset = 2;
            series1.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ch_log_hr.Series.Add(series1);
            this.ch_log_hr.Size = new System.Drawing.Size(364, 163);
            this.ch_log_hr.TabIndex = 2;
            // 
            // ch_log_rpm
            // 
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarksNextToAxis = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.LineWidth = 0;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisX2.IsMarksNextToAxis = false;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX2.LineWidth = 0;
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.IsMarksNextToAxis = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Silver;
            stripLine3.ForeColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.StripLines.Add(stripLine3);
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.Silver;
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY2.IsLabelAutoFit = false;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.Silver;
            stripLine4.ForeColor = System.Drawing.Color.Silver;
            chartArea2.AxisY2.StripLines.Add(stripLine4);
            chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.Silver;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea1";
            this.ch_log_rpm.ChartAreas.Add(chartArea2);
            this.ch_log_rpm.Location = new System.Drawing.Point(9, 266);
            this.ch_log_rpm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ch_log_rpm.Name = "ch_log_rpm";
            this.ch_log_rpm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Name = "Series1";
            series2.ShadowColor = System.Drawing.Color.Silver;
            series2.ShadowOffset = 2;
            series2.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ch_log_rpm.Series.Add(series2);
            this.ch_log_rpm.Size = new System.Drawing.Size(364, 163);
            this.ch_log_rpm.TabIndex = 3;
            this.ch_log_rpm.Text = "v";
            // 
            // ch_log_power
            // 
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.IsMarksNextToAxis = false;
            chartArea3.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.LineWidth = 0;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.AxisX2.IsMarksNextToAxis = false;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX2.LineWidth = 0;
            chartArea3.AxisX2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.IsMarksNextToAxis = false;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.LineColor = System.Drawing.Color.Silver;
            stripLine5.ForeColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.StripLines.Add(stripLine5);
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.Silver;
            chartArea3.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisY2.IsLabelAutoFit = false;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.Silver;
            stripLine6.ForeColor = System.Drawing.Color.Silver;
            chartArea3.AxisY2.StripLines.Add(stripLine6);
            chartArea3.AxisY2.TitleForeColor = System.Drawing.Color.Silver;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.Silver;
            chartArea3.Name = "ChartArea1";
            this.ch_log_power.ChartAreas.Add(chartArea3);
            this.ch_log_power.Location = new System.Drawing.Point(379, 68);
            this.ch_log_power.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ch_log_power.Name = "ch_log_power";
            this.ch_log_power.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Fuchsia;
            series3.Name = "Series1";
            series3.ShadowColor = System.Drawing.Color.Silver;
            series3.ShadowOffset = 2;
            series3.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ch_log_power.Series.Add(series3);
            this.ch_log_power.Size = new System.Drawing.Size(364, 163);
            this.ch_log_power.TabIndex = 4;
            this.ch_log_power.Text = "v";
            // 
            // ch_log_speed
            // 
            chartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.IsMarksNextToAxis = false;
            chartArea4.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.LineWidth = 0;
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisX2.IsMarksNextToAxis = false;
            chartArea4.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX2.LineWidth = 0;
            chartArea4.AxisX2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.IsMarksNextToAxis = false;
            chartArea4.AxisY.LabelStyle.Enabled = false;
            chartArea4.AxisY.LineColor = System.Drawing.Color.Silver;
            stripLine7.ForeColor = System.Drawing.Color.Silver;
            chartArea4.AxisY.StripLines.Add(stripLine7);
            chartArea4.AxisY.TitleForeColor = System.Drawing.Color.Silver;
            chartArea4.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea4.AxisY2.IsLabelAutoFit = false;
            chartArea4.AxisY2.LineColor = System.Drawing.Color.Silver;
            stripLine8.ForeColor = System.Drawing.Color.Silver;
            chartArea4.AxisY2.StripLines.Add(stripLine8);
            chartArea4.AxisY2.TitleForeColor = System.Drawing.Color.Silver;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.BorderColor = System.Drawing.Color.Silver;
            chartArea4.Name = "ChartArea1";
            this.ch_log_speed.ChartAreas.Add(chartArea4);
            this.ch_log_speed.Location = new System.Drawing.Point(378, 266);
            this.ch_log_speed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ch_log_speed.Name = "ch_log_speed";
            this.ch_log_speed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Lime;
            series4.Name = "Series1";
            series4.ShadowColor = System.Drawing.Color.Silver;
            series4.ShadowOffset = 2;
            series4.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ch_log_speed.Series.Add(series4);
            this.ch_log_speed.Size = new System.Drawing.Size(364, 163);
            this.ch_log_speed.TabIndex = 5;
            this.ch_log_speed.Text = "v";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Heartrate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Power";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 249);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "RPM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 249);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(739, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Absolute VO2Max:";
            // 
            // lb_absvo2max
            // 
            this.lb_absvo2max.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_absvo2max.Location = new System.Drawing.Point(884, 182);
            this.lb_absvo2max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_absvo2max.Name = "lb_absvo2max";
            this.lb_absvo2max.Size = new System.Drawing.Size(46, 19);
            this.lb_absvo2max.TabIndex = 11;
            this.lb_absvo2max.Text = "35";
            this.lb_absvo2max.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_relvo2max
            // 
            this.lb_relvo2max.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_relvo2max.Location = new System.Drawing.Point(884, 205);
            this.lb_relvo2max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_relvo2max.Name = "lb_relvo2max";
            this.lb_relvo2max.Size = new System.Drawing.Size(46, 19);
            this.lb_relvo2max.TabIndex = 13;
            this.lb_relvo2max.Text = "35";
            this.lb_relvo2max.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(739, 205);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Relatieve VO2Max:";
            // 
            // lb_test_power
            // 
            this.lb_test_power.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_test_power.Location = new System.Drawing.Point(884, 78);
            this.lb_test_power.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_test_power.Name = "lb_test_power";
            this.lb_test_power.Size = new System.Drawing.Size(46, 19);
            this.lb_test_power.TabIndex = 15;
            this.lb_test_power.Text = "35";
            this.lb_test_power.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(739, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Test power:";
            // 
            // lb_steady
            // 
            this.lb_steady.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_steady.Location = new System.Drawing.Point(884, 118);
            this.lb_steady.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_steady.Name = "lb_steady";
            this.lb_steady.Size = new System.Drawing.Size(46, 19);
            this.lb_steady.TabIndex = 17;
            this.lb_steady.Text = "Yes";
            this.lb_steady.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(739, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Reached Steadystate:";
            // 
            // lb_hr
            // 
            this.lb_hr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hr.Location = new System.Drawing.Point(884, 140);
            this.lb_hr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_hr.Name = "lb_hr";
            this.lb_hr.Size = new System.Drawing.Size(46, 19);
            this.lb_hr.TabIndex = 19;
            this.lb_hr.Text = "130";
            this.lb_hr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(739, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Steady Heartrate:";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 448);
            this.Controls.Add(this.lb_hr);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_steady);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_test_power);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lb_relvo2max);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_absvo2max);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ch_log_speed);
            this.Controls.Add(this.ch_log_power);
            this.Controls.Add(this.ch_log_rpm);
            this.Controls.Add(this.ch_log_hr);
            this.Controls.Add(this.lb_dob_age);
            this.Controls.Add(this.lb_name_gender);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Log";
            this.Text = "Log";
            this.Load += new System.EventHandler(this.Log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_hr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_rpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_power)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_log_speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_name_gender;
        private System.Windows.Forms.Label lb_dob_age;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_log_hr;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_log_rpm;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_log_power;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_log_speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_absvo2max;
        private System.Windows.Forms.Label lb_relvo2max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_test_power;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_steady;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_hr;
        private System.Windows.Forms.Label label11;
    }
}