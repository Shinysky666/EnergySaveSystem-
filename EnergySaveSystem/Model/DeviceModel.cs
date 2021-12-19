using EnergySaveSystem.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergySaveSystem.Model
{
    public class DeviceModel: NotifyPropertyBase
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }

        private bool is_Warning = false;
        public bool IsWarning
        {
            get { return is_Warning; }
            set { is_Warning = value; this.RaisePropertyChanged(); }
        }
        private bool is_Runing;

        public bool IsRuning
        {
            get { return is_Runing; }
            set { is_Runing = value; this.RaisePropertyChanged(); }
        }

        public ObservableCollection<MonitorValueModel> MonitorValueList { get; set; } =
            new ObservableCollection<MonitorValueModel>();
        public ObservableCollection<WarningMessageModel> WarningMessageList { get; set; } =
            new ObservableCollection<WarningMessageModel>();
    }
}
