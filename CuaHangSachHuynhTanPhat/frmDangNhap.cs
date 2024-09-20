using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatBUS;

namespace CuaHangSachHuynhTanPhat
{

    public partial class frmDangNhap : Form
    {
        public int maNV;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
           
            

            if(LoginSuccessfully(tenDangNhap, matKhau))
            {
                if (Permission(tenDangNhap, matKhau))
                {
                    frmMainAdmin frmMainAdmin = new frmMainAdmin(maNV);
                    frmMainAdmin.Show();
                    this.Hide();
                }
                else
                {
                    frmMainNhanVien frmMaiNhanVien = new frmMainNhanVien(maNV);
                    frmMaiNhanVien.Show();
                    this.Hide();
                }
            }
            else
            {
                FUNCTION.hienThongBao(lbError, timer1);
            }
           
        }


        private bool LoginSuccessfully(string tenDangNhap, string matKhau)
        {
            return DangNhapBUS.Instance.LoginSuccessfully(tenDangNhap, matKhau, out maNV);
        }

        private bool Permission(string tenDangNhap, string matKhau)
        {
            return DangNhapBUS.Instance.Permission(tenDangNhap, matKhau);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbError.Visible = false;
            timer1.Stop();
        }

    }
}
