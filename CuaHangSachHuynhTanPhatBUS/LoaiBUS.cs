using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class LoaiBUS
    {
        private static LoaiBUS instance;
        private LoaiBUS() { }

        public static LoaiBUS Instance
        {

            get
            {
                if (instance == null) instance = new LoaiBUS();
                return instance;
            }
            private set { instance = value; }

        }

        public List<LoaiDTO> LayDSLoai()
        {
            return LoaiDAO.Instance.LayDSLoai();
        }

        public bool ThemLoai(LoaiDTO loai, out int maLoi)
        {
            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(loai.tenLoai))
            {
                maLoi = 1;
                return false;
            }
            //Kiểm tra loại đã tồn tại chưa khi người dùng chọn 1 mục rồi thêm lần nữa
            else if (LayDSLoai().FindAll(u => u.maLoai == loai.maLoai).Count > 0)
            {
                maLoi = 2;
                return false;
            }
            //Kiểm tra tên loại đã tồn tại chưa
            else if (LayDSLoai().FindAll(u => u.tenLoai.ToLower().Trim() == loai.tenLoai.ToLower().Trim()).Count > 0)
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return LoaiDAO.Instance.ThemLoai(loai);
            }

        }
        public bool SuaLoai(LoaiDTO loai, out int maLoi)
        {
            if (ReferenceEquals(loai, null))
            {
                maLoi = 2;
                return false;
            }
            else if (string.IsNullOrEmpty(loai.tenLoai))
            {
                maLoi = 1;
                return false;
            }
            else if (LayDSLoai().FindAll(u => u.tenLoai.ToLower().Trim() == loai.tenLoai.ToLower().Trim()).Count > 0 &&
               LayDSLoai().Find(u => u.tenLoai.ToLower().Trim() == loai.tenLoai.ToLower().Trim()).maLoai != loai.maLoai )
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return LoaiDAO.Instance.SuaLoai(loai);
            }
        }
        public bool XoaLoai(LoaiDTO loai)
        {
            if(MatHangDAO.Instance.LayDSMatHang().FindAll(u => u.maLoai == loai.maLoai).Count > 0)
            {
                return false;
            }
            return LoaiDAO.Instance.XoaLoai(loai);
            
        }

        public List<LoaiDTO> TimKiemLoaiTheoTen(string tenLoai)
        {
            return LoaiDAO.Instance.TimKiemLoaiTheoTen(tenLoai);
        }

    }
}
