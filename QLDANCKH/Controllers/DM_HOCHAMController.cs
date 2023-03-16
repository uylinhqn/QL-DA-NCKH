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
    public class DM_HOCHAMController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_HOCHAM
        public IQueryable<DM_HOCHAM> GetDM_HOCHAM()
        {
            return db.DM_HOCHAM;
        }

        // GET: api/DM_HOCHAM/5
        [ResponseType(typeof(DM_HOCHAM))]
        public IHttpActionResult GetDM_HOCHAM(int id)
        {
            DM_HOCHAM dM_HOCHAM = db.DM_HOCHAM.Find(id);
            if (dM_HOCHAM == null)
            {
                return NotFound();
            }

            return Ok(dM_HOCHAM);
        }

        // PUT: api/DM_HOCHAM/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_HOCHAM(int id, DM_HOCHAM dM_HOCHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_HOCHAM.IDHocHam)
            {
                return BadRequest();
            }

            db.Entry(dM_HOCHAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_HOCHAMExists(id))
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

        // POST: api/DM_HOCHAM
        [ResponseType(typeof(DM_HOCHAM))]
        public IHttpActionResult PostDM_HOCHAM(DM_HOCHAM dM_HOCHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_HOCHAM.Add(dM_HOCHAM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_HOCHAM.IDHocHam }, dM_HOCHAM);
        }

        // DELETE: api/DM_HOCHAM/5
        [ResponseType(typeof(DM_HOCHAM))]
        public IHttpActionResult DeleteDM_HOCHAM(int id)
        {
            DM_HOCHAM dM_HOCHAM = db.DM_HOCHAM.Find(id);
            if (dM_HOCHAM == null)
            {
                return NotFound();
            }

            db.DM_HOCHAM.Remove(dM_HOCHAM);
            db.SaveChanges();

            return Ok(dM_HOCHAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_HOCHAMExists(int id)
        {
            return db.DM_HOCHAM.Count(e => e.IDHocHam == id) > 0;
        }
    }
}