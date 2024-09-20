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
using CuaHangSachHuynhTanPhatDTO;
using CuaHangSachHuynhTanPhatBUS;

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmTaiKhoan : Form
    {
       
        private string maTaiKhoan;
        
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        


        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            

            //Xu li combobox maNV
            cboMaNhanVien.DataSource = layMaNV();
            
            //Lay ra ten nhan vien ma cbomaNV dang hien thi
            txtTenNhanVien.Text = layTenNhanVien(cboMaNhanVien.Text);


            //Xu li combobox quyen
            cboQuyen.SelectedIndex = 0;

            //Xu li datagridview DSTaiKhoan
            dgvDSTK.AutoGenerateColumns = false;
            dgvDSTK.DataSource = layDSTaiKhoan();
            dgvDSTK.ClearSelection();
        }

       
        private List<int> layMaNV()
        {
            return TaiKhoanBUS.Instance.LayMaNV();
        }


        private List<TaiKhoanDTO> layDSTaiKhoan()
        {
            return TaiKhoanBUS.Instance.LayDSTaiKhoan();
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            TaiKhoanDTO taiKhoanMoi = new TaiKhoanDTO()
            {
                tenDangNhap = txtTenDangNhap.Text.Trim(),
                matKhau = txtMatKhau.Text.Trim(),
                maNV = Convert.ToInt32(cboMaNhanVien.SelectedValue.ToString().Trim()),
                quyen = cboQuyen.Text.Trim(),
                trangThai = true

            };

            int maLoi = 0;
            //Thêm thành công thì hiện ra thông báo
            if (TaiKhoanBUS.Instance.themTaiKhoan(taiKhoanMoi, out maLoi))
            {

                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm thành công");
                dgvDSTK.DataSource = layDSTaiKhoan();
                lamMoi();
            }
            else
            {
                if (maLoi == 1)
                {
                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa nhập đủ thông tin");

                    return;
                }
                else if(maLoi == 2)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Tài khoản này đã tồn tại");

                    return;
                }
                else if (maLoi == 3)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Tên đăng nhập này đã tồn tại");

                    return;
                }
                else if (maLoi == 4)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Nhân viên này đã có tài khoản");

                    return;
                }
            }

           
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = layTenNhanVien(cboMaNhanVien.Text);
           
        }

        private void lamMoi()
        {
            txtMatKhau.Text = string.Empty;
            txtTenDangNhap.Text= string.Empty;
            cboQuyen.SelectedIndex = 0;
            cboMaNhanVien.SelectedIndex = 0;
            maTaiKhoan = string.Empty;
            dgvDSTK.ClearSelection();
            
        }
        private string layTenNhanVien(string maNV)
        {
            return TaiKhoanBUS.Instance.LayTenNV(maNV);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }

       
        private void dgvDSTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            maTaiKhoan = dgvDSTK.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenDangNhap.Text = dgvDSTK.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txtMatKhau.Text = dgvDSTK.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            cboMaNhanVien.Text = dgvDSTK.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            cboQuyen.SelectedIndex = dgvDSTK.Rows[e.RowIndex].Cells[4].Value.ToString() == "Admin" ? 0 : 1;
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            if (dgvDSTK.SelectedRows.Count == 0 || string.IsNullOrEmpty(maTaiKhoan))
            {
                taiKhoan = null;
            }
            else
            {
                taiKhoan.maTaiKhoan = Convert.ToInt32(maTaiKhoan);
                taiKhoan.tenDangNhap = txtTenDangNhap.Text.Trim();
                taiKhoan.matKhau = txtMatKhau.Text.Trim();
                taiKhoan.maNV = Convert.ToInt32(cboMaNhanVien.SelectedValue.ToString().Trim());
                taiKhoan.quyen = cboQuyen.Text.Trim();
            }

            int maLoi = 0;

            if (TaiKhoanBUS.Instance.suaTaiKhoan(taiKhoan, out maLoi) || maLoi == 0)
            {

                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Cập nhật thành công");
                dgvDSTK.DataSource = layDSTaiKhoan();
                dgvDSTK.ClearSelection();
                lamMoi();
            }
            else
            {
                if (maLoi == 1)
                {
                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa nhập đủ thông tin");

                    return;
                }
                else if (maLoi == 2)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa chọn mục nào để sửa");

                    return;
                }
                else if (maLoi == 3)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Tên đăng nhập này đã tồn tại");

                    return;
                }
                else if (maLoi == 4)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Nhân viên này đã có tài khoản");

                    return;
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            TaiKhoanDTO taiKhoan = new TaiKhoanDTO();
            if (dgvDSTK.SelectedRows.Count == 0 || maTaiKhoan == null)
            {
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa chọn mục nào để xóa");
                return;
            }
            else
            {
                taiKhoan.maTaiKhoan = Convert.ToInt32(maTaiKhoan);

            }
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {

                if (TaiKhoanBUS.Instance.xoaTaiKhoan(taiKhoan))
                {
                   
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Xóa thành công");
                    dgvDSTK.DataSource = layDSTaiKhoan();
                    lamMoi();

                }
                else
                {
                    lbThongBao.ForeColor= Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Không thể xóa tài khoản Admin cuối cùng");
                    return;
                }
                

            }
            
        }

       
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTimKiem.Text)) 
            {

                dgvDSTK.DataSource = layDSTaiKhoan().FindAll(item => item.tenDangNhap.ToLower() == txtTimKiem.Text.ToLower());

            }
            else
            {
                dgvDSTK.DataSource = layDSTaiKhoan();

            }

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {

                dgvDSTK.DataSource = layDSTaiKhoan().FindAll(item => item.tenDangNhap.ToLower().Contains(txtTimKiem.Text.ToLower()));

            }
            else
            {
                dgvDSTK.DataSource = layDSTaiKhoan();

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
        }
    }
}
