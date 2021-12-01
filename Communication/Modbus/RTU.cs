using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Modbus
{
    public class RTU
    {
        private static RTU _instance;
        private static SerialInfo _serialInfo;
        SerialPort _serialPort;

        private RTU(SerialInfo serialInfo)
        {
            _serialInfo = serialInfo;
        }

        public static RTU GetInstance(SerialInfo serialInfo)
        {
            lock ("rtu")
            {
                if (_instance == null)
                    _instance = new RTU(serialInfo);
            }
            return _instance;
        }

        public bool Connection()
        {
            try
            {
                if(_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                _serialPort.PortName = _serialInfo.PortName;
                _serialPort.BaudRate = _serialInfo.BaudRate;
                _serialPort.DataBits = _serialInfo.DataBit;
                _serialPort.Parity = _serialInfo.Parity_Check;
                _serialPort.StopBits = _serialInfo.Stop_Bits;

                _serialPort.ReceivedBytesThreshold = 1;
                _serialPort.DataReceived += _serialPort_DataReceived;

                _serialPort.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
