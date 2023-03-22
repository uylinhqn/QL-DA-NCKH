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
    public class DM_CHUNHIEMController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_CHUNHIEM
        public IQueryable<DM_CHUNHIEM> GetDM_CHUNHIEM()
        {
            return db.DM_CHUNHIEM;
        }

        // GET: api/DM_CHUNHIEM/5
        [ResponseType(typeof(DM_CHUNHIEM))]
        public IHttpActionResult GetDM_CHUNHIEM(int id)
        {
            DM_CHUNHIEM dM_CHUNHIEM = db.DM_CHUNHIEM.Find(id);
            if (dM_CHUNHIEM == null)
            {
                return NotFound();
            }

            return Ok(dM_CHUNHIEM);
        }

        // PUT: api/DM_CHUNHIEM/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_CHUNHIEM(int id, DM_CHUNHIEM dM_CHUNHIEM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_CHUNHIEM.ChuNhiemID)
            {
                return BadRequest();
            }

            db.Entry(dM_CHUNHIEM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_CHUNHIEMExists(id))
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

        // POST: api/DM_CHUNHIEM
        [ResponseType(typeof(DM_CHUNHIEM))]
        public IHttpActionResult PostDM_CHUNHIEM(DM_CHUNHIEM dM_CHUNHIEM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_CHUNHIEM.Add(dM_CHUNHIEM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_CHUNHIEM.ChuNhiemID }, dM_CHUNHIEM);
        }

        // DELETE: api/DM_CHUNHIEM/5
        [ResponseType(typeof(DM_CHUNHIEM))]
        public IHttpActionResult DeleteDM_CHUNHIEM(int id)
        {
            DM_CHUNHIEM dM_CHUNHIEM = db.DM_CHUNHIEM.Find(id);
            if (dM_CHUNHIEM == null)
            {
                return NotFound();
            }

            db.DM_CHUNHIEM.Remove(dM_CHUNHIEM);
            db.SaveChanges();

            return Ok(dM_CHUNHIEM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_CHUNHIEMExists(int id)
        {
            return db.DM_CHUNHIEM.Count(e => e.ChuNhiemID == id) > 0;
        }
    }
}