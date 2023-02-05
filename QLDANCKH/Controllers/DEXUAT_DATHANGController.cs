using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using QLDANCKH.Models;

namespace QLDANCKH.Controllers
{
    public class DEXUAT_DATHANGController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DEXUAT_DATHANG
        [Authorize(Roles = "admin, member, client")]
        [HttpGet]
        [Route("api/dsdathang")]
        public ObjectResult<Proc_DEXUAT_DATHANG_Select_Result> GetDEXUAT_DATHANG_DS()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return db.Proc_DEXUAT_DATHANG_Select(identity.Name);
        }
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
        [Authorize(Roles = "admin, member, client")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDEXUAT_DATHANG(int id, DEXUAT_DATHANG dEXUAT_DATHANG)
        {
            db.Proc_DEXUAT_DATHANG_Update(id, dEXUAT_DATHANG.Tendexuat, dEXUAT_DATHANG.Noidungdexuat, dEXUAT_DATHANG.NamDeXuat, dEXUAT_DATHANG.CapDeXuat, dEXUAT_DATHANG.LinkTaiLieu, dEXUAT_DATHANG.IdLinhVucNC, dEXUAT_DATHANG.IdLinhVucNV);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DEXUAT_DATHANG
        [Authorize(Roles = "admin, member, client")]
        [HttpPost]
        [ResponseType(typeof(DEXUAT_DATHANG))]
        public IHttpActionResult PostDEXUAT_DATHANG(DEXUAT_DATHANG dEXUAT_DATHANG)
        {
            var identity = (ClaimsIdentity)User.Identity;
             db.Proc_DEXUAT_DATHANG_Insert(dEXUAT_DATHANG.Tendexuat, dEXUAT_DATHANG.Noidungdexuat,dEXUAT_DATHANG.NamDeXuat, dEXUAT_DATHANG.CapDeXuat, dEXUAT_DATHANG.TrangthaiPD, dEXUAT_DATHANG.LinkTaiLieu, identity.Name, dEXUAT_DATHANG.IdLinhVucNC, dEXUAT_DATHANG.IdLinhVucNV);
             return StatusCode(HttpStatusCode.NoContent);
            
        }

        // DELETE: api/DEXUAT_DATHANG/5

        [Authorize(Roles = "admin, member, client")]
        [HttpDelete]
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