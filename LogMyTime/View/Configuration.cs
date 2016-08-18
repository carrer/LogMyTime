using LogMyTime.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogMyTime
{
    public partial class ConfigurationView : Form
    {
        public ConfigurationPresenter Presenter { get; set; }
        public ConfigurationView()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Presenter.Close();
        }


        public int Workload
        {
            set
            {
                dtWorkload.Value = Utils.IntToDateTime(value);
            }
            get
            {
                return (int) dtWorkload.Value.TimeOfDay.TotalMinutes;
            }
        }

        public int Tolerance
        {
            set
            {
                dtTolerance.Value = Utils.IntToDateTime(value);
            }
            get
            {
                return (int)dtTolerance.Value.TimeOfDay.TotalMinutes;
            }
        }


        public int SubtractQuantity
        {
            set
            {
                dtSubtract.Value = Utils.IntToDateTime(value);
            }
            get
            {
                return (int) dtSubtract.Value.TimeOfDay.TotalMinutes;
            }
        }

        public int SubtractCondition
        {
            set
            {
                if (value == -1)
                    rbDaily.Checked = true;
                else if (value == 0)
                    rbBothPeriods.Checked = true;
                else
                {
                    rbWorkedHours.Checked = true;
                    dtCondition.Value = Utils.IntToDateTime(value);
                }
            }
            get
            {
                return rbDaily.Checked ? -1 : ( rbBothPeriods.Checked ? 0 : (dtCondition.Value.TimeOfDay.TotalMinutes == 0 ? -1 : (int)dtCondition.Value.TimeOfDay.TotalMinutes));
            }
        }

        public int WarnCondition
        {
            set
            {
                dtWarn.Value = Utils.IntToDateTime(value);
            }
            get
            {
                return (int)dtWarn.Value.TimeOfDay.TotalMinutes;
            }
        }

        public bool Warn
        {
            set
            {
                ckWarn.Checked = value;
            }
            get
            {
                return ckWarn.Checked;
            }
        }

        public bool Startup
        {
            set
            {
                ckStartup.Checked = value;
            }
            get
            {
                return ckStartup.Checked;
            }
        }
        public bool Subtract
        {
            set
            {
                ckSubtract.Checked = value;
            }
            get
            {
                return ckSubtract.Checked;
            }
        }

    }
}
