using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class NhaCungCapBUS
    {

        private static NhaCungCapBUS instance;
        private NhaCungCapBUS() { }

        public static NhaCungCapBUS Instance
        {

            get
            {
                if (instance == null) instance = new NhaCungCapBUS();
                return instance;
            }
            private set { instance = value; }

        }
        public List<NhaCungCapDTO> LayDSNhaCungCap()
        {
            return NhaCungCapDAO.Instance.LayDSNhaCungCap();
        }
        public string LayTenNCCTheoMa(int maNCC)
        {
            return NhaCungCapDAO.Instance.LayTenNCCTheoMa(maNCC);
        }

        public bool ThemNCC(NhaCungCapDTO NCC, out int maLoi)
        {

            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(NCC.tenNCC) )
            {
                maLoi = 1;
                return false;
            }
            else if (LayDSNhaCungCap().FindAll(u => u.tenNCC.ToLower().Trim() == NCC.tenNCC.ToLower().Trim()).Count > 0)
            {
                maLoi = 2;
                return false;
            }
            else
            {
                maLoi = 0;
                return NhaCungCapDAO.Instance.ThemNCC(NCC);
            }

        }
        public bool SuaNCC(NhaCungCapDTO NCC, out int maLoi)
        {

            if (ReferenceEquals(NCC, null))
            {
                maLoi = 2;
                return false;
            }
            else if (string.IsNullOrEmpty(NCC.tenNCC))
            {
                maLoi = 1;
                return false;
            }
            else if (LayDSNhaCungCap().FindAll(u => u.tenNCC.ToLower().Trim() == NCC.tenNCC.ToLower().Trim()).Count > 0 &&
                LayDSNhaCungCap().Find(u => u.tenNCC.ToLower().Trim() == NCC.tenNCC.ToLower().Trim()).maNCC != NCC.maNCC)
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return NhaCungCapDAO.Instance.SuaNCC(NCC);
            }

        }


        public bool XoaNCC(NhaCungCapDTO NCC)
        {
            
            return NhaCungCapDAO.Instance.XoaNCC(NCC);

        }

        public List<NhaCungCapDTO> TimNhaCungCapTheoTen(string tenNCC)
        {
            return NhaCungCapDAO.Instance.TimNhaCungCapTheoTen(tenNCC);
        }

    }
}
