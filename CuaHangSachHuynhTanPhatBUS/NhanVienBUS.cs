using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatBUS
{
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;
        private NhanVienBUS() { }

        public static NhanVienBUS Instance
        {

            get
            {
                if (instance == null) instance = new NhanVienBUS();
                return instance;
            }
            private set { instance = value; }

        }

       
        public List<NhanVienDTO> LayDSNhanVien()
        {
           return NhanVienDAO.Instance.LayDSNhanVien();
        }

        public bool ThemNhanVien(NhanVienDTO nvMoi, out int maLoi)
        {

            //Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(nvMoi.tenNV) || string.IsNullOrEmpty(nvMoi.diaChi) || string.IsNullOrEmpty(nvMoi.CCCD) || string.IsNullOrEmpty(nvMoi.SDT))
            {
                maLoi = 1;
                return false;
            }
            //Kiểm tra thông tin lương đã tồn tại thông qua mã lương khi người dùng cố ý chọn 1 cái rồi thêm lại
            else if (LayDSNhanVien().FindAll(u => u.maNV == nvMoi.maNV).Count > 0)
            {
                maLoi = 2;
                return false;
            }
            else if (LayDSNhanVien().FindAll(u => u.CCCD.Trim() == nvMoi.CCCD.Trim()).Count > 0)
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return NhanVienDAO.Instance.ThemNhanVien(nvMoi);
            }


        }

        public bool SuaNhanVien(NhanVienDTO nvMoi, out int maLoi)
        {

            if (ReferenceEquals(nvMoi, null))
            {
                maLoi = 2;
                return false;
            }
            else if (string.IsNullOrEmpty(nvMoi.tenNV) || string.IsNullOrEmpty(nvMoi.diaChi) || string.IsNullOrEmpty(nvMoi.CCCD) || string.IsNullOrEmpty(nvMoi.SDT))
            {
                maLoi = 1;
                return false;
            }
            else if (LayDSNhanVien().FindAll(u => u.CCCD.Trim() == nvMoi.CCCD.Trim()).Count > 0 && 
                LayDSNhanVien().Find(u => u.CCCD.Trim() == nvMoi.CCCD.Trim()).maNV != nvMoi.maNV)
            {
                maLoi = 3;
                return false;
            }
            else
            {
                maLoi = 0;
                return NhanVienDAO.Instance.SuaNhanVien(nvMoi);
            }

        }

        public bool XoaNhanVien(NhanVienDTO nv)
        {
            int maNV = Convert.ToInt32(nv.maNV);
            if(NhanVienDAO.Instance.QuyenNhanVien(maNV) && NhanVienDAO.Instance.SoNhanVienAdmin() < 2)
                return false;
            else
                return NhanVienDAO.Instance.XoaNhanVien(nv);
            
        }

        public List<NhanVienDTO> TimKiemNhanVienTheoTen(string tenNV)
        {
            return NhanVienDAO.Instance.TimKiemNhanVienTheoTen(tenNV);
        }


    }
}
