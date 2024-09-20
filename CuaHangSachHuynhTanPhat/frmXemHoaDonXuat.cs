using CuaHangSachHuynhTanPhatBUS;
using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmXemHoaDonXuat : Form
    {
       
        private int maHD;
        private string tenKH;
        private string diaChi;
        private string tong;
        public frmXemHoaDonXuat()
        {
            InitializeComponent();
        }

        public frmXemHoaDonXuat(int maHD, string tenKH, string diaChi, string tong)
        {
            InitializeComponent();
            this.maHD = maHD;
            this.tenKH = tenKH;
            this.diaChi = diaChi;
            this.tong = tong;
        }
        private void frmXemHoaDonXuat_Load(object sender, EventArgs e)
        {
            
            this.rpvXuatHoaDon.LocalReport.ReportPath = @"..\..\Reports\rptXuatHoaDon.rdlc";
            

            //this.HoaDonTableAdapter.Fill(this.HoaDon.HoaDon);
            HoaDon rpHoaDon = new HoaDon();
            string connectionString = "Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";
            string query = $"SELECT CTHD_MH.soLuongBan, HOADON.ngayLap, HOADON.tongTien, MATHANG.tenMH, MATHANG.giaBan FROM CTHD_MH INNER JOIN HOADON ON CTHD_MH.maHD = HOADON.maHD INNER JOIN MATHANG ON CTHD_MH.maMH = MATHANG.maMH WHERE HOADON.maHD = {maHD}";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter adptr = new SqlDataAdapter(query, conn);
            adptr.Fill(rpHoaDon, rpHoaDon.Tables[0].TableName);

            ReportDataSource rds = new ReportDataSource("DSHD", rpHoaDon.Tables[0]);
            this.rpvXuatHoaDon.LocalReport.DataSources.Clear();
            this.rpvXuatHoaDon.LocalReport.DataSources.Add(rds);

            this.rpvXuatHoaDon.LocalReport.SetParameters(new ReportParameter("paTenKH", tenKH));
            this.rpvXuatHoaDon.LocalReport.SetParameters(new ReportParameter("paDiaChi", diaChi));
            this.rpvXuatHoaDon.LocalReport.SetParameters(new ReportParameter("paTong", tong));

            this.rpvXuatHoaDon.LocalReport.Refresh();

           
            this.rpvXuatHoaDon.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
