using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using maxcare.Helper;

namespace maxcare
{
	public class fViewChrome : Form
	{
		public static fViewChrome remote;

		private IContainer components = null;

		private FlowLayoutPanel panelListDevice;

		public fViewChrome()
		{
			InitializeComponent();
			ChangeLanguage();
			remote = this;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(this);
		}

		public void AddChromeIntoPanel(IntPtr MainWindowHandle, int indexDevice, int width, int heigh, int x = -10, int y = -30)
		{
			Invoke((MethodInvoker)delegate
			{
				User32Helper.SetParent(MainWindowHandle, (from Control h in panelListDevice.Controls
					where h.Tag.Equals(indexDevice)
					select h).FirstOrDefault().Handle);
				User32Helper.MoveWindow(MainWindowHandle, x, y, width, heigh, repaint: true);
			});
		}

		public void RemovePanelDevice(int indexDevice)
		{
			Control ctr = panelListDevice.Controls["dv" + indexDevice];
			panelListDevice.Invoke((MethodInvoker)delegate
			{
				panelListDevice.Controls.Remove(ctr);
			});
		}

		public void AddPanelDevice(int indexDevice, int width, int heigh)
		{
			Panel panel = new Panel();
			panel.Name = "dv" + indexDevice;
			panel.Tag = indexDevice;
			panel.Size = new Size(width, heigh);
			panel.BackColor = Color.White;
			panel.BorderStyle = BorderStyle.FixedSingle;
			Invoke((MethodInvoker)delegate
			{
				panelListDevice.Controls.Add(panel);
			});
			for (int i = 0; i < 10; i++)
			{
				if (panelListDevice.Controls["dv" + indexDevice] != null)
				{
					break;
				}
				Thread.Sleep(1000);
			}
		}

		private void TurnOffDevice(object sender, EventArgs e)
		{
			RemovePanelDevice(Convert.ToInt32((sender as PictureBox).Name.Replace("pic", "")));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fViewChrome));
			panelListDevice = new System.Windows.Forms.FlowLayoutPanel();
			SuspendLayout();
			panelListDevice.AutoScroll = true;
			panelListDevice.BackColor = System.Drawing.Color.White;
			panelListDevice.Dock = System.Windows.Forms.DockStyle.Fill;
			panelListDevice.Location = new System.Drawing.Point(0, 0);
			panelListDevice.Name = "panelListDevice";
			panelListDevice.Padding = new System.Windows.Forms.Padding(10);
			panelListDevice.Size = new System.Drawing.Size(933, 554);
			panelListDevice.TabIndex = 1;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(933, 554);
			base.Controls.Add(panelListDevice);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fInterfaceChrome";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Giao diện Chrome";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			ResumeLayout(false);
		}
	}
}
