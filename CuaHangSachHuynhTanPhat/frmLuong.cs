using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhat;
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
using CuaHangSachHuynhTanPhatDTO;
using CuaHangSachHuynhTanPhatBUS;

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmLuong : Form
    {
        private string maLuong = string.Empty;
        public frmLuong()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            cboTinhTrang.SelectedIndex = 0;
            dgvDSLuong.AutoGenerateColumns = false;
            dgvDSLuong.DataSource = layDSLuong();
            dtpThoiGian.MaxDate = DateTime.Now.Date;
            cboMaNV.DataSource = LuongBUS.Instance.LayMaNV();

            txtLuongCung.ShortcutsEnabled = false;
            txtPhuCap.ShortcutsEnabled = false;
            txtTienPhat.ShortcutsEnabled = false;

        }


        private List<LuongDTO> layDSLuong()
        {
            return LuongBUS.Instance.LayDSLuong();
        }

        //Hàm chỉ cho phép nhập số
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = FUNCTION.laChuSo(e.KeyChar);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lamMoi()
        {
            cboMaNV.SelectedIndex = 0;
            txtLuongCung.Text = string.Empty;
            txtPhuCap.Text = string.Empty;
            txtTienPhat.Text = string.Empty;
            cboTinhTrang.SelectedIndex = 0;
            maLuong = string.Empty;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LuongDTO luong = new LuongDTO();
            if (dgvDSLuong.SelectedRows.Count == 0)
            {
                luong = null;
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa chọn mục nào để xóa");

                return;
            }
            else
            {
                luong.maLuong = Convert.ToInt32(maLuong);
            }

            int maLoi = 0;
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {


                if (LuongBUS.Instance.XoaLuong(luong, out maLoi) && maLoi == 0)
                {

                    cboMaNV.Enabled = true;
                    lbThongBao.ForeColor = Color.Green;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Xóa thành công");
                    dgvDSLuong.DataSource = layDSLuong();
                    lamMoi();

                }
               
            }
        }

        private void dgvDSLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;


            //cboMaNhanVien.Enabled = false;
            maLuong = dgvDSLuong.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenNV.Text = dgvDSLuong.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txtLuongCung.Text = dgvDSLuong.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            txtPhuCap.Text = dgvDSLuong.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            txtTienPhat.Text = dgvDSLuong.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            lbTong.Text = dgvDSLuong.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
            cboTinhTrang.SelectedIndex = dgvDSLuong.Rows[e.RowIndex].Cells[8].Value.ToString() == "Chưa thanh toán" ? 0 : 1;
            dtpThoiGian.Value = Convert.ToDateTime(dgvDSLuong.Rows[e.RowIndex].Cells[6].Value.ToString());
            cboMaNV.Text = dgvDSLuong.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = LuongBUS.Instance.LayTenNV(cboMaNV.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            LuongDTO luong = new LuongDTO()
            {
                maLuong = Convert.ToInt32(maLuong == string.Empty ? "0" : maLuong),
                luongCung = Convert.ToDouble(string.IsNullOrEmpty(txtLuongCung.Text) ? "0" : txtLuongCung.Text),
                phuCap = Convert.ToDouble(string.IsNullOrEmpty(txtPhuCap.Text) ? "0" : txtPhuCap.Text),
                tienPhat = Convert.ToDouble(string.IsNullOrEmpty(txtTienPhat.Text) ? "0" : txtTienPhat.Text),
                thoiGian = dtpThoiGian.Value,
                tongLuong = Convert.ToDouble(lbTong.Text == "0 VND" ? "0" : lbTong.Text),
                tinhTrang = cboTinhTrang.Text.Trim(),
                maNV = Convert.ToInt32(cboMaNV.Text),
                trangThai = true,
            };

            int maLoi = 0;
            if (LuongBUS.Instance.ThemLuong(luong, out maLoi) && maLoi == 0)
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm thành công");
                dgvDSLuong.ClearSelection();
                dgvDSLuong.DataSource = layDSLuong();
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
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Thông tin lương này đã tồn tại");

                    return;
                }
                else if (maLoi == 3)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Lương cứng phải lớn hơn 0");

                    return;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            LuongDTO luong = new LuongDTO();
            if (dgvDSLuong.SelectedRows.Count == 0 || string.IsNullOrEmpty(maLuong))
            {
                luong = null;
            }
            else
            {
                luong.maLuong = Convert.ToInt32(maLuong);
                luong.phuCap = Convert.ToDouble(string.IsNullOrEmpty(txtPhuCap.Text) ? "0" : txtPhuCap.Text);
                luong.tinhTrang = (cboTinhTrang.Text == "Chưa thanh toán" ? 0 : 1).ToString().Trim();
                luong.maNV = Convert.ToInt32(cboMaNV.Text.Trim());
                luong.tongLuong = Convert.ToDouble(lbTong.Text == "0" ? "0" : lbTong.Text);
                luong.luongCung = Convert.ToDouble(string.IsNullOrEmpty(txtLuongCung.Text) ? "0" : txtLuongCung.Text);
                luong.tienPhat = Convert.ToDouble(string.IsNullOrEmpty(txtTienPhat.Text) ? "0" : txtTienPhat.Text);
                luong.thoiGian = dtpThoiGian.Value;
            }


            int maLoi = 0;
            if (LuongBUS.Instance.SuaLuong(luong, out maLoi) || maLoi == 0)
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Sửa thành công");
                dgvDSLuong.ClearSelection();
                dgvDSLuong.DataSource = layDSLuong();
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

        private void txt_TextChanged(object sender, EventArgs e)
        {

            double Tong = Convert.ToDouble(string.IsNullOrEmpty(txtLuongCung.Text) ? "0" : txtLuongCung.Text)
                + Convert.ToDouble(string.IsNullOrEmpty(txtPhuCap.Text) ? "0" : txtPhuCap.Text)
                - Convert.ToDouble(string.IsNullOrEmpty(txtTienPhat.Text) ? "0" : txtTienPhat.Text);
            lbTong.Text = Tong.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {

                dgvDSLuong.DataSource = LuongBUS.Instance.TimKiemNhanVienTheoTen(txtTimKiem.Text);

            }
            else
            {
                dgvDSLuong.DataSource = layDSLuong();

            }
        }
    }
}
