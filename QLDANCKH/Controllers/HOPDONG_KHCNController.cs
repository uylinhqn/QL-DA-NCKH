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
    public class HOPDONG_KHCNController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/HOPDONG_KHCN
        public ObjectResult<Proc_HOPDONG_KHCN_Select_2_Result> GetHOPDONG_KHCN()
        {
            return db.Proc_HOPDONG_KHCN_Select_2();
        }

        // GET: api/HOPDONG_KHCN/5
        [ResponseType(typeof(HOPDONG_KHCN))]
        public ObjectResult<Proc_HOPDONG_KHCN_SelectPK3_Result> GetHOPDONG_KHCN(int id)
        {
            return db.Proc_HOPDONG_KHCN_SelectPK3(id);
        }

        public class HDNT
        {
            public HDNT() { }
            public int ID { get; set; }
            public Nullable<int> IdNV { get; set; }
            public string DonVi { get; set; }
            public string DiaChi { get; set; }
            public string DanhMucTaiLieu { get; set; }
            public string FileHS { get; set; }
            public Nullable<bool> Trangthai { get; set; }
            public string TenHoSo { get; set; }
            public string SoHoSo { get; set; }
            public Nullable<int> PDHoSo { get; set; }
            public int IDHD { get; set; }
            public Nullable<int> IdHoSoDK { get; set; }
            public string TenHD { get; set; }
            public string FileHD { get; set; }
            public string FileNT { get; set; }
            public Nullable<decimal> TongKinhPhi { get; set; }
            public Nullable<System.DateTime> NgayLap { get; set; }
            public Nullable<System.DateTime> NgayKetThuc { get; set; }
            public string NguoiLap { get; set; }
            public string SoHD { get; set; }
        }
        public class HDNTGH
        {
            public HDNTGH() { }
            public int ID { get; set; }
            public Nullable<int> IdNV { get; set; }
            public string DonVi { get; set; }
            public string DiaChi { get; set; }
            public string DanhMucTaiLieu { get; set; }
            public string FileHS { get; set; }
            public Nullable<bool> Trangthai { get; set; }
            public string TenHoSo { get; set; }
            public string SoHoSo { get; set; }
            public Nullable<int> PDHoSo { get; set; }
            public int IDHD { get; set; }
            public Nullable<int> IdHoSoDK { get; set; }
            public string TenHD { get; set; }
            public string FileHD { get; set; }
            public string FileNT { get; set; }
            public string DonGiaHan { get; set; }
            public string FilePheDuyet { get; set; }
            public Nullable<decimal> TongKinhPhi { get; set; }
            public Nullable<System.DateTime> NgayLap { get; set; }
            public Nullable<System.DateTime> NgayKetThuc { get; set; }
            public string NguoiLap { get; set; }
            public string SoHD { get; set; }
        }
        public List<HDNT> GetHOPDONG_KHCNx(int idx)
        {
            var l1 = db.Proc_HOPDONG_KHCN_SelectPK3(idx).ToList();
            var l2 = db.Proc_NGHIEMTHU_HOPDONG_Select_NT(idx).ToList();
            if (l2.Count > 0)
            {
                var resultsum = l1.Join(l2,
                 b1 => b1.ID,
                 b2 => b2.IdHD,
                 (b1, b2) => new
                 {
                     b1.ID,
                     b1.IdNV,
                     b1.DonVi,
                     b1.DiaChi,
                     b1.DanhMucTaiLieu,
                     b1.FileHS,
                     b1.Trangthai,
                     b1.TenHoSo,
                     b1.SoHoSo,
                     b1.PDHoSo,
                     b1.IDHD,
                     b1.IdHoSoDK,
                     b1.TenHD,
                     b1.FileHD,
                     b2.HoSoNghiemThu,
                     b1.TongKinhPhi,
                     b1.NgayLap,
                     b1.NgayKetThuc,
                     b1.NguoiLap,
                     b1.SoHD
                 }
               );
                List<HDNT> hds = new List<HDNT>();
                foreach (var item in resultsum)
                {
                    hds.Add(new HDNT
                    {
                        ID = item.ID,
                        IdNV = item.IdNV,
                        DonVi = item.DonVi,
                        DiaChi = item.DiaChi,
                        DanhMucTaiLieu = item.DanhMucTaiLieu,
                        FileHS = item.FileHS,
                        Trangthai = item.Trangthai,
                        TenHoSo = item.TenHoSo,
                        SoHoSo = item.SoHoSo,
                        PDHoSo = item.PDHoSo,
                        IDHD = item.IDHD,
                        IdHoSoDK = item.IdHoSoDK,
                        TenHD = item.TenHD,
                        FileHD = item.FileHD,
                        FileNT = item.HoSoNghiemThu,
                        TongKinhPhi = item.TongKinhPhi,
                        NgayLap = item.NgayLap,
                        NgayKetThuc = item.NgayKetThuc,
                        NguoiLap = item.NguoiLap,
                        SoHD = item.SoHD
                    });
                }
                return hds;
            }
            else { List<HDNT> hds = new List<HDNT>();
                foreach (var item in l1)
                {
                    hds.Add(new HDNT { ID=item.ID,
                     IdNV= item.IdNV,
                     DonVi= item.DonVi,
                     DiaChi= item.DiaChi,
                     DanhMucTaiLieu= item.DanhMucTaiLieu,
                     FileHS= item.FileHS,
                     Trangthai= item.Trangthai,
                     TenHoSo= item.TenHoSo,
                     SoHoSo= item.SoHoSo,
                     PDHoSo= item.PDHoSo,
                     IDHD= item.IDHD,
                     IdHoSoDK= item.IdHoSoDK,
                     TenHD= item.TenHD,
                     FileHD= item.FileHD,
                     FileNT = "",
                     TongKinhPhi= item.TongKinhPhi,
                     NgayLap= item.NgayLap,
                     NgayKetThuc= item.NgayKetThuc,
                     NguoiLap= item.NguoiLap,
                     SoHD= item.SoHD});
                }return hds;
            }
        }
        public List<HDNTGH> GetHOPDONG_KHCNxgh(int idxgh)
        {
            var l1 = db.Proc_HOPDONG_KHCN_SelectPK3(idxgh).ToList();
            var l2 = db.Proc_GIAHAN_HOPDONG_Select_NT(idxgh).ToList();
            if (l2.Count > 0)
            {
                var resultsum = l1.Join(l2,
                 b1 => b1.ID,
                 b2 => b2.IdHD,
                 (b1, b2) => new
                 {
                     b1.ID,
                     b1.IdNV,
                     b1.DonVi,
                     b1.DiaChi,
                     b1.DanhMucTaiLieu,
                     b1.FileHS,
                     b1.Trangthai,
                     b1.TenHoSo,
                     b1.SoHoSo,
                     b1.PDHoSo,
                     b1.IDHD,
                     b1.IdHoSoDK,
                     b1.TenHD,
                     b1.FileHD,
                     b2.DonGiaHan,
                     b2.Id,
                     b2.FilePheduyet,
                     b1.TongKinhPhi,
                     b1.NgayLap,
                     b1.NgayKetThuc,
                     b1.NguoiLap,
                     b1.SoHD
                 }
               );
                List<HDNTGH> hds = new List<HDNTGH>();
                foreach (var item in resultsum)
                {
                    hds.Add(new HDNTGH
                    {
                        ID = item.ID,
                        IdNV = item.IdNV,
                        DonVi = item.DonVi,
                        DiaChi = item.DiaChi,
                        DanhMucTaiLieu = item.DanhMucTaiLieu,
                        FileHS = item.FileHS,
                        Trangthai = item.Trangthai,
                        TenHoSo = item.TenHoSo,
                        SoHoSo = item.SoHoSo,
                        PDHoSo = item.PDHoSo,
                        IDHD = item.IDHD,
                        IdHoSoDK = item.IdHoSoDK,
                        TenHD = item.TenHD,
                        FileHD = item.FileHD,
                        DonGiaHan = item.DonGiaHan,
                        FilePheDuyet = item.FilePheduyet,
                        TongKinhPhi = item.TongKinhPhi,
                        NgayLap = item.NgayLap,
                        NgayKetThuc = item.NgayKetThuc,
                        NguoiLap = item.NguoiLap,
                        SoHD = item.SoHD
                    });
                }
                return hds;
            }
            else
            {
                List<HDNTGH> hds = new List<HDNTGH>();
                foreach (var item in l1)
                {
                    hds.Add(new HDNTGH
                    {
                        ID = item.ID,
                        IdNV = item.IdNV,
                        DonVi = item.DonVi,
                        DiaChi = item.DiaChi,
                        DanhMucTaiLieu = item.DanhMucTaiLieu,
                        FileHS = item.FileHS,
                        Trangthai = item.Trangthai,
                        TenHoSo = item.TenHoSo,
                        SoHoSo = item.SoHoSo,
                        PDHoSo = item.PDHoSo,
                        IDHD = item.IDHD,
                        IdHoSoDK = item.IdHoSoDK,
                        TenHD = item.TenHD,
                        FileHD = item.FileHD,
                        DonGiaHan = "",
                        FilePheDuyet = "",
                        TongKinhPhi = item.TongKinhPhi,
                        NgayLap = item.NgayLap,
                        NgayKetThuc = item.NgayKetThuc,
                        NguoiLap = item.NguoiLap,
                        SoHD = item.SoHD
                    });
                }
                return hds;
            }
        }
        public ObjectResult<Proc_HOPDONG_KHCN_SelectPK_HD_Result> GetHOPDONG_KHCNSU(int idsu)
        {
            return db.Proc_HOPDONG_KHCN_SelectPK_HD(idsu);
        }

        //[HttpGet]
        //[Route("api/DATHANGBYTINH")]
        //public IQueryable<HDNT> GetHOPDONGKHOAHOCBYNAM()
        //{
            
        //    return db.HOPDONG_KHCN.Where(p => p.NgayLap == "Tỉnh");


        //}

        // PUT: api/HOPDONG_KHCN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHOPDONG_KHCN(int id, HOPDONG_KHCN HOPDONG_KHCN)
        {
            db.Proc_HOPDONG_KHCN_Update(id, HOPDONG_KHCN.TenHD, HOPDONG_KHCN.FileHD, HOPDONG_KHCN.TongKinhPhi, HOPDONG_KHCN.NgayLap, HOPDONG_KHCN.NgayKetThuc, HOPDONG_KHCN.SoHD);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HOPDONG_KHCN
        [ResponseType(typeof(HOPDONG_KHCN))]
        public IHttpActionResult PostHOPDONG_KHCN(HOPDONG_KHCN HOPDONG_KHCN)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_HOPDONG_KHCN_Insert(HOPDONG_KHCN.IdHoSoDK, HOPDONG_KHCN.DonVi, HOPDONG_KHCN.DiaChi, HOPDONG_KHCN.TenHD, HOPDONG_KHCN.FileHD, HOPDONG_KHCN.TongKinhPhi, HOPDONG_KHCN.NgayLap, HOPDONG_KHCN.NgayKetThuc, false, identity.Name, HOPDONG_KHCN.SoHD);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/HOPDONG_KHCN/5
        [ResponseType(typeof(HOPDONG_KHCN))]
        public IHttpActionResult DeleteHOPDONG_KHCN(int id)
        {
            db.Proc_HOPDONG_KHCN_Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: api/HOPDONG_KHCN
        [Authorize(Roles = "admin, member, client")]
        [HttpGet]
        [Route("api/hopdongkhcnbynam")]
        public ObjectResult<Proc_HOPDONGKHCNBYNAM_Result> GetHOPDONGKHCNBYNAM(int nam)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return db.Proc_HOPDONGKHCNBYNAM(identity.Name, nam);
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