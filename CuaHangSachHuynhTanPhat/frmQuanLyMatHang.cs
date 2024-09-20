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
    public partial class frmQuanLyMatHang : Form
    {
        private string maLoai;
        private string maMatHang;
        public frmQuanLyMatHang()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            lbThongBao1.Visible = false;
            timer1.Stop();
        }
        private void lamMoiLoai()
        {
            txtTenLoai.Text = string.Empty;
            maLoai= string.Empty;
            dgvDSLoai.ClearSelection();
        }

        private void lamMoiMatHang()
        {
            cboMaLoai.SelectedIndex = 0;
            txtTenMatHang.Text = string.Empty;
            nudSoLuong.Value = 0;
            txtGiaBan.Text = string.Empty;
            maMatHang = string.Empty;
        }

        private List<LoaiDTO> LayDSLoai()
        {
            return LoaiBUS.Instance.LayDSLoai();
        }


        private List<MatHangDTO> LayDSMatHang()
        {
            return MatHangBUS.Instance.LayDSMatHang();
        }


        //Hàm chỉ cho phép nhập số
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuanLyMatHang_Load(object sender, EventArgs e)
        {
            dgvDSLoai.AutoGenerateColumns = false;
            dgvDSLoai.DataSource = LayDSLoai();
            dgvDSLoai.ClearSelection();

            dgvDSMatHang.AutoGenerateColumns = false;
            dgvDSMatHang.DataSource = LayDSMatHang();
            dgvDSMatHang.ClearSelection();
            
            cboMaLoai.DataSource = MatHangBUS.Instance.LayMaLoai();

            txtGiaBan.ShortcutsEnabled = false;
            

        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            LoaiDTO loaiMoi = new LoaiDTO()
            {
                tenLoai = txtTenLoai.Text,
            };
            int maLoi = 0;
            if(LoaiBUS.Instance.ThemLoai(loaiMoi, out maLoi) && maLoi == 0)
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm thành công");
                dgvDSLoai.DataSource = LayDSLoai();
                lamMoiLoai();
            }
            else
            {
                if(maLoi == 1)
                {
                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa nhập đủ thông tin");

                    return;
                }
                else if (maLoi == 2 || maLoi == 3)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Loại này đã tồn tại");

                    return;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lamMoiLoai();
        }

        

        private void dgvDSLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //isClick= true;
            maLoai = dgvDSLoai.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenLoai.Text = dgvDSLoai.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            LoaiDTO loai = new LoaiDTO();
            if (dgvDSLoai.SelectedRows.Count == 0 || string.IsNullOrEmpty(maLoai))
            {
                loai = null;
            }
            else
            {
                loai.maLoai = Convert.ToInt32(maLoai);
                loai.tenLoai = txtTenLoai.Text;
            }


            int maLoi = 0;
            if (LoaiBUS.Instance.SuaLoai(loai, out maLoi) || maLoi == 0)
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Sửa thành công");
                dgvDSLoai.DataSource = LayDSLoai();
                lamMoiLoai();
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
                else if ( maLoi == 3)
                {

                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Loại này đã tồn tại");

                    return;
                }
            }
        }

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            MatHangDTO matHangMoi = new MatHangDTO()
            {
                tenMH = txtTenMatHang.Text,
                giaBan = Convert.ToDouble(string.IsNullOrEmpty(txtGiaBan.Text.Trim()) ? "0" : txtGiaBan.Text.Trim()),
                tonKho = Convert.ToInt32(nudSoLuong.Value.ToString()),
                maLoai = Convert.ToInt32(string.IsNullOrEmpty(cboMaLoai.Text.Trim()) ? "0" : cboMaLoai.Text.Trim()),

            };

            int maLoi = 0;
            if (MatHangBUS.Instance.ThemMatHang(matHangMoi, out maLoi))
            {
                lbThongBao1.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao1, timer1, "Thêm thành công");
                dgvDSMatHang.DataSource = LayDSMatHang();
                lamMoiMatHang();
            }
            else
            {
                if (maLoi == 1)
                {
                    lbThongBao1.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao1, timer1, "Bạn chưa nhập đủ thông tin");

                    return;
                }
                else if (maLoi == 2)
                {

                    lbThongBao1.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao1, timer1, "Mặt hàng này đã tồn tại");

                    return;
                }
                else if (maLoi == 3)
                {

                    lbThongBao1.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao1, timer1, "Tên mặt hàng này đã tồn tại");

                    return;
                }


            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = FUNCTION.laChuSo(e.KeyChar);
        }

        private void cboMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenLoai1.Text = MatHangBUS.Instance.LayTenLoai(cboMaLoai.Text.Trim());
        }

        
        private void dgvDSMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            maMatHang = dgvDSMatHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenMatHang.Text = dgvDSMatHang.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenLoai1.Text = dgvDSMatHang.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGiaBan.Text = dgvDSMatHang.Rows[e.RowIndex].Cells[3].Value.ToString();
            nudSoLuong.Value = Convert.ToInt32(dgvDSMatHang.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        private void txtTenLoai1_TextChanged(object sender, EventArgs e)
        {
            cboMaLoai.Text = LayDSLoai().Find(u => u.tenLoai == txtTenLoai1.Text).maLoai.ToString();
        }

        private void btnSuaMatHang_Click(object sender, EventArgs e)
        {
            MatHangDTO matHang = new MatHangDTO();
            if (dgvDSLoai.Rows.Count == 0 || string.IsNullOrEmpty(maMatHang))
            {
                matHang = null;
            }
            else
            {
                matHang.maMH = Convert.ToInt32(maMatHang);
                matHang.tenMH = txtTenMatHang.Text;
                matHang.giaBan = Convert.ToDouble(string.IsNullOrEmpty(txtGiaBan.Text.Trim()) ? "0" : txtGiaBan.Text.Trim());
                matHang.tonKho = Convert.ToInt32(nudSoLuong.Value.ToString());
                matHang.maLoai = Convert.ToInt32(cboMaLoai.Text.Trim());

            };

            int maLoi = 0;
            if (MatHangBUS.Instance.SuaMatHang(matHang, out maLoi) || maLoi == 0)
            {
                lbThongBao1.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao1, timer1, "Sửa thành công");
                dgvDSMatHang.DataSource = LayDSMatHang();
                lamMoiMatHang();
            }
            else
            {
                if (maLoi == 1)
                {
                    lbThongBao1.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao1, timer1, "Bạn chưa nhập đủ thông tin");

                    return;
                }
                else if (maLoi == 2)
                {

                    lbThongBao1.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao1, timer1, "Bạn chưa chọn mục nào để sửa");

                    return;
                }
                else if (maLoi == 3)
                {

                    lbThongBao1.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao1, timer1, "Tên mặt hàng này đã tồn tại");

                    return;
                }


            }
        }

        private void btnLamMoiMatHang_Click(object sender, EventArgs e)
        {
            lamMoiMatHang();
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            LoaiDTO loai = new LoaiDTO();
            if (dgvDSLoai.SelectedRows.Count == 0)
            {
                loai = null;
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa chọn mục nào để xóa");

                return;
            }
            else
            {
                loai.maLoai = Convert.ToInt32(maLoai);
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {


                if (LoaiBUS.Instance.XoaLoai(loai))
                {

                    FUNCTION.hienThongBao(lbThongBao, timer1, "Xóa thành công");
                    dgvDSLoai.DataSource = LayDSLoai();
                    lamMoiLoai();
                }
                else
                {   lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Loại này vẫn còn sản phẩm, không thể xóa");
                    return;
                }

            }
        }

        private void btnXoaMatHang_Click(object sender, EventArgs e)
        {
            MatHangDTO matHang = new MatHangDTO();
            if (dgvDSMatHang.SelectedRows.Count == 0)
            {
                matHang = null;
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao1, timer1, "Bạn chưa chọn mục nào để xóa");

                return;
            }
            else
            {
                matHang.maMH = Convert.ToInt32(maMatHang);
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {


                if (MatHangBUS.Instance.XoaMatHang(matHang))
                {

                    FUNCTION.hienThongBao(lbThongBao1, timer1, "Xóa thành công");
                    dgvDSMatHang.DataSource = LayDSMatHang();
                    lamMoiMatHang();
                }
                

            }
        }

        private void txtTimMH_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimMH.Text))
            {

                dgvDSMatHang.DataSource = MatHangBUS.Instance.TimKiemMatHangTheoTen(txtTimMH.Text, "");

            }
            else
            {
                dgvDSMatHang.DataSource = LayDSMatHang();

            }
        }

        private void txtTimLoai_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimLoai.Text))
            {

                dgvDSLoai.DataSource = LoaiBUS.Instance.TimKiemLoaiTheoTen(txtTimLoai.Text);

            }
            else
            {
                dgvDSLoai.DataSource = LayDSLoai();

            }
        }
    }
    
}
