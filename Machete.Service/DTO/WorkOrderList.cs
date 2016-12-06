﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machete.Service.DTO
{
    public class WorkOrderList
    {
        public int ID { get; set; }
        public int EmployerID { get; set; }
        public DateTime dateTimeofWork { get; set; }
        public int? paperOrderNum { get; set; }
        public int status { get; set; }
        public int transportMethodID { get; set; }
        public string contactName { get; set; }
        public string workSiteAddress1 { get; set; }
        public string zipcode { get; set; }
        public bool onlineSource { get; set; }
        public string updatedby { get; set; }
        public DateTime dateupdated { get; set; }
        public int WAcount { get; set; }
        public int emailSentCount { get; set; }
        public int emailErrorCount { get; set; }
    }
}
