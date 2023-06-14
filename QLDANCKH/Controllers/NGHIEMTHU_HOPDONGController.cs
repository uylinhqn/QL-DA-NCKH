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
    public class NGHIEMTHU_HOPDONGController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();

        // GET: api/PHEDUYET_DEXUAT/5

        // POST: api/PHEDUYET_DEXUAT
        [Authorize(Roles = "admin, member, client")]
        [HttpPost]
        [Route("api/nghiemthu")]
        [ResponseType(typeof(NGHIEMTHU_HOPDONG))]
        public IHttpActionResult PostNGHIEMTHU_HOPDONG(NGHIEMTHU_HOPDONG pHEDUYET_DEXUAT)
        {
            var identity = (ClaimsIdentity)User.Identity;
            db.Proc_NGHIEMTHU_HOPDONG_Insert(pHEDUYET_DEXUAT.IdHD, pHEDUYET_DEXUAT.HoSoNghiemThu, identity.Name);
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