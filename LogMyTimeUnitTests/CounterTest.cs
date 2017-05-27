using LogMyTime;
using LogMyTime.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LogMyTimeUnitTests
{
    [TestClass]
    public class CounterTest
    {
        [TestMethod]
        public void ShouldSerialize()
        {
            ProgramInfo prog = new ProgramInfo("Name", "Path", "Title");
            Counter counter = new Counter(prog);

            var xmlserializer = new XmlSerializer(counter.GetType());
            var stringWriter = new StringWriter();
            string output;
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, counter);
                output = stringWriter.ToString();
            }
            System.Diagnostics.Debug.WriteLine(output);
            Assert.IsTrue(output.Contains("<Name>Name</Name>"));
            Assert.IsTrue(output.Contains("<Title>Title</Title>"));
            Assert.IsTrue(output.Contains("<Count>1</Count>"));
            Assert.IsTrue(output.Contains("<Reference>"));
        }

    }
}