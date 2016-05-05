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
    public partial class Configuration : Form
    {
        protected ConfigSettings config;
        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            config = ConfigSettings.Instance();
            dtWorkload.Value = DateTime.ParseExact(Utils.MinutesToString(config.Workload), "HH:mm", CultureInfo.InvariantCulture);
            dtSubtract.Value = DateTime.ParseExact(Utils.MinutesToString(config.SubtractQuantity), "HH:mm", CultureInfo.InvariantCulture);
            int condition = config.SubtractCondition;
            if (condition == -1)
                rbDaily.Checked = true;
            else if (condition == 0)
                rbBothPeriods.Checked = true;
            else
            {
                rbWorkedHours.Checked = true;
                dtCondition.Value = DateTime.ParseExact(Utils.MinutesToString(condition), "HH:mm", CultureInfo.InvariantCulture);
            }
            dtWarn.Value = DateTime.ParseExact(Utils.MinutesToString(config.WarnCondition), "HH:mm", CultureInfo.InvariantCulture);
            ckStartup.Checked = Utils.IsAtWindowsRegistry();
            ckSubtract.Checked = config.Subtract;
            ckWarn.Checked = config.Warn;
        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.Workload = (int) dtWorkload.Value.TimeOfDay.TotalMinutes;
            config.Startup = ckStartup.Checked;
            config.Subtract = ckSubtract.Checked;
            if (rbDaily.Checked)
                config.SubtractCondition = -1;
            else if (rbBothPeriods.Checked)
                config.SubtractCondition = 0;
            else
                config.SubtractCondition = (int) dtCondition.Value.TimeOfDay.TotalMinutes;

            config.SubtractQuantity = (int)dtSubtract.Value.TimeOfDay.TotalMinutes;
            config.Warn = ckWarn.Checked;
            config.WarnCondition = (int)dtWarn.Value.TimeOfDay.TotalMinutes;
            config.SaveToRegistry();
        }
    }
}
