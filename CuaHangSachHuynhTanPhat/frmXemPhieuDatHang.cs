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
    public partial class frmXemPhieuDatHang : Form
    {
        private int maPD;
        private string tenNCC;
        public frmXemPhieuDatHang()
        {
            InitializeComponent();
        }

        public frmXemPhieuDatHang(int maPD, string tenNCC)
        {
            InitializeComponent();
            this.maPD = maPD;
            this.tenNCC = tenNCC;
        }

        private void frmXemPhieuDatHang_Load(object sender, EventArgs e)
        {
            this.rpvXuatPhieuDat.LocalReport.ReportPath = @"..\..\Reports\rptXuatPhieuDat.rdlc";


            //this.HoaDonTableAdapter.Fill(this.HoaDon.HoaDon);
            PhieuDatHang rpPhieuDat = new PhieuDatHang();
            string connectionString = "Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";
            string query = $"SELECT CTDH.soLuong, PHIEUDATHANG.ngayDat, MATHANG.tenMH, MATHANG.giaBan FROM CTDH INNER JOIN MATHANG ON CTDH.maMH = MATHANG.maMH INNER JOIN PHIEUDATHANG ON CTDH.maPhieuDat = PHIEUDATHANG.maPhieuDat WHERE PHIEUDATHANG.maPhieuDat = {maPD}";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter adptr = new SqlDataAdapter(query, conn);
            adptr.Fill(rpPhieuDat, rpPhieuDat.Tables[0].TableName);

            ReportDataSource rds = new ReportDataSource("DSDH", rpPhieuDat.Tables[0]);
            this.rpvXuatPhieuDat.LocalReport.DataSources.Clear();
            this.rpvXuatPhieuDat.LocalReport.DataSources.Add(rds);

            this.rpvXuatPhieuDat.LocalReport.SetParameters(new ReportParameter("paTenNCC", tenNCC));
           

            this.rpvXuatPhieuDat.LocalReport.Refresh();


            this.rpvXuatPhieuDat.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
