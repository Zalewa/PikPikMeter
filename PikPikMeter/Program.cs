using System;
using System.Windows.Forms;

namespace PikPikMeter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var appContext = new AppContext();
            Application.Run(new MainWindow(appContext));
        }
    }
}
