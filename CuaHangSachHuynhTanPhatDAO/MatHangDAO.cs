using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class MatHangDAO
    {
        private static MatHangDAO instance;
        private MatHangDAO() { }

        public static MatHangDAO Instance
        {

            get
            {
                if (instance == null) instance = new MatHangDAO();
                return instance;
            }
            private set { instance = value; }

        }

        public int LayTonKho(int maMH)
        {
            return  QLiCuaHangSachEntities.Instance.MATHANG.Where(u => u.maMH == maMH).Select(v => v.tonKho).FirstOrDefault();
        }

        public List<MatHangDTO> TimKiemMatHangTheoTonKho(int tonKho)
        {
            List<MatHangDTO> dsMH = LayDSMatHang().FindAll(u => u.tonKho < tonKho + 1);
            return dsMH;
        }

        public List<int> LayMaLoai()
        {
            List<int> dsMaLoai = new List<int>();
            dsMaLoai = QLiCuaHangSachEntities.Instance.LOAIHANG.Where(u => u.trangThai == true).Select(v => v.maLoai).ToList();

            return dsMaLoai;
        }

        public string LayTenLoai(string maLoai)
        {

            string tenLoai = string.Empty;
            int ml = Convert.ToInt32(maLoai);
            LOAIHANG MaLoai = QLiCuaHangSachEntities.Instance.LOAIHANG.FirstOrDefault(u => u.maLoai == ml);

            if (MaLoai != null)
            {
                tenLoai = MaLoai.tenLoai;
            }

            return tenLoai;

        }


        public List<MatHangDTO> LayDSMatHang()
        {
            List<MatHangDTO> dsMH = new List<MatHangDTO>();

            var query = from mh in QLiCuaHangSachEntities.Instance.MATHANG
                        join loai in QLiCuaHangSachEntities.Instance.LOAIHANG
                        on mh.maLoai equals loai.maLoai
                        where mh.trangThai == true
                        select new
                        {
                            mh,
                            loai.tenLoai
                        };

            foreach (var item in query)
            {
                MATHANG u = item.mh;
                string tenLoai = item.tenLoai;

                MatHangDTO matHang = new MatHangDTO()
                {
                    maMH = u.maMH,
                    tenMH = u.tenMH,
                    giaBan = u.giaBan,
                    tonKho = u.tonKho,
                    maLoai= u.maLoai,
                    tenLoai = tenLoai
                };

                dsMH.Add(matHang);
            }
            return dsMH;
        }


        public List<MatHangDTO> LayDSMatHangTheoLoai(string tenLoai)
        {
            List<MatHangDTO> dsMH = new List<MatHangDTO>();

            dsMH = LayDSMatHang().FindAll(u => u.tenLoai.Trim() == tenLoai);

            return dsMH;
        }


        public List<MatHangDTO> TimKiemMatHangTheoTen(string tenMH, string tenLoai = null)
        {
            List<MatHangDTO> dsMH = new List<MatHangDTO>();

            if(!string.IsNullOrEmpty(tenLoai))
                dsMH = LayDSMatHangTheoLoai(tenLoai).FindAll(u => u.tenMH.ToLower().Trim().Contains(tenMH.ToLower().Trim()));
            else
                dsMH = LayDSMatHang().FindAll(u => u.tenMH.ToLower().Trim().Contains(tenMH.ToLower().Trim()));

            return dsMH;
        }



        public bool ThemMatHang(MatHangDTO matHang)
        {
            MATHANG MHMoi = new MATHANG()
            {
                tenMH = matHang.tenMH,
                giaBan = matHang.giaBan,
                tonKho= matHang.tonKho,
                maLoai = matHang.maLoai,
                trangThai = true,
            };

            QLiCuaHangSachEntities.Instance.MATHANG.Add(MHMoi);
            

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public bool SuaMatHang(MatHangDTO matHang)
        {

            MATHANG maMH = QLiCuaHangSachEntities.Instance.MATHANG.FirstOrDefault(u => u.maMH == matHang.maMH);

            if (maMH != null)
            {
                maMH.tenMH = matHang.tenMH;
                maMH.giaBan = matHang.giaBan;
                maMH.tonKho = matHang.tonKho;
                maMH.maLoai = matHang.maLoai;
            };
            
            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

        }
        public bool SuaTonKhoMatHang(MatHangDTO matHang)
        {

            MATHANG maMH = QLiCuaHangSachEntities.Instance.MATHANG.FirstOrDefault(u => u.maMH == matHang.maMH);

            if (maMH != null)
            {
                maMH.tonKho = matHang.tonKho;
            };

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

        }



        public bool XoaMatHang(MatHangDTO matHang)
        {
            MATHANG maMH = QLiCuaHangSachEntities.Instance.MATHANG.FirstOrDefault(u => u.maMH == matHang.maMH);
            if (maMH != null)
            {
                maMH.trangThai = false;
            };

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }
    }
}
