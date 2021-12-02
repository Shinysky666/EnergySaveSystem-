using Communication;
using Communication.Modbus;
using EnergySaveSystem.BLL;
using EnergySaveSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergySaveSystem.Base
{
    public class GlobalMonitor
    {
        public static List<StorageAreaModel> StorageList { get; set; }
        public static List<DeviceModel> DeviceList { get; set; }
        public static SerialInfo serialInfo { get; set; }

        static bool IsRunging = true;
        static Task mainTask = null;
        static RTU rtuInstance;

        public static void Start(Action SuccessAction, Action<string> FalseAction)
        {
            mainTask = Task.Run(() =>
            {
                IndustrialBLL industrialbll = new IndustrialBLL();
                //获取串口配置信息
                var si = industrialbll.InitSerialInfo();
                if (si.State)
                {
                    serialInfo = si.Data;
                }
                else
                {
                    FalseAction(si.Message);
                    return;
                }
                //获取存储区信息
                var sa = industrialbll.InitStorageArea();
                if(sa.State)
                {
                    StorageList = sa.Data;
                }
                else
                {
                    FalseAction(sa.Message);
                    return;
                }
                //初始化设备变量集合及其警戒值
                var dr = industrialbll.InitDevices();
                if (dr.State)
                {
                    DeviceList = dr.Data;
                }
                else
                {
                    FalseAction(dr.Message);
                    return;
                }

                //初始化串口通信
                rtuInstance = RTU.GetInstance(serialInfo);
                if(rtuInstance.Connection())
                {
                    SuccessAction();
                    //程序运行时不断刷新串口通信
                    while (IsRunging)
                    {

                    }
                }
                else
                {
                    FalseAction("程序无法启动,串口连接初始化失败!请检查设备是否连接正常");
                    return;
                }    
            });
        }

        public static void Dispose()
        {
            IsRunging = false;

            if (rtuInstance != null)
            {
                rtuInstance.Dispose();
            }

            if (mainTask != null)
            {
                mainTask.Wait();
            }
        }
    }
}
