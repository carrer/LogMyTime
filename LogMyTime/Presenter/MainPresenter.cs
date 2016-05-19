using LogMyTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMyTime.Presenter
{
    public class MainPresenter
    {
        private MainModel model;
        private MainView view;

        private DayInfoRow edit;
        private bool editStartField;

        // to implement --start-minimized feature
        public bool InitializeMinimized { get; set; }
        protected int secondsToClose = 1;

        public MainPresenter(MainModel model, MainView view)
        {
            this.model = model;
            this.view = view;
            view.Presenter = this;
            InitializeMinimized = false;
        }

        public void Load()
        {
            model.Load();
            OnChangeMonth(model.GetToday());
            UpdateWorkingHour();
        }

        public void UpdateWorkingHour()
        {
            DayInfoRow data = model.GetTodayRow();
            view.WorkingHours = data;
            view.TrayIcon = "Today you've worked " + data.Net;
        }

        public void TickSecond()
        {
            if (DateTime.Now.TimeOfDay.TotalSeconds == 1)
                model.TurnDay();

            if (InitializeMinimized)
                if (secondsToClose-- <= 0)
                {
                    InitializeMinimized = false; // prevent from hiding the form onShow again
                    view.Minimize();
                }
        }

        public void RequestRestore()
        {
            view.Restore();
        }

        public void ConfigurationChanged()
        {
            model.CalcMonth();
            model.Tick();
            UpdateMonth();
            UpdateWorkingHour();
        }


        public void TickMinute()
        {
            if (Utils.GetIdleTime() < 60000) // If I'm idle for more than a minute, don't update counter
            {
                model.Tick();
                if (model.IsCurrentMonth())
                    UpdateMonth();

                if (model.ShouldWarn())
                    view.ShowGoHome();

                UpdateWorkingHour();
            }
        }

        public void OnChangeMonth(DayInfo newMonth)
        {
            model.SetMonth(newMonth);
            UpdateMonth();
        }

        public void UpdateMonth()
        {
            model.CalcMonth();
            view.DataSet = model.GetDataSet();
            view.AverageStart = model.AverageStart;
            view.AverageEnd = model.AverageEnd;
            view.AverageDifference = model.AverageDifference;
            view.AverageNet = model.AverageNet;
            view.AverageDelta = model.AverageDelta;
            view.TotalNet = model.TotalNet;
            view.TotalDelta = model.TotalDelta;
        }

        public void RequestDateEdit(int index, int column, bool today)
        {
            DateTime date;
            edit = today ? model.GetTodayRow() : model.GetDataSet()[index];
            if (column == 0)
            {
                date = Utils.StringToTime(edit.Start);
                editStartField = true;
            }
            else
            {
                date = Utils.StringToTime(edit.End);
                editStartField = false;
            }

            if (edit.Day == model.GetToday().GetDay() && edit.Month.Equals(model.GetToday().GetMonth()) && !editStartField)
                return;

            view.ShowDateInputForm(date);
        }

        public void GridEntryHasChanged(DateTime newDate)
        {
            if (editStartField)
                edit.Start = Utils.DatetimeToTime(newDate);
            else
                edit.End = Utils.DatetimeToTime(newDate);

            model.UpdateRow(edit);

            UpdateMonth();
            UpdateWorkingHour();

        }
    }
}
