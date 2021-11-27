﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergySaveSystem.Model
{
    public class DeviceModel
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }

        public ObservableCollection<MonitorValueModel> MonitorValueList { get; set; } =
            new ObservableCollection<MonitorValueModel>();
        public ObservableCollection<string> WarningMessageList { get; set; } =
            new ObservableCollection<string>();
    }
}
