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
    public class enterprise_typesController : ApiController
    {
        private ioasysDBEntities db = new ioasysDBEntities();

        // GET: api/enterprise_types
        public IQueryable<enterprise_types> Getenterprise_types()
        {
            return db.enterprise_types;
        }

        // GET: api/enterprise_types/5
        [ResponseType(typeof(enterprise_types))]
        public IHttpActionResult Getenterprise_types(int id)
        {
            enterprise_types enterprise_types = db.enterprise_types.Find(id);
            if (enterprise_types == null)
            {
                return NotFound();
            }

            return Ok(enterprise_types);
        }

        // PUT: api/enterprise_types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putenterprise_types(int id, enterprise_types enterprise_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enterprise_types.id)
            {
                return BadRequest();
            }

            db.Entry(enterprise_types).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!enterprise_typesExists(id))
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

        // POST: api/enterprise_types
        [ResponseType(typeof(enterprise_types))]
        public IHttpActionResult Postenterprise_types(enterprise_types enterprise_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.enterprise_types.Add(enterprise_types);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enterprise_types.id }, enterprise_types);
        }

        // DELETE: api/enterprise_types/5
        [ResponseType(typeof(enterprise_types))]
        public IHttpActionResult Deleteenterprise_types(int id)
        {
            enterprise_types enterprise_types = db.enterprise_types.Find(id);
            if (enterprise_types == null)
            {
                return NotFound();
            }

            db.enterprise_types.Remove(enterprise_types);
            db.SaveChanges();

            return Ok(enterprise_types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool enterprise_typesExists(int id)
        {
            return db.enterprise_types.Count(e => e.id == id) > 0;
        }
    }
}