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
    public class DM_CHUCVUController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_CHUCVU
        public IQueryable<DM_CHUCVU> GetDM_CHUCVU()
        {
            return db.DM_CHUCVU;
        }

        // GET: api/DM_CHUCVU/5
        [ResponseType(typeof(DM_CHUCVU))]
        public IHttpActionResult GetDM_CHUCVU(int id)
        {
            DM_CHUCVU dM_CHUCVU = db.DM_CHUCVU.Find(id);
            if (dM_CHUCVU == null)
            {
                return NotFound();
            }

            return Ok(dM_CHUCVU);
        }

        // PUT: api/DM_CHUCVU/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_CHUCVU(int id, DM_CHUCVU dM_CHUCVU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_CHUCVU.IDChucVu)
            {
                return BadRequest();
            }

            db.Entry(dM_CHUCVU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_CHUCVUExists(id))
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

        // POST: api/DM_CHUCVU
        [ResponseType(typeof(DM_CHUCVU))]
        public IHttpActionResult PostDM_CHUCVU(DM_CHUCVU dM_CHUCVU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_CHUCVU.Add(dM_CHUCVU);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_CHUCVU.IDChucVu }, dM_CHUCVU);
        }

        // DELETE: api/DM_CHUCVU/5
        [ResponseType(typeof(DM_CHUCVU))]
        public IHttpActionResult DeleteDM_CHUCVU(int id)
        {
            DM_CHUCVU dM_CHUCVU = db.DM_CHUCVU.Find(id);
            if (dM_CHUCVU == null)
            {
                return NotFound();
            }

            db.DM_CHUCVU.Remove(dM_CHUCVU);
            db.SaveChanges();

            return Ok(dM_CHUCVU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_CHUCVUExists(int id)
        {
            return db.DM_CHUCVU.Count(e => e.IDChucVu == id) > 0;
        }
    }
}