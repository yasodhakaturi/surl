using Analytics.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class ClientView:BaseEntity
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
       // public List<ClientView> ClientsList { get; set; }
    }
    public class ClientView1
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public bool? IsActive { get; set; }
        // public List<ClientView> ClientsList { get; set; }
    }
}