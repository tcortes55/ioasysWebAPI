using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ioasysWebAPI.Models;

namespace ioasysWebAPI.Controllers
{
    public class EnterpriseTypesV1Controller : ApiController
    {
        private EnterpriseModel db = new EnterpriseModel();
        
        // COMENTÁRIO:
        // Optei por utilizar a anotação Route para definir as rotas utilizadas para as diferentes requests
        [Route("api/v1/enterprise_types")]
        public IHttpActionResult Get()
        {
            return Ok(new { enterprise_types = db.enterprise_types.ToList(), success = true });
        }
        
        [Route("api/v1/enterprise_types/{id}")]
        public IHttpActionResult Get(int id)
        {
            var enterpriseType = db.enterprise_types.FirstOrDefault(x => x.id == id);

            if (enterpriseType == null)
            {
                return NotFound();
            }

            return Ok(enterpriseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnterpriseTypeV1Exists(int id)
        {
            return db.enterprise_types.Count(e => e.id == id) > 0;
        }
    }
}