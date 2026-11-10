using System;
using System.Windows.Forms;
using OOP10FEXLab.UI;

namespace OOP10FEXLab
{
    internal static class Program
    {
        /// <summary>Opens the Queue Monitor and the Kiosk together. Closing the Kiosk exits the app.</summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new QueueMonitorForm().Show();
            Application.Run(new KioskForm());
        }
    }
}
