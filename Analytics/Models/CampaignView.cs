﻿using Analytics.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class CampaignView : BaseEntity
    {
        public int id { get; set; }
        public string ReferenceNumber { get; set; }
        public string pwd { get; set; }
        public bool? isactive { get; set; }
        //public List<string> listcampaigns { get; set; }

    }
    public class CampaignView1
    {
        public int id { get; set; }
        public string ReferenceNumber { get; set; }
       // public string pwd { get; set; }
        public bool? isactive { get; set; }
        //public List<string> listcampaigns { get; set; }

    }
}