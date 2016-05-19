using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogMyTime;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace LogMyTimeUnitTests
{
    [TestClass]
    public class FileHandlerTest
    {
        [ClassCleanup]
        public static void cleanup()
        {
            if (File.Exists(Directory.GetCurrentDirectory()+"\\data\\2000\\12\\20001210.csv"))
                File.Delete(Directory.GetCurrentDirectory() + "\\data\\2000\\12\\20001210.csv");
        }

        [TestMethod]
        public void ShouldListFile()
        {
            FileHandler io = new FileHandler();
            io.InjectPath(Directory.GetCurrentDirectory());
            List<String> files = io.ListAllFiles("2000\\12\\");
            Assert.IsTrue(files.Count != 0);
            Assert.AreEqual<string>("20001201.csv" , files[0]);   
        }

        [TestMethod]
        public void ShouldReadFromFile()
        {
            FileHandler io = new FileHandler();
            io.InjectPath(Directory.GetCurrentDirectory());
            Assert.AreEqual<string>("20001201;080000;180000", io.ReadFromFile("2000\\12\\", "20001201.csv"));
        }

        [TestMethod]
        public void ShouldWriteFile()
        {
            FileHandler io = new FileHandler();
            io.InjectPath(Directory.GetCurrentDirectory());
            Assert.IsFalse(File.Exists(Directory.GetCurrentDirectory() +"\\data\\2000\\12\\20001210.csv"));
            io.WriteToFile("2000\\12\\", "20001210.csv", "20001210;060000;040000");
            Assert.AreEqual<string>("20001210;060000;040000", io.ReadFromFile("2000\\12\\", "20001210.csv"));
            List<String> files = io.ListAllFiles("2000\\12\\");
            Assert.IsTrue(files.Count != 0);
            Assert.AreEqual<string>("20001201.csv", files[0]);
        }
    }
}
