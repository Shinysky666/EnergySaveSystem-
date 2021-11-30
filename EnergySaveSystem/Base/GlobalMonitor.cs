using Communication;
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


                SuccessAction();

                while (IsRunging)
                {

                }
            });
        }

        public static void Dispose()
        {
            IsRunging = false;
            if (mainTask != null)
            {
                mainTask.Wait();
            }
        }
    }
}
