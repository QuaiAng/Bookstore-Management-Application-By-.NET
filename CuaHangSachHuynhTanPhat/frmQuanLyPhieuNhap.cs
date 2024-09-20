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
    public partial class frmQuanLyPhieuNhap : Form
    {
        public frmQuanLyPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhieuNhap_Load(object sender, EventArgs e)
        {
            dgvDSPN.AutoGenerateColumns = false;
            dgvDSPN.DataSource = PhieuNhapBUS.Instance.LayDSPhieuNhap();
            dgvDSPN.ClearSelection();
        }

        private void dgvDSPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMaPhieuNhap.Text = dgvDSPN.Rows[e.RowIndex].Cells["colMaPhieuNhap"].Value.ToString();
            txtTenNV.Text = LuongBUS.Instance.LayTenNV(dgvDSPN.Rows[e.RowIndex].Cells["colMaNV"].Value.ToString());
            txtMaNCC.Text = dgvDSPN.Rows[e.RowIndex].Cells["colMaNCC"].Value.ToString();
            txtTenNCC.Text = NhaCungCapBUS.Instance.LayTenNCCTheoMa(Convert.ToInt32(dgvDSPN.Rows[e.RowIndex].Cells["colMaNCC"].Value));
            dtpNgayNhan.Value = Convert.ToDateTime(dgvDSPN.Rows[e.RowIndex].Cells["colNgayNhan"].Value);
            txtMaNV.Text = dgvDSPN.Rows[e.RowIndex].Cells["colMaNV"].Value.ToString();
        }
    }
}
