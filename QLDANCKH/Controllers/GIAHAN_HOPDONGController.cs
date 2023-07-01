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
    public class GIAHAN_HOPDONGController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/GIAHAN_HOPDONG
        [Authorize(Roles = "admin, member, client")]
        [HttpPost]
        [Route("api/giahanhd")]
        [ResponseType(typeof(GIAHAN_HOPDONG))]
        public IHttpActionResult PostGIAHAN_HOPDONG(GIAHAN_HOPDONG pHEDUYET_DEXUAT)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_GIAHAN_HOPDONG_Insert(pHEDUYET_DEXUAT.IdHD, pHEDUYET_DEXUAT.DonGiaHan,pHEDUYET_DEXUAT.NgayKetThuc, identity.Name);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Authorize(Roles = "admin, member, client")]
        [HttpPut]
        [Route("api/giahanhd")]
        [ResponseType(typeof(GIAHAN_HOPDONG))]
        public IHttpActionResult PutGIAHAN_HOPDONG(GIAHAN_HOPDONG pHEDUYET_DEXUAT)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_GIAHAN_HOPDONG_Update(pHEDUYET_DEXUAT.Id, pHEDUYET_DEXUAT.FilePheduyet);
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

        private bool GIAHAN_HOPDONGExists(int id)
        {
            return db.GIAHAN_HOPDONG.Count(e => e.Id == id) > 0;
        }
    }
}