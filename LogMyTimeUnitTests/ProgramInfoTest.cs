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
    public class ProgramInfoTest
    {
        [TestMethod]
        public void ShouldSerialize()
        {
            ProgramInfo prog = new ProgramInfo("Name", "Path", "Title");

            var xmlserializer = new XmlSerializer(prog.GetType());
            var stringWriter = new StringWriter();
            string output;
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, prog);
                output = stringWriter.ToString();
            }
            Assert.IsTrue(output.Contains("<Name>Name</Name>"));
            Assert.IsTrue(output.Contains("<AbsolutePath>Path</AbsolutePath>"));
            Assert.IsTrue(output.Contains("<Title>Title</Title>"));
        }

    }
}