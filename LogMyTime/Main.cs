using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LogMyTime
{
    public partial class frmMain : Form
    {
        protected ConfigSettings config;
        protected bool initializeMinimized;
        protected bool canClose = false;
        protected DayInfo today;
        protected DataGridViewRow todayRow;
        protected FileHandler io = new FileHandler();
        protected DataTable dataset;
        protected int secondsToClose = 1;

        public frmMain(bool minimized)
        {
            InitializeComponent();
            MaximizeBox = false;
            initializeMinimized = minimized;
        }

        /*
        * Form Events
        */

        private void frmMain_Shown(object sender, EventArgs e)
        {
            today = new DayInfo();
            string line = io.ReadFromFile(today.getSubDirectory(), today.getFilename());
            today = line.Length > 0 ? new DayInfo(line) : new DayInfo();
            today.tick();
            persistData();
            updateInterface();
        }

        private void updateInterface()
        {
            UpdateWorkingHours();
            FulfillDataSource(today);
            UpdateTrayHint();
//            lblStartTime.Text = today.getFirstActivity() != null ? Utils.DatetimeToTime((DateTime)today.getFirstActivity()) : "(missing)";
            timerSecond.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            config = ConfigSettings.Instance();
            monthYearPicker.Format = DateTimePickerFormat.Custom;
            monthYearPicker.CustomFormat = "MM/yyyy";
            dataset = new DataTable();
            dataset.Columns.Add("Day", typeof(int));
            dataset.Columns.Add("Start", typeof(String));
            dataset.Columns.Add("End", typeof(String));
            dataset.Columns.Add("Diff", typeof(String));
            dataset.Columns.Add("Net", typeof(String));
            dataset.Columns.Add("Delta", typeof(String));
            reportGrid.DataSource = dataset;
            reportGrid.Columns[0].Width = 60;
            reportGrid.Columns[4].Width = 75;
            reportGrid.Columns[5].Width = 75;
            gridToday.Rows.Add("dd/mm/yyyy", "00:00:00", "00:00:00", "00:00", "00:00", "00:00");
            todayRow = gridToday.Rows[0];
        }

        // Prevent from closing the form and exiting the app
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
                Hide();
            }
            else
                trayIcon.Visible = false;
        }

        // Minimize to tray
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
                Hide();
        }

        /*
         * popupMenu buttons
         */

        private void showApp_Click(object sender, EventArgs e)
        {
            RestoreForm();
        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            canClose = true;
            Close();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            RestoreForm();
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.TimeOfDay.TotalSeconds == 1)
                today = new DayInfo(); // change dates at midnight 

            if (initializeMinimized)
                if (secondsToClose-- <= 0)
                {
                    initializeMinimized = false; // prevent from hiding the form onShow again
                    WindowState = FormWindowState.Minimized;
                }

        }

        private void timerMinute_Tick(object sender, EventArgs e)
        {
            if (Utils.GetIdleTime() < 60000) // If I'm idle for more than a minute, don't update counter
            {
                today.tick();
                persistData();
                UpdateTrayHint();

                if (Visible)
                {
                    UpdateWorkingHours();
                    FulfillDataSource(today);
                }

                if (config.Warn && Utils.getWorkingHours(today) == config.WarnCondition)
                {
                    /*
                     * gohome.ShowModal() doesn't bring the Form to focus,
                     * therefore keyboard events aren't capture by the form (for
                     * auto closing) 
                     */
                    Form gohome = new Warn();
                    gohome.WindowState = FormWindowState.Minimized;
                    gohome.Show();
                    gohome.WindowState = FormWindowState.Maximized;
                }

            }
        }

        private void monthYearPicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime m = (DateTime)monthYearPicker.Value;
            FulfillDataSource(new DayInfo(m, m, m));
        }

        /*
         * Auxiliary methods
         */

        private void RestoreForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            updateInterface();
        }

        private void UpdateTrayHint()
        {
            trayIcon.Text = "Today you worked " + Utils.MinutesToString(Utils.getWorkingHours(today));
        }

        private void UpdateWorkingHours()
        {
            todayRow.Cells[0].Value = today.GetFormattedDay();
            todayRow.Cells[1].Value = today.GetFormattedFirstActivity();
            todayRow.Cells[2].Value = today.GetFormattedLastActivity();
            todayRow.Cells[3].Value = Utils.MinutesToString(Utils.GetRawDiff(today));
            int worked = Utils.getWorkingHours(today);
            todayRow.Cells[4].Value = Utils.MinutesToString(worked);
            todayRow.Cells[5].Value = Utils.MinutesToString(worked - config.Workload);
        }

        private void persistData()
        {
            io.WriteToFile(today.getSubDirectory(), today.getFilename(), today.ToCSV());
        }

        private void FulfillDataSource(DayInfo month)
        {
            int totalNet = 0;
            int totalDelta = 0;
            int avgStart = 0;
            int avgEnd = 0;
            int avgDiff = 0;

            dataset.Rows.Clear();
            List<string> files = io.ListAllFiles(month.getSubDirectory());
            foreach (string filename in files.OrderByDescending(o => o).ToList())
            {
                DayInfo day = new DayInfo(io.ReadFromFile(month.getSubDirectory(), filename));
                DateTime first = (DateTime)day.getFirstActivity();
                DateTime last = (DateTime)day.getLastActivity();
                int worked = (int)(last - first).TotalMinutes;
                avgDiff += worked;
                avgStart += (int) first.TimeOfDay.TotalSeconds;
                avgEnd += (int) last.TimeOfDay.TotalSeconds;

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
                totalNet += worked;
                totalDelta += ( worked - config.Workload );
                dataset.Rows.Add(first.Day, Utils.DatetimeToTime(first), Utils.DatetimeToTime(last), Utils.MinutesToString(raw), Utils.MinutesToString(worked), Utils.MinutesToString(worked - config.Workload));
            }

            if (files.Count==0)
            {
                lblAvgDelta.Text = "";
                lblAvgDiff.Text = "";
                lblAvgNet.Text = "";
                lblAvgStart.Text = "";
                lblAvgEnd.Text = "";
                lblTotalDelta.Text = "";
                lblTotalNet.Text = "";
            }
            else
            {
                lblAvgStart.Text = Utils.SecondsToString(avgStart / files.Count);
                lblAvgEnd.Text = Utils.SecondsToString(avgEnd / files.Count);
                lblAvgDelta.Text = Utils.MinutesToString(totalDelta / files.Count);
                lblAvgDiff.Text = Utils.MinutesToString(avgDiff / files.Count);
                lblAvgNet.Text = Utils.MinutesToString(totalNet / files.Count);
                lblTotalDelta.Text = Utils.MinutesToString(totalDelta);
                lblTotalNet.Text = Utils.MinutesToString(totalNet);
            }

/*
            lblAvgNet.Text = Utils.MinutesToString(avgTime);
            lblAvgNet.ForeColor = avgTime >= 0 ? Color.Black : Color.Red;
            lblTotalNet.Text = Utils.MinutesToString(timeTotal);
            lblTotalNet.ForeColor = timeTotal >= 0 ? Color.Black : Color.Red;
*/
        }

        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Configuration();
            f.ShowDialog(this);
            updateInterface();
        }

        private void reportGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value.ToString().IndexOf('-') != -1)
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private void reportGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 2)
            {
                int c = e.ColumnIndex == 1 ? 0 : 1;
                DateInput form = new DateInput(this);
                DayInfo d = getItem(e.RowIndex);
                if (d.getDayToString().Equals(today.getDayToString()) && c == 1)
                    return;
                form.setTime(d, c);
                form.ShowDialog();
            }
        }

        private DayInfo getItem(int row)
        {
            string day = today.getMonth() + Convert.ToInt16(dataset.Rows[row][0]).ToString("D2");
            string csv = day + ";" + day + dataset.Rows[row][1].ToString().Replace(":", "") + ";" + day + dataset.Rows[row][2].ToString().Replace(":", "");
            return new DayInfo(csv);

        }

        public void callbackSetTime(DayInfo output)
        {
            io.WriteToFile(output.getSubDirectory(), output.getFilename(), output.ToCSV());
            FulfillDataSource(today);
            if (output.getDayToString().Equals(today.getDayToString()))
            {
                this.today = output;
                updateInterface();
            }
        }

        private void lblLabel_TextChanged(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text.IndexOf('-') != -1)
                label.ForeColor = Color.Red;
            else
                label.ForeColor = Color.Black;
        }
    }
}
