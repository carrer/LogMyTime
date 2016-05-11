﻿using System;
using System.Linq;

namespace LogMyTime
{
    public class DayInfo
    {
        protected DateTime date;
        protected Nullable<DateTime> activityFirst;
        protected Nullable<DateTime> activityLast;

        public DayInfo()
        {
            date = DateTime.Now;
        }

        public DayInfo(DateTime date, DateTime first, DateTime last)
        {
            this.date = date;
            this.activityFirst = first;
            this.activityLast = last;
        }

        public DayInfo(string csvLine)
        {
            string[] dates = csvLine.Split(';');
            if (dates != null && dates.Count() == 3)
            {
                if (dates[0].Length > 0)
                    try
                    {
                        this.date = DateTime.ParseExact(dates[0], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {
                        this.date = DateTime.Now;
                    }

                if (dates[1].Length > 0)
                    try
                    {
                        this.activityFirst = DateTime.ParseExact(dates[1], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {
                        //ignore
                    }
                if (dates[1].Length > 0)
                    try
                    {
                        this.activityLast = DateTime.ParseExact(dates[2], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {
                        //ignore
                    }
            }
            else
                this.date = DateTime.Now;
        }

        public string ToCSV()
        {
            string d1 = activityFirst != null ? ((DateTime)activityFirst).ToString("yyyyMMddHHmmss") : "";
            string d2 = activityLast != null ? ((DateTime)activityLast).ToString("yyyyMMddHHmmss") : "";
            return date.ToString("yyyyMMdd") + ";" + d1 + ";" + d2;
        }

        public string getFilename()
        {
            return date.ToString("yyyyMMdd") + ".csv";
        }

        public Nullable<DateTime> getFirstActivity()
        {
            return activityFirst;
        }

        public Nullable<DateTime> getLastActivity()
        {
            return activityLast;
        }

        public void tick()
        {
            activityLast = DateTime.Now;
            if (activityFirst == null)
                activityFirst = activityLast;

        }

        public string getSubDirectory()
        {
            return string.Format("{0:D4}\\{1:D2}\\", date.Year, date.Month);
        }

        public string getMonth()
        {
            return string.Format("{0:D4}{1:D2}", date.Year, date.Month);
        }

        public string getDayToString()
        {
            return date.ToString("yyyyMMdd");
        }

        public void setFirstActivity(string t)
        {
            activityFirst = DateTime.ParseExact(getDayToString()+t.Replace(":",""), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void setLastActivity(string t)
        {
            activityLast = DateTime.ParseExact(getDayToString() + t.Replace(":", ""), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
        }

    }
}
