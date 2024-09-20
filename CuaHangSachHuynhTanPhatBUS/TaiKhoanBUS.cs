using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;
        private TaiKhoanBUS() { }

        public static TaiKhoanBUS Instance
        {

            get
            {
                if (instance == null) instance = new TaiKhoanBUS();
                return instance;
            }
            private set { instance = value; }

        }

        public List<int> LayMaNV()
        {
           return TaiKhoanDAO.Instance.LayMaNV();
        }


        public string LayTenNV(string maNV)
        {

            return TaiKhoanDAO.Instance.LayTenNV(maNV);
        }


        public List<TaiKhoanDTO> LayDSTaiKhoan()
        {
            return TaiKhoanDAO.Instance.LayDSTaiKhoan().Count > 0 ? TaiKhoanDAO.Instance.LayDSTaiKhoan() : null;
        }


        public bool themTaiKhoan(TaiKhoanDTO tk, out int maLoi)
        {
           
            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(tk.tenDangNhap) || string.IsNullOrEmpty(tk.matKhau))
            {
                maLoi = 1;
                return false;
            } 
            //Kiểm tra tài khoản đã tồn tại thông qua mã tài khoản khi người dùng cố ý chọn 1 tài khoản rồi thêm 
            else if (LayDSTaiKhoan().FindAll(u => u.maTaiKhoan == tk.maTaiKhoan).Count > 0)
            {
                maLoi = 2;
                return false;
            }
            //Kiểm tra tài khoản đã tồn tại thông qua tên đăng nhập khi người dùng nhập một tên đăng nhập đã tồn tại trong hệ thống
            else if (LayDSTaiKhoan().FindAll(u => u.tenDangNhap.Trim() == tk.tenDangNhap.Trim()).Count > 0)
            {
                maLoi = 3;
                return false;
            }
            //Kiểm tra khi người dùng thêm tài khoản cho nhân viên, nếu nhân viên đã có tài khoản thì báo lỗi
            else if (LayDSTaiKhoan().FindAll(u => u.maNV == tk.maNV).Count > 0)
            {
                maLoi= 4;
                return false;
            }
            else
            {
                maLoi = 0;  
                return TaiKhoanDAO.Instance.themTaiKhoan(tk);
            }
           
        }



        public bool suaTaiKhoan(TaiKhoanDTO tk, out int maLoi)
        {
            


            if (ReferenceEquals(tk, null))
            {
                maLoi = 2;
                return false;
            }
            

            if (string.IsNullOrEmpty(tk.tenDangNhap) || string.IsNullOrEmpty(tk.matKhau))
            {
                maLoi = 1;
                return false;
            }
            else if (LayDSTaiKhoan().FindAll(u => u.tenDangNhap.Trim() == tk.tenDangNhap.Trim()).Count > 0 &&
                LayDSTaiKhoan().Find(u => u.tenDangNhap.Trim() == tk.tenDangNhap.Trim()).maTaiKhoan != tk.maTaiKhoan)
            {
                maLoi = 3;
                return false;
            }
            else if (LayDSTaiKhoan().FindAll(u => u.maNV == tk.maNV).Count > 0 &&
                LayDSTaiKhoan().Find(u => u.maNV == tk.maNV).maTaiKhoan != tk.maTaiKhoan)
            {
                maLoi = 4;
                return false;
            }
            else
            {
                maLoi = 0;
                return TaiKhoanDAO.Instance.suaTaiKhoan(tk);
            }
        }

        public bool xoaTaiKhoan(TaiKhoanDTO tk)
        {

            if (TaiKhoanDAO.Instance.SoTaiKhoanAdmin() < 2)
            {
                return false;
            }
            else
            {
                return TaiKhoanDAO.Instance.xoaTaiKhoan(tk);
            }
        }


    }
}
