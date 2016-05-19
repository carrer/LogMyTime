using System;
using LogMyTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogMyTimeUnitTests
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void ShouldConvertMinutesToString()
        {
            Assert.AreEqual<string>("00:01", Utils.MinutesToString(1));
            Assert.AreEqual<string>("01:00", Utils.MinutesToString(60));
            Assert.AreEqual<string>("01:30", Utils.MinutesToString(90));
            Assert.AreEqual<string>("25:00", Utils.MinutesToString(1500));
            Assert.AreEqual<string>("00:01", Utils.MinutesToString(1));
            Assert.AreEqual<string>("01:00", Utils.MinutesToString(60));
            Assert.AreEqual<string>("01:30", Utils.MinutesToString(90));
            Assert.AreEqual<string>("26:05", Utils.MinutesToString(1565));
        }

        [TestMethod]
        public void ShouldConvertDatetimeToTime()
        {
            Assert.AreEqual<string>("00:00:00",Utils.DatetimeToTime(DateTime.Parse("2013-01-1 00:00:00")));
            Assert.AreEqual<string>("01:10:00", Utils.DatetimeToTime(DateTime.Parse("2013-01-1 01:10:00")));
            Assert.AreEqual<string>("00:00:00", Utils.DatetimeToTime(DateTime.Parse("2013-01-1")));
        }

    }
}
