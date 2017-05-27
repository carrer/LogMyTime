using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LogMyTime
{
    public class FileHandler
    {
        protected string DataPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath)+ @"\data\";

        public void InjectPath(string path)
        {
            DataPath = path + @"\data\";
        }

        protected bool VerifyDataDirectory(string subdirectory)
        {
            return Directory.Exists(DataPath + subdirectory);
        }

        public bool FileExists(string subdirectory, string filename)
        {
            return File.Exists(DataPath + subdirectory + filename);
        }

        protected bool CreateDataDirectory(string subdirectory)
        {
            if (!VerifyDataDirectory(subdirectory))
                Directory.CreateDirectory(DataPath + subdirectory);
            return VerifyDataDirectory(subdirectory);
        }

        public bool WriteToFile(string subdirectory, string filename, string text)
        {
            if (!CreateDataDirectory(subdirectory))
                return false;

            DateTime lastWritten = File.GetLastWriteTime(DataPath+ subdirectory + filename);
            try
            {
                File.WriteAllText(DataPath + subdirectory + filename, text);
            } catch(Exception)
            {
                return false;
            }
            return lastWritten != File.GetLastWriteTime(DataPath + subdirectory + filename);
        }

        public string ReadFromFile(string subdirectory, string filename)
        {
            if (File.Exists(DataPath + subdirectory + filename))
            {
                try
                {
                    return File.ReadAllText(DataPath + subdirectory + filename);
                }
                catch (Exception) {
                    // in the worst case, I'll return an empty string
                }
            }
            return "";
        }

        public List<string> ListAllFiles(string subdirectory)
        {
            List<string> output = new List<string>();
            if (Directory.Exists(DataPath + subdirectory))
            foreach(string filename in Directory.GetFiles(DataPath+subdirectory))
            {
                if (filename.EndsWith(".csv") && filename.Contains('\\'))
                    output.Add(filename.Substring(filename.LastIndexOf("\\")+1));
            }
            return output;
        }

        public bool DeleteFile(string subdirectory, string filename)
        {
            if (File.Exists(DataPath + subdirectory + filename))
                File.Delete(DataPath + subdirectory + filename);

            return !File.Exists(DataPath + subdirectory + filename);
        }
    }
}
