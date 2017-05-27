using System;
using System.Collections.Generic;

namespace LogMyTime.Model
{
    public class TimeBook
    {
        private DateTime date = DateTime.Now;
        private int minutes = 0;
        private List<TimeCard> cards = new List<TimeCard>();
        private List<ProgramInfo> apps = new List<ProgramInfo>();
        private Dictionary<string, int> map = new Dictionary<string, int>();

        public string Date { set { date = DateTime.ParseExact(value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); } get { return date.ToString("yyyy-MM-dd"); } }
        public string Duration {
            set {
                DateTime temp = DateTime.ParseExact(value, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                minutes = (temp.Hour * 60) + temp.Minute;
            } get { return Utils.MinutesToString(minutes); } }
        public List<TimeCard> Cards { set { cards = value; } get { return cards; } }
        public List<ProgramInfo> Apps { set { apps = value; } get { return apps; } }

        public TimeBook() { }

        public TimeBook(DateTime date)
        {
            this.date = date;
        }

        public void Add(TimeCard card)
        {
            if (cards.Count == 0)
                cards.Add(card);
            else if (cards[cards.Count - 1].End.Equals(card.Start))
                cards[cards.Count - 1].Merge(card);
            else
                cards.Add(card);

            minutes++;
        }

        public void Add(ProgramInfo prog)
        {
            if (map.Count < apps.Count)
                for (int i = 0; i < apps.Count; i++)
                    map.Add(apps[i].ID, i);
            
            if (prog == null || map.ContainsKey(prog.ID))
                return;

            apps.Add(prog);
            map.Add(prog.ID, apps.Count - 1);
        }

    }
}
