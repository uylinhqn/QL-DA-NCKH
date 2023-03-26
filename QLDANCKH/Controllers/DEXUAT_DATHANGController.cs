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
            return db.DEXUAT_DATHANG.OrderByDescending(p => p.NamDeXuat);
        }


        // GET: api/DEXUAT_DATHANG
        [Authorize(Roles = "admin, member, client")]
        [HttpGet]
        [Route("api/opt")]
        public ObjectResult<Proc_DEXUAT_DATHANG_Select_Option_Result> GetDEXUAT_DATHANGBYNHANUOC(int op)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return db.Proc_DEXUAT_DATHANG_Select_Option(identity.Name, op);
        }

        // GET: api/DEXUAT_DATHANG
        [Authorize(Roles = "admin, member, client")]
        [HttpGet]
        [Route("api/lv")]
        public ObjectResult<Proc_DEXUAT_DATHANG_Select_LvucNC_Result> GetDEXUAT_DATHANGBYLINHVUC(int lv)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return db.Proc_DEXUAT_DATHANG_Select_LvucNC(identity.Name, lv);
        }


        // GET: api/DEXUAT_DATHANG
        [Authorize(Roles = "admin, member, client")]
        [HttpGet]
        [Route("api/nam")]
        public ObjectResult<Proc_DEXUAT_DATHANG_Select_Nam_Result> GetDEXUAT_DATHANGBYNAM(int nam)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return db.Proc_DEXUAT_DATHANG_Select_Nam(identity.Name, nam);
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
        public class dspd
        {
            public int IDDexuat { get; set; }
            public string Tendexuat { get; set; }
            public string Noidungdexuat { get; set; }
            public Nullable<int> NamDeXuat { get; set; }
            public string CapDeXuat { get; set; }
            public Nullable<bool> TrangthaiPD { get; set; }
            public string LinkTaiLieu { get; set; }
            public string NguoiDeXuat { get; set; }
            public string NguoiPheDuyet { get; set; }
            public string TenLinhVucNC { get; set; }
            public string TenLinhVucNV { get; set; }
            public Nullable<int> DonViThucHien { get; set; }
            public Nullable<bool> ChuyenGiao { get; set; }
            public Nullable<bool> NghiemThu { get; set; }
            public string Quyetdinhpduyet { get; set; }
        }
        [HttpGet]
        [Route("api/pheduyet")]
        public List<dspd> GetDEXUAT_DATHANG_PD(int idv)
        {
            List<dspd> ds = new List<dspd>();
            var dx = db.Proc_DEXUAT_DATHANG_Select_PK(idv).ToList();
            var pd= db.Proc_PHEDUYET_DEXUAT_Select_DX(idv).ToList();
            if (pd.Count > 0)
            {
                ds.Add(new dspd
                {
                    IDDexuat = dx[0].IDDexuat,
                    Tendexuat = dx[0].Tendexuat,
                    Noidungdexuat = dx[0].Noidungdexuat,
                    NamDeXuat = dx[0].NamDeXuat,
                    CapDeXuat = dx[0].CapDeXuat,
                    TrangthaiPD = dx[0].TrangthaiPD,
                    LinkTaiLieu = dx[0].LinkTaiLieu,
                    NguoiDeXuat = dx[0].NguoiDeXuat,
                    NguoiPheDuyet = dx[0].NguoiPheDuyet,
                    TenLinhVucNC = dx[0].TenLinhVucNC,
                    TenLinhVucNV = dx[0].TenLinhVucNV,
                    DonViThucHien = dx[0].DonViThucHien,
                    ChuyenGiao = dx[0].ChuyenGiao,
                    NghiemThu = dx[0].NghiemThu,
                    Quyetdinhpduyet = pd[0].Quyetdinhpduyet
                });
            }
            else {
                ds.Add(new dspd
                {
                    IDDexuat = dx[0].IDDexuat,
                    Tendexuat = dx[0].Tendexuat,
                    Noidungdexuat = dx[0].Noidungdexuat,
                    NamDeXuat = dx[0].NamDeXuat,
                    CapDeXuat = dx[0].CapDeXuat,
                    TrangthaiPD = dx[0].TrangthaiPD,
                    LinkTaiLieu = dx[0].LinkTaiLieu,
                    NguoiDeXuat = dx[0].NguoiDeXuat,
                    NguoiPheDuyet = dx[0].NguoiPheDuyet,
                    TenLinhVucNC = dx[0].TenLinhVucNC,
                    TenLinhVucNV = dx[0].TenLinhVucNV,
                    DonViThucHien = dx[0].DonViThucHien,
                    ChuyenGiao = dx[0].ChuyenGiao,
                    NghiemThu = dx[0].NghiemThu,
                    Quyetdinhpduyet = ""
                });
            }
            return ds;
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