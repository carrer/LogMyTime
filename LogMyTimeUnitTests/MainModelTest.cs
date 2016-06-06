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
            if (File.Exists(Directory.GetCurrentDirectory() + "\\data\\2000\\12\\20001210.csv"))
                File.Delete(Directory.GetCurrentDirectory() + "\\data\\2000\\12\\20001210.csv");
        }

        [TestMethod]
        public void ShouldCalcMonth()
        {
            MainModel model = new MainModel();
            model.InjectPath(Directory.GetCurrentDirectory());
            model.SetMonth(new LogMyTime.DayInfo("20001201;080000;180000"));
            ConfigurationSettings config = ConfigurationSettings.GetInstance();
            config.Subtract = false;
            config.Workload = 480;
            model.CalcMonth();
            Assert.AreEqual<int>(28800, model.AverageStart);
            Assert.AreEqual<int>(48600, model.AverageEnd);
            Assert.AreEqual<int>(330, model.AverageDifference);
            Assert.AreEqual<int>(330, model.AverageNet);
            Assert.AreEqual<int>(-150, model.AverageDelta);
            Assert.AreEqual<int>(660, model.TotalNet);
            Assert.AreEqual<int>(-300, model.TotalDelta);
            config.Subtract = true;
            config.SubtractCondition = -1; //all
            config.SubtractQuantity = 60; //1hr
            model.CalcMonth();
            Assert.AreEqual<int>(28800, model.AverageStart);
            Assert.AreEqual<int>(48600, model.AverageEnd);
            Assert.AreEqual<int>(330, model.AverageDifference);
            Assert.AreEqual<int>(270, model.AverageNet);
            Assert.AreEqual<int>(-210, model.AverageDelta);
            Assert.AreEqual<int>(540, model.TotalNet);
            Assert.AreEqual<int>(-420, model.TotalDelta);
        }

        [TestMethod]
        public void ShouldTickNCalc()
        {
            MainModel model = new MainModel();
            model.InjectPath(Directory.GetCurrentDirectory());

            DayInfoRow today = model.GetTodayRow();
            ConfigurationSettings config = ConfigurationSettings.GetInstance();

            // set start as now-1hr
            today.Start = Utils.SecondsToString((int) DateTime.Now.TimeOfDay.TotalSeconds - 3600);
            config.Subtract = false;
            config.Workload = 60;
            model.UpdateRow(today);
            Assert.AreEqual<string>("01:00", model.GetTodayRow().Net);
            Assert.AreEqual<string>("00:00", model.GetTodayRow().Delta);
            Assert.AreEqual<string>("01:00", model.GetTodayRow().Difference);
            config.Subtract = true;
            config.SubtractCondition = -1;
            config.SubtractQuantity = 60;
            config.Workload = 480;
            model.UpdateRow(today);
            Assert.AreEqual<string>("00:00", model.GetTodayRow().Net);
            Assert.AreEqual<string>("-08:00", model.GetTodayRow().Delta);
            Assert.AreEqual<string>("01:00", model.GetTodayRow().Difference);
        }

    }
}
