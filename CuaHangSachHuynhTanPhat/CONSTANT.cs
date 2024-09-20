using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangSachHuynhTanPhat
{
    public static class CONSTANT
    {
        public const string connectionString = @"Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";

        //Query cho DangNhap
        public const string QUERY_DANGNHAP = "EXEC DangNhap @TenDangNhap = @tenDangNhap, @MatKhau =  @matKhau";
       
        public const string QUERY__QUYEN_DANGNHAP = "SELECT quyen FROM TAIKHOAN WHERE TRIM(tenDangNhap) = @tenDangNhap AND TRIM(matKhau) = @matKhau";


        //Query cho bang NHANVIEN
        public const string QUERY_SELECT_NHANVIEN = "SELECT * FROM NHANVIEN WHERE trangThai = 1";

        public const string QUERY_INSERT_NHANVIEN = "INSERT INTO NHANVIEN ( tenNV, gioiTinh, ngaySinh, SDT, diaChi, CCCD, trangThai) VALUES (@tenNV, @gioiTinh, @ngaySinh, @SDT, @diaChi, @CCCD, 1)";

        public const string QUERY_UPDATE_NHANVIEN = "UPDATE NHANVIEN SET tenNV = @tenNV, gioiTinh = @gioiTinh, ngaySinh = @ngaySinh, SDT = @SDT, diaChi = @diaChi, CCCD = @CCCD WHERE maNV = @maNV";

        public const string QUERY_DELETE_NHANVIEN = "UPDATE NHANVIEN SET trangThai = 0 WHERE maNV = @maNV";




        //Query cho bang MATHANG
        public const string QUERY_SELECT_MATHANG = "SELECT * FROM MATHANG WHERE trangThai = 1";



        //Query cho bang LUONG
        public const string QUERY_SELECT_LUONG = "SELECT LUONG.*, NHANVIEN.tenNV  FROM LUONG JOIN NHANVIEN ON NHANVIEN.maNV = LUONG.maNV WHERE LUONG.trangThai = 1";
        public const string QUERY_INSERT_LUONG = "INSERT INTO LUONG (luongCung, phuCap, tienPhat, tongLuong, tinhTrang, maNV) VALUES (@luongCung, @phuCap, @tienPhat, @tongLuong, @tinhTrang, @maNV)";
        public const string QUERY_UPDATE_LUONG = "UPDATE LUONG SET luongCung = @luongCung, phuCap = @phuCap, tienPhat = @tienPhat, tongLuong = @tongLuong, tinhTrang = @tinhTrang, maNV = @maNV";
        public const string QUERY_DELETE_LUONG = "UPDATE LUONG SET trangThai = 0 WHERE maLuong = @maLuong";




        //Query cho bang TAIKHOAN
        public const string QUERY_SELECT_TAIKHOAN = "SELECT * FROM TAIKHOAN WHERE trangThai = 1";

        public const string QUERY_UPDATE_TAIKHOAN = "UPDATE TAIKHOAN SET tenDangNhap = @tenDangNhap, matKhau = @matKhau, quyen = @quyen, maNV = @maNV WHERE maTaiKhoan = @maTaiKhoan";

        public const string QUERY_INSERT_TAIKHOAN = "INSERT INTO TAIKHOAN (tenDangNhap, matKhau, maNV, quyen, trangThai) VALUES (@TenDangNhap, @MatKhau, @MaNV, @Quyen, 1)";

        public const string QUERY_DELETE_TAIKHOAN = "UPDATE TAIKHOAN SET trangThai = 0 WHERE maTaiKhoan = @maTaiKhoan";



        //Query cho bang NHACUNGCAP
        public const string QUERY_SELECT_NHACUNGCAP = "SELECT * FROM NHACUNGCAP WHERE trangThai = 1";

        public const string QUERY_INSERT_NHACUNGCAP = "INSERT INTO NHACUNGCAP (tenNCC, trangThai) VALUES (@tenNCC, 1)";

        public const string QUERY_UPDATE_NHACUNGCAP = "UPDATE NHACUNGCAP SET tenNCC = @tenNCC WHERE maNCC = @maNCC";

        public const string QUERY_DELETE_NHACUNGCAP = "UPDATE NHACUNGCAP SET trangThai = 0 WHERE maNCC = @maNCC";






        //Magic number lay du lieu tu bang TAIKHOAN
        public const int TAIKHOAN_GET_MATAIKHOAN = 0;
        public const int TAIKHOAN_GET_TENDANGNHAP = 1;
        public const int TAIKHOAN_GET_MATKHAU = 2;
        public const int TAIKHOAN_GET_MANV = 3;
        public const int TAIKHOAN_GET_QUYEN = 4;
        public const int TAIKHOAN_GET_TRANGTHAI = 5;



        //Magic number lay du lieu tu bang NHANVIEN
        public const int NHANVIEN_GET_MANV = 0;
        public const int NHANVIEN_GET_TENNV = 1;
        public const int NHANVIEN_GET_GIOITINH = 2;
        public const int NHANVIEN_GET_NGAYSINH = 3;
        public const int NHANVIEN_GET_SDT = 4;
        public const int NHANVIEN_GET_DIACHI = 5;
        public const int NHANVIEN_GET_CCCD = 6;


       
    }
}
