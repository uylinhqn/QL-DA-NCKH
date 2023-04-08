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
    public class TAMUNGKINHPHI_HOPDONG_KHCNController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();
        public class TamUng
        {
            public int ID { get; set; }
            public Nullable<int> IdHoSoDK { get; set; }
            public string DonVi { get; set; }
            public string DiaChi { get; set; }
            public string TenHD { get; set; }
            public string FileHD { get; set; }
            public Nullable<decimal> TongKinhPhi { get; set; }
            public Nullable<System.DateTime> NgayLap { get; set; }
            public Nullable<System.DateTime> NgayKetThuc { get; set; }
            public Nullable<bool> TrangThai { get; set; }
            public string NguoiLap { get; set; }
            public string SoHD { get; set; }
            public decimal? TienTamUng { get; set; }
        }
        // GET: api/TAMUNGKINHPHI_HOPDONG_KHCN
        public List<TamUng> GetTAMUNGKINHPHI_HOPDONG_KHCN()
        {
            List<TamUng> dt = new List<TamUng>();
               var lhd = db.Proc_HOPDONG_KHCN_Select_2().ToList();
            foreach (var item in lhd)
            {
                decimal? sotien = db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Selete_HD(item.ID).ToList()[0];
                dt.Add(new TamUng { ID = item.ID, IdHoSoDK = item.IdHoSoDK, DonVi = item.DonVi, DiaChi = item.DiaChi, TenHD = item.TenHD, FileHD = item.FileHD, TongKinhPhi = item.TongKinhPhi, NgayLap = item.NgayLap, NgayKetThuc = item.NgayKetThuc, TrangThai = item.TrangThai, NguoiLap = item.NguoiLap, SoHD = item.SoHD, TienTamUng = sotien });
            }
            return dt;
        }

        // GET: api/TAMUNGKINHPHI_HOPDONG_KHCN/5
        [ResponseType(typeof(TAMUNGKINHPHI_HOPDONG_KHCN))]
        public ObjectResult<Proc_TAMUNGKINHPHI_HOPDONG_KHCN_SeletePK2_Result> GetTAMUNGKINHPHI_HOPDONG_KHCN(int id)
        {
            return db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_SeletePK2(id);
        }
        public ObjectResult<Proc_TAMUNGKINHPHI_HOPDONG_KHCN_SeletePK2_HD_Result> GetTAMUNGKINHPHI_HOPDONG_KHCN_THD(int idsu)
        {
            return db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_SeletePK2_HD(idsu);
        }

        // PUT: api/TAMUNGKINHPHI_HOPDONG_KHCN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTAMUNGKINHPHI_HOPDONG_KHCN(int id, TAMUNGKINHPHI_HOPDONG_KHCN TAMUNGKINHPHI_HOPDONG_KHCN)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Update(id, TAMUNGKINHPHI_HOPDONG_KHCN.IdHDKHCN, TAMUNGKINHPHI_HOPDONG_KHCN.FileHD, TAMUNGKINHPHI_HOPDONG_KHCN.SoTien,  TAMUNGKINHPHI_HOPDONG_KHCN.NgayLap, identity.Name, TAMUNGKINHPHI_HOPDONG_KHCN.NoiDung);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TAMUNGKINHPHI_HOPDONG_KHCN
        [ResponseType(typeof(TAMUNGKINHPHI_HOPDONG_KHCN))]
        public IHttpActionResult PostTAMUNGKINHPHI_HOPDONG_KHCN(TAMUNGKINHPHI_HOPDONG_KHCN TAMUNGKINHPHI_HOPDONG_KHCN)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Insert(TAMUNGKINHPHI_HOPDONG_KHCN.IdHDKHCN, TAMUNGKINHPHI_HOPDONG_KHCN.FileHD, TAMUNGKINHPHI_HOPDONG_KHCN.SoTien, TAMUNGKINHPHI_HOPDONG_KHCN.NgayLap,identity.Name, TAMUNGKINHPHI_HOPDONG_KHCN.NoiDung);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/TAMUNGKINHPHI_HOPDONG_KHCN/5
        [ResponseType(typeof(TAMUNGKINHPHI_HOPDONG_KHCN))]
        public IHttpActionResult DeleteTAMUNGKINHPHI_HOPDONG_KHCN(int id)
        {
            db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}