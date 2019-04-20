using ioasysWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ioasysWebAPI.Controllers
{
    public class EnterpriseTypesV1Controller : ApiController
    {
        private EnterpriseTypeV1[] enterpriseTypes = new EnterpriseTypeV1[]
        {
            new EnterpriseTypeV1 {id = 1, enterprise_type_name = "Technology" },
            new EnterpriseTypeV1 {id = 2, enterprise_type_name = "Industry" }
        };


        // GET: api/EnterpriseTypesV1
        [Route("api/v1/enterprise_types")]
        public IEnumerable<EnterpriseTypeV1> Get()
        {
            return enterpriseTypes;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/EnterpriseTypesV1/5
        [Route("api/v1/enterprise_types/{id}")]
        public IHttpActionResult Get(int id)
        {
            var enterpriseType = enterpriseTypes.FirstOrDefault(x => x.id == id);

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
