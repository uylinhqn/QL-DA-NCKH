using QLDANCKH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace QLDANCKH.Controllers
{
    public class menuController : ApiController
    {
        private QL_NCKHQBEntities db = new QL_NCKHQBEntities();
        public class menushow
        {
            public int? nhom { get; set; }
            public string link { get; set; }
        }
        public List<menushow> GetChiTietQuyenHTs()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var UserName = identity.Name;
            List<menushow> menus = new List<menushow>();
            var listmenu = db.Proc_ChiTietQuyenHT_Select_Menu(UserName).ToList();
            int? idn = 0;string link = "";
            foreach (var item in listmenu)
            {
                if (idn == 0) { idn = item.nhom; link = ""; }
                else if (idn != item.nhom)
                {
                    menus.Add(new menushow
                    {
                        nhom = idn,
                        link = link
                    }); idn = item.nhom; link = "";
                }
                if (idn == item.nhom) link += item.link;
                
            }
            menus.Add(new menushow
            {
                nhom = idn,
                link = link
            });
            return menus;
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
