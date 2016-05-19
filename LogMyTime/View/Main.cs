using LogMyTime.Model;
using LogMyTime.Presenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LogMyTime
{
    public partial class MainView : Form
    {
        public MainPresenter Presenter { get; set; }
        private bool canClose = false;
        private DataGridViewRow todayRow;

        public MainView()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        /* auxiliary funcs */
        public void Minimize()
        {
            WindowState = FormWindowState.Minimized;
        }

        public void Restore()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        public void ShowGoHome()
        {
            Form gohome = new Warn();
            gohome.WindowState = FormWindowState.Minimized;
            gohome.Show();
            gohome.WindowState = FormWindowState.Maximized;
        }

        public void ShowDateInputForm(DateTime datetime)
        {
            DateInputModel model = new DateInputModel();
            DateInputView view = new DateInputView(this);
            DateInputPresenter presenter = new DateInputPresenter(model, view);
            presenter.setContext(datetime);
            view.ShowDialog();
            if (model.HasChanged)
                Presenter.GridEntryHasChanged(model.Date);
        }

        /* setters/getters */
        public DayInfoRow WorkingHours
        {
            set
            {
                todayRow.Cells[0].Value = value.Day;
                todayRow.Cells[1].Value = value.Start;
                todayRow.Cells[2].Value = value.End;
                todayRow.Cells[3].Value = value.Difference;
                todayRow.Cells[4].Value = value.Net;
                todayRow.Cells[5].Value = value.Delta;
            }
        }

        public string TrayIcon
        {
            set
            {
                trayIcon.Text = value;
            }
            get
            {
                return trayIcon.Text;
            }
        }

        public int AverageStart
        {
            set
            {
                lblAvgStart.Text = Utils.SecondsToString(value);
            }
        }

        public int AverageEnd
        {
            set
            {
                lblAvgEnd.Text = Utils.SecondsToString(value);
            }
        }

        public int AverageDifference
        {
            set
            {
                lblAvgDiff.Text = Utils.MinutesToString(value);
            }
        }

        public int AverageNet
        {
            set
            {
                lblAvgNet.Text = Utils.MinutesToString(value);
            }
        }

        public int AverageDelta
        {
            set
            {
                lblAvgDelta.Text = Utils.MinutesToString(value);
            }
        }

        public int TotalNet
        {
            set
            {
                lblTotalNet.Text = Utils.MinutesToString(value);
            }
        }

        public int TotalDelta
        {
            set
            {
                lblTotalDelta.Text = Utils.MinutesToString(value);
            }
        }

        public List<DayInfoRow> DataSet
        {
            set
            {
                int c = ( gridReport.SelectedCells.Count > 0 ? gridReport.SelectedCells[0].ColumnIndex : 1 ),
                    r = (gridReport.SelectedCells.Count > 0 ? gridReport.SelectedCells[0].RowIndex : 0 );

                gridReport.DataSource = value;

                if (gridReport.RowCount > r && gridReport.Rows[r].Cells.Count > c)
                    gridReport.CurrentCell = gridReport.Rows[r].Cells[c];
            }
        }

        /* event funcs */
        private void frmMain_Load(object sender, EventArgs e)
        {
            gridToday.Rows.Add("dd/mm/yyyy", "00:00:00", "00:00:00", "00:00", "00:00", "00:00");
            todayRow = gridToday.Rows[0];
            Presenter.Load();
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

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
                Hide();
        }


        private void showApp_Click(object sender, EventArgs e)
        {
            Presenter.RequestRestore();
        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            canClose = true;
            Close();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            Presenter.RequestRestore();
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            Presenter.TickSecond();
        }

        private void timerMinute_Tick(object sender, EventArgs e)
        {
            Presenter.TickMinute();
        }

        private void monthYearPicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime m = (DateTime)monthYearPicker.Value;
            Presenter.OnChangeMonth(new DayInfo(m, m, m));
        }

        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurationModel model = new ConfigurationModel();
            ConfigurationView view = new ConfigurationView();
            ConfigurationPresenter presenter = new ConfigurationPresenter(model, view);
            view.ShowDialog(this);
            Presenter.ConfigurationChanged();
        }

        private void gridReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 6)
                if (e.Value.ToString().IndexOf('-') != -1)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
        }

        private void gridToday_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 5)
                if (e.Value.ToString().IndexOf('-') != -1)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkGreen;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
        }

        private void gridReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.ColumnIndex <= 3)
            {
                int c = e.ColumnIndex == 2 ? 0 : 1;
                Presenter.RequestDateEdit(e.RowIndex, c, false);
            }
        }

        private void gridToday_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 2)
            {
                int c = e.ColumnIndex == 1 ? 0 : 1;
                Presenter.RequestDateEdit(e.RowIndex, c, true);
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
