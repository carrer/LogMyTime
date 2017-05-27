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
            this.timerSecond = new System.Windows.Forms.Timer(this.components);
            this.timerMinute = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.popupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApp = new System.Windows.Forms.ToolStripMenuItem();
            this.timeSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeApp = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.timeSheetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblClock = new System.Windows.Forms.Label();
            this.imgRec = new System.Windows.Forms.PictureBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.popupMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRec)).BeginInit();
            this.pnlConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerSecond
            // 
            this.timerSecond.Interval = 1000;
            this.timerSecond.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // timerMinute
            // 
            this.timerMinute.Interval = 2000;
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
            this.timeSheetToolStripMenuItem,
            this.closeApp});
            this.popupMenu.Name = "contextMenuStrip1";
            this.popupMenu.Size = new System.Drawing.Size(134, 70);
            // 
            // showApp
            // 
            this.showApp.Name = "showApp";
            this.showApp.Size = new System.Drawing.Size(152, 22);
            this.showApp.Text = "Show";
            this.showApp.Click += new System.EventHandler(this.showApp_Click);
            // 
            // timeSheetToolStripMenuItem
            // 
            this.timeSheetToolStripMenuItem.Name = "timeSheetToolStripMenuItem";
            this.timeSheetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.timeSheetToolStripMenuItem.Text = "Time Sheet";
            this.timeSheetToolStripMenuItem.Click += new System.EventHandler(this.timeSheetToolStripMenuItem_Click);
            // 
            // closeApp
            // 
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(152, 22);
            this.closeApp.Text = "Close";
            this.closeApp.Click += new System.EventHandler(this.closeApp_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeSheetToolStripMenuItem1,
            this.ConfigMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(227, 24);
            this.mainMenu.TabIndex = 21;
            this.mainMenu.Text = "menuStrip1";
            // 
            // timeSheetToolStripMenuItem1
            // 
            this.timeSheetToolStripMenuItem1.Name = "timeSheetToolStripMenuItem1";
            this.timeSheetToolStripMenuItem1.Size = new System.Drawing.Size(78, 20);
            this.timeSheetToolStripMenuItem1.Text = "Time Sheet";
            this.timeSheetToolStripMenuItem1.Click += new System.EventHandler(this.timeSheetToolStripMenuItem_Click);
            // 
            // ConfigMenuItem
            // 
            this.ConfigMenuItem.Name = "ConfigMenuItem";
            this.ConfigMenuItem.Size = new System.Drawing.Size(55, 20);
            this.ConfigMenuItem.Text = "Config";
            this.ConfigMenuItem.Click += new System.EventHandler(this.ConfigMenuItem_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Calibri", 36F);
            this.lblClock.ForeColor = System.Drawing.Color.Black;
            this.lblClock.Location = new System.Drawing.Point(88, 37);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(130, 68);
            this.lblClock.TabIndex = 24;
            this.lblClock.Text = "00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClock.UseCompatibleTextRendering = true;
            // 
            // imgRec
            // 
            this.imgRec.Image = global::LogMyTime.Properties.Resources.rec;
            this.imgRec.Location = new System.Drawing.Point(206, 27);
            this.imgRec.Name = "imgRec";
            this.imgRec.Size = new System.Drawing.Size(12, 12);
            this.imgRec.TabIndex = 23;
            this.imgRec.TabStop = false;
            this.imgRec.Visible = false;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Image = global::LogMyTime.Properties.Resources.Play;
            this.btnStartStop.Location = new System.Drawing.Point(12, 27);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(70, 70);
            this.btnStartStop.TabIndex = 22;
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // pnlConfig
            // 
            this.pnlConfig.AutoSize = true;
            this.pnlConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfig.Controls.Add(this.cbAutoStart);
            this.pnlConfig.Controls.Add(this.cbStartWithWindows);
            this.pnlConfig.Location = new System.Drawing.Point(12, 108);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(206, 58);
            this.pnlConfig.TabIndex = 25;
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbAutoStart.Location = new System.Drawing.Point(13, 32);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(131, 21);
            this.cbAutoStart.TabIndex = 1;
            this.cbAutoStart.Text = "Auto start counter";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            this.cbAutoStart.Click += new System.EventHandler(this.cbAutoStart_Click);
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbStartWithWindows.Location = new System.Drawing.Point(13, 5);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(149, 21);
            this.cbStartWithWindows.TabIndex = 0;
            this.cbStartWithWindows.Text = "Launch with Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            this.cbStartWithWindows.Click += new System.EventHandler(this.cbStartWithWindows_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 176);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.imgRec);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.lblClock);
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
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgRec)).EndInit();
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
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
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem ConfigMenuItem;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.PictureBox imgRec;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.ToolStripMenuItem timeSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeSheetToolStripMenuItem1;
    }
}

