using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using LogMyTime.Model;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static ProgramInfo GetActiveProcess()
        {
            uint focused;
            GetWindowThreadProcessId(GetForegroundWindow(), out focused);
            Process active;
            try
            {
                active = Process.GetProcessById((int)focused);
                return new ProgramInfo(active.ProcessName, active.MainModule.FileName, active.MainWindowTitle);
            }
            catch (Exception)
            {
            }
            return null;
        }

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

        public static string GetToday()
        {
            return (new DateTime()).ToShortDateString();
        }

        public static DateTime StringToTime(string dt)
        {
            return DateTime.ParseExact(dt, "HH:mm:ss", CultureInfo.InvariantCulture);
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

        // add/remove binary from Windows Startup list
        public static void SetAutoStartCounter(bool add)
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey("SOFTWARE\\LogMyTime", true);
            if (path == null)
                path = Registry.CurrentUser.CreateSubKey("SOFTWARE\\LogMyTime");
            if (add)
                path.SetValue("AutoStart", 1);
            else
                path.SetValue("AutoStart", 0);
        }

        public static bool AutoStartCounter()
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey("SOFTWARE\\LogMyTime", true);
            return path != null && path.GetValue("AutoStart") != null && (int)path.GetValue("AutoStart") == 1;
        }

        public static DateTime IntToDateTime(int v)
        {
            return DateTime.ParseExact(Utils.MinutesToString(v), "HH:mm", CultureInfo.InvariantCulture);
        }

        public static bool IsActive()
        {
            return Utils.GetIdleTime() < 60000;
        }

        public static string MD5(string input)
        {
            MD5 md5Hash = System.Security.Cryptography.MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string Serialize(Object obj)
        {
            var xmlserializer = new XmlSerializer(obj.GetType());
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, obj);
                return stringWriter.ToString();
            }
            return null;
        }

        public static Object Deserialize<T>(string xml)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            StringReader sRead = new StringReader(xml);
            return deserializer.Deserialize(sRead);
        }
    }

}
