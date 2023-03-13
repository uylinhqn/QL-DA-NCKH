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
        public ObjectResult<Proc_HOSODANGKY_Select2_Result> GetHOSODANGKies()
        {
            return db.Proc_HOSODANGKY_Select2();
        }
         public ObjectResult<Proc_DEXUAT_DATHANG_SelectForHSDK_Result> GetHOSODANGKieChons(int ldk)
        {
            return db.Proc_DEXUAT_DATHANG_SelectForHSDK();
        }

        // GET: api/HOSODANGKies/5
        [ResponseType(typeof(HOSODANGKY))]
        public ObjectResult<Proc_HOSODANGKY_SelectPK2_Result> GetHOSODANGKY(int id)
        {
            return db.Proc_HOSODANGKY_SelectPK2(id);
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