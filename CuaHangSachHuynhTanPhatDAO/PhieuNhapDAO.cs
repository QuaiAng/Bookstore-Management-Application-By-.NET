using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class PhieuNhapDAO
    {
        private static PhieuNhapDAO instance;
        private PhieuNhapDAO() { }

        public static PhieuNhapDAO Instance
        {

            get
            {
                if (instance == null) instance = new PhieuNhapDAO();
                return instance;
            }
            private set { instance = value; }

        }

        public List<PhieuNhapDTO> LayDSPhieuNhap()
        {
            List<PhieuNhapDTO> dsPN = new List<PhieuNhapDTO>();

            dsPN = QLiCuaHangSachEntities.Instance.PHIEUNHAPHANG.Select(u => new PhieuNhapDTO
            {
                maPhieuNhap = u.maPhieuNhap,
                ngayNhap = u.ngayNhap,
                maNCC = u.maNCC,
                maNV = u.maNV,
                tongTien = u.tongTien,

            }).ToList();

            return dsPN;
        }


        public bool ThemPhieuNhap(PhieuNhapDTO pn, out int maPN)
        {
            PHIEUNHAPHANG pnMoi = new PHIEUNHAPHANG()
            {
                maNCC = pn.maNCC,
                ngayNhap = pn.ngayNhap,
                maNV = pn.maNV,
                tongTien= pn.tongTien,
            };

            QLiCuaHangSachEntities.Instance.PHIEUNHAPHANG.Add(pnMoi);

            bool kq = QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
            maPN = pnMoi.maPhieuNhap;

            return kq;
        }

        public bool ThemCTNH(CTNH_DTO ctnh)
        {

            string connectionString = "Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";
            string query = $"INSERT INTO CTNH (maPhieuNhap, maMH, soLuong, giaNhap) VALUES ({ctnh.maPhieuNhap}, {ctnh.maMH}, {ctnh.soLuong}, {ctnh.giaNhap})";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count > 0;

        }
    }
}
