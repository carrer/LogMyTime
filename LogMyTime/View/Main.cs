using LogMyTime.Model;
using LogMyTime.Presenter;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LogMyTime
{
    public partial class MainView : Form
    {
        public MainPresenter Presenter { get; set; }
        private bool canClose = false;
        private bool firstTimeClosing = true;
        private PrivateFontCollection fontCollection = new PrivateFontCollection();

        public MainView()
        {
            InitializeComponent();
            MaximizeBox = false;

            int fontLength = Properties.Resources.Digital.Length;
            byte[] fontdata = Properties.Resources.Digital;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            fontCollection.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);
            lblClock.Font = new Font(fontCollection.Families[0], lblClock.Font.Size);
            timerMinute.Interval = TimeCard.TIMECARD_LENGTH * 1000;
            Height = 135;
            cbStartWithWindows.Checked = Utils.IsAtWindowsRegistry();
            cbAutoStart.Checked = Utils.AutoStartCounter();

            bool hasManager = File.Exists("calendar.exe");
            timeSheetToolStripMenuItem.Visible = hasManager;
            timeSheetToolStripMenuItem1.Visible = hasManager;
        }

        public void SetPresenter(MainPresenter presenter)
        {
            Presenter = presenter;
            if (cbAutoStart.Checked)
                Presenter.Toogle();
        }

        /* auxiliary funcs */
        public void Minimize()
        {
            firstTimeClosing = false;
            WindowState = FormWindowState.Minimized;
        }

        public void Restore()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        public void Start()
        {
            timerSecond.Start();
            timerMinute.Start();
            btnStartStop.Image = LogMyTime.Properties.Resources.Stop;
            imgRec.Visible = true;
        }

        public void Stop()
        {
            timerSecond.Stop();
            timerMinute.Stop();
            btnStartStop.Image = LogMyTime.Properties.Resources.Play;
            imgRec.Visible = false;
        }

        public void SetTime(string time)
        {
            lblClock.Text = time;
            trayIcon.Text = time;
        }

        /* event funcs */
        private void frmMain_Load(object sender, EventArgs e)
        {
            Presenter.Load();
        }

        private void toogleRec()
        {
            imgRec.Visible = !imgRec.Visible;
        }

        // Prevent from closing the form and exiting the app
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
                if (firstTimeClosing)
                {
                    trayIcon.ShowBalloonTip(1000, "Hey!", "I'm still running", ToolTipIcon.None);
                    firstTimeClosing = false;
                }
                Hide();
            }
            else
                trayIcon.Visible = false;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                Hide();
                firstTimeClosing = false;
            }
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
            toogleRec();
            Presenter.TickSecond();
        }

        private void timerMinute_Tick(object sender, EventArgs e)
        {
            Presenter.TickMinute();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            Presenter.Toogle();
        }

        private void ConfigMenuItem_Click(object sender, EventArgs e)
        {
            Height = Height == 205 ? 135 : 205;
        }

        private void cbStartWithWindows_Click(object sender, EventArgs e)
        {
            Utils.SetWindowsRegistry(!Utils.IsAtWindowsRegistry());
        }

        private void cbAutoStart_Click(object sender, EventArgs e)
        {
            Utils.SetAutoStartCounter(!Utils.AutoStartCounter());
        }

        private void timeSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("manager.exe");
        }
    }
}
