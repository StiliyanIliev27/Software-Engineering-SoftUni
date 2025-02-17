﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int BatteryCapacity = 40_000;
        private const int ConvertionCapacityIndex = 5_000;
        public IndustrialAssistant(string model)
            : base(model, BatteryCapacity, ConvertionCapacityIndex)
        {
        }
    }
}
