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
using Newtonsoft.Json;
using QLDANCKH.Models;
using RestSharp;

namespace QLDANCKH.Controllers
{
    public class NHANVIENsController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        public class Tokens
        {
            public Tokens() { }
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }
        public class users
        {
            public users() { }
            public string email { get; set; }
            public string pass { get; set; }
        }
        public Tokens Postkey(users acc)
        {
            var client = new RestClient("https://localhost:44338/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "079524ee-6d2c-33c7-ff89-ef4e71b4cc12");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "username=" + acc.email + "&password=" + acc.pass + "&grant_type=password", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString() == "BadRequest") { return null; }
            else
            {
                return JsonConvert.DeserializeObject<Tokens>(response.Content);
            }
        }

        // GET: api/NHANVIENs
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ObjectResult<Proc_ThanhVien_Select2_Result> GetNHANVIENs()
        {
            return db.Proc_ThanhVien_Select2();
        }

        // GET: api/NHANVIENs/5
        [Authorize(Roles = "admin")]
        [HttpGet]
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult GetNHANVIEN(string idnv)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(idnv);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            return Ok(nHANVIEN);
        }

        // PUT: api/NHANVIENs/5
        [Authorize(Roles = "admin")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNHANVIEN(string id, NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nHANVIEN.TenDangNhap)
            {
                return BadRequest();
            }

            db.Entry(nHANVIEN).State = EntityState.Modified;

            try
            {
                db.Proc_ThanhVien_UpdateInfo(id, nHANVIEN.TenNhanVien, nHANVIEN.Trinhdo, nHANVIEN.Diachi, nHANVIEN.Phone, nHANVIEN.Trangthai, nHANVIEN.quyen, nHANVIEN.IDDonvi, nHANVIEN.IDHocvi);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHANVIENExists(id))
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

        [Authorize(Roles = "admin")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNHANVIENPass(string idpas, NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idpas != nHANVIEN.TenDangNhap)
            {
                return BadRequest();
            }

            db.Entry(nHANVIEN).State = EntityState.Modified;

            try
            {
                db.Proc_ThanhVien_UpdatePass(idpas, nHANVIEN.Matkhau);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHANVIENExists(idpas))
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
        [Authorize(Roles = "admin")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNHANVIENStatus(string idsta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Proc_ThanhVien_UpdateStatus(idsta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHANVIENExists(idsta))
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
        [Authorize(Roles = "admin")]
        [HttpPost]
        // POST: api/NHANVIENs
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult PostNHANVIEN(int ck, NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHANVIENs.Add(nHANVIEN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nHANVIEN.TenDangNhap }, nHANVIEN);
        }

        // DELETE: api/NHANVIENs/5
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult DeleteNHANVIEN(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            db.NHANVIENs.Remove(nHANVIEN);
            db.SaveChanges();

            return Ok(nHANVIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHANVIENExists(string id)
        {
            return db.NHANVIENs.Count(e => e.TenDangNhap == id) > 0;
        }
    }
}