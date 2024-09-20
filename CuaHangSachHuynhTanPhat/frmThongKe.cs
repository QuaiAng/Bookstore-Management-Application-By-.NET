using CuaHangSachHuynhTanPhatBUS;
using CuaHangSachHuynhTanPhatDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmThongKe : Form
    {
        private int maNV;
        public frmThongKe()
        {
            InitializeComponent();
        }
        public frmThongKe(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<ThongKeDTO> LayThongKeTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return ThongKeBUS.Instance.LayThongKeTheoNgay(ngayBatDau, ngayKetThuc);
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            //dgvDSThongKe.AutoGenerateColumns = false;
            //dgvDSThongKe.DataSource = LayThongKe();
            //dgvDSThongKe.ClearSelection();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            dgvDSThongKe.AutoGenerateColumns = false;
            dgvDSThongKe.DataSource = LayThongKeTheoNgay(dtpNgayBatDau.Value, dtpNgayKetThuc.Value);
        }
    }
}
