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
    public class HOPDONG_KHCNController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/HOPDONG_KHCN
        public ObjectResult<Proc_HOPDONG_KHCN_Select_Result> GetHOPDONG_KHCN()
        {
            return db.Proc_HOPDONG_KHCN_Select();
        }

        // GET: api/HOPDONG_KHCN/5
        [ResponseType(typeof(HOPDONG_KHCN))]
        public ObjectResult<Proc_HOPDONG_KHCN_SelectPK_Result> GetHOPDONG_KHCN(int id)
        {
            return db.Proc_HOPDONG_KHCN_SelectPK(id);
        }

        // PUT: api/HOPDONG_KHCN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHOPDONG_KHCN(int id, HOPDONG_KHCN HOPDONG_KHCN)
        {
            db.Proc_HOPDONG_KHCN_Update(id, HOPDONG_KHCN.IdHoSoDK, HOPDONG_KHCN.DonVi, HOPDONG_KHCN.DiaChi, HOPDONG_KHCN.TenHD, HOPDONG_KHCN.FileHD, HOPDONG_KHCN.TongKinhPhi, HOPDONG_KHCN.NgayLap, HOPDONG_KHCN.NgayKetThuc, HOPDONG_KHCN.TrangThai, HOPDONG_KHCN.NguoiLap);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HOPDONG_KHCN
        [ResponseType(typeof(HOPDONG_KHCN))]
        public IHttpActionResult PostHOPDONG_KHCN(HOPDONG_KHCN HOPDONG_KHCN)
        {
            db.Proc_HOPDONG_KHCN_Insert(HOPDONG_KHCN.IdHoSoDK, HOPDONG_KHCN.DonVi, HOPDONG_KHCN.DiaChi, HOPDONG_KHCN.TenHD, HOPDONG_KHCN.FileHD, HOPDONG_KHCN.TongKinhPhi, HOPDONG_KHCN.NgayLap, HOPDONG_KHCN.NgayKetThuc, HOPDONG_KHCN.TrangThai, HOPDONG_KHCN.NguoiLap);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/HOPDONG_KHCN/5
        [ResponseType(typeof(HOPDONG_KHCN))]
        public IHttpActionResult DeleteHOPDONG_KHCN(int id)
        {
            db.Proc_HOPDONG_KHCN_Delete(id);
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