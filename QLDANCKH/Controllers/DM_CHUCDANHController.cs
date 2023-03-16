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
    public class DM_CHUCDANHController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DM_CHUCDANH
        public IQueryable<DM_CHUCDANH> GetDM_CHUCDANH()
        {
            return db.DM_CHUCDANH;
        }

        // GET: api/DM_CHUCDANH/5
        [ResponseType(typeof(DM_CHUCDANH))]
        public IHttpActionResult GetDM_CHUCDANH(int id)
        {
            DM_CHUCDANH dM_CHUCDANH = db.DM_CHUCDANH.Find(id);
            if (dM_CHUCDANH == null)
            {
                return NotFound();
            }

            return Ok(dM_CHUCDANH);
        }

        // PUT: api/DM_CHUCDANH/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_CHUCDANH(int id, DM_CHUCDANH dM_CHUCDANH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_CHUCDANH.IDChucDanh)
            {
                return BadRequest();
            }

            db.Entry(dM_CHUCDANH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_CHUCDANHExists(id))
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

        // POST: api/DM_CHUCDANH
        [ResponseType(typeof(DM_CHUCDANH))]
        public IHttpActionResult PostDM_CHUCDANH(DM_CHUCDANH dM_CHUCDANH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_CHUCDANH.Add(dM_CHUCDANH);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dM_CHUCDANH.IDChucDanh }, dM_CHUCDANH);
        }

        // DELETE: api/DM_CHUCDANH/5
        [ResponseType(typeof(DM_CHUCDANH))]
        public IHttpActionResult DeleteDM_CHUCDANH(int id)
        {
            DM_CHUCDANH dM_CHUCDANH = db.DM_CHUCDANH.Find(id);
            if (dM_CHUCDANH == null)
            {
                return NotFound();
            }

            db.DM_CHUCDANH.Remove(dM_CHUCDANH);
            db.SaveChanges();

            return Ok(dM_CHUCDANH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_CHUCDANHExists(int id)
        {
            return db.DM_CHUCDANH.Count(e => e.IDChucDanh == id) > 0;
        }
    }
}