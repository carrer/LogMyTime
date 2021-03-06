﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMyTime
{
    public class ConfigurationSettings
    {
        private static ConfigurationSettings instance;
        public int Workload;
        public int Tolerance;
        public bool Startup;
        public bool Subtract;
        public int SubtractQuantity;
        public int SubtractCondition;
        public bool Warn;
        public int WarnCondition;

        private ConfigurationSettings()
        {
            LoadFromRegistry();
        }

        public static ConfigurationSettings GetInstance()
        {
            if (instance == null)
                instance = new ConfigurationSettings();

            return instance;
        }

        public void LoadFromRegistry()
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LogMyTime", true);
            this.Startup = Utils.IsAtWindowsRegistry();
            try
            {
                this.Workload = Convert.ToInt32(path.GetValue("Workload"));
            } catch(Exception e)
            {
                this.Workload = 480; // 8hours
            }

            try
            {
                this.Tolerance = Convert.ToInt32(path.GetValue("Tolerance"));
            }
            catch (Exception e)
            {
                this.Tolerance = 15; // 15min
            }

            try
            {
                this.Subtract = Convert.ToBoolean(path.GetValue("Subtract"));
                this.SubtractQuantity = Convert.ToInt32(path.GetValue("SubtractQuantity"));
                this.SubtractCondition = Convert.ToInt32(path.GetValue("SubtractCondition"));
            }
            catch (Exception e)
            {
                this.Subtract = false;
                this.SubtractQuantity = 60; // 1hr
                this.SubtractCondition = 0; // work morning & afternoon
            }
            try
            {
                this.Warn = Convert.ToBoolean(path.GetValue("Warn"));
                this.WarnCondition = Convert.ToInt32(path.GetValue("WarnCondition"));
            }
            catch (Exception e)
            {
                this.Warn = false;
                this.WarnCondition = this.Workload;
            }
        }

        public void SaveToRegistry()
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LogMyTime", true);
            if (path == null)
                path = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LogMyTime");

            if (path == null)
                return;

            path.SetValue("Workload", this.Workload);
            path.SetValue("Tolerance", this.Tolerance);
            path.SetValue("Subtract", Convert.ToString(this.Subtract));
            path.SetValue("SubtractQuantity", Convert.ToString(this.SubtractQuantity));
            path.SetValue("SubtractCondition", Convert.ToString(this.SubtractCondition));
            path.SetValue("Warn", Convert.ToString(this.Warn));
            path.SetValue("WarnCondition", Convert.ToString(this.WarnCondition));
            Utils.SetWindowsRegistry(this.Startup);
        }

    }
}
