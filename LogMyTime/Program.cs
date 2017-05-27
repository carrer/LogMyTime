using LogMyTime.Model;
using LogMyTime.Presenter;
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
            MainModel model = new MainModel();
            MainView view = new MainView();
            MainPresenter presenter = new MainPresenter(model, view);
            if (args.Contains("--start-minimized"))
                presenter.InitializeMinimized = true;
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            Application.Run(view);
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}
