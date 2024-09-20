using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class ThongKeDAO
    {
        private static ThongKeDAO instance;
        private ThongKeDAO() { }

        public static ThongKeDAO Instance
        {

            get
            {
                if (instance == null) instance = new ThongKeDAO();
                return instance;
            }
            private set { instance = value; }

        }


        public List<ThongKeDTO> LayThongKeTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            List<ThongKeDTO> dsTK = new List<ThongKeDTO>();

            var query = from hd in QLiCuaHangSachEntities.Instance.HOADON
                        join nhanvien in QLiCuaHangSachEntities.Instance.NHANVIEN
                        on hd.maNV equals nhanvien.maNV
                        where hd.trangThai == true && hd.ngayLap >= ngayBatDau && hd.ngayLap <= ngayKetThuc
                        select new
                        {
                            hd,
                            nhanvien.tenNV
                        };

            foreach (var item in query)
            {
                HOADON u = item.hd;
                string tenNV = item.tenNV;

                ThongKeDTO tk = new ThongKeDTO()
                {
                    maHD = u.maHD,
                    tongTien = u.tongTien,
                    ngayLap = u.ngayLap,
                    maNV = u.maNV,
                    tenNV = tenNV,
                    trangThai = u.trangThai,
                };

                dsTK.Add(tk);
            }

            return dsTK;
        }

    }
}
