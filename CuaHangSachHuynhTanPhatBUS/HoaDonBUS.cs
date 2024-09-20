using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;
        private HoaDonBUS() { }

        public static HoaDonBUS Instance
        {

            get
            {
                if (instance == null) instance = new HoaDonBUS();
                return instance;
            }
            private set { instance = value; }

        }


        public double LayGiaMatHang(int maMH)
        {
            return HoaDonDAO.Instance.LayGiaMatHang(maMH);
        }


        public bool ThemHoaDon(HoaDonDTO hd,out int maHD)
        {
            return HoaDonDAO.Instance.ThemHoaDon(hd, out maHD);
        }
        public bool ThemCTHD(CTHD_DTO cthd)
        {
           return HoaDonDAO.Instance.ThemCTHD(cthd);
        }

    }
}
