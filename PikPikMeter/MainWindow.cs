﻿using PikPikMeter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPikMeter
{
	public partial class MainWindow : Form
	{
		private bool Moving = false;
		private bool Resizing = false;
		private Point MouseDownLocation;
		private TrafficMasterMonitor TrafficMonitor;

		public MainWindow()
		{
			InitializeComponent();
		}

		private double MinimumOpacity
		{
			get { return OpacityTrackBar.Minimum / (double)OpacityTrackBar.Maximum; }
		}

		private void LoadSettings()
		{
			Point location = Settings.Default.WindowLocation;
			Size size = Settings.Default.WindowSize;
			if (!ScreenPosition.IsValidLocation(location, size))
			{
				location = ScreenPosition.DefaultLocation();
				size = ScreenPosition.DefaultSize;
			}
			this.Location = location;
			this.Size = size;
			this.TopMost = Settings.Default.TopMost;
			this.stayOnTopToolStripMenuItem.Checked = Settings.Default.TopMost;
			TrafficMonitor.GraphOnIcon = Settings.Default.GraphOnTray;
			this.graphOnTrayToolStripMenuItem.Checked = Settings.Default.GraphOnTray;
			this.startWithSystemToolStripMenuItem.Checked = SystemStart.On;
			this.Opacity = Math.Max(MinimumOpacity, Settings.Default.Opacity);

			TrafficMonitor.GraphPaint.Scale = new TrafficUnitValue(
				Math.Max(1.0f, Settings.Default.ScaleFactor),
				Settings.Default.Bits);

			if (Settings.Default.DisabledNics == null)
				Settings.Default.DisabledNics = new System.Collections.Specialized.StringCollection();
			foreach (string disabledNic in Settings.Default.DisabledNics)
				TrafficMonitor.SetNicEnabled(disabledNic, false);
		}

		private void SaveSettings()
		{
			Settings.Default.WindowLocation = this.Location;
			Settings.Default.WindowSize = (this.WindowState == FormWindowState.Normal) ?
				this.Size :
				this.RestoreBounds.Size;
			Settings.Default.TopMost = this.TopMost;
			Settings.Default.ScaleFactor = TrafficMonitor.GraphPaint.Scale.Value;
			Settings.Default.Bits = TrafficMonitor.GraphPaint.Scale.InBits;
			Settings.Default.GraphOnTray = TrafficMonitor.GraphOnIcon;
			Settings.Default.Opacity = this.Opacity;
			Settings.Default.Save();
		}

		private void SetupTrafficMonitor()
		{
			TrafficMonitor = new TrafficMasterMonitor();
			TrafficMonitor.Display = new TrafficMasterMonitorDisplay()
			{
				Graph = this.GraphBox,
				LabelDownload = this.LbLDownloadTotal,
				LabelUpload = this.LblUploadTotal,
				Icon = this.trayIcon
			};
			RefreshTimer.Interval = 1000;
			RefreshTimer.Enabled = true;
		}

		private void Repaint()
		{
			if (TrafficMonitor != null)
				TrafficMonitor.Repaint();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			trayIcon.Visible = true;
			SetupTrafficMonitor();
			LoadSettings();
			TrafficMonitor.Tick();
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
		}

		private void MainWindow_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Moving = true;
				MouseDownLocation = e.Location;
			}
		}

		private void MainWindow_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				Moving = false;
		}

		private void MainWindow_MouseMove(object sender, MouseEventArgs e)
		{
			if (Moving && e.Button.HasFlag(MouseButtons.Left))
			{
				Point delta = new Point(
					e.Location.X - MouseDownLocation.X,
					e.Location.Y - MouseDownLocation.Y);
				this.Location = new Point(this.Location.X + delta.X, this.Location.Y + delta.Y);
				this.Update();
			}
		}

		private void resizer_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Resizing = true;
				MouseDownLocation = e.Location;
			}
		}

		private void resizer_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				Resizing = false;
		}

		private void resizer_MouseMove(object sender, MouseEventArgs e)
		{
			if (Resizing && e.Button.HasFlag(MouseButtons.Left))
			{
				Point delta = new Point(
					e.Location.X - MouseDownLocation.X,
					e.Location.Y - MouseDownLocation.Y);
				this.Size = ScreenPosition.NormalizedSize(
					new Size(this.Size.Width + delta.X, this.Size.Height + delta.Y));
				this.Update();
			}
		}

		private void resizer_MouseEnter(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.SizeNWSE;
		}

		private void resizer_MouseLeave(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.Default;
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void refreshTimer_Tick(object sender, EventArgs e)
		{
			TrafficMonitor.Tick();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About about = new About();
			about.StartPosition = FormStartPosition.CenterParent;
			about.ShowDialog(this);
		}

		private void trayIcon_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button.HasFlag(MouseButtons.Left))
			{
				if (this.Visible)
					this.Visible = false;
				else
				{
					this.Visible = true;
					this.BringToFront();

					// BringToFront works exactly once.
					// If you wish to actually bring it to front, this is how it's done.
					if (!this.TopMost)
					{
						this.TopMost = true;
						this.TopMost = false;
					}
				}
			}
		}

		private void setScaleMenuItem_Click(object sender, EventArgs e)
		{
			while (true)
			{
				string scale = TrafficUnit.Humanize(TrafficMonitor.GraphPaint.Scale);
				AskValue askValueDialog = new AskValue()
				{
					Text = "Set Scale",
					ValueTitle = "Set graph scale (allowed units: GB, MB, KB, Gb, Mb, Kb):",
					Value = scale
				};
				askValueDialog.StartPosition = FormStartPosition.CenterParent;
				if (askValueDialog.ShowDialog(this) == DialogResult.OK)
				{
					TrafficUnitValue trafficScale;
					try
					{
						trafficScale = TrafficUnit.Dehumanize(askValueDialog.Value);
						if (trafficScale.Value <= 0)
							throw new ArgumentException("must be greater than zero");
					}
					catch (ArgumentException ex)
					{
						MessageBox.Show("Bad scale: " + ex.Message,
							Application.ProductName + " - Bad Input",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						continue;
					}
					TrafficMonitor.GraphPaint.Scale = trafficScale;
				}
				break;
			}
			Repaint();
		}

		private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = stayOnTopToolStripMenuItem.Checked;
			this.TopMost = flag;
			Settings.Default.TopMost = flag;
		}

		private void graphOnTrayToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = graphOnTrayToolStripMenuItem.Checked;
			TrafficMonitor.GraphOnIcon = flag;
			Settings.Default.GraphOnTray = flag;
			Repaint();
		}

		private void startWithSystemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				SystemStart.On = this.startWithSystemToolStripMenuItem.Checked;
				// Get the factual state.
				this.startWithSystemToolStripMenuItem.Checked = SystemStart.On;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Can't set up PikPikMeter to start with system, " +
					"try running PikPikMeter as an Administrator.\n" +
					"Reason: " + ex.Message);
			}
		}

		private void GraphPanel_Resize(object sender, EventArgs e)
		{
			GraphBox.Size = GraphPanel.Size;
			Repaint();
		}

		private void setOpacityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.setOpacityToolStripMenuItem.Checked)
			{
				OpacityTrackBar.Value = (int)(this.Opacity * OpacityTrackBar.Maximum);
				OpacityTrackBar.Visible = true;
				OpacityTrackBar.BringToFront();
			}
			else
			{
				OpacityTrackBar.Visible = false;
			}
		}

		private void OpacityTrackBar_Scroll(object sender, EventArgs e)
		{
			this.Opacity = OpacityTrackBar.Value / (double) OpacityTrackBar.Maximum;
			Settings.Default.Opacity = this.Opacity;
		}

		private void interfacesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			var items = new ToolStripItem[interfacesToolStripMenuItem.DropDownItems.Count];
			interfacesToolStripMenuItem.DropDownItems.CopyTo(items, 0);
			foreach (var item in items)
			{
				if (item != noNicsToolStripMenuItem)
					interfacesToolStripMenuItem.DropDownItems.Remove(item);
			}
			noNicsToolStripMenuItem.Text = "No NICs";
			noNicsToolStripMenuItem.Visible = true;

			string[] measuredNics = TrafficMonitor.KnownMeasuredNics;
			string[] osAvailableNics;
			try
			{
				osAvailableNics = TrafficNic.Nics;
			}
			catch (Exception ex)
			{
				noNicsToolStripMenuItem.Text = "Cannot obtain NICs from system: " + ex.Message;
				osAvailableNics = new string[0];
			}
			HashSet<string> toggleableNics = new HashSet<string>();
			toggleableNics.UnionWith(measuredNics);
			toggleableNics.UnionWith(osAvailableNics);

			noNicsToolStripMenuItem.Visible = (toggleableNics.Count == 0);
			foreach (string nic in toggleableNics)
			{
				var name = nic;
				if (!osAvailableNics.Contains(nic))
					name += " [down]";
				var nicItem = new ToolStripMenuItem(name);
				nicItem.CheckOnClick = true;
				nicItem.Checked = !Settings.Default.DisabledNics.Contains(nic);
				nicItem.Click += NicItem_Click;
				nicItem.Tag = nic;
				interfacesToolStripMenuItem.DropDownItems.Add(nicItem);
			}
		}

		private void NicItem_Click(object sender, EventArgs e)
		{
			var item = sender as ToolStripMenuItem;
			string nic = item.Tag as string;
			if (item.Checked)
			{
				Settings.Default.DisabledNics.Remove(nic);
			}
			else
			{
				if (!Settings.Default.DisabledNics.Contains(nic))
					Settings.Default.DisabledNics.Add(nic);
			}
			TrafficMonitor.SetNicEnabled(nic, item.Checked);
			Repaint();
		}
	}
}
