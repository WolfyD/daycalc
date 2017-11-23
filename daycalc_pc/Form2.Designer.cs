namespace daycalc_pc
{
	partial class Form2
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_Close = new System.Windows.Forms.Button();
			this.tc_Tabs = new System.Windows.Forms.TabControl();
			this.tp_Today = new System.Windows.Forms.TabPage();
			this.tp_WeeklyData = new System.Windows.Forms.TabPage();
			this.tp_MonthlyData = new System.Windows.Forms.TabPage();
			this.tp_ReportGen = new System.Windows.Forms.TabPage();
			this.tp_Options = new System.Windows.Forms.TabPage();
			this.tp_About = new System.Windows.Forms.TabPage();
			this.panel1.SuspendLayout();
			this.tc_Tabs.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btn_Close);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 435);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(680, 29);
			this.panel1.TabIndex = 0;
			// 
			// btn_Close
			// 
			this.btn_Close.Location = new System.Drawing.Point(602, 3);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(75, 23);
			this.btn_Close.TabIndex = 0;
			this.btn_Close.Text = "Close";
			this.btn_Close.UseVisualStyleBackColor = true;
			// 
			// tc_Tabs
			// 
			this.tc_Tabs.Controls.Add(this.tp_Today);
			this.tc_Tabs.Controls.Add(this.tp_WeeklyData);
			this.tc_Tabs.Controls.Add(this.tp_MonthlyData);
			this.tc_Tabs.Controls.Add(this.tp_ReportGen);
			this.tc_Tabs.Controls.Add(this.tp_Options);
			this.tc_Tabs.Controls.Add(this.tp_About);
			this.tc_Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tc_Tabs.Location = new System.Drawing.Point(0, 0);
			this.tc_Tabs.Name = "tc_Tabs";
			this.tc_Tabs.SelectedIndex = 0;
			this.tc_Tabs.Size = new System.Drawing.Size(680, 435);
			this.tc_Tabs.TabIndex = 1;
			// 
			// tp_Today
			// 
			this.tp_Today.Location = new System.Drawing.Point(4, 22);
			this.tp_Today.Name = "tp_Today";
			this.tp_Today.Padding = new System.Windows.Forms.Padding(3);
			this.tp_Today.Size = new System.Drawing.Size(672, 409);
			this.tp_Today.TabIndex = 0;
			this.tp_Today.Text = "Today";
			this.tp_Today.UseVisualStyleBackColor = true;
			// 
			// tp_WeeklyData
			// 
			this.tp_WeeklyData.Location = new System.Drawing.Point(4, 22);
			this.tp_WeeklyData.Name = "tp_WeeklyData";
			this.tp_WeeklyData.Padding = new System.Windows.Forms.Padding(3);
			this.tp_WeeklyData.Size = new System.Drawing.Size(672, 409);
			this.tp_WeeklyData.TabIndex = 1;
			this.tp_WeeklyData.Text = "One week report";
			this.tp_WeeklyData.UseVisualStyleBackColor = true;
			// 
			// tp_MonthlyData
			// 
			this.tp_MonthlyData.Location = new System.Drawing.Point(4, 22);
			this.tp_MonthlyData.Name = "tp_MonthlyData";
			this.tp_MonthlyData.Padding = new System.Windows.Forms.Padding(3);
			this.tp_MonthlyData.Size = new System.Drawing.Size(672, 409);
			this.tp_MonthlyData.TabIndex = 2;
			this.tp_MonthlyData.Text = "One month report";
			this.tp_MonthlyData.UseVisualStyleBackColor = true;
			// 
			// tp_ReportGen
			// 
			this.tp_ReportGen.Location = new System.Drawing.Point(4, 22);
			this.tp_ReportGen.Name = "tp_ReportGen";
			this.tp_ReportGen.Padding = new System.Windows.Forms.Padding(3);
			this.tp_ReportGen.Size = new System.Drawing.Size(672, 409);
			this.tp_ReportGen.TabIndex = 3;
			this.tp_ReportGen.Text = "Report Generator";
			this.tp_ReportGen.UseVisualStyleBackColor = true;
			// 
			// tp_Options
			// 
			this.tp_Options.Location = new System.Drawing.Point(4, 22);
			this.tp_Options.Name = "tp_Options";
			this.tp_Options.Padding = new System.Windows.Forms.Padding(3);
			this.tp_Options.Size = new System.Drawing.Size(672, 409);
			this.tp_Options.TabIndex = 4;
			this.tp_Options.Text = "Options";
			this.tp_Options.UseVisualStyleBackColor = true;
			// 
			// tp_About
			// 
			this.tp_About.Location = new System.Drawing.Point(4, 22);
			this.tp_About.Name = "tp_About";
			this.tp_About.Padding = new System.Windows.Forms.Padding(3);
			this.tp_About.Size = new System.Drawing.Size(672, 409);
			this.tp_About.TabIndex = 5;
			this.tp_About.Text = "About";
			this.tp_About.UseVisualStyleBackColor = true;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(680, 464);
			this.Controls.Add(this.tc_Tabs);
			this.Controls.Add(this.panel1);
			this.Name = "Form2";
			this.Text = "WolfPaw DayCalc";
			this.panel1.ResumeLayout(false);
			this.tc_Tabs.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_Close;
		private System.Windows.Forms.TabControl tc_Tabs;
		private System.Windows.Forms.TabPage tp_Today;
		private System.Windows.Forms.TabPage tp_WeeklyData;
		private System.Windows.Forms.TabPage tp_MonthlyData;
		private System.Windows.Forms.TabPage tp_ReportGen;
		private System.Windows.Forms.TabPage tp_Options;
		private System.Windows.Forms.TabPage tp_About;
	}
}