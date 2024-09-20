using CuaHangSachHuynhTanPhatBUS;
using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CuaHangSachHuynhTanPhat
{
    

    public partial class frmThongTinNhanVien : Form
    {
       
        
        private string maNV = string.Empty;
        


        public frmThongTinNhanVien()
        {
            InitializeComponent();
        }


        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18); 
            dtpNgaySinh.MaxDate = DateTime.Now.AddYears(-18); 

            cboGioiTinh.SelectedIndex = 0;

            dgvDSNV.AutoGenerateColumns= false;
            dgvDSNV.DataSource = LayDSNhanVien();
            dgvDSNV.ClearSelection();

            

        }

        //Chỉ cho người dùng nhập số
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = FUNCTION.laChuSo(e.KeyChar);
        }

        private List<NhanVienDTO> LayDSNhanVien()
        {
            return NhanVienBUS.Instance.LayDSNhanVien();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            NhanVienDTO nvMoi = new NhanVienDTO()
            {
                maNV = Convert.ToInt32(maNV == string.Empty ? "0" : maNV),
                tenNV = txtTenNV.Text,
                gioiTinh = cboGioiTinh.Text,
                ngaySinh = dtpNgaySinh.Value.Date,
                SDT = txtSDT.Text,
                diaChi = txtDiaChi.Text,
                CCCD = txtSoCCCD.Text,
            };

            int maLoi = 0;
            if (NhanVienBUS.Instance.ThemNhanVien(nvMoi, out maLoi))
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm thành công");
                dgvDSNV.DataSource = LayDSNhanVien();
                LamMoi();
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
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Dữ liệu này đã tồn tại");

                    return;
                }
                else if (maLoi == 3)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Số CCCD này đã tồn tại");

                    return;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }

        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            
           
            maNV = dgvDSNV.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenNV.Text = dgvDSNV.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            cboGioiTinh.Text = dgvDSNV.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            dtpNgaySinh.Value = DateTime.Parse(dgvDSNV.Rows[e.RowIndex].Cells[3].Value.ToString());
            txtSoCCCD.Text = dgvDSNV.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            txtDiaChi.Text = dgvDSNV.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
            txtSDT.Text = dgvDSNV.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();



        }

        void LamMoi()
        {
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtSoCCCD.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            cboGioiTinh.SelectedIndex = 0;
            dgvDSNV.ClearSelection();
            maNV = string.Empty;
            txtTimKiem.Text = string.Empty;
            dgvDSNV.DataSource = LayDSNhanVien();
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            NhanVienDTO nv = new NhanVienDTO();
            if (dgvDSNV.SelectedRows.Count == 0 || string.IsNullOrEmpty(maNV))
            {
                nv = null;

            }
            else
            {
                nv.maNV = Convert.ToInt32(maNV);
                nv.tenNV = txtTenNV.Text;
                nv.SDT = txtSDT.Text;
                nv.gioiTinh = cboGioiTinh.Text;
                nv.diaChi = txtDiaChi.Text;
                nv.ngaySinh = dtpNgaySinh.Value.Date;
                nv.CCCD = txtSoCCCD.Text;

            };

            int maLoi = 0;

            if (NhanVienBUS.Instance.SuaNhanVien(nv, out maLoi) || maLoi == 0)
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Sửa thành công");
                dgvDSNV.DataSource = LayDSNhanVien();
                LamMoi();
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
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Số CCCD này đã tồn tại");

                    return;
                }

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            if (dgvDSNV.SelectedRows.Count == 0)
            {
               
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa chọn mục nào để xóa");

                return;
            }
            else
            {
                nv.maNV = Convert.ToInt32(maNV);
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {


                if (NhanVienBUS.Instance.XoaNhanVien(nv))
                {

                    lbThongBao.ForeColor = Color.Green;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Xóa thành công");
                    dgvDSNV.DataSource = LayDSNhanVien();
                    LamMoi();

                }
                else
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Không thể xóa nhân viên Admin cuối cùng");
                    return;
                }

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {

                dgvDSNV.DataSource = NhanVienBUS.Instance.TimKiemNhanVienTheoTen(txtTimKiem.Text);

            }
            else
            {
                dgvDSNV.DataSource = LayDSNhanVien();

            }
        }

      
        

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}

