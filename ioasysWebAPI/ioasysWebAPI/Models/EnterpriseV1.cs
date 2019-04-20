using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ioasysWebAPI.Models
{
    public class EnterpriseV1
    {
        public int id { get; set; }
        public string email_enterprise { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string linkedin { get; set; }
        public string phone { get; set; }
        public bool own_enterprise { get; set; }
        public string enterprise_name { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int value { get; set; }
        public int share_price { get; set; }
        public EnterpriseTypeV1 enterprise_type { get; set; }
    }
}