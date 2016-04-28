using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LogMyTime
{
    public partial class frmMain : Form
    {
        protected bool initializeMinimized;
        protected bool canClose = false;
        protected DayInfo today;
        protected FileHandler io = new FileHandler();
        protected DataTable dataset;

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
            if (initializeMinimized)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                initializeMinimized = false; // prevent from hiding the form onShow again
            }

            today = new DayInfo();
            string line = io.ReadFromFile(today.getSubDirectory(), today.getFilename());
            today = line.Length > 0 ? new DayInfo(line) : new DayInfo();
            today.tick();
            persistData();
            UpdateWorkingHours();
            FulfillDataSource(today);
            UpdateTrayHint();
            lblStartTime.Text = today.getFirstActivity() != null ? Utils.DatetimeToTime((DateTime)today.getFirstActivity()) : "(missing)";
            timerSecond.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            monthYearPicker.Format = DateTimePickerFormat.Custom;
            monthYearPicker.CustomFormat = "MM/yyyy";
            dataset = new DataTable();
            dataset.Columns.Add("Day", typeof(int));
            dataset.Columns.Add("Started", typeof(String));
            dataset.Columns.Add("End", typeof(String));
            dataset.Columns.Add("Total", typeof(String));
            reportGrid.DataSource = dataset;
            reportGrid.Columns[0].Width = 70;
            startup.Checked = Utils.IsAtWindowsRegistry();
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

        private void startup_Click(object sender, EventArgs e)
        {
            startup.Checked = !startup.Checked;
            Utils.SetWindowsRegistry(startup.Checked);
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
        }

        private void timerMinute_Tick(object sender, EventArgs e)
        {
            if (Utils.GetIdleTime() < 60000) // If I'm idle for more than a minute, don't update counter
            {
                today.tick();
                persistData();
                UpdateTrayHint();

                if (Visible)
                    UpdateWorkingHours();
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
        }

        private void UpdateTrayHint()
        {
            trayIcon.Text = "Today you worked " + Utils.getWorkingHours(today);
        }

        private void UpdateWorkingHours()
        {
            lblWorkingHours.Text = Utils.getWorkingHours(today);
        }

        private void persistData()
        {
            io.WriteToFile(today.getSubDirectory(), today.getFilename(), today.ToCSV());
        }

        private void FulfillDataSource(DayInfo month)
        {
            int timeTotal = 0;
            dataset.Rows.Clear();
            List<string> files = io.ListAllFiles(month.getSubDirectory());
            foreach (string filename in files.OrderByDescending(o => o).ToList())
            {
                DayInfo day = new DayInfo(io.ReadFromFile(month.getSubDirectory(), filename));
                DateTime first = (DateTime)day.getFirstActivity();
                DateTime last = (DateTime)day.getLastActivity();
                int working = (int)(last - first).TotalMinutes;
                timeTotal += working;
                dataset.Rows.Add(first.Day, Utils.DatetimeToTime(first), Utils.DatetimeToTime(last), Utils.MinutesToString(working));
            }

            int avgTime = files.Count() > 0 ? timeTotal / files.Count() : 0;
            lblAvgTime.Text = Utils.MinutesToString(avgTime);
            lblTotalTime.Text = Utils.MinutesToString(timeTotal);
        }

    }
}
