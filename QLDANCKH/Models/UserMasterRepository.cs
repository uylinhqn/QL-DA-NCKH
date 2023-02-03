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
            var users = context.Proc_ThanhVien_CheckLogIn_2(username, password).ToList();
            if (users.Count > 0)
            {
                NHANVIEN nv = new NHANVIEN();
                nv.TenDangNhap = users.ToList()[0].TenDangNhap;
                nv.Matkhau = users.ToList()[0].Matkhau;
                nv.TenNhanVien = users.ToList()[0].TenNhanVien;
                nv.Trinhdo = users.ToList()[0].Trinhdo;
                nv.Diachi = users.ToList()[0].Diachi;
                nv.Phone = users.ToList()[0].Phone;
                nv.Trangthai = users.ToList()[0].Trangthai;
                nv.quyen = users.ToList()[0].quyen;
                return nv;
            }
            else return null;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}