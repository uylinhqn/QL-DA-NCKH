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
    public class TIEUCHI_DANHGIAController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/TIEUCHI_DANHGIA
        public IQueryable<TIEUCHI_DANHGIA> GetTIEUCHI_DANHGIA()
        {
            return db.TIEUCHI_DANHGIA;
        }

        // GET: api/TIEUCHI_DANHGIA/5
        [ResponseType(typeof(TIEUCHI_DANHGIA))]
        public IHttpActionResult GetTIEUCHI_DANHGIA(int id)
        {
            TIEUCHI_DANHGIA tIEUCHI_DANHGIA = db.TIEUCHI_DANHGIA.Find(id);
            if (tIEUCHI_DANHGIA == null)
            {
                return NotFound();
            }

            return Ok(tIEUCHI_DANHGIA);
        }

        // PUT: api/TIEUCHI_DANHGIA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIEUCHI_DANHGIA(int id, TIEUCHI_DANHGIA tIEUCHI_DANHGIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIEUCHI_DANHGIA.IDTieuchi)
            {
                return BadRequest();
            }

            db.Entry(tIEUCHI_DANHGIA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIEUCHI_DANHGIAExists(id))
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

        // POST: api/TIEUCHI_DANHGIA
        [ResponseType(typeof(TIEUCHI_DANHGIA))]
        public IHttpActionResult PostTIEUCHI_DANHGIA(TIEUCHI_DANHGIA tIEUCHI_DANHGIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIEUCHI_DANHGIA.Add(tIEUCHI_DANHGIA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tIEUCHI_DANHGIA.IDTieuchi }, tIEUCHI_DANHGIA);
        }

        // DELETE: api/TIEUCHI_DANHGIA/5
        [ResponseType(typeof(TIEUCHI_DANHGIA))]
        public IHttpActionResult DeleteTIEUCHI_DANHGIA(int id)
        {
            TIEUCHI_DANHGIA tIEUCHI_DANHGIA = db.TIEUCHI_DANHGIA.Find(id);
            if (tIEUCHI_DANHGIA == null)
            {
                return NotFound();
            }

            db.TIEUCHI_DANHGIA.Remove(tIEUCHI_DANHGIA);
            db.SaveChanges();

            return Ok(tIEUCHI_DANHGIA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIEUCHI_DANHGIAExists(int id)
        {
            return db.TIEUCHI_DANHGIA.Count(e => e.IDTieuchi == id) > 0;
        }
    }
}