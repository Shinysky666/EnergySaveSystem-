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
        public static List<StorageAreaModel> StorageLis { get; set; }
        public static List<DeviceModel> DeviceList { get; set; }
        public static SerialInfo serialInfo { get; set; }

        static bool IsRunging = true;
        static Task mainTask = null;

        public static void Start(Action SuccessAction, Action<string> FalseAction)
        {
            mainTask = Task.Run(() =>
            {
                IndustrialBLL industrialbll = new IndustrialBLL();
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
