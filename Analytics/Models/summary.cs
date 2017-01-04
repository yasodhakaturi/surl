using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class Summary
    {
        public string url { get; set; }
        public int visits { get; set; }
        public int? unique_users { get; set; }
        public int total_users { get; set; }
    }
}