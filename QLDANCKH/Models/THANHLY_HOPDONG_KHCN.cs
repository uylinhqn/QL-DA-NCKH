//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLDANCKH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THANHLY_HOPDONG_KHCN
    {
        public int ID { get; set; }
        public Nullable<int> IdHDKHCN { get; set; }
        public string TieuDeThanhLy { get; set; }
        public string NoiDung { get; set; }
        public Nullable<decimal> SoTienDaTU { get; set; }
        public Nullable<decimal> SoTienCanTT { get; set; }
        public Nullable<decimal> SoTienCanThuHoi { get; set; }
        public string FileHSTLHD { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public Nullable<System.DateTime> ThoiHanThanhLy { get; set; }
    }
}