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
using QLDANCKH.Models;

namespace QLDANCKH.Controllers
{
    public class CONGNHANKETQUAsController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/PHEDUYET_DEXUAT/5

        // POST: api/PHEDUYET_DEXUAT
        [Authorize(Roles = "admin, member, client")]
        [HttpPost]
        [Route("api/congnhankq")]
        [ResponseType(typeof(CONGNHANKETQUA))]
        public IHttpActionResult PostPHEDUYET_DEXUAT(CONGNHANKETQUA pHEDUYET_DEXUAT)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_CONGNHANKETQUA_Insert(pHEDUYET_DEXUAT.IdHSDK, pHEDUYET_DEXUAT.HoSoCongNhan, identity.Name);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPut]
        [Route("api/congnhankq")]
        public IHttpActionResult PutPHEDUYET_DEXUAT(CONGNHANKETQUA pHEDUYET_DEXUAT)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_CONGNHANKETQUA_PDCN(pHEDUYET_DEXUAT.Id, pHEDUYET_DEXUAT.HoSoPD);
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

        private bool PHEDUYET_DEXUATExists(int id)
        {
            return db.PHEDUYET_DEXUAT.Count(e => e.Id == id) > 0;
        }
    }
}