using PikPikMeter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PikPikMeter
{
    public class Style
    {
        private Color _backgroundColor = Color.SteelBlue;
        private Color _borderColor = Color.RoyalBlue;
        private Color _graphBackgroundColor = Color.Black;

        public event EventHandler Changed;

        public Color BackgroundColor { get => _backgroundColor; set => Set(ref _backgroundColor, value); }
        public Color BorderColor { get => _borderColor; set => Set(ref _borderColor, value); }
        public Color GraphBackgroundColor { get => _graphBackgroundColor; set => Set(ref _graphBackgroundColor, value); }

        private void Set<T>(ref T field, T value)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;

            field = value;
            OnChanged();
        }

        private void OnChanged()
        {
            var handler = Changed;
            if (handler != null)
                handler.Invoke(this, EventArgs.Empty);
        }

        internal void SaveSettings(Settings settings)
        {
            settings.WindowBackgroundColor = this._backgroundColor;
            settings.WindowBorderColor = this._borderColor;
            settings.GraphBackgroundColor = this._graphBackgroundColor;
        }

        internal void LoadSettings(Settings settings)
        {
            this._backgroundColor = settings.WindowBackgroundColor;
            this._borderColor = settings.WindowBorderColor;
            this._graphBackgroundColor = settings.GraphBackgroundColor;
        }
    }
}
