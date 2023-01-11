using QLDANCKH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loginauth.Models
{
    public class UserMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        QL_NCKHQBEntities context = new QL_NCKHQBEntities();
        //This method is used to check and validate the user credentials
        public NHANVIEN ValidateUser(string username, string password)
        {
            return context.NHANVIENs.FirstOrDefault(user =>
            user.TenDangNhap.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Matkhau == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}