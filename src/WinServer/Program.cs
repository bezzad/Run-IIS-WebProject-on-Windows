using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var dir = Environment.CurrentDirectory;
            var server = new ProcessStartInfo(@"C:\Program Files (x86)\IIS Express\iisexpress.exe", $@"/port:8001 /path:{dir}\Publish");
            server.CreateNoWindow = true;
            server.UseShellExecute = false;
            server.WindowStyle = ProcessWindowStyle.Hidden;

            Process _process;
            _process = Process.Start(server);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            _process.Kill();
        }


    }
}
