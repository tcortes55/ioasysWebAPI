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
    public class EnterprisesV1Controller : ApiController
    {
        private EnterpriseModel2 db = new EnterpriseModel2();

        // GET: api/EnterprisesV1
        // GET: api/EnterprisesV1
        [Route("api/v1/enterprises")]
        public IHttpActionResult Get()
        {
            return Ok(new { enterprises = db.enterprises.ToList() });
        }
        //public IQueryable<EnterpriseV1> Getenterprises()
        //{
        //    return db.enterprises;
        //}

        // GET: api/EnterprisesV1/5
        [ResponseType(typeof(EnterpriseV1))]
        public IHttpActionResult GetEnterpriseV1(int id)
        {
            EnterpriseV1 enterpriseV1 = db.enterprises.Find(id);
            if (enterpriseV1 == null)
            {
                return NotFound();
            }

            return Ok(enterpriseV1);
        }

        // PUT: api/EnterprisesV1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnterpriseV1(int id, EnterpriseV1 enterpriseV1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enterpriseV1.id)
            {
                return BadRequest();
            }

            db.Entry(enterpriseV1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnterpriseV1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EnterprisesV1
        [ResponseType(typeof(EnterpriseV1))]
        public IHttpActionResult PostEnterpriseV1(EnterpriseV1 enterpriseV1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.enterprises.Add(enterpriseV1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enterpriseV1.id }, enterpriseV1);
        }

        // DELETE: api/EnterprisesV1/5
        [ResponseType(typeof(EnterpriseV1))]
        public IHttpActionResult DeleteEnterpriseV1(int id)
        {
            EnterpriseV1 enterpriseV1 = db.enterprises.Find(id);
            if (enterpriseV1 == null)
            {
                return NotFound();
            }

            db.enterprises.Remove(enterpriseV1);
            db.SaveChanges();

            return Ok(enterpriseV1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnterpriseV1Exists(int id)
        {
            return db.enterprises.Count(e => e.id == id) > 0;
        }
    }
}