using System;
using System.Linq;
using System.Windows.Forms;

namespace LogMyTime
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(args.Count() > 0 && args[0].Equals("--start-minimized")));
        }
    }
}
