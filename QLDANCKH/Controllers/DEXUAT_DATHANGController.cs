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
    public class DEXUAT_DATHANGController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DEXUAT_DATHANG
        public IQueryable<DEXUAT_DATHANG> GetDEXUAT_DATHANG()
        {
            return db.DEXUAT_DATHANG.OrderByDescending(p=>p.NamDeXuat);
        }


        // GET: api/DEXUAT_DATHANG
        [HttpGet]
        [Route("api/DATHANGBYNHANUOC")]
        public IQueryable<DEXUAT_DATHANG> GetDEXUAT_DATHANGBYNHANUOC()
        {
          
                return db.DEXUAT_DATHANG.Where(p=>p.CapDeXuat =="Nhà nước");
            
               
        }

        // GET: api/DEXUAT_DATHANG
        [HttpGet]
        [Route("api/DATHANGBYNAM")]
        public IQueryable<DEXUAT_DATHANG> GetDEXUAT_DATHANGBYNAM()
        {

            return db.DEXUAT_DATHANG.OrderByDescending(P=> P.NamDeXuat);


        }

        [HttpGet]
        [Route("api/DATHANGBYTINH")]
        public IQueryable<DEXUAT_DATHANG> GetDEXUAT_DATHANGBYTINH()
        {

            return db.DEXUAT_DATHANG.Where(p => p.CapDeXuat == "Tỉnh");


        }

        // GET: api/DEXUAT_DATHANG/5
        [ResponseType(typeof(DEXUAT_DATHANG))]
        public IHttpActionResult GetDEXUAT_DATHANG(int id)
        {
            DEXUAT_DATHANG dEXUAT_DATHANG = db.DEXUAT_DATHANG.Find(id);
            if (dEXUAT_DATHANG == null)
            {
                return NotFound();
            }

            return Ok(dEXUAT_DATHANG);
        }

        // PUT: api/DEXUAT_DATHANG/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDEXUAT_DATHANG(int id, DEXUAT_DATHANG dEXUAT_DATHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dEXUAT_DATHANG.IDDexuat)
            {
                return BadRequest();
            }

            db.Entry(dEXUAT_DATHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEXUAT_DATHANGExists(id))
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

        // POST: api/DEXUAT_DATHANG
        [ResponseType(typeof(DEXUAT_DATHANG))]
        public IHttpActionResult PostDEXUAT_DATHANG(DEXUAT_DATHANG dEXUAT_DATHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DEXUAT_DATHANG.Add(dEXUAT_DATHANG);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dEXUAT_DATHANG.IDDexuat }, dEXUAT_DATHANG);
        }

        // DELETE: api/DEXUAT_DATHANG/5
        [ResponseType(typeof(DEXUAT_DATHANG))]
        public IHttpActionResult DeleteDEXUAT_DATHANG(int id)
        {
            DEXUAT_DATHANG dEXUAT_DATHANG = db.DEXUAT_DATHANG.Find(id);
            if (dEXUAT_DATHANG == null)
            {
                return NotFound();
            }

            db.DEXUAT_DATHANG.Remove(dEXUAT_DATHANG);
            db.SaveChanges();

            return Ok(dEXUAT_DATHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DEXUAT_DATHANGExists(int id)
        {
            return db.DEXUAT_DATHANG.Count(e => e.IDDexuat == id) > 0;
        }
    }
}