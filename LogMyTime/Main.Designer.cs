namespace LogMyTime
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTodayCaption = new System.Windows.Forms.Label();
            this.lblWorkingHoursCaption = new System.Windows.Forms.Label();
            this.timerSecond = new System.Windows.Forms.Timer(this.components);
            this.timerMinute = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.popupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApp = new System.Windows.Forms.ToolStripMenuItem();
            this.closeApp = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblWorkingHours = new System.Windows.Forms.Label();
            this.reportGrid = new System.Windows.Forms.DataGridView();
            this.monthYearPicker = new System.Windows.Forms.DateTimePicker();
            this.lblHistoricalDataCaption = new System.Windows.Forms.Label();
            this.lblAvgCaption = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblAvgTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLeftCaption = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.popupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTodayCaption
            // 
            this.lblTodayCaption.AutoSize = true;
            this.lblTodayCaption.Location = new System.Drawing.Point(9, 29);
            this.lblTodayCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodayCaption.Name = "lblTodayCaption";
            this.lblTodayCaption.Size = new System.Drawing.Size(126, 17);
            this.lblTodayCaption.TabIndex = 1;
            this.lblTodayCaption.Text = "You started today at:";
            this.lblTodayCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkingHoursCaption
            // 
            this.lblWorkingHoursCaption.AutoSize = true;
            this.lblWorkingHoursCaption.Location = new System.Drawing.Point(250, 29);
            this.lblWorkingHoursCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkingHoursCaption.Name = "lblWorkingHoursCaption";
            this.lblWorkingHoursCaption.Size = new System.Drawing.Size(120, 17);
            this.lblWorkingHoursCaption.TabIndex = 2;
            this.lblWorkingHoursCaption.Text = "Time worked today:";
            this.lblWorkingHoursCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerSecond
            // 
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
            this.popupMenu.Size = new System.Drawing.Size(127, 48);
            // 
            // showApp
            // 
            this.showApp.Name = "showApp";
            this.showApp.Size = new System.Drawing.Size(126, 22);
            this.showApp.Text = "Show app";
            this.showApp.Click += new System.EventHandler(this.showApp_Click);
            // 
            // closeApp
            // 
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(126, 22);
            this.closeApp.Text = "Close app";
            this.closeApp.Click += new System.EventHandler(this.closeApp_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(143, 29);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(58, 17);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "00:00:00";
            // 
            // lblWorkingHours
            // 
            this.lblWorkingHours.AutoSize = true;
            this.lblWorkingHours.Location = new System.Drawing.Point(377, 29);
            this.lblWorkingHours.Name = "lblWorkingHours";
            this.lblWorkingHours.Size = new System.Drawing.Size(40, 17);
            this.lblWorkingHours.TabIndex = 5;
            this.lblWorkingHours.Text = "00:00";
            // 
            // reportGrid
            // 
            this.reportGrid.AllowUserToAddRows = false;
            this.reportGrid.AllowUserToDeleteRows = false;
            this.reportGrid.AllowUserToResizeColumns = false;
            this.reportGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.reportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.reportGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.reportGrid.Location = new System.Drawing.Point(12, 80);
            this.reportGrid.MultiSelect = false;
            this.reportGrid.Name = "reportGrid";
            this.reportGrid.ReadOnly = true;
            this.reportGrid.RowHeadersVisible = false;
            this.reportGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportGrid.Size = new System.Drawing.Size(535, 196);
            this.reportGrid.TabIndex = 15;
            this.reportGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.reportGrid_CellFormatting);
            // 
            // monthYearPicker
            // 
            this.monthYearPicker.Location = new System.Drawing.Point(108, 54);
            this.monthYearPicker.Name = "monthYearPicker";
            this.monthYearPicker.Size = new System.Drawing.Size(125, 24);
            this.monthYearPicker.TabIndex = 13;
            this.monthYearPicker.ValueChanged += new System.EventHandler(this.monthYearPicker_ValueChanged);
            // 
            // lblHistoricalDataCaption
            // 
            this.lblHistoricalDataCaption.AutoSize = true;
            this.lblHistoricalDataCaption.Location = new System.Drawing.Point(12, 57);
            this.lblHistoricalDataCaption.Name = "lblHistoricalDataCaption";
            this.lblHistoricalDataCaption.Size = new System.Drawing.Size(92, 17);
            this.lblHistoricalDataCaption.TabIndex = 16;
            this.lblHistoricalDataCaption.Text = "Historical Data";
            // 
            // lblAvgCaption
            // 
            this.lblAvgCaption.AutoSize = true;
            this.lblAvgCaption.Location = new System.Drawing.Point(12, 280);
            this.lblAvgCaption.Name = "lblAvgCaption";
            this.lblAvgCaption.Size = new System.Drawing.Size(178, 17);
            this.lblAvgCaption.TabIndex = 17;
            this.lblAvgCaption.Text = "Average time worked per day:";
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Location = new System.Drawing.Point(309, 280);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(177, 17);
            this.lblTotalCaption.TabIndex = 18;
            this.lblTotalCaption.Text = "Total time worked this month:";
            // 
            // lblAvgTime
            // 
            this.lblAvgTime.AutoSize = true;
            this.lblAvgTime.Location = new System.Drawing.Point(196, 280);
            this.lblAvgTime.Name = "lblAvgTime";
            this.lblAvgTime.Size = new System.Drawing.Size(40, 17);
            this.lblAvgTime.TabIndex = 19;
            this.lblAvgTime.Text = "00:00";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(507, 280);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(40, 17);
            this.lblTotalTime.TabIndex = 20;
            this.lblTotalTime.Text = "00:00";
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
            // lblLeftCaption
            // 
            this.lblLeftCaption.AutoSize = true;
            this.lblLeftCaption.Location = new System.Drawing.Point(466, 29);
            this.lblLeftCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLeftCaption.Name = "lblLeftCaption";
            this.lblLeftCaption.Size = new System.Drawing.Size(34, 17);
            this.lblLeftCaption.TabIndex = 22;
            this.lblLeftCaption.Text = "Left:";
            this.lblLeftCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblLeft.Location = new System.Drawing.Point(507, 29);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(40, 17);
            this.lblLeft.TabIndex = 23;
            this.lblLeft.Text = "00:00";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 306);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.lblLeftCaption);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.lblAvgTime);
            this.Controls.Add(this.lblTotalCaption);
            this.Controls.Add(this.lblAvgCaption);
            this.Controls.Add(this.lblHistoricalDataCaption);
            this.Controls.Add(this.reportGrid);
            this.Controls.Add(this.monthYearPicker);
            this.Controls.Add(this.lblWorkingHours);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblWorkingHoursCaption);
            this.Controls.Add(this.lblTodayCaption);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogMyTime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.popupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTodayCaption;
        private System.Windows.Forms.Label lblWorkingHoursCaption;
        private System.Windows.Forms.Timer timerSecond;
        private System.Windows.Forms.Timer timerMinute;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip popupMenu;
        private System.Windows.Forms.ToolStripMenuItem closeApp;
        private System.Windows.Forms.ToolStripMenuItem showApp;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblWorkingHours;
        private System.Windows.Forms.DataGridView reportGrid;
        private System.Windows.Forms.DateTimePicker monthYearPicker;
        private System.Windows.Forms.Label lblHistoricalDataCaption;
        private System.Windows.Forms.Label lblAvgCaption;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblAvgTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.Label lblLeftCaption;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

