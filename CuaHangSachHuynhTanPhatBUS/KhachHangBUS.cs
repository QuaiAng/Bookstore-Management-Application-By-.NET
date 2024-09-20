using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;
        private KhachHangBUS() { }

        public static KhachHangBUS Instance
        {

            get
            {
                if (instance == null) instance = new KhachHangBUS();
                return instance;
            }
            private set { instance = value; }

        }

        public List<KhachHangDTO> LayDSKhachHang()
        {
            return KhachHangDAO.Instance.LayDSKhachHang();
        }

        public bool ThemKhachHang(KhachHangDTO KH, out int maLoi)
        {
            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(KH.tenKH) || string.IsNullOrEmpty(KH.SDT) || string.IsNullOrEmpty(KH.diaChi))
            {
                maLoi = 1;
                return false;
            }
            else if (LayDSKhachHang().FindAll(u => u.maKH == KH.maKH).Count > 0)
            {
                maLoi = 2;
                return false;
            }
            else
            {
                maLoi = 0;
                return KhachHangDAO.Instance.ThemKhachHang(KH);
            }

        }
        public bool SuaKhachHang(KhachHangDTO KH, out int maLoi)
        {
            if (ReferenceEquals(KH, null))
            {
                maLoi = 2;
                return false;
            }
            else if (string.IsNullOrEmpty(KH.tenKH) || string.IsNullOrEmpty(KH.SDT) || string.IsNullOrEmpty(KH.diaChi))
            {
                maLoi = 1;
                return false;
            }
            else
            {
                maLoi = 0;
                return KhachHangDAO.Instance.SuaKhachHang(KH);
            }
        }
        public bool XoaKhachHang(KhachHangDTO KH)
        {
            
             return KhachHangDAO.Instance.XoaKhachHang(KH);
            
        }

        public List<KhachHangDTO> TimKiemKhachHangTheoTen(string tenKH)
        {
            return KhachHangDAO.Instance.TimKiemKhachHangTheoTen(tenKH);
        }
    }
}
