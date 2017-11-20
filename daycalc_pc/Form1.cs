using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace daycalc_pc
{
	public partial class Form1 : Form
	{
		NotifyIcon ni = new NotifyIcon();
		ContextMenuStrip cms = new ContextMenuStrip();

		public DateTime? firstToday = null;
		public DateTime? lastToday = null;

		public Form1()
		{
			Visible = false;
			InitializeComponent();
			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			getLatestData();

			ni.Text = "WolfPaw Day Calc";
			ni.Icon = Properties.Resources.clock2;
			ni.Visible = true;
			createCMS();
			ni.MouseClick += Ni_MouseClick;
			ni.ContextMenuStrip = cms;
			this.ShowInTaskbar = false;
			this.Hide();
		}

		private void Ni_MouseClick(object sender, MouseEventArgs e)
		{
			ni.ContextMenuStrip.Show(Cursor.Position);
		}

		public void createCMS()
		{
			cms.ShowCheckMargin = false;
			cms.ShowImageMargin = false;
			cms.Font = new Font("Consolas", 10, FontStyle.Regular);
			
			drawnTitle tmi_title = new drawnTitle();
			tmi_title.Text2 = "WolfPaw Day calc";
			tmi_title._cms = cms;

			ToolStripMenuItem tmi_login = new ToolStripMenuItem();
			tmi_login.Text = "Send Login";

			ToolStripMenuItem tmi_logout = new ToolStripMenuItem();
			tmi_logout.Text = "Send Logout";

			ToolStripMenuItem tmi_openWindow = new ToolStripMenuItem();
			tmi_openWindow.Text = "Show Window";


			drawnButton graph = new drawnButton();
			graph.firstToday = firstToday;
			graph.lastToday = lastToday;
			graph._cms = cms;
			

			ToolStripMenuItem tmi_exit = new ToolStripMenuItem();
			tmi_exit.Text = "Exit";
			tmi_exit.Click += Tmi_exit_Click;

			cms.Items.Add(tmi_title);
			cms.Items.Add(tmi_login);
			cms.Items.Add(tmi_logout);
			cms.Items.Add(tmi_openWindow);
			cms.Items.Add(graph);
			cms.Items.Add(tmi_exit);
			
		}

		private void Tmi_exit_Click(object sender, EventArgs e)
		{
			ni.Visible = false;
			Application.Exit();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			while (ni.Visible) { ni.Visible = false; }
		}

		public void login()
		{
			string username = "";
			string password = "";

		}

		public void getLatestData()
		{
			//WebBrowser wb = new WebBrowser();
			//wb.Navigate("http://daycalc.byethost5.com/calldata.php?getdata=1&date=2017-11-15");
			//MessageBox.Show(wb.DocumentText);

			string ret = new WebClient().DownloadString("http://wpss.atoldavid.hu/api/calldata.php?getdata=1");
			MessageBox.Show(ret);

			firstToday = new DateTime(2017, 11, 16, 7, 10, 0);
			lastToday = new DateTime(2017, 11, 16, 10, 20, 0);

		}
	}


	public class drawnTitle : ToolStripMenuItem
	{
		public String Text2 { get; set; }
		public ContextMenuStrip _cms { get; set; }

		public drawnTitle()
		{
			AutoSize = false;
			Margin = new Padding(0, -1, 0, 0);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if(_cms != null && _cms.Bounds != null)
			{
				Height = 15;
				Width = _cms.Bounds.Width;
			}
			
			e.Graphics.Clear(Color.Gray);
			e.Graphics.DrawString(Text2, new Font(this.Font.FontFamily,8,FontStyle.Underline), Brushes.White, new Point(10, 0));
		}
	}

	public class drawnButton : ToolStripMenuItem
	{
		public DateTime? firstToday { get; set; }
		public DateTime? lastToday { get; set; }
		public ContextMenuStrip _cms { get; set; }

		public drawnButton()
		{
			AutoSize = false;

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (_cms != null && _cms.Bounds != null)
			{
				Height = 5 + 20 + 5 + (_cms.Bounds.Width - 4) + 5 + 40 + 5;
				Width = _cms.Bounds.Width;
			}

			int[] data = calc.calcDay((DateTime)firstToday, (DateTime)lastToday);
			int barWidth = Width;
			int barHeight = 20;
			int diagramWidth = Width - 4;
			int diagramHeight = diagramWidth;
			int drawTop = 5;
			int workTime = Properties.Settings.Default.s_InTime;
			double currentPercent = calc.getPercentages(workTime, data[1], percentModes._1_whatPercentageIsAOfB);
			double lastMarkPercent = calc.getPercentages(workTime, data[4], percentModes._1_whatPercentageIsAOfB);

			int currentBarGreen = (int)calc.getPercentages(currentPercent, barWidth, percentModes._2_whatIsAPercentageOfB);
			int lastMarkBar = (int)calc.getPercentages(lastMarkPercent, barWidth, percentModes._2_whatIsAPercentageOfB);

			e.Graphics.FillRectangle(Brushes.LightPink, new Rectangle(0, drawTop, barWidth, barHeight));
			e.Graphics.FillRectangle(Brushes.ForestGreen, new Rectangle(0, drawTop, currentBarGreen, barHeight));
			e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(lastMarkBar - 1, drawTop, 2, barHeight));

			drawTop += 25;

			int currentPie = (int)calc.getPercentages(currentPercent, 360, percentModes._2_whatIsAPercentageOfB);
			int lastMarkPie = (int)calc.getPercentages(lastMarkPercent, 360, percentModes._2_whatIsAPercentageOfB);

			e.Graphics.FillPie(Brushes.LightPink, new Rectangle(2, drawTop, diagramWidth, diagramHeight), 360f, 360f);
			e.Graphics.FillPie(Brushes.ForestGreen, new Rectangle(2, drawTop, diagramWidth, diagramHeight),270f,-currentPie);
			e.Graphics.FillPie(Brushes.Blue, new Rectangle(2, drawTop, diagramWidth, diagramHeight), -lastMarkPie+270, -3);

			drawTop += diagramHeight + 5;

			string gotins = (data[0] / 60).ToString().PadLeft(2,'0') + ":" + (data[0] % 60).ToString().PadLeft(2, '0');
			string leavings = (data[2] / 60).ToString().PadLeft(2, '0') + ":" + (data[2] % 60).ToString().PadLeft(2, '0');
			string leavingIns = (data[3] / 60).ToString().PadLeft(2, '0') + ":" + (data[3] % 60).ToString().PadLeft(2, '0');

			e.Graphics.DrawString("Got in: " + gotins + "\r\nLeaving: " + leavings + "\r\nLeaving in: " + leavingIns, this.Font, Brushes.Black, new Point(2, drawTop));
		}
	}

	public static class calc
	{
		/// <summary>
		/// Calculates data in minutes.
		/// returns array: [gotIn, beenIn, leaving, tillLeave];
		/// </summary>
		public static int[] calcDay(DateTime first, DateTime last)
		{
			int[] ret = new int[5];

			//int now = (int)Math.Ceiling(DateTime.Now.TimeOfDay.TotalMinutes);
			int now = (int)Math.Ceiling(new DateTime(2017, 11, 16, 14, 20, 0).TimeOfDay.TotalMinutes);
			int gotIn = (int)Math.Ceiling(first.TimeOfDay.TotalMinutes);
			int lastMark = (int)Math.Ceiling(last.TimeOfDay.TotalMinutes);
			int leaving = gotIn + Properties.Settings.Default.s_InTime;
			int beenIn = now - gotIn;
			int tillLeave = leaving - now;

			ret[0] = gotIn;
			ret[1] = beenIn;
			ret[2] = leaving;
			ret[3] = tillLeave;
			ret[4] = lastMark - gotIn;

			return ret;
		}

		/// <summary>
		/// Returns percentage values of a and b in 3 different calculations.
		/// <para>1: b = c / a * 100</para>
		/// <para>2: c = b / 100 * a</para>
		/// <para>3: a = c / b * 100</para>
		/// </summary>
		/// <param name="a">First Number</param>
		/// <param name="b">Second Number</param>
		/// <param name="pmo">Percentage method</param>
		/// <returns>Returns Double value of calculation</returns>
		public static double getPercentages(double a, double b, percentModes pmo)
		{
			double ret = 0d;

			switch (pmo)
			{
				//b = c / a * 100
				case percentModes._1_whatPercentageIsAOfB:
					ret = (b / a) * 100;
					break;

				//c = b / 100 * a
				case percentModes._2_whatIsAPercentageOfB:
					ret = (b / 100) * a;
					break;

				//a = c / b * 100
				case percentModes._3_ofWhatIsAPercentageB:
					ret = (b / a) * 100;
					break;
			}

			return ret;
		}

	}

	/// <summary>
	/// <para>public enum percentModes	//200 % 20 = 40</para>
	/// <para>_1_whatPercentageIsAOfB,	//what is 20</para>
	/// <para>_2_whatIsAPercentageOfB,	//what is 40</para>
	/// <para>_3_ofWhatIsAPercentageB		//what is 200</para>
	/// </summary>
	public enum percentModes    //200 % 20 = 40
	{
		_1_whatPercentageIsAOfB,   //what is 20
		_2_whatIsAPercentageOfB,   //what is 40
		_3_ofWhatIsAPercentageB    //what is 200
	}

}
