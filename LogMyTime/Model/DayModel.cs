using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMyTime.Model
{
    public class DayModel
    {
        public DateTime Month { get; set;}
        public bool HasAdded { get; set; }

        public Nullable<DateTime> Date { get; set; }

        public void SetMonth(string month)
        {
            Month = DateTime.ParseExact(month + "01", "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        public void CreateFile()
        {
            if (Date.HasValue)
            {
                FileHandler handler = new FileHandler();
                DayInfo day = new DayInfo(Date.Value, Date.Value, Date.Value);
                handler.WriteToFile(day.getSubDirectory(), day.getFilename(), day.ToCSV());
            }
        }

    }
}
