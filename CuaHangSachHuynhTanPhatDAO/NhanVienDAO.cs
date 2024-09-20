using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;
        private NhanVienDAO() { }

        public static NhanVienDAO Instance
        {

            get
            {
                if (instance == null) instance = new NhanVienDAO();
                return instance;
            }
            private set { instance = value; }

        }


        public List<NhanVienDTO> LayDSNhanVien()
        {
            List<NhanVienDTO> dsNV = new List<NhanVienDTO>();

            

            dsNV = QLiCuaHangSachEntities.Instance.NHANVIEN.Select(u => new NhanVienDTO
            {
                maNV = u.maNV,
                tenNV = u.tenNV,
                gioiTinh = u.gioiTinh == true ? "Nam" : "Nữ",
                ngaySinh = u.ngaySinh,
                SDT = u.SDT,
                diaChi = u.diaChi,
                CCCD = u.CCCD,
                trangThai = u.trangThai,
                

            }).Where(v => v.trangThai == true).ToList();


            return dsNV;
        }

        public bool ThemNhanVien(NhanVienDTO nvMoi)
        {

            NHANVIEN nv = new NHANVIEN()
            {
                tenNV = nvMoi.tenNV,
                gioiTinh = nvMoi.gioiTinh == "Nam" ? true : false,
                ngaySinh = nvMoi.ngaySinh,
                SDT = nvMoi.SDT,
                diaChi= nvMoi.diaChi,
                CCCD= nvMoi.CCCD,
                trangThai = true
            };

            QLiCuaHangSachEntities.Instance.NHANVIEN.Add(nv);

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
           
        }
       
        public bool SuaNhanVien(NhanVienDTO nvMoi)
        {

            NHANVIEN maNV = QLiCuaHangSachEntities.Instance.NHANVIEN.FirstOrDefault(u => u.maNV == nvMoi.maNV);

            if(maNV != null)
            {
                maNV.tenNV = nvMoi.tenNV;
                maNV.gioiTinh = nvMoi.gioiTinh == "Nam" ? true : false;
                maNV.ngaySinh = nvMoi.ngaySinh;
                maNV.SDT = nvMoi.SDT;
                maNV.diaChi = nvMoi.diaChi;
                maNV.CCCD = nvMoi.CCCD;
                
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

        }

        public bool QuyenNhanVien(int maNV)
        {   
           
            TAIKHOAN tk =  QLiCuaHangSachEntities.Instance.TAIKHOAN.FirstOrDefault(u => u.maNV == maNV);

            return tk.quyen;
        }
        public int SoNhanVienAdmin()
        {
            return QLiCuaHangSachEntities.Instance.NHANVIEN.Count(u => u.TAIKHOAN.Any(v => v.quyen == true && v.trangThai == true));
        }

        public bool XoaNhanVien(NhanVienDTO nvMoi)
        {

            NHANVIEN maNV = QLiCuaHangSachEntities.Instance.NHANVIEN.FirstOrDefault(u => u.maNV == nvMoi.maNV);
            TAIKHOAN tk = QLiCuaHangSachEntities.Instance.TAIKHOAN.FirstOrDefault(u => u.maNV == nvMoi.maNV);

            if (maNV != null)
            {
                maNV.trangThai = false;
                tk.trangThai = false;
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public List<NhanVienDTO> TimKiemNhanVienTheoTen(string tenNV)
        {
            List<NhanVienDTO> dsNV = new List<NhanVienDTO>();

            dsNV = LayDSNhanVien().FindAll(u => u.tenNV.ToLower().Trim().Contains(tenNV.ToLower().Trim()));

            return dsNV;
        }

    }
}
