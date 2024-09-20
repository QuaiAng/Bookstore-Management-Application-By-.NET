using CuaHangSachHuynhTanPhatBUS;
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
    public partial class FrmQuanLyPhieuDat : Form
    {
        public FrmQuanLyPhieuDat()
        {
            InitializeComponent();
        }

        
        private void FrmQuanLyPhieuDat_Load(object sender, EventArgs e)
        {
            dgvDSPD.AutoGenerateColumns = false;
            dgvDSPD.DataSource = PhieuDatBUS.Instance.LayDSPhieuDat();
            dgvDSPD.ClearSelection();
        }

        private void dgvDSPD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMaNCC.Text = dgvDSPD.Rows[e.RowIndex].Cells["colMaNCC"].Value.ToString();
            txtTenNV.Text = TaiKhoanBUS.Instance.LayTenNV(dgvDSPD.Rows[e.RowIndex].Cells["colMaNCC"].Value.ToString());
            txtMaNV.Text = dgvDSPD.Rows[e.RowIndex].Cells["colMaNV"].Value.ToString();
            txtTenNCC.Text = NhaCungCapBUS.Instance.LayTenNCCTheoMa(Convert.ToInt32(dgvDSPD.Rows[e.RowIndex].Cells["colMaNCC"].Value));
            dtpNgayTao.Text = dgvDSPD.Rows[e.RowIndex].Cells["colNgayDat"].Value.ToString();
            txtMaPhieuDat.Text = dgvDSPD.Rows[e.RowIndex].Cells["colMaPhieuDat"].Value.ToString();
        }
    }
}
