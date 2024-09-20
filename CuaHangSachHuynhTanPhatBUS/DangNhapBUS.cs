using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CuaHangSachHuynhTanPhatBUS
{
    public class DangNhapBUS
    {
        private static DangNhapBUS instance;
        private DangNhapBUS() { }

        public static DangNhapBUS Instance
        {

            get
            {
                if (instance == null) instance = new DangNhapBUS();
                return instance;
            }
            private set { instance = value; }

        }


        public bool LoginSuccessfully(string tenDangNhap, string matKhau, out int maNV)
        {
            string matKhauMD5 = Utils.GetMD5(matKhau).Trim();
            tenDangNhap = tenDangNhap.Trim();
            return DangNhapDAO.Instance.LoginSuccessfully(tenDangNhap, matKhauMD5, out maNV);
        }

        public bool Permission(string tenDangNhap, string matKhau)
        {
            string matKhauMD5 = Utils.GetMD5(matKhau);
            return DangNhapDAO.Instance.Permission(tenDangNhap, matKhauMD5);
        }


    }
}
