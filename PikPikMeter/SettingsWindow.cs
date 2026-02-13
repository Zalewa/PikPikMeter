using PikPikMeter.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PikPikMeter
{
    public partial class SettingsWindow : Form
    {
        private AppContext _appContext;
        private Settings _settings;

        internal SettingsWindow(AppContext appContext, Settings settings)
        {
            this._appContext = appContext;
            this._settings = settings;
            InitializeComponent();
            this.AcceptButton = this.okButton;
            this.CancelButton = this.cancelButton;

            this._appContext.Style.Changed += (_, __) =>
            {
                ApplyStyle();
            };
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            var style = this._appContext.Style;
            this.backgroundColorButton.BackColor = style.BackgroundColor;
            this.borderColorButton.BackColor = style.BorderColor;
            this.graphBackgroundColorButton.BackColor = style.GraphBackgroundColor;
        }

        private void backgroundColorButton_Click(object sender, System.EventArgs e)
        {
            var selectedColor = AskForColor(this._appContext.Style.BackgroundColor);
            if (selectedColor.HasValue)
                this._appContext.Style.BackgroundColor = selectedColor.Value;
        }
        private void borderColorButton_Click(object sender, EventArgs e)
        {
            var selectedColor = AskForColor(this._appContext.Style.BorderColor);
            if (selectedColor.HasValue)
                this._appContext.Style.BorderColor = selectedColor.Value;
        }

        private void graphBackgroundColorButton_Click(object sender, EventArgs e)
        {
            var selectedColor = AskForColor(this._appContext.Style.GraphBackgroundColor);
            if (selectedColor.HasValue)
                this._appContext.Style.GraphBackgroundColor = selectedColor.Value;
        }

        private static Color? AskForColor(Color currentColor)
        {
            using (var colorDialog = new ColorDialog
            {
                Color = currentColor,
                FullOpen = true,
            })
            {
                return colorDialog.ShowDialog() == DialogResult.OK
                    ? colorDialog.Color
                    : (Color?)null;
            }
        }

        internal void ResetSettings()
        {
            var style = this._appContext.Style;
            style.BackgroundColor = this._settings.WindowBackgroundColor;
            style.BorderColor = this._settings.WindowBorderColor;
            style.GraphBackgroundColor = this._settings.GraphBackgroundColor;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.ResetSettings();
        }

        private void resetDefaultBackgroundColorButton_Click(object sender, EventArgs e)
        {
            this._appContext.Style.BackgroundColor = new Style().BackgroundColor;
        }

        private void resetDefaultBorderColorButton_Click(object sender, EventArgs e)
        {
            this._appContext.Style.BorderColor = new Style().BorderColor;
        }

        private void resetGraphBackgroundColorButton_Click(object sender, EventArgs e)
        {
            this._appContext.Style.GraphBackgroundColor = new Style().GraphBackgroundColor;
        }
    }
}
