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
    public class DM_LINHVUC_NHIEMVUController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_LINHVUC_NHIEMVU
        public IQueryable<DM_LINHVUC_NHIEMVU> GetDM_LINHVUC_NHIEMVU()
        {
            return db.DM_LINHVUC_NHIEMVU;
        }

        // GET: api/DM_LINHVUC_NHIEMVU/5
        [ResponseType(typeof(DM_LINHVUC_NHIEMVU))]
        public IHttpActionResult GetDM_LINHVUC_NHIEMVU(int id)
        {
            DM_LINHVUC_NHIEMVU dM_LINHVUC_NHIEMVU = db.DM_LINHVUC_NHIEMVU.Find(id);
            if (dM_LINHVUC_NHIEMVU == null)
            {
                return NotFound();
            }

            return Ok(dM_LINHVUC_NHIEMVU);
        }

        // PUT: api/DM_LINHVUC_NHIEMVU/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_LINHVUC_NHIEMVU(int id, DM_LINHVUC_NHIEMVU dM_LINHVUC_NHIEMVU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_LINHVUC_NHIEMVU.IDLinhvucNhiemvu)
            {
                return BadRequest();
            }

            db.Entry(dM_LINHVUC_NHIEMVU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_LINHVUC_NHIEMVUExists(id))
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

        // POST: api/DM_LINHVUC_NHIEMVU
        [ResponseType(typeof(DM_LINHVUC_NHIEMVU))]
        public IHttpActionResult PostDM_LINHVUC_NHIEMVU(DM_LINHVUC_NHIEMVU dM_LINHVUC_NHIEMVU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_LINHVUC_NHIEMVU.Add(dM_LINHVUC_NHIEMVU);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_LINHVUC_NHIEMVU.IDLinhvucNhiemvu }, dM_LINHVUC_NHIEMVU);
        }

        // DELETE: api/DM_LINHVUC_NHIEMVU/5
        [ResponseType(typeof(DM_LINHVUC_NHIEMVU))]
        public IHttpActionResult DeleteDM_LINHVUC_NHIEMVU(int id)
        {
            DM_LINHVUC_NHIEMVU dM_LINHVUC_NHIEMVU = db.DM_LINHVUC_NHIEMVU.Find(id);
            if (dM_LINHVUC_NHIEMVU == null)
            {
                return NotFound();
            }

            db.DM_LINHVUC_NHIEMVU.Remove(dM_LINHVUC_NHIEMVU);
            db.SaveChanges();

            return Ok(dM_LINHVUC_NHIEMVU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_LINHVUC_NHIEMVUExists(int id)
        {
            return db.DM_LINHVUC_NHIEMVU.Count(e => e.IDLinhvucNhiemvu == id) > 0;
        }
    }
}