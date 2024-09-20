using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        private KhachHangDAO() { }

        public static KhachHangDAO Instance
        {

            get
            {
                if (instance == null) instance = new KhachHangDAO();
                return instance;
            }
            private set { instance = value; }

        }


        public List<KhachHangDTO> LayDSKhachHang()
        {
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();

            dsKhachHang = QLiCuaHangSachEntities.Instance.KHACHHANG.Select(u => new KhachHangDTO
            {
                maKH = u.maKH,
                tenKH = u.tenKH,
                gioiTinh = u.gioiTinh.Value == true ? "Nam" : "Nữ",
                SDT = u.SDT,
                diaChi = u.diaChi,
                trangThai = u.trangThai,

            }).Where(v => v.trangThai == true).ToList();

            
            return dsKhachHang;
        }




        public bool ThemKhachHang(KhachHangDTO KH)
        {
            KHACHHANG KHMoi = new KHACHHANG()
            {
                tenKH = KH.tenKH,
                gioiTinh = KH.gioiTinh == "Nam" ? true : false,
                SDT= KH.SDT,
                diaChi= KH.diaChi,
                trangThai = true,
            };
            QLiCuaHangSachEntities.Instance.KHACHHANG.Add(KHMoi);

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public bool SuaKhachHang(KhachHangDTO KH)
        {

            KHACHHANG maKH = QLiCuaHangSachEntities.Instance.KHACHHANG.FirstOrDefault(u => u.maKH == KH.maKH);

            if (maKH != null)
            {
                maKH.tenKH = KH.tenKH;
                maKH.gioiTinh = KH.gioiTinh == "Nam" ? true : false;
                maKH.SDT= KH.SDT;
                maKH.diaChi = KH.diaChi;
            }

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;

        }


        public bool XoaKhachHang(KhachHangDTO KH)
        {
            KHACHHANG maKH = QLiCuaHangSachEntities.Instance.KHACHHANG.FirstOrDefault(u => u.maKH == KH.maKH);

            if (maKH != null)
            {
                maKH.trangThai = false;
            };

            return QLiCuaHangSachEntities.Instance.SaveChanges() > 0;
        }

        public List<KhachHangDTO> TimKiemKhachHangTheoTen(string tenKH)
        {
            List<KhachHangDTO> dsKH = new List<KhachHangDTO>();

            dsKH = LayDSKhachHang().FindAll(u => u.tenKH.ToLower().Trim().Contains(tenKH.ToLower().Trim()));

            return dsKH;
        }


    }
}
