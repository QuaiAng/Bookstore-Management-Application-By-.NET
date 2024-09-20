using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class LuongBUS
    {
        private static LuongBUS instance;
        private LuongBUS() { }

        public static LuongBUS Instance
        {

            get
            {
                if (instance == null) instance = new LuongBUS();
                return instance;
            }
            private set { instance = value; }

        }

        public List<LuongDTO> LayDSLuong()
        {
            return LuongDAO.Instance.LayDSLuong();
        }

        public List<int> LayMaNV()
        {

            return LuongDAO.Instance.LayMaNV();

        }

        public string LayTenNV(string maNV)
        {
            return LuongDAO.Instance.LayTenNV(maNV);
        }

        public bool ThemLuong(LuongDTO luong, out int maLoi)
        {
            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (luong.luongCung == 0)
            {
                maLoi = 1;
                return false;
            }
            //Kiểm tra thông tin lương đã tồn tại thông qua mã lương khi người dùng cố ý chọn 1 cái rồi thêm lại
            else if (LayDSLuong().FindAll(u => u.maLuong == luong.maLuong).Count > 0)
            {
                maLoi = 2;
                return false;
            }
            else if(luong.luongCung < 1)
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return LuongDAO.Instance.ThemLuong(luong);
            }
            
        }
        public bool SuaLuong(LuongDTO luong, out int maLoi)
        {
            if (ReferenceEquals(luong, null))
            {
                maLoi = 2;
                return false;
            }
            else if (luong.luongCung == 0)
            {
                maLoi = 1;
                return false;
            }
            else
            {
                maLoi = 0;
                return LuongDAO.Instance.SuaLuong(luong);
            }
        }
        public bool XoaLuong(LuongDTO luong, out int maLoi)
        {
            if (luong == null)
            {
                maLoi = 1;
                return false;
            }
            else
            {
                maLoi = 0;
                return LuongDAO.Instance.XoaLuong(luong);
            }
            
        }

        public List<LuongDTO> TimKiemNhanVienTheoTen(string tenNV)
        {
            return LuongDAO.Instance.TimKiemNhanVienTheoTen(tenNV);
        }

    }
}
