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
    public class PHEDUYET_DEXUATController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/PHEDUYET_DEXUAT/5

        // POST: api/PHEDUYET_DEXUAT
        [Authorize(Roles = "admin, member, client")]
        [HttpPost]
        [Route("api/pheduyetda")]
        [ResponseType(typeof(PHEDUYET_DEXUAT))]
        public IHttpActionResult PostPHEDUYET_DEXUAT(PHEDUYET_DEXUAT pHEDUYET_DEXUAT)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_PHEDUYET_DEXUAT_Insert(pHEDUYET_DEXUAT.IDDexuat, pHEDUYET_DEXUAT.Quyetdinhpduyet, identity.Name);
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