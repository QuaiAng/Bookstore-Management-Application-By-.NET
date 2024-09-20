using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class NhaCungCapDAO
    {

        private static NhaCungCapDAO instance;
        private NhaCungCapDAO() { }

        public static NhaCungCapDAO Instance
        {

            get
            {
                if (instance == null) instance = new NhaCungCapDAO();
                return instance;
            }
            private set { instance = value; }

        }


        public List<NhaCungCapDTO> LayDSNhaCungCap()
        {
            List<NhaCungCapDTO> dsNCC = new List<NhaCungCapDTO>();

            dsNCC = QLiCuaHangSachEntities.Instance.NHACUNGCAP.Select(u => new NhaCungCapDTO
            {
                maNCC = u.maNCC,
                tenNCC = u.tenNCC,
                trangThai = u.trangThai,
            }).Where(v => v.trangThai == true).ToList();

            return dsNCC;
        }

        public string LayTenNCCTheoMa(int maNCC)
        {
            return QLiCuaHangSachEntities.Instance.NHACUNGCAP.Where(u => u.maNCC == maNCC && u.trangThai == true).Select(v => v.tenNCC).FirstOrDefault().ToString();
        }

        public bool ThemNCC(NhaCungCapDTO NCC)
        {
            NHACUNGCAP nccMoi = new NHACUNGCAP()
            {

                tenNCC = NCC.tenNCC,
                trangThai = true,

            };
            QLiCuaHangSachEntities.Instance.NHACUNGCAP.Add(nccMoi);

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public bool SuaNCC(NhaCungCapDTO NCC)
        {

            NHACUNGCAP ncc = QLiCuaHangSachEntities.Instance.NHACUNGCAP.FirstOrDefault(u => u.maNCC == NCC.maNCC);

            if (ncc != null)
            {
                ncc.tenNCC = NCC.tenNCC;
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

        }


        public bool XoaNCC(NhaCungCapDTO NCC)
        {
            NHACUNGCAP ncc = QLiCuaHangSachEntities.Instance.NHACUNGCAP.FirstOrDefault(u => u.maNCC == NCC.maNCC);
            if (ncc != null)
            {
                ncc.trangThai = false;
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public List<NhaCungCapDTO> TimNhaCungCapTheoTen(string tenNCC)
        {
            List<NhaCungCapDTO> dsNCC = new List<NhaCungCapDTO>();

            dsNCC = LayDSNhaCungCap().FindAll(u => u.tenNCC.ToLower().Trim().Contains(tenNCC.ToLower().Trim()));

            return dsNCC;
        }

    }
}
