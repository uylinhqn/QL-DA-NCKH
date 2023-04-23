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
    public class THANHLY_HOPDONG_KHCNController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/THANHLY_HOPDONG_KHCN
        public ObjectResult<Proc_THANHLY_HOPDONG_KHCN_Selete_Result> GetTHANHLY_HOPDONG_KHCN()
        {
            return db.Proc_THANHLY_HOPDONG_KHCN_Selete();
        }
          // GET: api/THANHLY_HOPDONG_KHCN
        public ObjectResult<Proc_THANHLY_HOPDONG_KHCN_Selete_XemTL_Result> GetTHANHLY_HOPDONG_KHCN(string xtl)
        {
            return db.Proc_THANHLY_HOPDONG_KHCN_Selete_XemTL();
        }

        // GET: api/THANHLY_HOPDONG_KHCN/5
        [ResponseType(typeof(THANHLY_HOPDONG_KHCN))]
        public ObjectResult<Proc_THANHLY_HOPDONG_KHCN_SeletePK_Result> GetTHANHLY_HOPDONG_KHCN(int id)
        {
            return db.Proc_THANHLY_HOPDONG_KHCN_SeletePK(id);
        }

        // PUT: api/THANHLY_HOPDONG_KHCN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTHANHLY_HOPDONG_KHCN(int id, THANHLY_HOPDONG_KHCN tHANHLY_HOPDONG_KHCN)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_THANHLY_HOPDONG_KHCN_Update(id, tHANHLY_HOPDONG_KHCN.IdHDKHCN, tHANHLY_HOPDONG_KHCN.TieuDeThanhLy, tHANHLY_HOPDONG_KHCN.NoiDung, tHANHLY_HOPDONG_KHCN.SoTienDaTU, tHANHLY_HOPDONG_KHCN.SoTienCanTT, tHANHLY_HOPDONG_KHCN.SoTienCanThuHoi, tHANHLY_HOPDONG_KHCN.FileHSTLHD, tHANHLY_HOPDONG_KHCN.NgayLap, identity.Name, tHANHLY_HOPDONG_KHCN.ThoiHanThanhLy); 
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/THANHLY_HOPDONG_KHCN
        [ResponseType(typeof(THANHLY_HOPDONG_KHCN))]
        public IHttpActionResult PostTHANHLY_HOPDONG_KHCN(THANHLY_HOPDONG_KHCN tHANHLY_HOPDONG_KHCN)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_THANHLY_HOPDONG_KHCN_Insert(tHANHLY_HOPDONG_KHCN.IdHDKHCN, tHANHLY_HOPDONG_KHCN.TieuDeThanhLy, tHANHLY_HOPDONG_KHCN.NoiDung, tHANHLY_HOPDONG_KHCN.SoTienDaTU, tHANHLY_HOPDONG_KHCN.SoTienCanTT, tHANHLY_HOPDONG_KHCN.SoTienCanThuHoi, tHANHLY_HOPDONG_KHCN.FileHSTLHD, tHANHLY_HOPDONG_KHCN.NgayLap, identity.Name, tHANHLY_HOPDONG_KHCN.ThoiHanThanhLy);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/THANHLY_HOPDONG_KHCN/5
        [ResponseType(typeof(THANHLY_HOPDONG_KHCN))]
        public IHttpActionResult DeleteTHANHLY_HOPDONG_KHCN(int id)
        {
            db.Proc_THANHLY_HOPDONG_KHCN_Delete(id);
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