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
    public class DM_HOCVIController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_HOCVI
        public IQueryable<DM_HOCVI> GetDM_HOCVI()
        {
            return db.DM_HOCVI;
        }

        // GET: api/DM_HOCVI/5
        [ResponseType(typeof(DM_HOCVI))]
        public IHttpActionResult GetDM_HOCVI(int id)
        {
            DM_HOCVI dM_HOCVI = db.DM_HOCVI.Find(id);
            if (dM_HOCVI == null)
            {
                return NotFound();
            }

            return Ok(dM_HOCVI);
        }

        // PUT: api/DM_HOCVI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_HOCVI(int id, DM_HOCVI dM_HOCVI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_HOCVI.IDHocvi)
            {
                return BadRequest();
            }

            db.Entry(dM_HOCVI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_HOCVIExists(id))
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

        // POST: api/DM_HOCVI
        [ResponseType(typeof(DM_HOCVI))]
        public IHttpActionResult PostDM_HOCVI(DM_HOCVI dM_HOCVI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_HOCVI.Add(dM_HOCVI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_HOCVI.IDHocvi }, dM_HOCVI);
        }

        // DELETE: api/DM_HOCVI/5
        [ResponseType(typeof(DM_HOCVI))]
        public IHttpActionResult DeleteDM_HOCVI(int id)
        {
            DM_HOCVI dM_HOCVI = db.DM_HOCVI.Find(id);
            if (dM_HOCVI == null)
            {
                return NotFound();
            }

            db.DM_HOCVI.Remove(dM_HOCVI);
            db.SaveChanges();

            return Ok(dM_HOCVI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_HOCVIExists(int id)
        {
            return db.DM_HOCVI.Count(e => e.IDHocvi == id) > 0;
        }
    }
}