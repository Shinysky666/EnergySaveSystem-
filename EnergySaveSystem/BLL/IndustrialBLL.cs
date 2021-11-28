using Communication;
using EnergySaveSystem.DAL;
using EnergySaveSystem.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergySaveSystem.BLL
{
    public class IndustrialBLL
    {
        //获取串口信息
        public DataResult<SerialInfo> InitSerialInfo()
        {
            DataResult<SerialInfo> result = new DataResult<SerialInfo>();
            try
            {
                SerialInfo serialinfo = new SerialInfo();
                serialinfo.PortName = ConfigurationManager.AppSettings["port"].ToString();
                serialinfo.BoundRate = int.Parse(ConfigurationManager.AppSettings["bound"].ToString());
                serialinfo.DataBit = int.Parse(ConfigurationManager.AppSettings["databit"].ToString());
                serialinfo.Parity_Check = (Parity)Enum.Parse(typeof(Parity),
                    ConfigurationManager.AppSettings["parity"].ToString(),true);
                serialinfo.Stop_Bits = (StopBits)Enum.Parse(typeof(StopBits),
                    ConfigurationManager.AppSettings["stop_bits"].ToString(), true);

                result.State = true;
                result.Data = serialinfo;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }
        //获取存储站
        public DataResult<List<StorageAreaModel>> InitStorageArea()
        {
            DataResult<List<StorageAreaModel>> result = new DataResult<List<StorageAreaModel>>();
            try
            {
                StorageAreaModel storageArea = new StorageAreaModel();
                //获取数据库中StorageArea表数据 并将数据赋值给 DataResult中的Data
                var value = DataAccess.instance.GetStorageArea();
                result.State = true;
                result.Data = (from data in value.AsEnumerable()
                               select new StorageAreaModel()
                               {
                                   Id = data.Field<string>("id"),
                                   SlaveAddress = data.Field<int>("slave_addr"),
                                   FuncCode = data.Field<string>("func_code"),
                                   StartAddress = data.Field<int>("start_addr"),
                                   Length = data.Field<int>("length")
                               }).ToList();
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }

        public DataResult<List<DeviceModel>> InitDevices()
        {
            DataResult<List<DeviceModel>> result = new DataResult<List<DeviceModel>>();
            try
            {
                var devices = DataAccess.instance.GetDevice();
                var monitorvalues = DataAccess.instance.GetMonitorValues();
                List<DeviceModel> devicelist = new List<DeviceModel>();

                foreach (var item in devices.AsEnumerable())
                {
                    DeviceModel dmodel = new DeviceModel();
                    devicelist.Add(dmodel);
                    dmodel.DeviceId = item.Field<string>("d_id");
                    dmodel.DeviceName = item.Field<string>("d_name");
                    
                    //连表查询
                    foreach (var monitor in monitorvalues.AsEnumerable().
                        Where(o=>o.Field<string>("id") == dmodel.DeviceId))
                    {
                        MonitorValueModel mvm = new MonitorValueModel();
                        dmodel.MonitorValueList.Add(mvm);

                        mvm.ValueId = monitor.Field<string>("value_id");
                        mvm.ValueName = monitor.Field<string>("value_name");
                        mvm.StorageAreaId = monitor.Field<string>("s_area_id");
                        mvm.StartAddress = monitor.Field<Int32>("address");
                        mvm.DataType = monitor.Field<string>("data_type");
                        mvm.IsAlarm = monitor.Field<Int32>("is_alarm") == 1;
                        mvm.ValueDesc = monitor.Field<string>("description");
                        mvm.Unit = monitor.Field<string>("unit");

                        //警戒值
                        var lolo = monitor.Field<string>("alarm_lolo");
                        mvm.LoLoAlarm = lolo == null ? 0.0 : double.Parse(lolo);
                        var low = monitor.Field<string>("alarm_low");
                        mvm.LoLoAlarm = low == null ? 0.0 : double.Parse(low);
                        var high = monitor.Field<string>("alarm_high");
                        mvm.LoLoAlarm = high == null ? 0.0 : double.Parse(high);
                        var hihi = monitor.Field<string>("alarm_hihi");
                        mvm.LoLoAlarm = hihi == null ? 0.0 : double.Parse(hihi);

                        mvm.ValueStateChanged = (state, msg, value_id) =>
                        {
                            //当报警的消息Id 在 WarningMessageList中存在时,清空并重新刷新该Id的报警信息
                            var index = dmodel.WarningMessageList.ToList().
                            FindIndex(w => w.ValueId == value_id);
                            if (index > -1)
                                dmodel.WarningMessageList.RemoveAt(index);

                            if (state != MonitorValueState.OK)
                            {
                                dmodel.IsWarning = true;
                                dmodel.WarningMessageList.Add(new WarningMessageModel
                                {
                                    ValueId = value_id,
                                    Message = msg
                                });
                            }
                            //防止报警消息过多 一直触发
                            bool ss = dmodel.WarningMessageList.Count > 0;
                            if (dmodel.IsWarning != ss)
                                dmodel.IsWarning = ss;

                        };
                    }
                    
                }
                result.Data = devicelist;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }

    }
}
