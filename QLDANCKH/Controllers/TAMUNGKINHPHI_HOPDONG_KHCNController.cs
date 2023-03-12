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
    public class TAMUNGKINHPHI_HOPDONG_KHCNController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/TAMUNGKINHPHI_HOPDONG_KHCN
        public ObjectResult<Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Selete_Result> GetTAMUNGKINHPHI_HOPDONG_KHCN()
        {
            return db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Selete();
        }

        // GET: api/TAMUNGKINHPHI_HOPDONG_KHCN/5
        [ResponseType(typeof(TAMUNGKINHPHI_HOPDONG_KHCN))]
        public ObjectResult<Proc_TAMUNGKINHPHI_HOPDONG_KHCN_SeletePK_Result> GetTAMUNGKINHPHI_HOPDONG_KHCN(int id)
        {
            return db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_SeletePK(id);
        }

        // PUT: api/TAMUNGKINHPHI_HOPDONG_KHCN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTAMUNGKINHPHI_HOPDONG_KHCN(int id, TAMUNGKINHPHI_HOPDONG_KHCN TAMUNGKINHPHI_HOPDONG_KHCN)
        {
            db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Update(id, TAMUNGKINHPHI_HOPDONG_KHCN.IdHDKHCN, TAMUNGKINHPHI_HOPDONG_KHCN.FileHD, TAMUNGKINHPHI_HOPDONG_KHCN.SoTien,  TAMUNGKINHPHI_HOPDONG_KHCN.NgayLap, TAMUNGKINHPHI_HOPDONG_KHCN.NguoiLap);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TAMUNGKINHPHI_HOPDONG_KHCN
        [ResponseType(typeof(TAMUNGKINHPHI_HOPDONG_KHCN))]
        public IHttpActionResult PostTAMUNGKINHPHI_HOPDONG_KHCN(TAMUNGKINHPHI_HOPDONG_KHCN TAMUNGKINHPHI_HOPDONG_KHCN)
        {
            db.Proc_TAMUNGKINHPHI_HOPDONG_KHCN_Insert(TAMUNGKINHPHI_HOPDONG_KHCN.IdHDKHCN, TAMUNGKINHPHI_HOPDONG_KHCN.FileHD, TAMUNGKINHPHI_HOPDONG_KHCN.SoTien, TAMUNGKINHPHI_HOPDONG_KHCN.NgayLap, TAMUNGKINHPHI_HOPDONG_KHCN.NguoiLap);
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