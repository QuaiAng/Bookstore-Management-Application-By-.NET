using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class LoaiDAO
    {

        private static LoaiDAO instance;
        private LoaiDAO() { }

        public static LoaiDAO Instance
        {

            get
            {
                if (instance == null) instance = new LoaiDAO();
                return instance;
            }
            private set { instance = value; }

        }

        public List<LoaiDTO> LayDSLoai()
        {
            List<LoaiDTO> dsLoai = new List<LoaiDTO>();

            dsLoai = QLiCuaHangSachEntities.Instance.LOAIHANG.Select(u => new LoaiDTO
            {
                maLoai = u.maLoai,
                tenLoai = u.tenLoai,
                trangThai = u.trangThai,
            }).Where(v => v.trangThai == true).ToList();

            return dsLoai;
        }

       



        public bool ThemLoai(LoaiDTO Loai)
        {
            LOAIHANG loaiMoi = new LOAIHANG()
            {
                tenLoai = Loai.tenLoai,
                trangThai = true,
            };
            QLiCuaHangSachEntities.Instance.LOAIHANG.Add(loaiMoi);

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public bool SuaLoai(LoaiDTO Loai)
        {

            LOAIHANG maLoai = QLiCuaHangSachEntities.Instance.LOAIHANG.FirstOrDefault(u => u.maLoai == Loai.maLoai);

            if (maLoai != null)
            {
                maLoai.tenLoai = Loai.tenLoai;
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

        }


        public bool XoaLoai(LoaiDTO Loai)
        {
            LOAIHANG lh = QLiCuaHangSachEntities.Instance.LOAIHANG.FirstOrDefault(u => u.maLoai == Loai.maLoai);
            if (lh != null)
            {
                lh.trangThai = false;
            };

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }



        public List<LoaiDTO> TimKiemLoaiTheoTen(string tenLoai)
        {
            List<LoaiDTO> dsLoai = new List<LoaiDTO>();

            dsLoai = LayDSLoai().FindAll(u => u.tenLoai.ToLower().Trim().Contains(tenLoai.ToLower().Trim()));

            return dsLoai;
        }

    }
}


