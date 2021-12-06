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
            mainTask = Task.Run(async () =>
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
                rtuInstance.ResponseData = new Action<int, List<byte>>(ParsingData);
                if (rtuInstance.Connection())
                {
                    SuccessAction();
                    //程序运行时不断刷新串口通信
                    int startAddr = 0;
                    while (IsRunging)
                    {
                        foreach (var item in StorageList)
                        {
                            if(item.Length>100)
                            {
                                startAddr = item.StartAddress;
                                int readCount = item.Length / 100;
                                for (int i = 0; i < readCount; i++)
                                {
                                    int readLen = (i == readCount) ? item.Length - 100 * i : 100;
                                    await rtuInstance.IsSendSuccess(item.SlaveAddress, (byte)int.Parse(item.FuncCode),
                                        startAddr + 100 * i, readLen);
                                }
                            }
                            if(item.Length %100 >0)
                            {
                                await rtuInstance.IsSendSuccess(item.SlaveAddress, (byte)int.Parse(item.FuncCode),
                                        startAddr + 100 * (item.Length / 100), item.Length % 100);
                            }
                        }
                    }
                }
                else
                {
                    FalseAction("程序无法启动,串口连接初始化失败!请检查设备是否连接正常");
                    return;
                }    
            });
        }

        private static void ParsingData(int start_addr, List<byte> bytelist)
        {
            if(bytelist!=null && bytelist.Count>0)
            {
                int startByte;
                byte[] res = null;
                //查找设备监控点位与当前返回报文相关的监控数据列表
                //根据从站地址、功能码、起始地址查找
                var mvl = (from q in DeviceList
                           from m in q.MonitorValueList
                           where m.StorageAreaId == 
                           (bytelist[0].ToString() + bytelist[1].ToString("00") + start_addr.ToString())
                           select m
                           ).ToList();

                foreach (var item in mvl)
                {
                    switch(item.DataType)
                    {
                        case "Float":
                            startByte = item.StartAddress * 2 + 3;
                            if(startByte < start_addr +bytelist.Count)
                            {
                                res = new byte[4] { bytelist[startByte],bytelist[startByte+1],bytelist[startByte+2],
                                    bytelist[startByte+3]
                                };
                                item.CurrentValue = Convert.ToDouble(res.ByteArrsyToFloat());
                            }
                            break;
                        case "Bool":
                            break;
                    }                  
                }

            }
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
