using CuaHangSachHuynhTanPhatBUS;
using CuaHangSachHuynhTanPhatDAO;
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
    public partial class frmThongTinKhachHang : Form
    {
        private string maKhachHang = string.Empty;
        public frmThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }

        private void lamMoi()
        {
            txtDiaChi.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            cboGioiTinh.SelectedIndex = 0;
            maKhachHang = string.Empty;
            dgvDSKH.ClearSelection();
        }

        private List<KhachHangDTO> LayDSKhachHang()
        {
            return KhachHangBUS.Instance.LayDSKhachHang();
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            dgvDSKH.AutoGenerateColumns = false;
            dgvDSKH.DataSource = LayDSKhachHang();
            dgvDSKH.ClearSelection();

            cboGioiTinh.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHangDTO KHMoi = new KhachHangDTO()
            {
                maKH = Convert.ToInt32(maKhachHang == string.Empty ? "0" : maKhachHang),
                tenKH = txtTenKH.Text,
                gioiTinh = cboGioiTinh.Text,
                SDT = txtSDT.Text,
                diaChi = txtDiaChi.Text,
            };
            int maLoi = 0;
            if(KhachHangBUS.Instance.ThemKhachHang(KHMoi, out maLoi))
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm thành công");
                dgvDSKH.DataSource = LayDSKhachHang();
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
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Dữ liệu này đã tồn tại");

                    return;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhachHangDTO KH = new KhachHangDTO();
            if (dgvDSKH.SelectedRows.Count == 0 || string.IsNullOrEmpty(maKhachHang))
            {
                KH = null;
                
            }   
            else
            {
                KH.maKH = Convert.ToInt32(maKhachHang);
                KH.tenKH = txtTenKH.Text;
                KH.SDT = txtSDT.Text;
                KH.gioiTinh = cboGioiTinh.Text;
                KH.diaChi = txtDiaChi.Text;
            };

            int maLoi = 0;

            if (KhachHangBUS.Instance.SuaKhachHang(KH, out maLoi) || maLoi == 0)
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Sửa thành công");
                dgvDSKH.DataSource = LayDSKhachHang();
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

            }
        }

        private void dgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            maKhachHang = dgvDSKH.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenKH.Text = dgvDSKH.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            cboGioiTinh.Text = dgvDSKH.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            txtSDT.Text = dgvDSKH.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            txtDiaChi.Text = dgvDSKH.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KhachHangDTO KH = new KhachHangDTO();
            if (dgvDSKH.SelectedRows.Count == 0)
            {
                KH = null;
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa chọn mục nào để xóa");

                return;
            }
            else
            {
                KH.maKH = Convert.ToInt32(maKhachHang);
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {


                if (KhachHangBUS.Instance.XoaKhachHang(KH))
                {

                    lbThongBao.ForeColor = Color.Green;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Xóa thành công");
                    dgvDSKH.DataSource = LayDSKhachHang();
                    lamMoi();

                }

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {

                dgvDSKH.DataSource = KhachHangBUS.Instance.TimKiemKhachHangTheoTen(txtTimKiem.Text);

            }
            else
            {
                dgvDSKH.DataSource = LayDSKhachHang();

            }
        }
    }
}
