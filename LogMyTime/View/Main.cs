﻿using LogMyTime.Model;
using LogMyTime.Presenter;
using LogMyTime.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            DateInputView view = new DateInputView();
            DateInputPresenter presenter = new DateInputPresenter(model, view);
            presenter.setContext(datetime);
            view.ShowDialog();
            if (model.HasChanged)
                Presenter.GridEntryHasChanged(model.Date);
        }

        public void ShowComment(DayInfoRow row)
        {
            CommentModel model = new CommentModel();
            model.Comment = row.Comment;
            CommentView view = new CommentView();
            CommentPresenter presenter = new CommentPresenter(model, view);
            view.ShowDialog();
            if (model.HasChanged)
                Presenter.GridCommentEntryHasChanged(model.Comment);
        }

        /* setters/getters */
        public DayInfoRow WorkingHours
        {
            set
            {
                todayRow.Cells[0].Value = value.Day;
                todayRow.Cells[1].Value = value.Weekday;
                todayRow.Cells[2].Value = value.Start;
                todayRow.Cells[3].Value = value.End;
                todayRow.Cells[4].Value = value.Difference;
                todayRow.Cells[5].Value = value.Net;
                todayRow.Cells[6].Value = value.Delta;
                todayRow.Cells[7].Value = value.ExpectedEnd;
                todayRow.Cells[8].Value = value.Comment;
                gridToday.Refresh();
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
            get
            {
                return (List<DayInfoRow>) gridReport.DataSource;
            }
        }

        /* event funcs */
        private void frmMain_Load(object sender, EventArgs e)
        {
            gridToday.Rows.Add("dd/mm/yyyy", "00:00:00", "00:00:00", "00:00", "00:00", "00:00", "", "");
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

        public void ShowNewDay(string v)
        {
            DayModel model = new DayModel();
            model.SetMonth(v);
            DayView view = new DayView();
            DayPresenter presenter = new DayPresenter(model, view);
            view.ShowDialog();
            if (model.HasAdded)
                Presenter.GridEntryAdded();

        }

        public bool RequestConfirmation()
        {
            return MessageBox.Show("This operation can't be undone. Are you sure you want to proceed?",
            "Delete record",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
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
            if (e.Value != null)
            {
                if (e.ColumnIndex == 7)
                {
                    if (e.Value.ToString().IndexOf('-') != -1)
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = Color.DarkRed;
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    else if (e.Value.ToString().IndexOf('•') != -1)
                    {
                        e.CellStyle.BackColor = Color.MediumSeaGreen;
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionBackColor = Color.SeaGreen;
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
            }

        }

        private void gridToday_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 6)
            {
                if (e.Value.ToString().IndexOf('-') != -1)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else if (e.Value.ToString().IndexOf('•') != -1)
                {
                    e.CellStyle.BackColor = Color.MediumSeaGreen;
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.SelectionBackColor = Color.SeaGreen;
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
            else if (e.Value != null && e.ColumnIndex == 7)
            {
                e.CellStyle.BackColor = Color.Khaki;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.SelectionBackColor = Color.Goldenrod;
                e.CellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void gridReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 3 && e.ColumnIndex <= 4)
            {
                int c = e.ColumnIndex == 3 ? 0 : 1;
                Presenter.RequestDateEdit(e.RowIndex, c, false);
            }
        }

        private void gridToday_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.ColumnIndex <= 3)
            {
                int c = e.ColumnIndex == 2 ? 0 : 1;
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

        private void gridReport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (gridReport.Rows[e.RowIndex].Cells[8].Value.ToString().Length>0)
            {
                using (SolidBrush b = new SolidBrush(gridReport.RowHeadersDefaultCellStyle.ForeColor))
                {
                    b.Color = Color.Red;
                    e.Graphics.DrawString("•", e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
                }
                gridReport.Rows[e.RowIndex].HeaderCell.ToolTipText = gridReport.Rows[e.RowIndex].Cells[8].Value.ToString();
            }

        }

        private void gridReport_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int currentColumn = gridReport.CurrentCell.ColumnIndex;
            gridReport.CurrentCell = gridReport.Rows[e.RowIndex].Cells[1];
        }

        private void gridReport_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Presenter.RequestCommentEdit(e.RowIndex);
        }

        private void gridToday_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Presenter.RequestTodayCommentEdit();
        }


        private void copyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridReport.SelectedCells.Count > 0)
                Presenter.CopyToClipboard(-1, gridReport.SelectedCells[0].RowIndex);
        }

        private void copyCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridReport.SelectedCells.Count > 0)
                Presenter.CopyToClipboard(gridReport.SelectedCells[0].ColumnIndex, gridReport.SelectedCells[0].RowIndex);
        }

        private void copyTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.CopyToClipboard(-1, -1);
        }
 

        private void gridReport_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.C | Keys.Control))
            {
                if (gridReport.SelectedCells.Count > 0)
                    Presenter.CopyToClipboard(gridReport.SelectedCells[0].ColumnIndex, gridReport.SelectedCells[0].RowIndex);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete)
            {
                Presenter.RequestDelete(gridReport.SelectedCells[0].RowIndex);
            }
        }

        private void gridReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
            {
                Font bold = new Font(gridReport.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                e.Graphics.DrawString("+", bold, new SolidBrush(gridReport.ColumnHeadersDefaultCellStyle.ForeColor), e.CellBounds.Location.X + 15, e.CellBounds.Location.Y + 4);
                e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background));
                e.Handled = true;
            }
        }

        private void gridReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex == -1)
            {
                Presenter.RequestAddDay();
            }
        }

        private void gridReport_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            gridReport.Rows[e.RowIndex].Cells[1].Selected = true;
        }

        private void deleteEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.RequestDelete(gridReport.SelectedCells[0].RowIndex);
        }
    }
}
