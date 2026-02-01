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
    public partial class AskValue : Form
    {
        public AskValue()
        {
            InitializeComponent();
        }

        public string ValueTitle
        {
            get { return LabelTitle.Text; }
            set { LabelTitle.Text = value; }
        }

        public string Value
        {
            get { return TextBoxValue.Text; }
            set { TextBoxValue.Text = value; }
        }

        private void AskValue_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            this.ButtonOk.DialogResult = DialogResult.OK;
            this.ButtonCancel.DialogResult = DialogResult.Cancel;
            this.CancelButton = this.ButtonCancel;
            this.AcceptButton = this.ButtonOk;
            this.ActiveControl = this.TextBoxValue;
        }
    }
}
