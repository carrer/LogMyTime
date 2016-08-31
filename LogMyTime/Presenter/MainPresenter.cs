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
                if (!DateTime.Now.ToString("dd").Equals(model.GetToday().GetDay())) // computer was idle for a day or more
                    model.TurnDay();

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

        public void GridCommentEntryHasChanged(string comment)
        {
            edit.Comment = comment;
            model.UpdateRow(edit);
            UpdateMonth();
            UpdateWorkingHour();
        }

        public void RequestCommentEdit(int index)
        {
            edit = model.GetDataSet()[index];
            view.ShowComment(edit);
        }

        public void RequestTodayCommentEdit()
        {
            edit = model.GetTodayRow();
            view.ShowComment(edit);
        }

        public void CopyToClipboard(int column, int row)
        {
            StringBuilder sb = new StringBuilder();
            if (column == -1)
            {
                sb.AppendLine("Day\tStart\tEnd\tDiff\tNet\tDelta\tComment");
                if (row == -1)
                {
                    foreach (DayInfoRow day in view.DataSet)
                        sb.AppendLine(day.ToString('\t'));
                }
                else
                {
                    sb.AppendLine(view.DataSet[row].ToString('\t'));
                }
            }
            else
                switch(column)
                {
                    case 1: sb.Append(view.DataSet[row].Day); break;
                    case 2: sb.Append(view.DataSet[row].Weekday); break;
                    case 3: sb.Append(view.DataSet[row].Start); break;
                    case 4: sb.Append(view.DataSet[row].End); break;
                    case 5: sb.Append(view.DataSet[row].Difference); break;
                    case 6: sb.Append(view.DataSet[row].Net); break;
                    case 7: sb.Append(view.DataSet[row].Delta); break;
                }

            Clipboard.SetText(sb.ToString());
        }

        public void RequestAddDay()
        {
            view.ShowNewDay(model.GetToday().GetMonth());
        }

        public void GridEntryAdded()
        {
            UpdateMonth();
        }

        public void RequestDelete(int recordIndex)
        {
            if (!(model.IsCurrentMonth() && recordIndex == 0))
            if (view.RequestConfirmation())
            {
                model.DeleteDay(model.GetDataSet()[recordIndex]);
                UpdateMonth();
            }
        }

    }
}
