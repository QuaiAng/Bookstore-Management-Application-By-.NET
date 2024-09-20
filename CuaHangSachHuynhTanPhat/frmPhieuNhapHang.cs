using CuaHangSachHuynhTanPhatBUS;
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
    public partial class frmPhieuNhapHang : Form
    {
        private int maMH;
        private int maNV;
        private int STT = 1;
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }

        public frmPhieuNhapHang(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = maNV.ToString();
            txtTenNV.Text = TaiKhoanBUS.Instance.LayTenNV(maNV.ToString());

            cboLoaiHang.DataSource = LoaiBUS.Instance.LayDSLoai();
            cboLoaiHang.DisplayMember = "tenLoai";
            cboLoaiHang.ValueMember = "maLoai";


            dtpNgayLap.MaxDate = DateTime.Now.Date;
            dtpNgayLap.MinDate = DateTime.Now.Date.Date;

            dgvDSMH.AutoGenerateColumns = false;
            dgvDSMH.DataSource = MatHangBUS.Instance.LayDSMatHang();
            dgvDSMH.ClearSelection();

            cboNCC.DataSource = NhaCungCapBUS.Instance.LayDSNhaCungCap();
            cboNCC.DisplayMember = "tenNCC";
            cboNCC.ValueMember = "maNCC";

            txtGia.ShortcutsEnabled = false;
        }

        private void lamMoi()
        {
            cboLoaiHang.SelectedIndex = 0;
            txtTenMatHang.Text = string.Empty;
            cboNCC.SelectedIndex = 0;
            nudSoLuong.Value = nudSoLuong.Minimum;
            txtGia.Text = string.Empty;
            dgvDSNH.ClearSelection();
            dgvDSMH.ClearSelection();
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = FUNCTION.laChuSo(e.KeyChar);
        }

        private void btnChonMatHang_Click(object sender, EventArgs e)
        {
            ChonMatHang frm = new ChonMatHang(cboLoaiHang.Text);
            DialogResult rs = frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;


            if (rs == DialogResult.OK)
            {
                txtTenMatHang.Text = frm.tenMH;
                maMH = frm.maMH;
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            bool tonTai = false;
            //Kiểm tra xem nhập đủ dữ liệu chưa
            if (string.IsNullOrEmpty(txtTenMatHang.Text))
            {
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Vui lòng chọn một mặt hàng");
                return;
            }    
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                lbThongBao.ForeColor= Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Vui lòng điền giá nhập hàng");
                return;
            }   
            if (nudSoLuong.Value < 1) return;



            foreach (DataGridViewRow row in dgvDSNH.Rows)
            {
                //Nếu maMH đã tồn tại thì cộng dồn số lượng và tiền
                if (row.Cells["colTenMatHang"].Value != null && row.Cells["colTenMatHang"].Value.ToString().Trim().Equals(txtTenMatHang.Text.Trim()))
                {
                    tonTai = true;
                    if (row.Cells["colSoLuong"].Value != null)
                    {
                        int SL = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        SL += Convert.ToInt32(nudSoLuong.Value);
                        row.Cells["colSoLuong"].Value = SL.ToString();

                    }

                }

            }


            if (!tonTai)
            {
                dgvDSNH.Rows.Add((STT++).ToString(), txtTenMatHang.Text, maMH.ToString(), nudSoLuong.Value.ToString(), txtGia.Text,  cboNCC.Text);
            }


            int thanhTien = 0;
            for (int i = 0; i < dgvDSNH.Rows.Count; i++)
            {

                thanhTien += (Convert.ToInt32(dgvDSNH.Rows[i].Cells["colGiaNhap"].Value) * Convert.ToInt32(dgvDSNH.Rows[i].Cells["colSoLuong"].Value));
            }

            lbTong.Text = thanhTien.ToString();

            lamMoi();
        }

        private void dgvDSMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            cboLoaiHang.Text = dgvDSMH.Rows[e.RowIndex].Cells["colLoai"].Value.ToString();
            txtTenMatHang.Text = dgvDSMH.Rows[e.RowIndex].Cells["colTenMH"].Value.ToString();
            txtGia.Text = string.Empty;
            nudSoLuong.Value = nudSoLuong.Minimum;
            maMH = Convert.ToInt32(dgvDSMH.Rows[e.RowIndex].Cells["colMaMH"].Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (dgvDSNH.SelectedRows.Count == 0) return;

            dgvDSNH.Rows[dgvDSNH.SelectedRows[0].Index].Cells[1].Value = txtTenMatHang.Text;
            dgvDSNH.Rows[dgvDSNH.SelectedRows[0].Index].Cells[2].Value = nudSoLuong.Value;
            dgvDSNH.Rows[dgvDSNH.SelectedRows[0].Index].Cells[3].Value = txtGia.Text;
            dgvDSNH.Rows[dgvDSNH.SelectedRows[0].Index].Cells[4].Value = cboNCC.Text;


            int thanhTien = 0;
            for (int i = 0; i < dgvDSNH.Rows.Count; i++)
            {

                thanhTien += Convert.ToInt32(dgvDSNH.Rows[i].Cells["colGiaNhap"].Value);
            }

            lbTong.Text = thanhTien.ToString();


            lamMoi();
        }

        private void dgvDSNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            txtTenMatHang.Text = dgvDSNH.Rows[e.RowIndex].Cells["colTenMatHang"].Value.ToString();
            nudSoLuong.Value = Convert.ToInt32(dgvDSNH.Rows[e.RowIndex].Cells["colSoLuong"].Value);
            cboNCC.Text = dgvDSNH.Rows[e.RowIndex].Cells["colNCC"].Value.ToString();
            txtGia.Text = dgvDSNH.Rows[e.RowIndex].Cells["colGiaNhap"].Value.ToString();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (dgvDSNH.SelectedRows.Count < 1)
            {
                MessageBox.Show("Vui lòng chọn 1 mục trong danh sách đặt hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvDSNH.SelectedRows)
                {
                    dgvDSNH.Rows.RemoveAt(item.Index);
                }


                int thanhTien = 0;
                for (int i = 0; i < dgvDSNH.Rows.Count; i++)
                {

                    thanhTien += Convert.ToInt32(dgvDSNH.Rows[i].Cells["colGiaNhap"].Value);
                }

                lbTong.Text = thanhTien.ToString();


                lamMoi();
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
            dgvDSNH.Rows.Clear();
            STT = 1;
            lbTong.Text = "0";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xuất hóa đơn này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                int maPN = 0;
                PhieuNhapDTO pdMoi = new PhieuNhapDTO()
                {
                    maNCC = Convert.ToInt32(cboNCC.SelectedValue),
                    ngayNhap = dtpNgayLap.Value,
                    maNV = Convert.ToInt32(txtMaNV.Text),
                    tongTien = Convert.ToDouble(lbTong.Text),

                };

                if (PhieuNhapBUS.Instance.ThemPhieuNhap(pdMoi, out maPN))
                {
                    for (int i = 0; i < dgvDSNH.Rows.Count - 1; i++)
                    {
                        CTNH_DTO ctnh = new CTNH_DTO()
                        {
                            maPhieuNhap = maPN,
                            maMH = Convert.ToInt32(dgvDSNH.Rows[i].Cells["colMaMatHang"].Value),
                            soLuong = Convert.ToInt32(dgvDSNH.Rows[i].Cells["colSoLuong"].Value),
                            giaNhap = Convert.ToInt32(dgvDSNH.Rows[i].Cells["colGiaNhap"].Value),
                        };

                        bool kq = PhieuNhapBUS.Instance.ThemCTNH(ctnh);
                    }
                }


                frmXemPhieuNhapHang frm = new frmXemPhieuNhapHang(maPN, lbTong.Text);
                frm.ShowDialog();
                frm.TopLevel = false;
                frm.Parent = this;
            }
        }

        private void txtTimMH_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtTimMH.Text))
            {

                dgvDSMH.DataSource = MatHangBUS.Instance.TimKiemMatHangTheoTen(txtTimMH.Text, "");

            }
            else
            {
                dgvDSMH.DataSource = MatHangBUS.Instance.LayDSMatHang();

            }
        }
    }
}
