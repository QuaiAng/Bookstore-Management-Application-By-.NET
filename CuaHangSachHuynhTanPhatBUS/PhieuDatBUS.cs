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
    public class PhieuDatBUS
    {
        private static PhieuDatBUS instance;
        private PhieuDatBUS() { }

        public static PhieuDatBUS Instance
        {

            get
            {
                if (instance == null) instance = new PhieuDatBUS();
                return instance;
            }
            private set { instance = value; }

        }
        public List<PhieuDatDTO> LayDSPhieuDat()
        {
          return PhieuDatDAO.Instance.LayDSPhieuDat();
        }

        public bool ThemPhieuDat(PhieuDatDTO pd, out int maPD)
        {
            return PhieuDatDAO.Instance.ThemPhieuDat(pd, out maPD);
        }
        public bool ThemCTDH(CTDH_DTO ctdh)
        {

            return PhieuDatDAO.Instance.ThemCTDH(ctdh);

        }

    }
}

