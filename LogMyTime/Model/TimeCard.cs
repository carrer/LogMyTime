using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LogMyTime.Model
{
    public class TimeCard
    {
        public const int TIMECARD_LENGTH = 60;
        private DateTime start;
        private DateTime end;
        private int clicks = 0;
        private int strokes = 0;
        private List<Counter> applications = new List<Counter>();
        private Dictionary<string, int> map = new Dictionary<string, int>();

        public string Start { set { start = DateTime.ParseExact(value, "HH:mm", System.Globalization.CultureInfo.InvariantCulture); } get { return start.ToString("HH:mm"); } }
        public string End { set { end = DateTime.ParseExact(value, "HH:mm", System.Globalization.CultureInfo.InvariantCulture); } get { return end.ToString("HH:mm"); } }
        public int Clicks { set { clicks = value; } get { return clicks; } }
        public int Strokes { set { strokes = value; } get { return strokes; } }

        [XmlArrayItem("App")]
        public List<Counter> Apps { set { applications = value; } get { return applications; } }

        public TimeCard() { }

        public TimeCard(DateTime start)
        {
            this.Start = start.ToString("HH:mm");
            this.End = start.AddSeconds(TIMECARD_LENGTH).ToString("HH:mm");
        }

        public void Add(ProgramInfo app, int inc = 1)
        {
            if (app == null || inc == 0)
                return;

            Add(app.ID, inc);
        }

        public void Add(string key, int inc = 1)
        {
            if (map.Count < applications.Count)
                for (int i = 0; i < applications.Count; i++)
                    map.Add(applications[i].ID, i);

            if (key == null || inc == 0)
                return;

            if (!map.ContainsKey(key))
            {
                applications.Add(new Counter(key, inc));
                map.Add(key, applications.Count - 1);
            }
            else
            {
                applications[map[key]].Inc();
            }
        }

        public void Merge(TimeCard card)
        {
            this.clicks += card.Clicks;
            this.strokes += card.Strokes;
            foreach(Counter app in card.Apps)
            {
                String key = app.ID;
                if (map.ContainsKey(key))
                    applications[map[key]].Count += app.Count;
                else
                    Add(app.ID, app.Count);
            }

            if (this.start > card.GetDateTimeStart())
                this.start = card.GetDateTimeStart();

            if (this.end < card.GetDateTimeEnd())
                this.end = card.GetDateTimeEnd();
        }

        public DateTime GetDateTimeStart()
        {
            return start;
        }

        public DateTime GetDateTimeEnd()
        {
            return end;
        }
    }
}
