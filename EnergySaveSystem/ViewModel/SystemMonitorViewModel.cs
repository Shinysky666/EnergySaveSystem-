using EnergySaveSystem.Base;
using EnergySaveSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergySaveSystem.ViewModel
{
    public class SystemMonitorViewModel : NotifyPropertyBase
    {
        public ObservableCollection<LogModel> Loglist { get; set; } = new ObservableCollection<LogModel>();
        public DeviceModel testdevice { get; set; }
        public CommandBase ComponentCommand { get; set; }

        private DeviceModel _currentDevice;
        public DeviceModel CurrentDevice
        {
            get { return _currentDevice; }
            set { _currentDevice = value; this.RaisePropertyChanged(); }
        }
        
        //是否展示左侧状态栏
        private bool _isShowDetail =false;
        public bool IsShowDetail
        {
            get { return _isShowDetail; }
            set { _isShowDetail = value; this.RaisePropertyChanged(); }
        }


        public SystemMonitorViewModel()
        {
            InitLogInfo();
            //InitDeviceModel();
            this.ComponentCommand = new CommandBase(new Action<object>(DoTowerCommand));
        }

        public void InitLogInfo()
        {
            this.Loglist.Add(new LogModel
            {
                RowNumber = 1, DeviceName = "冷却塔 1#", LogInfo = "已启动", LogType = LogType.Info
            });
            this.Loglist.Add(new LogModel
            {
                RowNumber = 2, DeviceName = "冷却塔 2#", LogInfo = "已启动", LogType = LogType.Info
            });
            this.Loglist.Add(new LogModel
            {
                RowNumber = 3, DeviceName = "冷却塔 3#", LogInfo = "液位极低", LogType = LogType.Warn
            });
            this.Loglist.Add(new LogModel
            {
                RowNumber = 4, DeviceName = "循环水泵 1#", LogInfo = "频率过大", LogType = LogType.Warn
            });
            this.Loglist.Add(new LogModel
            {
                RowNumber = 5, DeviceName = "循环水泵 2#", LogInfo = "已启动", LogType = LogType.Info
            });
            this.Loglist.Add(new LogModel
            {
                RowNumber = 6, DeviceName = "循环水泵 3#", LogInfo = "已启动", LogType = LogType.Info
            });
        }

        public void InitDeviceModel()
        {
            testdevice = new DeviceModel();
            testdevice.DeviceName = "冷却塔 1#";
            testdevice.IsRuning = true;
            testdevice.IsWarning = true;
            testdevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "液位",
                Unit = "m",
                CurrentValue = 0,
                LivecharValues = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue>{
                    new LiveCharts.Defaults.ObservableValue(0),new LiveCharts.Defaults.ObservableValue(0)
                }
            });
            testdevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "入口压力",
                Unit = "Mpa",
                CurrentValue = 30,
                LivecharValues = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue>{
                    new LiveCharts.Defaults.ObservableValue(0),new LiveCharts.Defaults.ObservableValue(2)
                }
            });
            testdevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "入口温度",
                Unit = "℃",
                CurrentValue = 35,
                LivecharValues = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue>{
                    new LiveCharts.Defaults.ObservableValue(0),new LiveCharts.Defaults.ObservableValue(0)
                }
            });
            testdevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "出口压力",
                Unit = "Mpa",
                CurrentValue = 25,
                LivecharValues = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue>{
                    new LiveCharts.Defaults.ObservableValue(0),new LiveCharts.Defaults.ObservableValue(0)
                }
            });
            testdevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "出口温度",
                Unit = "℃",
                CurrentValue = 22,
                LivecharValues = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue>{
                    new LiveCharts.Defaults.ObservableValue(0),new LiveCharts.Defaults.ObservableValue(0)
                }
            });
            testdevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "补水压力",
                Unit = "Mpa",
                CurrentValue = 15,
                LivecharValues = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue>{
                    new LiveCharts.Defaults.ObservableValue(0),new LiveCharts.Defaults.ObservableValue(0)
                }
            });
            testdevice.WarningMessageList.Add(new WarningMessageModel
            {
                Message = "冷却塔 1#液位极低, 当前值: 0"
            });
            testdevice.WarningMessageList.Add(new WarningMessageModel
            {
                Message = "冷却塔 1#入口压力极低, 当前值: 0"
            });
            testdevice.WarningMessageList.Add(new WarningMessageModel
            {
                Message = "冷却塔 1#入口温度极低, 当前值: 0"
            });
        }

        private void DoTowerCommand(object param)
        {
            CurrentDevice = param as DeviceModel;
            this.IsShowDetail = true;
        }
    }
}
