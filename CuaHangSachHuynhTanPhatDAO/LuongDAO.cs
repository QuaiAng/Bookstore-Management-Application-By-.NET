using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class LuongDAO
    {
        //QLiCuaHangSachEntities qlCuaHangSach = new QLiCuaHangSachEntities();
        private static LuongDAO instance;
        private LuongDAO() { }

        public static LuongDAO Instance
        {

            get
            {
                if (instance == null) instance = new LuongDAO();
                return instance;
            }
            private set { instance = value; }

        }

        public List<int> LayMaNV()
        {
        
            return TaiKhoanDAO.Instance.LayMaNV();
        
        }

        public string LayTenNV(string maNV)
        {
            return TaiKhoanDAO.Instance.LayTenNV(maNV);
        }

        public List<LuongDTO> LayDSLuong()
        {
            List<LuongDTO> dsLuong = new List<LuongDTO>();

            
            var query = from luong in QLiCuaHangSachEntities.Instance.LUONG
                        join nhanvien in QLiCuaHangSachEntities.Instance.NHANVIEN
                        on luong.maNV equals nhanvien.maNV
                        where luong.trangThai == true 
                        select new
                        {
                            luong, 
                            nhanvien.tenNV 
                        };

            foreach (var item in query)
            {
                LUONG u = item.luong; 
                string tenNV = item.tenNV;
                
                LuongDTO luong = new LuongDTO()
                {
                    maLuong = u.maLuong,
                    luongCung = u.luongCung,
                    phuCap = u.phuCap,
                    tienPhat = u.tienPhat,
                    tongLuong = u.tongLuong,
                    tinhTrang = u.tinhTrang == true ? "Đã thanh toán" : "Chưa thanh toán",
                    maNV = u.maNV,
                    trangThai = u.trangThai,
                    thoiGian = u.thoiGian.Date,
                    tenNV = tenNV
                };

                dsLuong.Add(luong);
            }

            return dsLuong;
        }
        public bool ThemLuong(LuongDTO luong)
        {
            LUONG luongMoi = new LUONG()
            {
                luongCung = luong.luongCung,
                phuCap = luong.phuCap,
                tienPhat= luong.tienPhat,
                tongLuong= luong.tongLuong,
                tinhTrang = luong.tinhTrang == "Đã thanh toán" ? true : false,
                maNV = luong.maNV,
                trangThai = true,
                thoiGian = luong.thoiGian,
            };
            QLiCuaHangSachEntities.Instance.LUONG.Add(luongMoi);

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public bool SuaLuong(LuongDTO luong)
        {

            LUONG maLuong = QLiCuaHangSachEntities.Instance.LUONG.FirstOrDefault(u => u.maLuong == luong.maLuong);

            if(maLuong != null)
            {
                maLuong.luongCung = luong.luongCung;
                maLuong.phuCap = luong.phuCap;
                maLuong.tienPhat = luong.tienPhat;
                maLuong.tongLuong = luong.tongLuong;
                maLuong.tinhTrang = luong.tinhTrang == "Đã thanh toán" ? true : false;
                maLuong.maNV = luong.maNV;
                maLuong.thoiGian = luong.thoiGian;
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }


        public bool XoaLuong(LuongDTO luong)
        {

            LUONG l = QLiCuaHangSachEntities.Instance.LUONG.FirstOrDefault(u => u.maLuong == luong.maLuong);
            if(l != null) 
            {
                l.trangThai = false;
            };

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public List<LuongDTO> TimKiemNhanVienTheoTen(string tenNV)
        {
            List<LuongDTO> dsNV = new List<LuongDTO>();

            dsNV = LayDSLuong().FindAll(u => u.tenNV.ToLower().Trim().Contains(tenNV.ToLower().Trim()));

            return dsNV;
        }

       

    }
}
