using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ioasysWebAPI.Models;

namespace ioasysWebAPI.Controllers
{
    public class EnterprisesV1Controller : ApiController
    {
        private EnterpriseV1[] enterprises = new EnterpriseV1[]
        {
            new EnterpriseV1 {
                id = 1,
                enterprise_name = "Google",
                photo = "/uploads/enterprise/photo/1/wood_trees_gloomy_fog_haze_darkness_50175_1920x1080.jpg",
                description = "Google LLC is an American multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, search engine, cloud computing, software, and hardware.",
                city = "Mountain View",
                country = "USA",
                value = 0,
                share_price = 1241,
                enterprise_type = new EnterpriseTypeV1 {id = 1, enterprise_type_name = "Technology" }
                },
            new EnterpriseV1 {
                id = 2,
                enterprise_name = "Apple",
                photo = "/uploads/enterprise/photo/1/wood_trees_gloomy_fog_haze_darkness_50175_1920x1080.jpg",
                description = "Apple Inc. is an American multinational technology company headquartered in Cupertino, California, that designs, develops, and sells consumer electronics, computer software, and online services.",
                city = "Cupertino",
                country = "USA",
                value = 0,
                share_price = 204,
                enterprise_type = new EnterpriseTypeV1 {id = 1, enterprise_type_name = "Technology" }
                },
            new EnterpriseV1 {
                id = 3,
                enterprise_name = "Citigroup",
                photo = "/uploads/enterprise/photo/1/wood_trees_gloomy_fog_haze_darkness_50175_1920x1080.jpg",
                description = "Citigroup Inc. or Citi (stylized as citi) is an American multinational investment bank and financial services corporation headquartered in New York City.",
                city = "New York City",
                country = "USA",
                value = 0,
                share_price = 69,
                enterprise_type = new EnterpriseTypeV1 {id = 2, enterprise_type_name = "Finance" }
                }
        };

        // GET: api/EnterprisesV1
        [Route("api/v1/enterprises")]
        public IEnumerable<EnterpriseV1> Get()
        {
            return enterprises;
        }

        // GET: api/EnterprisesV1/5
        [Route("api/v1/enterprises/{id}")]
        public IHttpActionResult Get(int id)
        {
            var enterprise = enterprises.FirstOrDefault(x => x.id == id);

            if (enterprise == null)
            {
                return NotFound();
            }

            return Ok(enterprise);
            //return "value";
        }

        //// POST: api/EnterprisesV1
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/EnterprisesV1/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/EnterprisesV1/5
        //public void Delete(int id)
        //{
        //}
    }
}
