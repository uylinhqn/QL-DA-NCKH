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
    public class THEODOITIENDONVsController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/THEODOITIENDONVs
        public ObjectResult<Proc_THEODOITIENDONV_Select_Result> GetTHEODOITIENDONV(int iddx)
        {
            return db.Proc_THEODOITIENDONV_Select(iddx);
        }
         public ObjectResult<Proc_THEODOITIENDONV_SelectPK_Result> GetTHEODOITIENDONVPK(int id)
        {
            return db.Proc_THEODOITIENDONV_SelectPK(id);
        }

        // PUT: api/THEODOITIENDONVs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTHEODOITIENDONV(int id, THEODOITIENDONV tHEODOITIENDONV)
        {
            db.Proc_THEODOITIENDONV_Update(id,tHEODOITIENDONV.NoiDungKiemTra, tHEODOITIENDONV.FileKiemTra);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/THEODOITIENDONVs
        [ResponseType(typeof(THEODOITIENDONV))]
        public IHttpActionResult PostTHEODOITIENDONV(THEODOITIENDONV THEODOITIENDONV)
        {
            db.Proc_THEODOITIENDONV_Insert(THEODOITIENDONV.IDDexuat, THEODOITIENDONV.Ngay, THEODOITIENDONV.NoiDungBaoCao, THEODOITIENDONV.FileBaoCao);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/THEODOITIENDONVs/5
        [ResponseType(typeof(THEODOITIENDONV))]
        public IHttpActionResult DeleteTHEODOITIENDONV(int id)
        {
            db.Proc_THEODOITIENDONV_Delete(id);
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