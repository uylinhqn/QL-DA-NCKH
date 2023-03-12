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
    public class CONGNHANKETQUA_HOPDONG_KHCNController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/CONGNHANKETQUA_HOPDONG_KHCN
        public ObjectResult<Proc_CONGNHANKETQUA_HOPDONG_KHCN_select_Result> GetCONGNHANKETQUA_HOPDONG_KHCN()
        {
            return db.Proc_CONGNHANKETQUA_HOPDONG_KHCN_select();
        }

        // GET: api/CONGNHANKETQUA_HOPDONG_KHCN/5
        [ResponseType(typeof(CONGNHANKETQUA_HOPDONG_KHCN))]
        public ObjectResult<Proc_CONGNHANKETQUA_HOPDONG_KHCN_selectPK_Result> GetCONGNHANKETQUA_HOPDONG_KHCN(int id)
        {
            return db.Proc_CONGNHANKETQUA_HOPDONG_KHCN_selectPK(id);
        }

        // PUT: api/CONGNHANKETQUA_HOPDONG_KHCN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCONGNHANKETQUA_HOPDONG_KHCN(int id, CONGNHANKETQUA_HOPDONG_KHCN CONGNHANKETQUA_HOPDONG_KHCN)
        {
            db.Proc_CONGNHANKETQUA_HOPDONG_KHCN_Update(id, CONGNHANKETQUA_HOPDONG_KHCN.IdHDKHCN, CONGNHANKETQUA_HOPDONG_KHCN.TieuDeCNKQ, CONGNHANKETQUA_HOPDONG_KHCN.NoiDung, CONGNHANKETQUA_HOPDONG_KHCN.FileHSCNKQ, CONGNHANKETQUA_HOPDONG_KHCN.NgayLap, CONGNHANKETQUA_HOPDONG_KHCN.NguoiLap, CONGNHANKETQUA_HOPDONG_KHCN.TieuDeGiayCNKQ, CONGNHANKETQUA_HOPDONG_KHCN.FileGiayCNKQ);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CONGNHANKETQUA_HOPDONG_KHCN
        [ResponseType(typeof(CONGNHANKETQUA_HOPDONG_KHCN))]
        public IHttpActionResult PostCONGNHANKETQUA_HOPDONG_KHCN(CONGNHANKETQUA_HOPDONG_KHCN CONGNHANKETQUA_HOPDONG_KHCN)
        {
            db.Proc_CONGNHANKETQUA_HOPDONG_KHCN_Insert(CONGNHANKETQUA_HOPDONG_KHCN.IdHDKHCN, CONGNHANKETQUA_HOPDONG_KHCN.TieuDeCNKQ, CONGNHANKETQUA_HOPDONG_KHCN.NoiDung, CONGNHANKETQUA_HOPDONG_KHCN.FileHSCNKQ, CONGNHANKETQUA_HOPDONG_KHCN.NgayLap, CONGNHANKETQUA_HOPDONG_KHCN.NguoiLap, CONGNHANKETQUA_HOPDONG_KHCN.TieuDeGiayCNKQ, CONGNHANKETQUA_HOPDONG_KHCN.FileGiayCNKQ);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/CONGNHANKETQUA_HOPDONG_KHCN/5
        [ResponseType(typeof(CONGNHANKETQUA_HOPDONG_KHCN))]
        public IHttpActionResult DeleteCONGNHANKETQUA_HOPDONG_KHCN(int id)
        {
            db.Proc_CONGNHANKETQUA_HOPDONG_KHCN_Delete(id);
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