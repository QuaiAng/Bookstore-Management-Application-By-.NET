//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuaHangSachHuynhTanPhatDAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class LUONG
    {
        public int maLuong { get; set; }
        public double luongCung { get; set; }
        public double phuCap { get; set; }
        public double tienPhat { get; set; }
        public double tongLuong { get; set; }
        public bool tinhTrang { get; set; }
        public int maNV { get; set; }
        public bool trangThai { get; set; }
        public System.DateTime thoiGian { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual NHANVIEN NHANVIEN1 { get; set; }
    }
}
