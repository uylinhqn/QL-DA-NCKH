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
    public class DM_LINHVUC_NGHIENCUUController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_LINHVUC_NGHIENCUU
        public IQueryable<DM_LINHVUC_NGHIENCUU> GetDM_LINHVUC_NGHIENCUU()
        {
            return db.DM_LINHVUC_NGHIENCUU;
        }

        // GET: api/DM_LINHVUC_NGHIENCUU/5
        [ResponseType(typeof(DM_LINHVUC_NGHIENCUU))]
        public IHttpActionResult GetDM_LINHVUC_NGHIENCUU(int id)
        {
            DM_LINHVUC_NGHIENCUU dM_LINHVUC_NGHIENCUU = db.DM_LINHVUC_NGHIENCUU.Find(id);
            if (dM_LINHVUC_NGHIENCUU == null)
            {
                return NotFound();
            }

            return Ok(dM_LINHVUC_NGHIENCUU);
        }

        // PUT: api/DM_LINHVUC_NGHIENCUU/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_LINHVUC_NGHIENCUU(int id, DM_LINHVUC_NGHIENCUU dM_LINHVUC_NGHIENCUU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_LINHVUC_NGHIENCUU.IDLinhvuc)
            {
                return BadRequest();
            }

            db.Entry(dM_LINHVUC_NGHIENCUU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_LINHVUC_NGHIENCUUExists(id))
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

        // POST: api/DM_LINHVUC_NGHIENCUU
        [ResponseType(typeof(DM_LINHVUC_NGHIENCUU))]
        public IHttpActionResult PostDM_LINHVUC_NGHIENCUU(DM_LINHVUC_NGHIENCUU dM_LINHVUC_NGHIENCUU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_LINHVUC_NGHIENCUU.Add(dM_LINHVUC_NGHIENCUU);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_LINHVUC_NGHIENCUU.IDLinhvuc }, dM_LINHVUC_NGHIENCUU);
        }

        // DELETE: api/DM_LINHVUC_NGHIENCUU/5
        [ResponseType(typeof(DM_LINHVUC_NGHIENCUU))]
        public IHttpActionResult DeleteDM_LINHVUC_NGHIENCUU(int id)
        {
            DM_LINHVUC_NGHIENCUU dM_LINHVUC_NGHIENCUU = db.DM_LINHVUC_NGHIENCUU.Find(id);
            if (dM_LINHVUC_NGHIENCUU == null)
            {
                return NotFound();
            }

            db.DM_LINHVUC_NGHIENCUU.Remove(dM_LINHVUC_NGHIENCUU);
            db.SaveChanges();

            return Ok(dM_LINHVUC_NGHIENCUU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_LINHVUC_NGHIENCUUExists(int id)
        {
            return db.DM_LINHVUC_NGHIENCUU.Count(e => e.IDLinhvuc == id) > 0;
        }
    }
}