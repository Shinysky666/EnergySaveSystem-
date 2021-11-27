﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class SerialInfo
    {
        public string PortName { get; set; } = "COM1";
        public int BoundRate { get; set; } = 9600;
        public int DataBit { get; set; } = 8;
        public Parity Parity_Check { get; set; } = Parity.None;
        public StopBits Stop_Bits { get; set; } = StopBits.One;
    }
}
