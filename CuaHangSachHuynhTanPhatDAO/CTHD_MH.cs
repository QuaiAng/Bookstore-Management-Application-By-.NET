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
    
    public partial class CTHD_MH
    {
        public int maHD { get; set; }
        public int maMH { get; set; }
        public int soLuongBan { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual MATHANG MATHANG { get; set; }
    }
}
