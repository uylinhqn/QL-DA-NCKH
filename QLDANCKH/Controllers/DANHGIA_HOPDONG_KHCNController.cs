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
    public class DANHGIA_HOPDONG_KHCNController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/DANHGIA_HOPDONG_KHCN
        public ObjectResult<Proc_DANHGIA_HOPDONG_KHCN_Select_Result> GetDANHGIA_HOPDONG_KHCN()
        {
            return db.Proc_DANHGIA_HOPDONG_KHCN_Select();
        }

        // GET: api/DANHGIA_HOPDONG_KHCN/5
        [ResponseType(typeof(DANHGIA_HOPDONG_KHCN))]
        public ObjectResult<Proc_DANHGIA_HOPDONG_KHCN_SelectPK_Result> GetDANHGIA_HOPDONG_KHCN(int id)
        {
            return db.Proc_DANHGIA_HOPDONG_KHCN_SelectPK(id);
        }

        // PUT: api/DANHGIA_HOPDONG_KHCN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDANHGIA_HOPDONG_KHCN(int id, DANHGIA_HOPDONG_KHCN DANHGIA_HOPDONG_KHCN)
        {
            db.Proc_DANHGIA_HOPDONG_KHCN_Update(id, DANHGIA_HOPDONG_KHCN.IdHDKHCN, DANHGIA_HOPDONG_KHCN.TieuDeDanhGia, DANHGIA_HOPDONG_KHCN.NoiDung, DANHGIA_HOPDONG_KHCN.FileDanhGia, DANHGIA_HOPDONG_KHCN.NgayLap, DANHGIA_HOPDONG_KHCN.NguoiLap);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DANHGIA_HOPDONG_KHCN
        [ResponseType(typeof(DANHGIA_HOPDONG_KHCN))]
        public IHttpActionResult PostDANHGIA_HOPDONG_KHCN(DANHGIA_HOPDONG_KHCN DANHGIA_HOPDONG_KHCN)
        {
            db.Proc_DANHGIA_HOPDONG_KHCN_Insert(DANHGIA_HOPDONG_KHCN.IdHDKHCN, DANHGIA_HOPDONG_KHCN.TieuDeDanhGia, DANHGIA_HOPDONG_KHCN.NoiDung, DANHGIA_HOPDONG_KHCN.FileDanhGia, DANHGIA_HOPDONG_KHCN.NgayLap, DANHGIA_HOPDONG_KHCN.NguoiLap);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/DANHGIA_HOPDONG_KHCN/5
        [ResponseType(typeof(DANHGIA_HOPDONG_KHCN))]
        public IHttpActionResult DeleteDANHGIA_HOPDONG_KHCN(int id)
        {
            db.Proc_DANHGIA_HOPDONG_KHCN_Delete(id);
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