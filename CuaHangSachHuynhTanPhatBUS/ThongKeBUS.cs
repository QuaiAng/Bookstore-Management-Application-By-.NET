using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class ThongKeBUS
    {
        private static ThongKeBUS instance;
        private ThongKeBUS() { }

        public static ThongKeBUS Instance
        {

            get
            {
                if (instance == null) instance = new ThongKeBUS();
                return instance;
            }
            private set { instance = value; }

        }


        public List<ThongKeDTO> LayThongKeTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
           
            return ThongKeDAO.Instance.LayThongKeTheoNgay(ngayBatDau, ngayKetThuc);
        }
    }
}
