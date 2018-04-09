namespace PikPikMeter
{
	partial class MainWindow
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.GraphBox = new System.Windows.Forms.PictureBox();
			this.mainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.setScaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.LblUploadTotal = new System.Windows.Forms.Label();
			this.LbLDownloadTotal = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.resizer = new System.Windows.Forms.PictureBox();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
			this.GraphPanel = new System.Windows.Forms.Panel();
			this.graphOnTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.GraphBox)).BeginInit();
			this.mainContextMenu.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.resizer)).BeginInit();
			this.GraphPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// GraphBox
			// 
			this.GraphBox.BackColor = System.Drawing.Color.Black;
			this.GraphBox.ContextMenuStrip = this.mainContextMenu;
			this.GraphBox.Location = new System.Drawing.Point(0, 0);
			this.GraphBox.Margin = new System.Windows.Forms.Padding(0);
			this.GraphBox.Name = "GraphBox";
			this.GraphBox.Size = new System.Drawing.Size(297, 100);
			this.GraphBox.TabIndex = 0;
			this.GraphBox.TabStop = false;
			this.GraphBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.GraphBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
			this.GraphBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
			// 
			// mainContextMenu
			// 
			this.mainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setScaleMenuItem,
            this.graphOnTrayToolStripMenuItem,
            this.stayOnTopToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
			this.mainContextMenu.Name = "contextMenuStrip1";
			this.mainContextMenu.Size = new System.Drawing.Size(153, 142);
			// 
			// setScaleMenuItem
			// 
			this.setScaleMenuItem.Name = "setScaleMenuItem";
			this.setScaleMenuItem.Size = new System.Drawing.Size(152, 22);
			this.setScaleMenuItem.Text = "&Set scale";
			this.setScaleMenuItem.Click += new System.EventHandler(this.setScaleMenuItem_Click);
			// 
			// stayOnTopToolStripMenuItem
			// 
			this.stayOnTopToolStripMenuItem.Checked = true;
			this.stayOnTopToolStripMenuItem.CheckOnClick = true;
			this.stayOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
			this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stayOnTopToolStripMenuItem.Text = "Stay on &top";
			this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.quitToolStripMenuItem.Text = "&Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.BackColor = System.Drawing.Color.SteelBlue;
			this.panel1.ContextMenuStrip = this.mainContextMenu;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.LblUploadTotal);
			this.panel1.Controls.Add(this.LbLDownloadTotal);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.resizer);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(1, 104);
			this.panel1.MinimumSize = new System.Drawing.Size(0, 20);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(297, 23);
			this.panel1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(149, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "UL:";
			// 
			// LblUploadTotal
			// 
			this.LblUploadTotal.AutoSize = true;
			this.LblUploadTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.LblUploadTotal.Location = new System.Drawing.Point(179, 5);
			this.LblUploadTotal.Name = "LblUploadTotal";
			this.LblUploadTotal.Size = new System.Drawing.Size(45, 13);
			this.LblUploadTotal.TabIndex = 1;
			this.LblUploadTotal.Text = "77 kB/s";
			// 
			// LbLDownloadTotal
			// 
			this.LbLDownloadTotal.AutoSize = true;
			this.LbLDownloadTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.LbLDownloadTotal.Location = new System.Drawing.Point(34, 5);
			this.LbLDownloadTotal.Name = "LbLDownloadTotal";
			this.LbLDownloadTotal.Size = new System.Drawing.Size(45, 13);
			this.LbLDownloadTotal.TabIndex = 1;
			this.LbLDownloadTotal.Text = "77 kB/s";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(4, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "DL:";
			// 
			// resizer
			// 
			this.resizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resizer.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.resizer.Image = ((System.Drawing.Image)(resources.GetObject("resizer.Image")));
			this.resizer.InitialImage = ((System.Drawing.Image)(resources.GetObject("resizer.InitialImage")));
			this.resizer.Location = new System.Drawing.Point(281, 7);
			this.resizer.Name = "resizer";
			this.resizer.Size = new System.Drawing.Size(16, 16);
			this.resizer.TabIndex = 0;
			this.resizer.TabStop = false;
			this.resizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resizer_MouseDown);
			this.resizer.MouseEnter += new System.EventHandler(this.resizer_MouseEnter);
			this.resizer.MouseLeave += new System.EventHandler(this.resizer_MouseLeave);
			this.resizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resizer_MouseMove);
			this.resizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resizer_MouseUp);
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.mainContextMenu;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "notifyIcon1";
			this.trayIcon.Visible = true;
			this.trayIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDown);
			// 
			// RefreshTimer
			// 
			this.RefreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
			// 
			// GraphPanel
			// 
			this.GraphPanel.AutoSize = true;
			this.GraphPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.GraphPanel.Controls.Add(this.GraphBox);
			this.GraphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GraphPanel.Location = new System.Drawing.Point(1, 1);
			this.GraphPanel.Name = "GraphPanel";
			this.GraphPanel.Size = new System.Drawing.Size(297, 103);
			this.GraphPanel.TabIndex = 2;
			this.GraphPanel.Resize += new System.EventHandler(this.GraphPanel_Resize);
			// 
			// graphOnTrayToolStripMenuItem
			// 
			this.graphOnTrayToolStripMenuItem.Checked = true;
			this.graphOnTrayToolStripMenuItem.CheckOnClick = true;
			this.graphOnTrayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.graphOnTrayToolStripMenuItem.Name = "graphOnTrayToolStripMenuItem";
			this.graphOnTrayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.graphOnTrayToolStripMenuItem.Text = "&Graph on tray";
			this.graphOnTrayToolStripMenuItem.Click += new System.EventHandler(this.graphOnTrayToolStripMenuItem_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.RoyalBlue;
			this.ClientSize = new System.Drawing.Size(299, 128);
			this.ControlBox = false;
			this.Controls.Add(this.GraphPanel);
			this.Controls.Add(this.panel1);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainWindow";
			this.Padding = new System.Windows.Forms.Padding(1);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
			((System.ComponentModel.ISupportInitialize)(this.GraphBox)).EndInit();
			this.mainContextMenu.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.resizer)).EndInit();
			this.GraphPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox GraphBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox resizer;
		private System.Windows.Forms.ContextMenuStrip mainContextMenu;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.Timer RefreshTimer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label LblUploadTotal;
		private System.Windows.Forms.Label LbLDownloadTotal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem setScaleMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
		private System.Windows.Forms.Panel GraphPanel;
		private System.Windows.Forms.ToolStripMenuItem graphOnTrayToolStripMenuItem;
	}
}

