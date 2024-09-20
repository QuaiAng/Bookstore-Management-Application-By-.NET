using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        private HoaDonDAO() { }

        public static HoaDonDAO Instance
        {

            get
            {
                if (instance == null) instance = new HoaDonDAO();
                return instance;
            }
            private set { instance = value; }

        }


        public double LayGiaMatHang(int maMH)
        {
            double giaBan = 0;

            giaBan = QLiCuaHangSachEntities.Instance.MATHANG.Where(u => u.maMH == maMH).Select(v => v.giaBan).FirstOrDefault();

            return giaBan;
        }

        public bool ThemHoaDon(HoaDonDTO hd, out int maHD)
        {
            HOADON hdMoi = new HOADON()
            {
                tongTien= hd.tongTien,
                ngayLap = hd.ngayLap,
                maNV = hd.maNV,
                //maKH = hd.maKH,
                trangThai = true,
            };
            QLiCuaHangSachEntities.Instance.HOADON.Add(hdMoi);

            bool kq = QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
            maHD = hdMoi.maHD;
            return kq;
        }

        public bool ThemCTHD(CTHD_DTO cthd)
        {
            
            string connectionString = "Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";
            string query = $"INSERT INTO CTHD_MH (maHD, maMH, soLuongBan) VALUES ({cthd.maHD}, {cthd.maMH}, {cthd.soLuongBan})";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count > 0;

        }

    }
}
