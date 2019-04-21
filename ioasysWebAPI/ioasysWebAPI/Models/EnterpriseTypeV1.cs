using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ioasysWebAPI.Models
{
    [Table("enterprise_types")]
    public class EnterpriseTypeV1
    {
        public int id { get; set; }
        public string enterprise_type_name { get; set; }

        //public virtual IQueryable<EnterpriseV1> enterprises { get; set; }
    }
}