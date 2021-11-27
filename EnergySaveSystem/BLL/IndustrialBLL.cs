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
                    dmodel.DeviceId = item.Field<string>("d_id");
                    dmodel.DeviceName = item.Field<string>("d_name");
                    devicelist.Add(dmodel);
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
