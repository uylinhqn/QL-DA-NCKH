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
    public class PHIEU_DANHGIA_CHAMDIEM_HSController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/PHIEU_DANHGIA_CHAMDIEM_HS
        public ObjectResult<Proc_PHIEU_DANHGIA_CHAMDIEM_HS_Select_Result> GetHOSODANGKies()
        {
            return db.Proc_PHIEU_DANHGIA_CHAMDIEM_HS_Select();
        }

        // GET: api/HOSODANGKies/5
        [ResponseType(typeof(PHIEU_DANHGIA_CHAMDIEM_HS))]
        public ObjectResult<Proc_PHIEU_DANHGIA_CHAMDIEM_HS_SelectPK_Result> GetPHIEU_DANHGIA_CHAMDIEM_HS(int id)
        {
            return db.Proc_PHIEU_DANHGIA_CHAMDIEM_HS_SelectPK(id);
        }

        // PUT: api/HOSODANGKies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPHIEU_DANHGIA_CHAMDIEM_HS(int id, PHIEU_DANHGIA_CHAMDIEM_HS PHIEU_DANHGIA_CHAMDIEM_HS)
        {
            db.Proc_PHIEU_DANHGIA_CHAMDIEM_HS_Update(id, PHIEU_DANHGIA_CHAMDIEM_HS.IDHS, PHIEU_DANHGIA_CHAMDIEM_HS.IDTV, PHIEU_DANHGIA_CHAMDIEM_HS.Diem);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HOSODANGKies
        [ResponseType(typeof(PHIEU_DANHGIA_CHAMDIEM_HS))]
        public IHttpActionResult PostPHIEU_DANHGIA_CHAMDIEM_HS(PHIEU_DANHGIA_CHAMDIEM_HS PHIEU_DANHGIA_CHAMDIEM_HS)
        {
            db.Proc_PHIEU_DANHGIA_CHAMDIEM_HS_Insert(PHIEU_DANHGIA_CHAMDIEM_HS.IDHS, PHIEU_DANHGIA_CHAMDIEM_HS.IDTV, PHIEU_DANHGIA_CHAMDIEM_HS.Diem);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/HOSODANGKies/5
        [ResponseType(typeof(PHIEU_DANHGIA_CHAMDIEM_HS))]
        public IHttpActionResult DeletePHIEU_DANHGIA_CHAMDIEM_HS(int id)
        {
            db.Proc_PHIEU_DANHGIA_CHAMDIEM_HS_Delete(id);
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

        private bool PHIEU_DANHGIA_CHAMDIEM_HSExists(int id)
        {
            return db.PHIEU_DANHGIA_CHAMDIEM_HS.Count(e => e.ID == id) > 0;
        }
    }
}