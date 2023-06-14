using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QLDANCKH.Models;

namespace QLDANCKH.Controllers
{
    public class HOSODANGKiesController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/HOSODANGKies
        public ObjectResult<Proc_HOSODANGKY_Select3_Result> GetHOSODANGKies()
        {
            return db.Proc_HOSODANGKY_Select3();
        }
        public ObjectResult<Proc_HOSODANGKY_Select_HSDat_Result> GetHOSODANGKiesDat(int loai)
        {
            return db.Proc_HOSODANGKY_Select_HSDat();
        }
        public ObjectResult<Proc_HOSODANGKY_Select_HSDat_CongNhan_Result> GetHOSODANGKiesDatCN(int loaicn)
        {
            return db.Proc_HOSODANGKY_Select_HSDat_CongNhan();
        }
        public ObjectResult<Proc_DEXUAT_DATHANG_SelectForHSDK_Result> GetHOSODANGKieChons(int ldk)
        {
            return db.Proc_DEXUAT_DATHANG_SelectForHSDK();
        }
        public class HSCN
        {
            public int ID { get; set; }
            public Nullable<int> IdNV { get; set; }
            public string DonVi { get; set; }
            public string DiaChi { get; set; }
            public string DanhMucTaiLieu { get; set; }
            public string FileHS { get; set; }
            public string FileHSCN { get; set; }
            public string FileQDCN { get; set; }
            public Nullable<bool> Trangthai { get; set; }
            public string TenHoSo { get; set; }
            public string SoHoSo { get; set; }
            public int IDDexuat { get; set; }
            public string Tendexuat { get; set; }
            public string Noidungdexuat { get; set; }
            public Nullable<int> NamDeXuat { get; set; }
            public string CapDeXuat { get; set; }
            public Nullable<bool> TrangthaiPD { get; set; }
            public string LinkTaiLieu { get; set; }
            public string NguoiDeXuat { get; set; }
            public string NguoiPheDuyet { get; set; }
            public Nullable<int> IdLinhVucNC { get; set; }
            public Nullable<int> IdLinhVucNV { get; set; }
            public Nullable<int> DonViThucHien { get; set; }
            public Nullable<bool> ChuyenGiao { get; set; }
            public Nullable<bool> NghiemThu { get; set; }
            public Nullable<System.DateTime> NgayDang { get; set; }
        }
        public List<HSCN> GetHOPDONG_KHCNx(int idx)
        {
            var l1 = db.Proc_HOSODANGKY_SelectPK_ChamDiem(idx).ToList();
            var l2 = db.Proc_CONGNHANKETQUA_Select_CN(idx).ToList();
            if (l2.Count > 0)
            {
                var resultsum = l1.Join(l2,
                 b1 => b1.ID,
                 b2 => b2.IdHSDK,
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
                     b1.IDDexuat,
                     b1.Tendexuat,
                     b1.Noidungdexuat,
                     b1.NamDeXuat,
                     b1.CapDeXuat,
                     b2.HoSoCongNhan,
                     b1.LinkTaiLieu,
                     b1.NguoiDeXuat,
                     b1.NguoiPheDuyet,
                     b1.IdLinhVucNC,
                     b1.IdLinhVucNV,
                     b1.DonViThucHien,
                     b1.ChuyenGiao,
                     b1.NghiemThu,
                     b1.NgayDang
                 }
               );
                List<HSCN> hds = new List<HSCN>();
                foreach (var item in resultsum)
                {
                    hds.Add(new HSCN
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
                        IDDexuat = item.IDDexuat,
                        Tendexuat = item.Tendexuat,
                        Noidungdexuat = item.Noidungdexuat,
                        CapDeXuat = item.CapDeXuat,
                        FileHSCN = item.HoSoCongNhan,
                        LinkTaiLieu = item.LinkTaiLieu,
                        NguoiDeXuat = item.NguoiDeXuat,
                        NguoiPheDuyet = item.NguoiPheDuyet,
                        IdLinhVucNC = item.IdLinhVucNC,
                        IdLinhVucNV = item.IdLinhVucNV,
                        DonViThucHien = item.DonViThucHien,
                        ChuyenGiao = item.ChuyenGiao,
                        NghiemThu = item.NghiemThu,
                        NgayDang = item.NgayDang
                    });
                }
                return hds;
            }
            else
            {
                List<HSCN> hds = new List<HSCN>();
                foreach (var item in l1)
                {
                    hds.Add(new HSCN
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
                        IDDexuat = item.IDDexuat,
                        Tendexuat = item.Tendexuat,
                        Noidungdexuat = item.Noidungdexuat,
                        CapDeXuat = item.CapDeXuat,
                        FileHSCN = "",
                        LinkTaiLieu = item.LinkTaiLieu,
                        NguoiDeXuat = item.NguoiDeXuat,
                        NguoiPheDuyet = item.NguoiPheDuyet,
                        IdLinhVucNC = item.IdLinhVucNC,
                        IdLinhVucNV = item.IdLinhVucNV,
                        DonViThucHien = item.DonViThucHien,
                        ChuyenGiao = item.ChuyenGiao,
                        NghiemThu = item.NghiemThu,
                        NgayDang = item.NgayDang
                    });
                }
                return hds;
            }
        }
        public List<HSCN> GetHOPDONG_KHCNPD(int idxpd)
        {
            var l1 = db.Proc_HOSODANGKY_SelectPK_ChamDiem(idxpd).ToList();
            var l2 = db.Proc_CONGNHANKETQUA_Select_CNPD(idxpd).ToList();
            if (l2.Count > 0)
            {
                var resultsum = l1.Join(l2,
                 b1 => b1.ID,
                 b2 => b2.IdHSDK,
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
                     b1.IDDexuat,
                     b1.Tendexuat,
                     b1.Noidungdexuat,
                     b1.NamDeXuat,
                     b1.CapDeXuat,
                     b2.HoSoCongNhan,
                     b2.HoSoPD,
                     b1.LinkTaiLieu,
                     b1.NguoiDeXuat,
                     b1.NguoiPheDuyet,
                     b1.IdLinhVucNC,
                     b1.IdLinhVucNV,
                     b1.DonViThucHien,
                     b1.ChuyenGiao,
                     b1.NghiemThu,
                     b1.NgayDang
                 }
               );
                List<HSCN> hds = new List<HSCN>();
                foreach (var item in resultsum)
                {
                    hds.Add(new HSCN
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
                        IDDexuat = item.IDDexuat,
                        Tendexuat = item.Tendexuat,
                        Noidungdexuat = item.Noidungdexuat,
                        CapDeXuat = item.CapDeXuat,
                        FileHSCN = item.HoSoCongNhan,
                        FileQDCN = item.HoSoPD,
                        LinkTaiLieu = item.LinkTaiLieu,
                        NguoiDeXuat = item.NguoiDeXuat,
                        NguoiPheDuyet = item.NguoiPheDuyet,
                        IdLinhVucNC = item.IdLinhVucNC,
                        IdLinhVucNV = item.IdLinhVucNV,
                        DonViThucHien = item.DonViThucHien,
                        ChuyenGiao = item.ChuyenGiao,
                        NghiemThu = item.NghiemThu,
                        NgayDang = item.NgayDang
                    });
                }
                return hds;
            }
            else
            {
                List<HSCN> hds = new List<HSCN>();
                foreach (var item in l1)
                {
                    hds.Add(new HSCN
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
                        IDDexuat = item.IDDexuat,
                        Tendexuat = item.Tendexuat,
                        Noidungdexuat = item.Noidungdexuat,
                        CapDeXuat = item.CapDeXuat,
                        FileHSCN = "",
                        FileQDCN = "",
                        LinkTaiLieu = item.LinkTaiLieu,
                        NguoiDeXuat = item.NguoiDeXuat,
                        NguoiPheDuyet = item.NguoiPheDuyet,
                        IdLinhVucNC = item.IdLinhVucNC,
                        IdLinhVucNV = item.IdLinhVucNV,
                        DonViThucHien = item.DonViThucHien,
                        ChuyenGiao = item.ChuyenGiao,
                        NghiemThu = item.NghiemThu,
                        NgayDang = item.NgayDang
                    });
                }
                return hds;
            }
        }
        // GET: api/HOSODANGKies/5
        [ResponseType(typeof(HOSODANGKY))]
        public ObjectResult<Proc_HOSODANGKY_SelectPK3_Result> GetHOSODANGKY(int id)
        {
            return db.Proc_HOSODANGKY_SelectPK3(id);
        }
        public ObjectResult<Proc_HOSODANGKY_SelectPK_ChamDiem_Result> GetHOSODANGKYcd(int idcd)
        {
            return db.Proc_HOSODANGKY_SelectPK_ChamDiem(idcd);
        }

        // PUT: api/HOSODANGKies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHOSODANGKY(int id, HOSODANGKY hOSODANGKY)
        {
            db.Proc_HOSODANGKY_Update(id, hOSODANGKY.IdNV, hOSODANGKY.DonVi, hOSODANGKY.DiaChi, hOSODANGKY.DanhMucTaiLieu, hOSODANGKY.FileHS, hOSODANGKY.Trangthai, hOSODANGKY.TenHoSo, hOSODANGKY.SoHoSo);
            return StatusCode(HttpStatusCode.NoContent);
        }
        public IHttpActionResult PutHOSODANGKYpheduyet(int hscd, int pdhs)
        {
            db.Proc_HOSODANGKY_Update_PheDuyet(hscd, pdhs);
            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: api/HOSODANGKies
        [ResponseType(typeof(HOSODANGKY))]
        public IHttpActionResult PostHOSODANGKY(HOSODANGKY hOSODANGKY)
        {
            db.Proc_HOSODANGKY_Insert(hOSODANGKY.IdNV, hOSODANGKY.DonVi, hOSODANGKY.DiaChi, hOSODANGKY.DanhMucTaiLieu, hOSODANGKY.FileHS, hOSODANGKY.Trangthai, hOSODANGKY.TenHoSo, hOSODANGKY.SoHoSo);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/HOSODANGKies/5
        [ResponseType(typeof(HOSODANGKY))]
        public IHttpActionResult DeleteHOSODANGKY(int id)
        {
            db.Proc_HOSODANGKY_Delete(id);
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

        private bool HOSODANGKYExists(int id)
        {
            return db.HOSODANGKies.Count(e => e.ID == id) > 0;
        }
    }
}