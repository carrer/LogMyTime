using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMyTime.Model
{
    public class DayInfoRow
    {
        public string Month { set; get; }
        public string Day { set; get; }
        public string Start { set; get; }
        public string End { set; get; }
        public string Difference { set; get; }
        public string Net { set; get; }
        public string Delta { set; get; }

        public DayInfoRow() { }

        public DayInfoRow(string month, string day, string start, string end, string diff, string net, string delta)
        {
            this.Month = month;
            this.Day = day;
            this.Start = start;
            this.End = end;
            this.Difference = diff;
            this.Net = net;
            this.Delta = delta;
        }
    }
}
