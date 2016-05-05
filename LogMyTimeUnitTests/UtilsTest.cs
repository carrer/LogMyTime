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

        [TestMethod]
        public void ShouldCalcWorkingHours()
        {
            ConfigSettings.Instance().Subtract = false;
            Assert.AreEqual<int>(325, Utils.getWorkingHours(new DayInfo(";20000101123400;20000101175900")));
            Assert.AreEqual<int>(0, Utils.getWorkingHours(new DayInfo(";;20000101175900")));
            Assert.AreEqual<int>(-325, Utils.getWorkingHours(new DayInfo(";20000101175900;20000101123400")));
            Assert.AreEqual<int>(1765, Utils.getWorkingHours(new DayInfo(";20000101123400;20000102175900")));
            Assert.AreEqual<int>(180, Utils.getWorkingHours(new DayInfo(";20000101100000;20000101130000")));
            ConfigSettings.Instance().Subtract = true;
            ConfigSettings.Instance().SubtractQuantity = 60;
            ConfigSettings.Instance().SubtractCondition = -1;
            Assert.AreEqual<int>(120, Utils.getWorkingHours(new DayInfo(";20000101100000;20000101130000")));
            ConfigSettings.Instance().SubtractCondition = 0;
            Assert.AreEqual<int>(120, Utils.getWorkingHours(new DayInfo(";20000101100000;20000101130000")));
            ConfigSettings.Instance().SubtractCondition = 120;
            Assert.AreEqual<int>(120, Utils.getWorkingHours(new DayInfo(";20000101100000;20000101130000")));
            ConfigSettings.Instance().SubtractCondition = 180;
            Assert.AreEqual<int>(180, Utils.getWorkingHours(new DayInfo(";20000101100000;20000101130000")));
            ConfigSettings.Instance().SubtractCondition = 179;
            Assert.AreEqual<int>(120, Utils.getWorkingHours(new DayInfo(";20000101100000;20000101130000")));
            ConfigSettings.Instance().SubtractCondition = 179;
            ConfigSettings.Instance().SubtractQuantity = 180;
            Assert.AreEqual<int>(0, Utils.getWorkingHours(new DayInfo(";20000101100000;20000101130000")));
        }

    }
}
