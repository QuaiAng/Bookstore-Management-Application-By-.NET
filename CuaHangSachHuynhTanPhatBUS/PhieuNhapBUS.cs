using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class PhieuNhapBUS
    {
        private static PhieuNhapBUS instance;
        private PhieuNhapBUS() { }

        public static PhieuNhapBUS Instance
        {

            get
            {
                if (instance == null) instance = new PhieuNhapBUS();
                return instance;
            }
            private set { instance = value; }

        }

        public List<PhieuNhapDTO> LayDSPhieuNhap()
        {
            return PhieuNhapDAO.Instance.LayDSPhieuNhap();
        }

        public bool ThemPhieuNhap(PhieuNhapDTO pn, out int maPN)
        {
            

            return PhieuNhapDAO.Instance.ThemPhieuNhap(pn, out maPN);
        }

        public bool ThemCTNH(CTNH_DTO ctnh)
        {

            return PhieuNhapDAO.Instance.ThemCTNH(ctnh);

        }
    }
}
