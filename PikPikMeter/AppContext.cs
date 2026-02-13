using PikPikMeter.Properties;

namespace PikPikMeter
{
    public class AppContext
    {
        private Style _style = new Style();

        public Style Style { get => _style; set => _style = value; }

        internal void SaveSettings(Settings settings)
        {
            Style.SaveSettings(settings);
        }

        internal void LoadSettings(Settings settings)
        {
            Style.LoadSettings(settings);
        }
    }
}
