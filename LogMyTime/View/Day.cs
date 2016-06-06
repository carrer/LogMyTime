using LogMyTime.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogMyTime.View
{
    public partial class DayView : Form
    {
        public DayPresenter Presenter { get; set; }

        public DayView()
        {
            InitializeComponent();
        }

        public DateTime Month
        {
            set
            {
                calendar.MinDate = new DateTime(value.Year, value.Month, 1);
                calendar.MaxDate = new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
            }
        }

        public DateTime GetDay()
        {
            return DateTime.ParseExact(calendar.SelectionEnd.ToString("yyyyMMdd")+"000000","yyyyMMddHHmmss",CultureInfo.InvariantCulture);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Presenter.Dismiss();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Presenter.Add();
        }
    }
}
