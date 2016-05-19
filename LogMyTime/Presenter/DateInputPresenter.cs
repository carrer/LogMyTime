using LogMyTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMyTime.Presenter
{
    public class DateInputPresenter
    {
        private DateInputModel model;
        private DateInputView view;

        public DateInputPresenter(DateInputModel model, DateInputView view)
        {
            this.model = model;
            this.view = view;
            view.Presenter = this;
        }

        public void setContext(DateTime value)
        {
            model.Date = value;
            view.DateField = value;
        }

        public void OK()
        {
            if (model.Date.TimeOfDay.TotalMinutes != view.DateField.TimeOfDay.TotalMinutes)
            {
                model.Date = view.DateField;
                model.HasChanged = true;
            }
            view.Close();
        }
    }
}
