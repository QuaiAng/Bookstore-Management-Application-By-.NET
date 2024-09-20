using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.Designer;
using CuaHangSachHuynhTanPhat;
using CuaHangSachHuynhTanPhatBUS;

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmMainAdmin : Form
    {
        private int maNV;
        public frmMainAdmin()
        {
            InitializeComponent();
        }
        public frmMainAdmin(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV; 
        }


        private void frmMainAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent= this;
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
                frmNhaCungCap frm = new frmNhaCungCap();
                frm.TopLevel = false;
                pnNhaCungCap.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
            else if (tbclDieuHuong.SelectedIndex == 2)
            {
                FrmQuanLyPhieuDat frm = new FrmQuanLyPhieuDat();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                pnQLPhieuDat.Controls.Add(frm);
                frm.Show();
            }
            else if (tbclDieuHuong.SelectedIndex == 3)
            {
                frmQuanLyPhieuNhap frm = new frmQuanLyPhieuNhap();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                pnQLPhieuNhap.Controls.Add(frm);
                frm.Show();
            }
            else if (tbclDieuHuong.SelectedIndex == 4)
            {
                
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Dispose();
            }
        }

        private void btnThongTinNhanVien_Click(object sender, EventArgs e)
        {
            frmThongTinNhanVien frm = new frmThongTinNhanVien();
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {

            frmLuong frm = new frmLuong();
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon(maNV);
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

        private void btnThongTinKhachHang_Click(object sender, EventArgs e)
        {
            frmThongTinKhachHang frm = new frmThongTinKhachHang();
            frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;
        }

        private void frmMainAdmin_Load(object sender, EventArgs e)
        {
            txtTenNV.Text = $"<strong>{LuongBUS.Instance.LayTenNV(maNV.ToString())}</strong>";
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
    }
}
