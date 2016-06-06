using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LogMyTime.Model
{
    public class MainModel
    {
        private FileHandler io = new FileHandler();
        private ConfigurationSettings config = ConfigurationSettings.GetInstance();
        private DayInfo today;
        private DayInfo month;
        private List<DayInfoRow> dataset = new List<DayInfoRow>();

        public Int32 AverageStart { get; set; }
        public Int32 AverageEnd { get; set; }
        public Int32 AverageDifference { get; set; }
        public Int32 AverageNet { get; set; }
        public Int32 AverageDelta { get; set; }
        public Int32 TotalDelta { get; set; }
        public Int32 TotalNet { get; set; }
        public Int32 Diff { get; set; }
        public Int32 Net { get; set; }
        public Int32 Delta { get; set; }

        public void Load()
        {
            today = new DayInfo();
            string line = io.ReadFromFile(today.getSubDirectory(), today.getFilename());
            today = line.Length > 0 ? new DayInfo(line) : new DayInfo();
            Tick();
            PersistData();
        }

        public bool ShouldWarn()
        {
            return config.Warn && Net == config.WarnCondition;
        }


        public void PersistData()
        {
            io.WriteToFile(today.getSubDirectory(), today.getFilename(), today.ToCSV());
        }

        public void UpdateRow(DayInfoRow row)
        {
            string prefix = row.Month + row.Day;
            string start = row.Start.Replace(":", "");
            string end = row.End.Replace(":", "");
            DayInfo d = new DayInfo(prefix + ";" + start + ";" + end+";" + row.Comment);
            if (d.GetDateToString().Equals(today.GetDateToString()))
            {
                today.SetComment(d.GetComment());
                today.setFirstActivity(d.GetFormattedFirstActivity());
                Tick();
            }
            else
                io.WriteToFile(d.getSubDirectory(), d.getFilename(), d.ToCSV());
        }

        public void TurnDay()
        {
            today = new DayInfo();
        }

        public void Tick()
        {
            today.tick();
            PersistData();
            DateTime first = today.getFirstActivity().Value;
            DateTime last = today.getLastActivity().Value;
            int worked = (int)(last - first).TotalMinutes;
            int raw = worked;
            if (config.Subtract)
            {
                if (config.SubtractCondition == -1)
                    worked -= config.SubtractQuantity;
                else if (config.SubtractCondition == 0)
                {
                    if (first.TimeOfDay.TotalHours < 12 && last.TimeOfDay.TotalHours > 12)
                        worked -= config.SubtractQuantity;
                }
                else
                {
                    if (worked > config.SubtractCondition)
                        worked -= config.SubtractQuantity;
                }
            }
            Diff = raw;
            Net = worked;
            Delta = worked - config.Workload;
        }

        public void SetMonth(DayInfo month)
        {
            this.month = month;
        }

        public DayInfo GetToday()
        {
            return today;
        }

        public DayInfoRow GetTodayRow()
        {
            return new DayInfoRow(today.GetMonth(), today.GetDay(), today.GetFormattedFirstActivity(), today.GetFormattedLastActivity(), Utils.MinutesToString(Diff), Utils.MinutesToString(Net), Utils.MinutesToString(Delta), today.GetComment());
        }

        public void CalcMonth()
        {
            AverageDelta = AverageDifference = AverageEnd = AverageNet = AverageStart = TotalDelta = TotalNet = 0;
            dataset = new List<DayInfoRow>();
            List<string> files = io.ListAllFiles(month.getSubDirectory());
            foreach (string filename in files.OrderByDescending(o => o).ToList())
            {
                DayInfo day = new DayInfo(io.ReadFromFile(month.getSubDirectory(), filename));
                DateTime first = (DateTime)day.getFirstActivity();
                DateTime last = (DateTime)day.getLastActivity();
                int worked = (int)(last - first).TotalMinutes;

                AverageDifference += worked;
                AverageStart += (int)first.TimeOfDay.TotalSeconds;
                AverageEnd += (int)last.TimeOfDay.TotalSeconds;

                int raw = worked;
                if (config.Subtract)
                {
                    if (config.SubtractCondition == -1)
                        worked -= config.SubtractQuantity;
                    else if (config.SubtractCondition == 0)
                    {
                        if (first.TimeOfDay.TotalHours < 12 && last.TimeOfDay.TotalHours > 12)
                            worked -= config.SubtractQuantity;
                    }
                    else
                    {
                        if (worked > config.SubtractCondition)
                            worked -= config.SubtractQuantity;
                    }
                }
                int delta = worked - config.Workload;
                TotalNet += worked;
                TotalDelta += delta;
                dataset.Add(new DayInfoRow(day.GetMonth(), day.GetDay(), Utils.SecondsToString((int)first.TimeOfDay.TotalSeconds), Utils.SecondsToString((int)last.TimeOfDay.TotalSeconds), Utils.MinutesToString(raw), Utils.MinutesToString(worked), Utils.MinutesToString(delta), day.GetComment()));
            }
            if (files.Count>0)
            {
                AverageStart /= files.Count;
                AverageEnd /= files.Count;
                AverageDifference /= files.Count;
                AverageNet = TotalNet / files.Count;
                AverageDelta = TotalDelta / files.Count;
            }
        }

        public void InjectPath(string path)
        {
            io.InjectPath(path);
        }

        public List<DayInfoRow> GetDataSet()
        {
            return dataset;
        }

        public bool IsCurrentMonth()
        {
            return today.GetMonth().Equals(month.GetMonth());
        }

    }
}
