﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Machete.Api.ViewModel
{
    public class TransportVehicle : BaseModel
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        //public List<TransportCostRule> costRules { get; set; }
    }

    public class TransportVehicleSchedule : BaseModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}