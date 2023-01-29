using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QLDANCKH.Models;

namespace QLDANCKH.Controllers
{
    public class TINTUC_THONGBAOController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/TINTUC_THONGBAO
        public IQueryable<TINTUC_THONGBAO> GetTINTUC_THONGBAO()
        {
            return db.TINTUC_THONGBAO;
        }

        // GET: api/TINTUC_THONGBAO/5
        [ResponseType(typeof(TINTUC_THONGBAO))]
        public IHttpActionResult GetTINTUC_THONGBAO(int id)
        {
            TINTUC_THONGBAO tINTUC_THONGBAO = db.TINTUC_THONGBAO.Find(id);
            if (tINTUC_THONGBAO == null)
            {
                return NotFound();
            }

            return Ok(tINTUC_THONGBAO);
        }

        // PUT: api/TINTUC_THONGBAO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTINTUC_THONGBAO(int id, TINTUC_THONGBAO tINTUC_THONGBAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tINTUC_THONGBAO.IDTintuc)
            {
                return BadRequest();
            }

            db.Entry(tINTUC_THONGBAO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TINTUC_THONGBAOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TINTUC_THONGBAO
        [ResponseType(typeof(TINTUC_THONGBAO))]
        public IHttpActionResult PostTINTUC_THONGBAO(TINTUC_THONGBAO tINTUC_THONGBAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TINTUC_THONGBAO.Add(tINTUC_THONGBAO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tINTUC_THONGBAO.IDTintuc }, tINTUC_THONGBAO);
        }

        // DELETE: api/TINTUC_THONGBAO/5
        [ResponseType(typeof(TINTUC_THONGBAO))]
        public IHttpActionResult DeleteTINTUC_THONGBAO(int id)
        {
            TINTUC_THONGBAO tINTUC_THONGBAO = db.TINTUC_THONGBAO.Find(id);
            if (tINTUC_THONGBAO == null)
            {
                return NotFound();
            }

            db.TINTUC_THONGBAO.Remove(tINTUC_THONGBAO);
            db.SaveChanges();

            return Ok(tINTUC_THONGBAO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TINTUC_THONGBAOExists(int id)
        {
            return db.TINTUC_THONGBAO.Count(e => e.IDTintuc == id) > 0;
        }
    }
}