using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class MobileNumbersList
    {
        
            public List<string> MobileNumbers { get; set; }
        //public string name { get; set; }

          
    }
    public class exportDataModel
    {
        public string Status { get; set; }
        public string MobileNumber { get; set; }
        public string ShortenUrl { get; set; }
        public string BatchID { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
    public class BatchStatus
    {
        public string Status { get; set; }
        public string Batchid { get; set; }

    }
    public class BatchIDList
    {
        public string BatchID { get; set; }
        public DateTime? CreatedDate{get;set;}
        public String Status{get;set;}
    }
    public class BatchDownload
    {
        public string Mobilenumber { get; set; }
        public string ShortUrl { get; set; }
    }
}