using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ioasysWebAPI.Models;

namespace ioasysWebAPI.Controllers
{
    public class EnterpriseTypesV1Controller : ApiController
    {
        //private EnterpriseTypeV1[] enterpriseTypesList = new EnterpriseTypeV1[]
        //{
        //    new EnterpriseTypeV1 {id = 1, enterprise_type_name = "Technology" },
        //    new EnterpriseTypeV1 {id = 2, enterprise_type_name = "Finance" }
        //};
        private ioasysDBEntities db = new ioasysDBEntities();

        // GET: api/enterprise_types
        public IQueryable<EnterpriseTypeV1> GetEnterpriseTypesV1()
        {
            return db.enterprise_types;
        }


        // GET: api/EnterpriseTypesV1
        [Route("api/v1/enterprise_types")]
        public IHttpActionResult Get()
        {
            var lala = db.enterprise_types.ToList();
            //return Ok(new { enterprise_types = enterpriseTypesList.ToList(), success = true });
            return Ok(new { enterprise_types = db.enterprise_types.ToList(), success = true });
            //return enterpriseTypes;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/EnterpriseTypesV1/5
        [Route("api/v1/enterprise_types/{id}")]
        public IHttpActionResult Get(int id)
        {
            //var enterpriseType = enterpriseTypesList.FirstOrDefault(x => x.id == id);
            var enterpriseType = db.enterprise_types.FirstOrDefault(x => x.id == id);

            if (enterpriseType == null)
            {
                return NotFound();
            }

            return Ok(enterpriseType);
            //return "value";
        }

        //// POST: api/EnterpriseTypesV1
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/EnterpriseTypesV1/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/EnterpriseTypesV1/5
        //public void Delete(int id)
        //{
        //}
    }
}
