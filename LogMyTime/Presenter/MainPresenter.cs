using LogMyTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogMyTime.Presenter
{
    public class MainPresenter
    {
        private MainModel model;
        private MainView view;

        // to implement --start-minimized feature
        public bool InitializeMinimized { get; set; }
        protected int secondsToClose = 1;

        public MainPresenter(MainModel model, MainView view)
        {
            this.model = model;
            this.view = view;
            view.SetPresenter(this);
            InitializeMinimized = false;
        }

        public void Load()
        {
            model.Load();
            view.SetTime(model.GetTotalTime());
        }

        public void TickSecond()
        {
            if (InitializeMinimized)
                if (secondsToClose-- <= 0)
                {
                    InitializeMinimized = false; // prevent from hiding the form onShow again
                    view.Minimize();
                }

            model.Tick();
        }

        public void RequestRestore()
        {
            view.Restore();
        }

        public void TickMinute()
        {
            model.WrapUpMinute();
            view.SetTime(model.GetTotalTime());
        }

        internal void Toogle()
        {
            if (model.IsRunning())
            {
                model.Stop();
                view.Stop();
            }
            else
            {
                model.Start();
                view.Start();
            }
        }
    }
}
