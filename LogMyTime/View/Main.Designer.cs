using System;

namespace LogMyTime
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timerSecond = new System.Windows.Forms.Timer(this.components);
            this.timerMinute = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.popupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApp = new System.Windows.Forms.ToolStripMenuItem();
            this.closeApp = new System.Windows.Forms.ToolStripMenuItem();
            this.gridReport = new System.Windows.Forms.DataGridView();
            this.clipboardMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthYearPicker = new System.Windows.Forms.DateTimePicker();
            this.lblHistoricalDataCaption = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToday = new System.Windows.Forms.DataGridView();
            this.clDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAvg = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAvgStart = new System.Windows.Forms.Label();
            this.lblAvgEnd = new System.Windows.Forms.Label();
            this.lblAvgDiff = new System.Windows.Forms.Label();
            this.lblAvgNet = new System.Windows.Forms.Label();
            this.lblAvgDelta = new System.Windows.Forms.Label();
            this.lblTotalNet = new System.Windows.Forms.Label();
            this.lblTotalDelta = new System.Windows.Forms.Label();
            this.clMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDayReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStartReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEndReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiffReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNetReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDeltaReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.popupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.clipboardMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridToday)).BeginInit();
            this.SuspendLayout();
            // 
            // timerSecond
            // 
            this.timerSecond.Enabled = true;
            this.timerSecond.Interval = 1000;
            this.timerSecond.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // timerMinute
            // 
            this.timerMinute.Enabled = true;
            this.timerMinute.Interval = 60000;
            this.timerMinute.Tick += new System.EventHandler(this.timerMinute_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipTitle = "LogMyTime";
            this.trayIcon.ContextMenuStrip = this.popupMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "LogMyTime";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // popupMenu
            // 
            this.popupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApp,
            this.closeApp});
            this.popupMenu.Name = "contextMenuStrip1";
            this.popupMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // showApp
            // 
            this.showApp.Name = "showApp";
            this.showApp.Size = new System.Drawing.Size(103, 22);
            this.showApp.Text = "Show";
            this.showApp.Click += new System.EventHandler(this.showApp_Click);
            // 
            // closeApp
            // 
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(103, 22);
            this.closeApp.Text = "Close";
            this.closeApp.Click += new System.EventHandler(this.closeApp_Click);
            // 
            // gridReport
            // 
            this.gridReport.AllowUserToAddRows = false;
            this.gridReport.AllowUserToDeleteRows = false;
            this.gridReport.AllowUserToResizeColumns = false;
            this.gridReport.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMonth,
            this.clDayReport,
            this.clStartReport,
            this.clEndReport,
            this.clDiffReport,
            this.clNetReport,
            this.clDeltaReport});
            this.gridReport.ContextMenuStrip = this.clipboardMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridReport.Location = new System.Drawing.Point(12, 121);
            this.gridReport.MultiSelect = false;
            this.gridReport.Name = "gridReport";
            this.gridReport.ReadOnly = true;
            this.gridReport.RowHeadersVisible = false;
            this.gridReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridReport.Size = new System.Drawing.Size(535, 196);
            this.gridReport.TabIndex = 15;
            this.gridReport.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridReport_CellDoubleClick);
            this.gridReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridReport_CellFormatting);
            this.gridReport.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridReport_KeyUp);
            // 
            // clipboardMenu
            // 
            this.clipboardMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCellToolStripMenuItem,
            this.copyRowToolStripMenuItem,
            this.copyTableToolStripMenuItem});
            this.clipboardMenu.Name = "clipboardMenu";
            this.clipboardMenu.Size = new System.Drawing.Size(134, 70);
            // 
            // copyCellToolStripMenuItem
            // 
            this.copyCellToolStripMenuItem.Name = "copyCellToolStripMenuItem";
            this.copyCellToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyCellToolStripMenuItem.Text = "Copy Cell";
            this.copyCellToolStripMenuItem.Click += new System.EventHandler(this.copyCellToolStripMenuItem_Click);
            // 
            // copyRowToolStripMenuItem
            // 
            this.copyRowToolStripMenuItem.Name = "copyRowToolStripMenuItem";
            this.copyRowToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyRowToolStripMenuItem.Text = "Copy Row";
            this.copyRowToolStripMenuItem.Click += new System.EventHandler(this.copyRowToolStripMenuItem_Click);
            // 
            // copyTableToolStripMenuItem
            // 
            this.copyTableToolStripMenuItem.Name = "copyTableToolStripMenuItem";
            this.copyTableToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyTableToolStripMenuItem.Text = "Copy Table";
            this.copyTableToolStripMenuItem.Click += new System.EventHandler(this.copyTableToolStripMenuItem_Click);
            // 
            // monthYearPicker
            // 
            this.monthYearPicker.CustomFormat = "MM/yyyy";
            this.monthYearPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthYearPicker.Location = new System.Drawing.Point(108, 95);
            this.monthYearPicker.Name = "monthYearPicker";
            this.monthYearPicker.Size = new System.Drawing.Size(125, 24);
            this.monthYearPicker.TabIndex = 13;
            this.monthYearPicker.ValueChanged += new System.EventHandler(this.monthYearPicker_ValueChanged);
            // 
            // lblHistoricalDataCaption
            // 
            this.lblHistoricalDataCaption.AutoSize = true;
            this.lblHistoricalDataCaption.Location = new System.Drawing.Point(12, 98);
            this.lblHistoricalDataCaption.Name = "lblHistoricalDataCaption";
            this.lblHistoricalDataCaption.Size = new System.Drawing.Size(92, 17);
            this.lblHistoricalDataCaption.TabIndex = 16;
            this.lblHistoricalDataCaption.Text = "Historical Data";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(559, 24);
            this.mainMenu.TabIndex = 21;
            this.mainMenu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem1_Click);
            // 
            // gridToday
            // 
            this.gridToday.AllowUserToAddRows = false;
            this.gridToday.AllowUserToDeleteRows = false;
            this.gridToday.AllowUserToResizeColumns = false;
            this.gridToday.AllowUserToResizeRows = false;
            this.gridToday.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridToday.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridToday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDay,
            this.clStart,
            this.clEnd,
            this.clDiff,
            this.clNet,
            this.clDelta});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridToday.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridToday.Location = new System.Drawing.Point(12, 27);
            this.gridToday.MultiSelect = false;
            this.gridToday.Name = "gridToday";
            this.gridToday.ReadOnly = true;
            this.gridToday.RowHeadersVisible = false;
            this.gridToday.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridToday.RowTemplate.ReadOnly = true;
            this.gridToday.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridToday.Size = new System.Drawing.Size(535, 48);
            this.gridToday.TabIndex = 24;
            this.gridToday.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridToday_CellDoubleClick);
            this.gridToday.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridToday_CellFormatting);
            // 
            // clDay
            // 
            this.clDay.HeaderText = "Today";
            this.clDay.Name = "clDay";
            this.clDay.ReadOnly = true;
            this.clDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDay.Width = 82;
            // 
            // clStart
            // 
            this.clStart.HeaderText = "Start";
            this.clStart.Name = "clStart";
            this.clStart.ReadOnly = true;
            this.clStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clEnd
            // 
            this.clEnd.HeaderText = "End";
            this.clEnd.Name = "clEnd";
            this.clEnd.ReadOnly = true;
            this.clEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clDiff
            // 
            this.clDiff.HeaderText = "Diff";
            this.clDiff.Name = "clDiff";
            this.clDiff.ReadOnly = true;
            this.clDiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clNet
            // 
            this.clNet.HeaderText = "Net";
            this.clNet.Name = "clNet";
            this.clNet.ReadOnly = true;
            this.clNet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clNet.Width = 75;
            // 
            // clDelta
            // 
            this.clDelta.HeaderText = "Delta";
            this.clDelta.Name = "clDelta";
            this.clDelta.ReadOnly = true;
            this.clDelta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDelta.Width = 75;
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.Location = new System.Drawing.Point(12, 320);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(55, 17);
            this.lblAvg.TabIndex = 25;
            this.lblAvg.Text = "Average";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 343);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 17);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(12, 340);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 1);
            this.panel1.TabIndex = 27;
            // 
            // lblAvgStart
            // 
            this.lblAvgStart.AutoSize = true;
            this.lblAvgStart.Location = new System.Drawing.Point(95, 320);
            this.lblAvgStart.Name = "lblAvgStart";
            this.lblAvgStart.Size = new System.Drawing.Size(58, 17);
            this.lblAvgStart.TabIndex = 28;
            this.lblAvgStart.Text = "00:00:00";
            this.lblAvgStart.TextChanged += new System.EventHandler(this.lblLabel_TextChanged);
            // 
            // lblAvgEnd
            // 
            this.lblAvgEnd.AutoSize = true;
            this.lblAvgEnd.Location = new System.Drawing.Point(194, 320);
            this.lblAvgEnd.Name = "lblAvgEnd";
            this.lblAvgEnd.Size = new System.Drawing.Size(58, 17);
            this.lblAvgEnd.TabIndex = 29;
            this.lblAvgEnd.Text = "00:00:00";
            this.lblAvgEnd.TextChanged += new System.EventHandler(this.lblLabel_TextChanged);
            // 
            // lblAvgDiff
            // 
            this.lblAvgDiff.AutoSize = true;
            this.lblAvgDiff.Location = new System.Drawing.Point(303, 320);
            this.lblAvgDiff.Name = "lblAvgDiff";
            this.lblAvgDiff.Size = new System.Drawing.Size(40, 17);
            this.lblAvgDiff.TabIndex = 31;
            this.lblAvgDiff.Text = "00:00";
            this.lblAvgDiff.TextChanged += new System.EventHandler(this.lblLabel_TextChanged);
            // 
            // lblAvgNet
            // 
            this.lblAvgNet.AutoSize = true;
            this.lblAvgNet.Location = new System.Drawing.Point(392, 320);
            this.lblAvgNet.Name = "lblAvgNet";
            this.lblAvgNet.Size = new System.Drawing.Size(40, 17);
            this.lblAvgNet.TabIndex = 32;
            this.lblAvgNet.Text = "00:00";
            this.lblAvgNet.TextChanged += new System.EventHandler(this.lblLabel_TextChanged);
            // 
            // lblAvgDelta
            // 
            this.lblAvgDelta.AutoSize = true;
            this.lblAvgDelta.Location = new System.Drawing.Point(467, 320);
            this.lblAvgDelta.Name = "lblAvgDelta";
            this.lblAvgDelta.Size = new System.Drawing.Size(40, 17);
            this.lblAvgDelta.TabIndex = 33;
            this.lblAvgDelta.Text = "00:00";
            this.lblAvgDelta.TextChanged += new System.EventHandler(this.lblLabel_TextChanged);
            // 
            // lblTotalNet
            // 
            this.lblTotalNet.AutoSize = true;
            this.lblTotalNet.Location = new System.Drawing.Point(392, 343);
            this.lblTotalNet.Name = "lblTotalNet";
            this.lblTotalNet.Size = new System.Drawing.Size(40, 17);
            this.lblTotalNet.TabIndex = 34;
            this.lblTotalNet.Text = "00:00";
            this.lblTotalNet.TextChanged += new System.EventHandler(this.lblLabel_TextChanged);
            // 
            // lblTotalDelta
            // 
            this.lblTotalDelta.AutoSize = true;
            this.lblTotalDelta.Location = new System.Drawing.Point(467, 343);
            this.lblTotalDelta.Name = "lblTotalDelta";
            this.lblTotalDelta.Size = new System.Drawing.Size(40, 17);
            this.lblTotalDelta.TabIndex = 35;
            this.lblTotalDelta.Text = "00:00";
            this.lblTotalDelta.TextChanged += new System.EventHandler(this.lblLabel_TextChanged);
            // 
            // clMonth
            // 
            this.clMonth.DataPropertyName = "Month";
            this.clMonth.HeaderText = "Month";
            this.clMonth.Name = "clMonth";
            this.clMonth.ReadOnly = true;
            this.clMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clMonth.Visible = false;
            // 
            // clDayReport
            // 
            this.clDayReport.DataPropertyName = "Day";
            this.clDayReport.HeaderText = "Day";
            this.clDayReport.Name = "clDayReport";
            this.clDayReport.ReadOnly = true;
            this.clDayReport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDayReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDayReport.Width = 60;
            // 
            // clStartReport
            // 
            this.clStartReport.DataPropertyName = "Start";
            this.clStartReport.HeaderText = "Start";
            this.clStartReport.Name = "clStartReport";
            this.clStartReport.ReadOnly = true;
            this.clStartReport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clStartReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clEndReport
            // 
            this.clEndReport.DataPropertyName = "End";
            this.clEndReport.HeaderText = "End";
            this.clEndReport.Name = "clEndReport";
            this.clEndReport.ReadOnly = true;
            this.clEndReport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clEndReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clDiffReport
            // 
            this.clDiffReport.DataPropertyName = "Difference";
            this.clDiffReport.HeaderText = "Diff";
            this.clDiffReport.Name = "clDiffReport";
            this.clDiffReport.ReadOnly = true;
            this.clDiffReport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDiffReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clNetReport
            // 
            this.clNetReport.DataPropertyName = "Net";
            this.clNetReport.HeaderText = "Net";
            this.clNetReport.Name = "clNetReport";
            this.clNetReport.ReadOnly = true;
            this.clNetReport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNetReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clNetReport.Width = 75;
            // 
            // clDeltaReport
            // 
            this.clDeltaReport.DataPropertyName = "Delta";
            this.clDeltaReport.HeaderText = "Delta";
            this.clDeltaReport.Name = "clDeltaReport";
            this.clDeltaReport.ReadOnly = true;
            this.clDeltaReport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDeltaReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clDeltaReport.Width = 75;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 368);
            this.Controls.Add(this.lblTotalDelta);
            this.Controls.Add(this.lblTotalNet);
            this.Controls.Add(this.lblAvgDelta);
            this.Controls.Add(this.lblAvgNet);
            this.Controls.Add(this.lblAvgDiff);
            this.Controls.Add(this.lblAvgEnd);
            this.Controls.Add(this.lblAvgStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblAvg);
            this.Controls.Add(this.gridToday);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.lblHistoricalDataCaption);
            this.Controls.Add(this.gridReport);
            this.Controls.Add(this.monthYearPicker);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogMyTime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.popupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            this.clipboardMenu.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridToday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerSecond;
        private System.Windows.Forms.Timer timerMinute;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip popupMenu;
        private System.Windows.Forms.ToolStripMenuItem closeApp;
        private System.Windows.Forms.ToolStripMenuItem showApp;
        private System.Windows.Forms.DataGridView gridReport;
        private System.Windows.Forms.DateTimePicker monthYearPicker;
        private System.Windows.Forms.Label lblHistoricalDataCaption;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.DataGridView gridToday;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDelta;
        private System.Windows.Forms.Label lblAvgStart;
        private System.Windows.Forms.Label lblAvgEnd;
        private System.Windows.Forms.Label lblAvgDiff;
        private System.Windows.Forms.Label lblAvgNet;
        private System.Windows.Forms.Label lblAvgDelta;
        private System.Windows.Forms.Label lblTotalNet;
        private System.Windows.Forms.Label lblTotalDelta;
        private System.Windows.Forms.ContextMenuStrip clipboardMenu;
        private System.Windows.Forms.ToolStripMenuItem copyRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTableToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDayReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStartReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEndReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiffReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNetReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDeltaReport;
    }
}

