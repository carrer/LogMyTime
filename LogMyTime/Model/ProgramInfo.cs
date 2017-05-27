using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace LogMyTime.Model
{
    [Serializable()]
    public class ProgramInfo
    {
        private string name;
        private string path;
        private string title;

        public string Name { get { return name; } set { name = value; } }
        public string Path { get { return path; } set { path = value; } }
        public string Title { get { return title; } set { title = value; } }

        [XmlAttribute]
        public string ID { get { return Key(); } set { } }

        public ProgramInfo() { }

        public ProgramInfo(string Name, string AbsolutePath, string Title)
        {
            name = Name;
            path = AbsolutePath;
            title = Title;
        }

        public string Key()
        {
            if (path == null || path.Length == 0)
                return "";

            return Utils.MD5(path).Substring(0, 5);
        }
    }
}
