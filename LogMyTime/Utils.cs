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
            bool negative = minutes < 0;
            if (negative)
                minutes *= -1;
            int h = minutes / 60;
            int m = minutes - (h * 60);
            return (negative ? "-" : "") + string.Format("{0:D2}:{1:D2}", h, m);
        }

        public static string SecondsToString(int seconds)
        {
            bool negative = seconds < 0;
            if (negative)
                seconds *= -1;
            int h = seconds / 3600;
            int m = ( seconds - (h * 3600) ) / 60;
            int s = seconds - (h * 3600) - (m * 60);
            return (negative ? "-" : "") + string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
        }

        public static string DatetimeToTime(DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }

        public static int getWorkingHours(DayInfo day)
        {
            int working = 0;
            if (day.getFirstActivity() != null)
            {
                working = (int)((DateTime)day.getLastActivity() - (DateTime)day.getFirstActivity()).TotalMinutes;
                ConfigSettings config = ConfigSettings.Instance();

                if (config.Subtract)
                {
                    if (config.SubtractCondition == -1)
                        working -= config.SubtractQuantity;
                    else if (config.SubtractCondition == 0)
                    {
                        if (((DateTime)day.getFirstActivity()).TimeOfDay.TotalHours < 12 && ((DateTime)day.getLastActivity()).TimeOfDay.TotalHours > 12)
                            working -= config.SubtractQuantity;
                    }
                    else
                    {
                        if (working > config.SubtractCondition)
                            working -= config.SubtractQuantity;
                    }
                }
            }
            return working;
        }

        public static int GetRawDiff(DayInfo day)
        {
            if (day.getFirstActivity() != null)
                return (int)((DateTime)day.getLastActivity() - (DateTime)day.getFirstActivity()).TotalMinutes;
            return 0;
        }
        // add/remove binary from Windows Startup list
        public static void SetWindowsRegistry(bool add)
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (add)
                path.SetValue("LogMyTime", "\"" + Application.ExecutablePath.ToString() + "\" --start-minimized");
            else
                if (path.GetValue("LogMyTime") != null)
                    path.DeleteValue("LogMyTime");
        }

        public static bool IsAtWindowsRegistry()
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return path.GetValue("LogMyTime") != null;
        }

    }

}
