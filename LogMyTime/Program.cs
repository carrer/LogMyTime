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
            Application.Run(view);
        }
    }
}
