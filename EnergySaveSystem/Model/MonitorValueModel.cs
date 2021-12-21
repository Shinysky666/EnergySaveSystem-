using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergySaveSystem.Model
{
    public enum MonitorValueState
    {
        LoLo = -2,
        Low = -1,
        OK = 0,
        High = 1,
        HiHi = 2
    }
    //监控数据模型
    public class MonitorValueModel
    {
        public Action<MonitorValueState, string, string> ValueStateChanged;
        public string ValueId { get; set; }
        public string ValueName { get; set; }
        public string StorageAreaId { get; set; }
        public int StartAddress { get; set; }
        public string DataType { get; set; }
        public bool IsAlarm { get; set; }
        public double LoLoAlarm { get; set; }
        public double LowAlarm { get; set; }
        public double HighAlarm { get; set; }
        public double HiHiAlarm { get; set; }
        public string Unit { get; set; }
        public string ValueDesc { get; set; }

        private double _currentValue;
        public double CurrentValue
        {
            get { return _currentValue; }
            set 
            { 
                _currentValue = value;
                if (IsAlarm)
                {
                    string msg = ValueDesc;
                    MonitorValueState state = MonitorValueState.OK;
                    if (value > HiHiAlarm)
                    {
                        msg += "极高";
                        state = MonitorValueState.HiHi;
                    }
                    else if (value > HighAlarm)
                    {
                        msg += "过高";
                        state = MonitorValueState.High;
                    }
                    else if (value < LowAlarm)
                    {
                        msg += "过低";
                        state = MonitorValueState.Low;
                    }
                    else if (value < LoLoAlarm)
                    {
                        msg += "极低";
                        state = MonitorValueState.LoLo;
                    }
                    ValueStateChanged(state, msg + " 当前值: " + value.ToString(), ValueId);
                }

                LivecharValues.Add(new ObservableValue(value));
                if (LivecharValues.Count > 60)
                    LivecharValues.RemoveAt(0);
            }
        }

        //LiveCharts绘制左侧设备详情
        public ChartValues<ObservableValue> LivecharValues { get; set; } = new ChartValues<ObservableValue>();

    }   

    
}
