using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class PhieuDatDAO
    {
        private static PhieuDatDAO instance;
        private PhieuDatDAO() { }

        public static PhieuDatDAO Instance
        {

            get
            {
                if (instance == null) instance = new PhieuDatDAO();
                return instance;
            }
            private set { instance = value; }

        }

        public List<PhieuDatDTO> LayDSPhieuDat()
        {
            List<PhieuDatDTO> dsPD = new List<PhieuDatDTO>();

            dsPD = QLiCuaHangSachEntities.Instance.PHIEUDATHANG.Select(u => new PhieuDatDTO
            {
                maPhieuDat = u.maPhieuDat,
                ngayDat = u.ngayDat,
                maNCC = u.maNCC,
                maNV = u.maNV,

            }).ToList();

            return dsPD;
        }


        public bool ThemPhieuDat(PhieuDatDTO pd, out int maPD)
        {
            PHIEUDATHANG pdMoi = new PHIEUDATHANG()
            {
                maNCC= pd.maNCC,
                ngayDat= pd.ngayDat,
                maNV = pd.maNV,
            };

            QLiCuaHangSachEntities.Instance.PHIEUDATHANG.Add(pdMoi);

            bool kq = QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
            maPD = pdMoi.maPhieuDat;

            return kq;
        }

        public bool ThemCTDH(CTDH_DTO ctdh)
        {

            string connectionString = "Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";
            string query = $"INSERT INTO CTDH (maPhieuDat, maMH, soLuong, maLoai) VALUES ({ctdh.maPhieuDat}, {ctdh.maMH}, {ctdh.soLuong}, {ctdh.maLoai})";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count > 0;

        }

    }
}
