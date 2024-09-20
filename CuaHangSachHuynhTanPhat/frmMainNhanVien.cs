using CuaHangSachHuynhTanPhatBUS;
using CuaHangSachHuynhTanPhatDAO;
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
   
    public partial class frmMainNhanVien : Form
    {
        public int maNV;
        public frmMainNhanVien()
        {
            InitializeComponent();
            
        }


        public frmMainNhanVien(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void frmMainNhanVien_Load(object sender, EventArgs e)
        {
            lbTenNV.Text = $"<strong>{LuongBUS.Instance.LayTenNV(maNV.ToString())}</strong>";
        }

        private void frmMainNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cậpNhậtMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapNhatMatKhau frm = new frmCapNhatMatKhau();
            this.Dispose();
            frm.Show();
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon(maNV);
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnThongTinKhachHang_Click(object sender, EventArgs e)
        {
            frmThongTinKhachHang frm = new frmThongTinKhachHang();
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnQuanLyMatHang_Click(object sender, EventArgs e)
        {
            frmQuanLyMatHang frm = new frmQuanLyMatHang();
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnTaoPhieuDat_Click(object sender, EventArgs e)
        {
            frmPhieuDatHang frm = new frmPhieuDatHang(maNV);
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnTaoPhieuNhap_Click(object sender, EventArgs e)
        {

            frmPhieuNhapHang frm = new frmPhieuNhapHang(maNV);
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe(maNV);
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Ẩn cửa sổ tạm thời

        }

        private void tbclDieuHuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbclDieuHuong.SelectedIndex == 1)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Dispose();
            }
        }
    }
}
