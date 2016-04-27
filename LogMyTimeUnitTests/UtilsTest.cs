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
            Assert.AreEqual<string>("00h 01m", Utils.MinutesToString(1));
            Assert.AreEqual<string>("01h 00m", Utils.MinutesToString(60));
            Assert.AreEqual<string>("01h 30m", Utils.MinutesToString(90));
            Assert.AreEqual<string>("25h 00m", Utils.MinutesToString(1500));
            Assert.AreEqual<string>("00h 01m", Utils.MinutesToString(1));
            Assert.AreEqual<string>("01h 00m", Utils.MinutesToString(60));
            Assert.AreEqual<string>("01h 30m", Utils.MinutesToString(90));
            Assert.AreEqual<string>("26h 05m", Utils.MinutesToString(1565));
        }

        [TestMethod]
        public void ShouldConvertDatetimeToTime()
        {
            Assert.AreEqual<string>("00:00:00",Utils.DatetimeToTime(DateTime.Parse("2013-01-1 00:00:00")));
            Assert.AreEqual<string>("01:10:00", Utils.DatetimeToTime(DateTime.Parse("2013-01-1 01:10:00")));
            Assert.AreEqual<string>("00:00:00", Utils.DatetimeToTime(DateTime.Parse("2013-01-1")));
        }

        [TestMethod]
        public void ShouldCalcWorkingHours()
        {
            Assert.AreEqual<string>("05h 25m", Utils.getWorkingHours(new DayInfo(";20000101123400;20000101175900")));
            Assert.AreEqual<string>("00h 00m", Utils.getWorkingHours(new DayInfo(";;20000101175900")));
            Assert.AreEqual<string>("-05h 25m", Utils.getWorkingHours(new DayInfo(";20000101175900;20000101123400")));
            Assert.AreEqual<string>("29h 25m", Utils.getWorkingHours(new DayInfo(";20000101123400;20000102175900")));
        }

    }
}
