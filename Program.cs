using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using QLTN.Forms;
using QLTN.Services;

namespace QLTN
{
    /// <summary>
    /// Application entry point for QLTN
    /// </summary>
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Thiết lập culture cho tiếng Việt
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi chạy ứng dụng với ApplicationManager
            //ApplicationManager.StartApplication();
            Application.Run(new FormMainSystem());
        }
    }
}
