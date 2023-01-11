using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Owin.Security.OAuth;
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
            request.AddParameter("application/x-www-form-urlencoded", "username=" + acc.email + "&password=" +acc.pass + "&grant_type=password", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString() == "BadRequest") { return null; }
            else
            {
                return JsonConvert.DeserializeObject<Tokens>(response.Content);
            }
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost]
        [Route("api/resource")]
        public IHttpActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + ", your Role(s) are: " + string.Join(",", roles.ToList()));
        }
        // GET: api/NHANVIENs
        public IQueryable<NHANVIEN> GetNHANVIENs()
        {
            return db.NHANVIENs;
        }

        // GET: api/NHANVIENs/5
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult GetNHANVIEN(int id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            return Ok(nHANVIEN);
        }

        // PUT: api/NHANVIENs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNHANVIEN(int id, NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nHANVIEN.IDNHANVIEN)
            {
                return BadRequest();
            }

            db.Entry(nHANVIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        // POST: api/NHANVIENs
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult PostNHANVIEN(int ck,NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHANVIENs.Add(nHANVIEN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nHANVIEN.IDNHANVIEN }, nHANVIEN);
        }

        // DELETE: api/NHANVIENs/5
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult DeleteNHANVIEN(int id)
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

        private bool NHANVIENExists(int id)
        {
            return db.NHANVIENs.Count(e => e.IDNHANVIEN == id) > 0;
        }
    }
}