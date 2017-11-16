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
			ni.Text = "WolfPaw Day Calc";
			ni.Icon = Properties.Resources.clock2;
			ni.Visible = true;
			createCMS();
			ni.MouseClick += Ni_MouseClick;
			ni.ContextMenuStrip = cms;
			this.ShowInTaskbar = false;
			this.Hide();

			getLatestData();
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

		public void getLatestData()
		{
			WebBrowser wb = new WebBrowser();
			wb.Navigate("http://daycalc.byethost5.com/calldata.php?getdata=1&date=2017-11-15");
			MessageBox.Show(wb.DocumentText);
			//string ret = new WebClient().DownloadString("http://daycalc.byethost5.com/calldata.php?getdata=1&date=2017-11-15");
			//MessageBox.Show(ret);
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
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}
	}

}
