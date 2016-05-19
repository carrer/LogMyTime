using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogMyTime;

namespace LogMyTimeUnitTests
{
    [TestClass]
    public class DayInfoTest
    {
        [TestMethod]
        public void ShouldInstantiateFromProperCSVLine()
        {
            DayInfo day = new DayInfo("20100101;20110202001122;20110303012345");
            Assert.AreEqual<string>("20100101.csv", day.getFilename());
            Assert.AreEqual<string>("2010\\01\\", day.getSubDirectory());
            Assert.AreEqual<DateTime>(Convert.ToDateTime("02/02/2011 00:11:22"), (DateTime) day.getFirstActivity());
            Assert.AreEqual<DateTime>(Convert.ToDateTime("03/03/2011 01:23:45"), (DateTime)day.getLastActivity());
        }

        [TestMethod]
        public void ShouldInstantiateFromInvalidCSVLine()
        {
            DayInfo day = new DayInfo("20100101;;");
            Assert.AreEqual<string>("20100101.csv", day.getFilename());
            Assert.AreEqual<string>("2010\\01\\", day.getSubDirectory());
            Assert.IsNull(day.getFirstActivity());
            Assert.IsNull(day.getLastActivity());
        }

        [TestMethod]
        public void ShouldOutputCSV()
        {
            DayInfo day = new DayInfo("20100101;20110202001122;20110303012345");
            Assert.AreEqual<string>("20100101;20110202001122;20110303012345", day.ToCSV());
        }


        [TestMethod]
        public void ShouldTick()
        {
            DayInfo day = new DayInfo(";;");
            day.tick();
            Assert.AreEqual<string>(DateTime.Now.ToString("yyyyMMddHHmmss"), day.ToCSV().Substring(24));
        }

        [TestMethod]
        public void ShouldFormattedDatesNTimes()
        {
            DayInfo day = new DayInfo("20101201;20101201001122;20101201012345");
            Assert.AreEqual<string>("01/12", day.GetFormattedDay());
            Assert.AreEqual<string>("00:11:22", day.GetFormattedFirstActivity());
            Assert.AreEqual<string>("01:23:45", day.GetFormattedLastActivity());
            Assert.AreEqual<string>("01", day.GetDay());
            Assert.AreEqual<string>("201012", day.GetMonth());
            Assert.AreEqual<string>("20101201", day.GetDateToString());
        }
    }
}
