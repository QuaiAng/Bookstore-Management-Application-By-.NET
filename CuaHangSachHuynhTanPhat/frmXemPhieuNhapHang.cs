using Microsoft.Reporting.WinForms;
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
    public partial class frmXemPhieuNhapHang : Form
    {
        private int maPN;
        private string tong;
        public frmXemPhieuNhapHang()
        {
            InitializeComponent();
        }

        public frmXemPhieuNhapHang(int maPN, string tong)
        {
            InitializeComponent();
            this.maPN = maPN;
            this.tong = tong;
        }

        private void frmXemPhieuNhapHang_Load(object sender, EventArgs e)
        {
            this.rpvXuatPhieuDat.LocalReport.ReportPath = @"..\..\Reports\rptXuatPhieuNhap.rdlc";


            //this.HoaDonTableAdapter.Fill(this.HoaDon.HoaDon);
            PhieuNhapHang rpPhieuNhap = new PhieuNhapHang();
            string connectionString = "Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";
            string query = $"SELECT CTNH.giaNhap, CTNH.soLuong, MATHANG.tenMH, MATHANG.maMH, PHIEUNHAPHANG.ngayNhap, PHIEUNHAPHANG.tongTien FROM CTNH INNER JOIN MATHANG ON CTNH.maMH = MATHANG.maMH INNER JOIN PHIEUNHAPHANG ON CTNH.maPhieuNhap = PHIEUNHAPHANG.maPhieuNhap WHERE PHIEUNHAPHANG.maPhieuNhap = {maPN}";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter adptr = new SqlDataAdapter(query, conn);
            adptr.Fill(rpPhieuNhap, rpPhieuNhap.Tables[0].TableName);

            ReportDataSource rds = new ReportDataSource("DSNH", rpPhieuNhap.Tables[0]);
            this.rpvXuatPhieuDat.LocalReport.DataSources.Clear();
            this.rpvXuatPhieuDat.LocalReport.DataSources.Add(rds);

            this.rpvXuatPhieuDat.LocalReport.SetParameters(new ReportParameter("paTong", tong));


            this.rpvXuatPhieuDat.LocalReport.Refresh();


            this.rpvXuatPhieuDat.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
