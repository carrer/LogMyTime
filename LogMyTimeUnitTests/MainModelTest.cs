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
        [TestMethod]
        public void ShouldCalcMonth()
        {
            MainModel model = new MainModel();
            model.InjectPath(Directory.GetCurrentDirectory());
            model.SetMonth(new LogMyTime.DayInfo("20001201;20001201080000;20001201180000"));
            model.CalcMonth();
            ConfigurationSettings config = ConfigurationSettings.GetInstance();
            config.Subtract = false;
            config.Workload = 480;
            Assert.AreEqual<int>(28800, model.AverageStart);
            Assert.AreEqual<int>(48600, model.AverageEnd);
            Assert.AreEqual<int>(330, model.AverageDifference);
            Assert.AreEqual<int>(600, model.TotalNet);
        }
    }
}
