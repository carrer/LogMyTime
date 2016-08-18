using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMyTime.Model
{
    public class ConfigurationModel
    {
        public int Workload { get; set; }
        public int Tolerance { get; set; }
        public bool Startup { get; set; }
        public bool Subtract { get; set; }
        public int SubtractQuantity { get; set; }
        public int SubtractCondition { get; set; }
        public bool Warn { get; set; }
        public int WarnCondition { get; set; }


        public void Load()
        {
            ConfigurationSettings config = ConfigurationSettings.GetInstance();
            Workload = config.Workload;
            Tolerance = config.Tolerance;
            Startup = Utils.IsAtWindowsRegistry();
            Subtract = config.Subtract;
            SubtractCondition = config.SubtractCondition;
            SubtractQuantity = config.SubtractQuantity;
            Warn = config.Warn;
            WarnCondition = config.WarnCondition;
        }

        public void Save()
        {
            ConfigurationSettings config = ConfigurationSettings.GetInstance();
            config.Workload = Workload;
            config.Tolerance = Tolerance;
            config.Subtract = Subtract;
            config.SubtractCondition = SubtractCondition;
            config.SubtractQuantity = SubtractQuantity;
            config.Warn = Warn;
            config.WarnCondition = WarnCondition;
            config.SaveToRegistry();
            Utils.SetWindowsRegistry(Startup);
        }
    }
}
