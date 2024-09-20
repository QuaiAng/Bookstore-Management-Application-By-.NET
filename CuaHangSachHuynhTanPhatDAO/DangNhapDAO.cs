using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class DangNhapDAO
    {
        //QLiCuaHangSachEntities qlCuaHangSach = new QLiCuaHangSachEntities();
        private static DangNhapDAO instance;
        private DangNhapDAO() { }

        public static DangNhapDAO Instance 
        {
            
            get
            {
                if (instance == null) instance = new DangNhapDAO();
                return instance;
            }
            private set { instance = value; }
        
        }

        /// <summary>
        /// Quản lý trạng thái đăng nhập của một tài khoản
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập mà người dùng nhập</param>
        /// <param name="matKhau">Mật khẩu mà người dùng nhập</param>
        /// <returns>Trả về True nếu tên đăng nhập và mật khẩu trùng khớp với dữ liệu trong database, ngược lại trả về False</returns>
        public bool LoginSuccessfully(string tenDangNhap, string matKhau, out int maNV)
        {

            TAIKHOAN taiKhoan = QLiCuaHangSachEntities.Instance.TAIKHOAN.FirstOrDefault(u => u.tenDangNhap.Trim() == tenDangNhap && u.matKhau.Trim() == matKhau);

            if (taiKhoan != null && taiKhoan.trangThai == true)
            {
                maNV = taiKhoan.maNV;
                return true;
            }
            else
            {
                maNV = 1;
                return false;
            }
               
            

           // return taiKhoan != null && taiKhoan.trangThai == true;

        }

        /// <summary>
        /// Dùng để lấy quyền của một tài khoản dựa trên tên đăng nhập và mật khẩu
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập mà người dùng nhập</param>
        /// <param name="matKhau">Mật khẩu mà người dùng nhập</param>
        /// <returns>Trả về True nếu tài khoản đó quyền Admin, ngược lại trả về False</returns>
        public bool Permission(string tenDangNhap, string matKhau)
        {
            //SqlParameter[] param = new SqlParameter[]
            

            TAIKHOAN taiKhoan = QLiCuaHangSachEntities.Instance.TAIKHOAN.FirstOrDefault(u => u.tenDangNhap == tenDangNhap && u.matKhau == matKhau);
            return taiKhoan.quyen;
            
        }
    }
}
