using LogMyTime;
using LogMyTime.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMyTimeUnitTests
{
    [TestClass]
    public class MainModelTest
    {
        [ClassInitialize]
        public static void CleanUp(TestContext context)
        {
        }

        [TestMethod]
        public void ShouldTickNCalc()
        {
//            Assert.AreEqual<string>("01:00", model.GetTodayRow().Difference);
        }

    }
}
