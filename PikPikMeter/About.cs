using PikPikMeter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPikMeter
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}

		private void About_Load(object sender, EventArgs e)
		{
			this.Text = Application.ProductName + " - About";
			LabelName.Text = Application.ProductName + " v" + Application.ProductVersion;
			CopyrightBox.Text = System.Text.Encoding.UTF8.GetString(Resources.LICENSE);
		}

		private void IconBox_Click(object sender, EventArgs e)
		{
			LabelEgg.Visible = true;
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void LabelBackLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LinkLabel label = sender as LinkLabel;
			Process.Start(label.Text);
		}
	}
}
