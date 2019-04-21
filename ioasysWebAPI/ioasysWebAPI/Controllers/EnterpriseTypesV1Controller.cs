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
        private EnterpriseModel2 db = new EnterpriseModel2();

        // GET: api/EnterpriseTypesV1
        [Route("api/v1/enterprise_types")]
        public IHttpActionResult Get()
        {
            return Ok(new { enterprise_types = db.enterprise_types.ToList(), success = true });
            //return enterpriseTypes;
            //return new string[] { "value1", "value2" };
        }
        //public IQueryable<EnterpriseTypeV1> Getenterprise_types()
        //{
        //    return db.enterprise_types;
        //}

        // GET: api/EnterpriseTypesV1/5
        [Route("api/v1/enterprise_types/{id}")]
        public IHttpActionResult Get(int id)
        {
            var enterpriseType = db.enterprise_types.FirstOrDefault(x => x.id == id);

            if (enterpriseType == null)
            {
                return NotFound();
            }

            return Ok(enterpriseType);
            //return "value";
        }

        //[ResponseType(typeof(EnterpriseTypeV1))]
        //public IHttpActionResult GetEnterpriseTypeV1(int id)
        //{
        //    EnterpriseTypeV1 enterpriseTypeV1 = db.enterprise_types.Find(id);
        //    if (enterpriseTypeV1 == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(enterpriseTypeV1);
        //}

        //// PUT: api/EnterpriseTypesV1/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutEnterpriseTypeV1(int id, EnterpriseTypeV1 enterpriseTypeV1)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != enterpriseTypeV1.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(enterpriseTypeV1).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnterpriseTypeV1Exists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/EnterpriseTypesV1
        //[ResponseType(typeof(EnterpriseTypeV1))]
        //public IHttpActionResult PostEnterpriseTypeV1(EnterpriseTypeV1 enterpriseTypeV1)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.enterprise_types.Add(enterpriseTypeV1);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = enterpriseTypeV1.id }, enterpriseTypeV1);
        //}

        //// DELETE: api/EnterpriseTypesV1/5
        //[ResponseType(typeof(EnterpriseTypeV1))]
        //public IHttpActionResult DeleteEnterpriseTypeV1(int id)
        //{
        //    EnterpriseTypeV1 enterpriseTypeV1 = db.enterprise_types.Find(id);
        //    if (enterpriseTypeV1 == null)
        //    {
        //        return NotFound();
        //    }

        //    db.enterprise_types.Remove(enterpriseTypeV1);
        //    db.SaveChanges();

        //    return Ok(enterpriseTypeV1);
        //}

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