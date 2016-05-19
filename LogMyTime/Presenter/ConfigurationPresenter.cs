using LogMyTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogMyTime.Presenter
{
    public class ConfigurationPresenter
    {
        private ConfigurationModel model;
        private ConfigurationView view;

        public ConfigurationPresenter(ConfigurationModel model, ConfigurationView view)
        {
            this.model = model;
            this.view = view;
            view.Presenter = this;
        }

        public void Load()
        {
            model.Load();
            view.Workload = model.Workload;
            view.Subtract = model.Subtract;
            view.SubtractCondition = model.SubtractCondition;
            view.SubtractQuantity = model.SubtractQuantity;
            view.Warn = model.Warn;
            view.WarnCondition = model.WarnCondition;
            view.Startup = model.Startup;
        }

        public void Close()
        {
            model.Workload = view.Workload;
            model.Subtract = view.Subtract;
            model.SubtractCondition = view.SubtractCondition;
            model.SubtractQuantity = view.SubtractQuantity;
            model.Warn = view.Warn;
            model.WarnCondition = view.WarnCondition;
            model.Startup = view.Startup;
            model.Save();
        }
    }
}
