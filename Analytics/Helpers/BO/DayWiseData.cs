﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Helpers.BO
{
    public class DayWiseData
    {
        public DateTime RequestedDate { get; set; }
        public int Hour { get; set; }
        public int RequestCount { get; set; }


    }
}