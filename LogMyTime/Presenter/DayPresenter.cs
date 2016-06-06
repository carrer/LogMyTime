using LogMyTime.Model;
using LogMyTime.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMyTime.Presenter
{
    public class DayPresenter
    {
        private DayModel model;
        private DayView view;

        public DayPresenter(DayModel model, DayView view)
        {
            this.model = model;
            this.view = view;
            view.Month = model.Month;
            view.Presenter = this;
        }

        public void Add()
        {
            model.Date = view.GetDay();
            model.CreateFile();
            model.HasAdded = true;
            view.Close();
        }

        public void Dismiss()
        {
            model.HasAdded = false;
            view.Close();
        }
    }
}
