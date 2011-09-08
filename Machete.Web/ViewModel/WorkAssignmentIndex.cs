﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Machete.Web.Models;
using Machete.Domain;

namespace Machete.Web.ViewModel
{   
    /// <summary>
    /// Class for /WorkAssignment/Index view. 
    /// </summary>
    public class WorkAssignmentIndex
    {
        public string todaysdate { get; set; }
        public string dwccardnum { get; set; }
        public int status { get; set; }
        public bool wa_grouping { get; set; }
        public bool typeofwork_grouping { get; set; }
        public bool assignedWorker_visible { get; set; }
        public bool signin_visible { get; set; }
        public bool requestedWorkers_visible { get; set; }
    }
}