using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;

namespace LogMyTime
{
    internal struct LASTINPUTINFO
    {
        public uint cbSize;

        public uint dwTime;
    }

    public class Utils
    {
        // taken from http://stackoverflow.com/questions/10977149/getlastinput-and-tickcount

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }

        public static long GetLastInputTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }
            return lastInPut.dwTime;
        }

        public static string MinutesToString(int minutes)
        {
            int h = minutes / 60;
            int m = minutes - (h * 60);
            if (m < 0)
                m *= -1;
            return string.Format("{0:D2}:{1:D2}", h, m);
        }

        public static string DatetimeToTime(DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }

        public static string getWorkingHours(DayInfo day)
        {
            if (day.getFirstActivity() != null)
                return MinutesToString((int) ((DateTime)day.getLastActivity() - (DateTime)day.getFirstActivity()).TotalMinutes);
            else
                return MinutesToString(0);
        }

        // add/remove binary from Windows Startup list
        public static void SetWindowsRegistry(bool add)
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (add)
                path.SetValue("LogMyTime", "\"" + Application.ExecutablePath.ToString() + "\" --start-minimized");
            else
                path.DeleteValue("LogMyTime");
        }

        public static bool IsAtWindowsRegistry()
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return path.GetValue("LogMyTime") != null;
        }

    }

}
