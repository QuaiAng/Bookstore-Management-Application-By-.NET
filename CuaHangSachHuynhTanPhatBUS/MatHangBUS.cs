using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class MatHangBUS
    {
        private static MatHangBUS instance;
        private MatHangBUS() { }

        public static MatHangBUS Instance
        {

            get
            {
                if (instance == null) instance = new MatHangBUS();
                return instance;
            }
            private set { instance = value; }

        }

        public List<MatHangDTO> TimKiemMatHangTheoTonKho(int tonKho)
        {
            return MatHangDAO.Instance.TimKiemMatHangTheoTonKho(tonKho);
        }

        public int LayTonKho(int maMH)
        {
            return MatHangDAO.Instance.LayTonKho(maMH);
        }
        public bool SuaTonKhoMatHang(MatHangDTO matHang)
        {

            return MatHangDAO.Instance.SuaTonKhoMatHang(matHang);

        }
        public List<MatHangDTO> LayDSMatHang()
        {
            return MatHangDAO.Instance.LayDSMatHang();
        }

        public List<MatHangDTO> LayDSMatHangTheoLoai(string tenLoai)
        {
            return MatHangDAO.Instance.LayDSMatHangTheoLoai(tenLoai);
        }
        public List<MatHangDTO> TimKiemMatHangTheoTen(string tenMH, string tenLoai)
        {
            return MatHangDAO.Instance.TimKiemMatHangTheoTen(tenMH, tenLoai);
        }

        public List<int> LayMaLoai()
        {
            return MatHangDAO.Instance.LayMaLoai();
        }

        public string LayTenLoai(string maLoai)
        {

            return MatHangDAO.Instance.LayTenLoai(maLoai);

        }

        

        public string LayTenNV(string maNV)
        {
            return LuongDAO.Instance.LayTenNV(maNV);
        }

        public bool ThemMatHang(MatHangDTO matHang, out int maLoi)
        {
            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(matHang.tenMH) || matHang.giaBan < 0 || matHang.tonKho < 0)
            {
                maLoi = 1;
                return false;
            }
            //Kiểm tra thông tin lương đã tồn tại thông qua mã lương khi người dùng cố ý chọn 1 cái rồi thêm lại
            else if (LayDSMatHang().FindAll(u => u.maMH == matHang.maMH).Count > 0)
            {
                maLoi = 2;
                return false;
            }
            else if (LayDSMatHang().FindAll(u => u.tenMH == matHang.tenMH).Count > 0)
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return MatHangDAO.Instance.ThemMatHang(matHang);
            }

        }
        public bool SuaMatHang(MatHangDTO matHang, out int maLoi)
        {
            if (ReferenceEquals(matHang, null))
            {
                maLoi = 2;
                return false;
            }
            else if (string.IsNullOrEmpty(matHang.tenMH) || matHang.giaBan < 0 || matHang.tonKho < 0)
            {
                maLoi = 1;
                return false;
            }
            else if (LayDSMatHang().FindAll(u => u.tenMH == matHang.tenMH).Count > 0 &&
                LayDSMatHang().FindAll(u => u.tenMH == matHang.tenMH)[0].maMH != matHang.maMH)
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return MatHangDAO.Instance.SuaMatHang(matHang);
            }
        }
        public bool XoaMatHang(MatHangDTO matHang)
        {
            
            return MatHangDAO.Instance.XoaMatHang(matHang);
            
        }
    }
}
