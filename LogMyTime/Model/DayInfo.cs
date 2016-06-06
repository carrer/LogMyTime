using System;
using System.Linq;

namespace LogMyTime
{
    public class DayInfo
    {
        protected DateTime date;
        protected Nullable<DateTime> activityFirst;
        protected Nullable<DateTime> activityLast;
        protected string comment = "";

        public DayInfo()
        {
            date = DateTime.Now;
        }

        public DayInfo(DateTime date, DateTime first, DateTime last)
        {
            this.date = date;
            this.activityFirst = first;
            this.activityLast = last;
            this.comment = "";
        }

        public DayInfo(DateTime date, DateTime first, DateTime last, string comment)
        {
            this.date = date;
            this.activityFirst = first;
            this.activityLast = last;
            this.comment = comment;
        }

        public DayInfo(string csvLine)
        {
            string[] info = csvLine.Split(';');
            if (info != null && info.Count() >= 3)
            {
                if (info[0].Length > 0)
                    try
                    {
                        this.date = DateTime.ParseExact(info[0], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {
                        this.date = DateTime.Now;
                    }

                if (info[1].Length > 0)
                    try
                    {
                        this.activityFirst = DateTime.ParseExact(GetDateToString() + info[1], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {
                        //ignore
                    }
                if (info[2].Length > 0)
                    try
                    {
                        this.activityLast = DateTime.ParseExact(GetDateToString() + info[2], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception e)
                    {
                        //ignore
                    }
                if (info.Length > 3 && info[3].Length > 0)
                    this.comment = info[3];
            }
            else
                this.date = DateTime.Now;
        }

        public string ToCSV()
        {
            string d1 = activityFirst != null ? ((DateTime)activityFirst).ToString("HHmmss") : "";
            string d2 = activityLast != null ? ((DateTime)activityLast).ToString("HHmmss") : "";
            return date.ToString("yyyyMMdd") + ";" + d1 + ";" + d2 + ";" + comment;
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

        public string GetComment()
        {
            return comment;
        }

        public void SetComment(string info)
        {
            comment = info;
        }

        public string GetMonth()
        {
            return string.Format("{0:D4}{1:D2}", date.Year, date.Month);
        }

        public string GetDateToString()
        {
            return date.ToString("yyyyMMdd");
        }

        public string GetDay()
        {
            return date.ToString("dd");
        }

        public string GetFormattedDay()
        {
            return date.ToString("dd/MM");
        }

        public string GetWeekday()
        {
            return date.ToString("dddd");
        }

        public string GetFormattedFirstActivity()
        {
            return activityFirst != null ? activityFirst.Value.ToString("HH:mm:ss") : "(missing)";
        }

        public string GetFormattedLastActivity()
        {
            return activityLast != null ? activityLast.Value.ToString("HH:mm:ss") : "(missing)";
        }

        public void setFirstActivity(string t)
        {
            try
            {
                activityFirst = DateTime.ParseExact(GetDateToString() + t.Replace(":", ""), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(Exception e)
            {
                //don't set
            }
        }

        public void setLastActivity(string t)
        {
            try
            {
                activityLast = DateTime.ParseExact(GetDateToString() + t.Replace(":", ""), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                //don't set
            }
        }

    }
}
