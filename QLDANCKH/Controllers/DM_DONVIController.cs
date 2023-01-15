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
using QLDANCKH.Models;

namespace QLDANCKH.Controllers
{
    public class DM_DONVIController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_DONVI
        public IQueryable<DM_DONVI> GetDM_DONVI()
        {
            return db.DM_DONVI;
        }

        // GET: api/DM_DONVI/5
        [ResponseType(typeof(DM_DONVI))]
        public IHttpActionResult GetDM_DONVI(int id)
        {
            DM_DONVI dM_DONVI = db.DM_DONVI.Find(id);
            if (dM_DONVI == null)
            {
                return NotFound();
            }

            return Ok(dM_DONVI);
        }

        // PUT: api/DM_DONVI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_DONVI(int id, DM_DONVI dM_DONVI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_DONVI.IDDonvi)
            {
                return BadRequest();
            }

            db.Entry(dM_DONVI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_DONVIExists(id))
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

        // POST: api/DM_DONVI
        [ResponseType(typeof(DM_DONVI))]
        public IHttpActionResult PostDM_DONVI(DM_DONVI dM_DONVI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_DONVI.Add(dM_DONVI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_DONVI.IDDonvi }, dM_DONVI);
        }

        // DELETE: api/DM_DONVI/5
        [ResponseType(typeof(DM_DONVI))]
        public IHttpActionResult DeleteDM_DONVI(int id)
        {
            DM_DONVI dM_DONVI = db.DM_DONVI.Find(id);
            if (dM_DONVI == null)
            {
                return NotFound();
            }

            db.DM_DONVI.Remove(dM_DONVI);
            db.SaveChanges();

            return Ok(dM_DONVI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_DONVIExists(int id)
        {
            return db.DM_DONVI.Count(e => e.IDDonvi == id) > 0;
        }
    }
}