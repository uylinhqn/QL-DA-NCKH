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
    public class ChiTietQuyenHTsController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/ChiTietQuyenHTs
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ObjectResult<Proc_ChiTietQuyenHT_Select_Result> GetChiTietQuyenHTs(string tdn)
        {
            return db.Proc_ChiTietQuyenHT_Select(tdn);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ResponseType(typeof(ChiTietQuyenHT))]
        public bool PostChiTietQuyenHT(string email, string idquyen)
        {
            bool kt;
            try
            {
                string[] strid = idquyen.Split(';');
                db.Proc_ChiTietQuyenHT_Delete(email);
                for (int i = 0; i < strid.Length - 1; i++)
                {
                    db.Proc_ChiTietQuyenHT_Insert(email, int.Parse(strid[i]));
                }
                kt = true;
            }
            catch
            {
                kt = false;
            }

            return kt;
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