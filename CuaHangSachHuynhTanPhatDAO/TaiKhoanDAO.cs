using CuaHangSachHuynhTanPhatBUS;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class TaiKhoanDAO
    {
        //QLiCuaHangSachEntities qlCuaHangSach = new QLiCuaHangSachEntities();
        private static TaiKhoanDAO instance;
        private TaiKhoanDAO() { }

        public static TaiKhoanDAO Instance
        {

            get
            {
                if (instance == null) instance = new TaiKhoanDAO();
                return instance;
            }
            private set { instance = value; }

        }


        public List<int> LayMaNV()
        {
            List<int> dsMaNV= new List<int>();
            
            dsMaNV = QLiCuaHangSachEntities.Instance.NHANVIEN.Where(u=> u.trangThai == true).Select(nv => nv.maNV).ToList();

            return dsMaNV;
        }


        public string LayTenNV(string maNV)
        {

            string tenNV = string.Empty;
            int MaNV = Convert.ToInt32(maNV);
            NHANVIEN nv = QLiCuaHangSachEntities.Instance.NHANVIEN.FirstOrDefault(u => u.maNV == MaNV);

            if (nv != null)
            {
                tenNV = nv.tenNV;
            }

            return tenNV;
            
        }



        public List<TaiKhoanDTO> LayDSTaiKhoan()
        {
             List<TaiKhoanDTO> dsTK = new List<TaiKhoanDTO>();

            dsTK = QLiCuaHangSachEntities.Instance.TAIKHOAN.Select(u => new TaiKhoanDTO
            {
                maTaiKhoan = u.maTaiKhoan,
                maNV = u.maNV,
                tenDangNhap = u.tenDangNhap,
                matKhau = u.matKhau,
                quyen = u.quyen == true ? "Admin" : "Nhân viên",
                trangThai = u.trangThai
            }).Where(v => v.trangThai == true).ToList();
            

            return dsTK;
        }


        public bool themTaiKhoan(TaiKhoanDTO tk)
        {
            string matKhauMD5 = Utils.GetMD5(tk.matKhau);
          
            TAIKHOAN taiKhoanMoi = new TAIKHOAN()
            {
                tenDangNhap = tk.tenDangNhap,
                matKhau = matKhauMD5,
                maNV = tk.maNV,
                quyen = tk.quyen == "Admin" ? true : false,
                trangThai = tk.trangThai
            };

            QLiCuaHangSachEntities.Instance.TAIKHOAN.Add(taiKhoanMoi);

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        private string LayMK(TaiKhoanDTO tk)
        {
            return QLiCuaHangSachEntities.Instance.TAIKHOAN.Where(u => u.maTaiKhoan == tk.maTaiKhoan).Select(v => v.matKhau).FirstOrDefault().ToString();
        }

        public bool suaTaiKhoan(TaiKhoanDTO tk)
        {
            string matKhauMD5 = "";
            if (tk.matKhau != LayMK(tk))
                matKhauMD5 = Utils.GetMD5(tk.matKhau);
            else
                matKhauMD5 = tk.matKhau;

            TAIKHOAN taikhoan = QLiCuaHangSachEntities.Instance.TAIKHOAN.FirstOrDefault(u => u.maTaiKhoan == tk.maTaiKhoan); 

           if(taikhoan != null)
           {
                taikhoan.tenDangNhap = tk.tenDangNhap;
                taikhoan.matKhau = matKhauMD5;
                taikhoan.maNV = tk.maNV;
                taikhoan.quyen = tk.quyen == "Admin" ? true : false;
           }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

        }

        public int SoTaiKhoanAdmin()
        {
            return QLiCuaHangSachEntities.Instance.TAIKHOAN.Count(u => u.quyen == true && u.trangThai == true);
        }

        public bool xoaTaiKhoan(TaiKhoanDTO tk)
        {
            
            TAIKHOAN taikhoan = QLiCuaHangSachEntities.Instance.TAIKHOAN.FirstOrDefault(u => u.maTaiKhoan == tk.maTaiKhoan);

            if (taikhoan != null)
            {
                taikhoan.trangThai = false;
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

            
        }
    }
}
