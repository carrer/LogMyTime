using System;
using System.Xml.Serialization;

namespace LogMyTime.Model
{
    [Serializable()]
    public class Counter
    {
        private string id;
        private int count = 1;
        private int inc;

        [XmlAttribute]
        public string ID { get { return id; } set { id = value; } }
        [XmlAttribute]
        public int Count { get { return count; } set { count = value; } }

        public Counter() { }

        public Counter(string ID)
        {
            this.id = ID;
        }

        public Counter(string ID, int inc)
        {
            this.id = ID;
            this.inc = inc;
        }

        public void Inc(int value = 1)
        {
            this.count += value;
        }
    }
}
