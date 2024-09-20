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
    public partial class frmPhieuDatHang : Form
    {
        private int maNV;
        private int maMH;
        private int STT = 1;
        public frmPhieuDatHang()
        {
            InitializeComponent();
        }

        public frmPhieuDatHang(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }
        private void frmPhieuDatHang_Load(object sender, EventArgs e)
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
            cboNCC.SelectedIndex = 0;
        }

        private void dgvDSMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            cboLoaiHang.Text = dgvDSMH.Rows[e.RowIndex].Cells["colLoai"].Value.ToString();
            txtTenMatHang.Text = dgvDSMH.Rows[e.RowIndex].Cells["colTenMH"].Value.ToString();
            maMH = Convert.ToInt32(dgvDSMH.Rows[e.RowIndex].Cells["colMaMH"].Value);
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

        private void txtTimMH_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTimMH.Text))
            {
                dgvDSMH.DataSource = MatHangBUS.Instance.LayDSMatHang();
            }
            else
            {
                dgvDSMH.DataSource = MatHangBUS.Instance.TimKiemMatHangTheoTonKho(Convert.ToInt32(txtTimMH.Text));
            }
        }

        private void lamMoi()
        {
            cboLoaiHang.SelectedIndex = 0;
            txtTenMatHang.Text = string.Empty;
            cboNCC.SelectedIndex = 0;
            nudSoLuong.Value = nudSoLuong.Minimum;
            dgvDSDH.ClearSelection();
            dgvDSMH.ClearSelection();
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
            if (nudSoLuong.Value < 1) return;

            

            foreach (DataGridViewRow row in dgvDSDH.Rows)
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
                dgvDSDH.Rows.Add((STT++).ToString(), txtTenMatHang.Text, maMH.ToString(), nudSoLuong.Value.ToString(), cboNCC.Text);
            }

            lamMoi();
        }

      

        private void dgvDSDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

           
            txtTenMatHang.Text = dgvDSDH.Rows[e.RowIndex].Cells["colTenMatHang"].Value.ToString();
            nudSoLuong.Value = Convert.ToInt32(dgvDSDH.Rows[e.RowIndex].Cells["colSoLuong"].Value);
            cboNCC.Text = dgvDSDH.Rows[e.RowIndex].Cells["colNCC"].Value.ToString();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (dgvDSDH.SelectedRows.Count == 0) return;

            dgvDSDH.Rows[dgvDSDH.SelectedRows[0].Index].Cells[1].Value = txtTenMatHang.Text;
            dgvDSDH.Rows[dgvDSDH.SelectedRows[0].Index].Cells[2].Value = nudSoLuong.Value;
            dgvDSDH.Rows[dgvDSDH.SelectedRows[0].Index].Cells[3].Value = cboNCC.Text;

            lamMoi();
           
        }


        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if(dgvDSDH.SelectedRows.Count < 1)
            {
                MessageBox.Show("Vui lòng chọn 1 mục trong danh sách đặt hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvDSDH.SelectedRows)
                {
                    dgvDSDH.Rows.RemoveAt(item.Index);
                }

                lamMoi();
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            lamMoi();
            dgvDSDH.Rows.Clear();
            STT = 1;

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xuất hóa đơn này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                int maPD;
                PhieuDatDTO pdMoi = new PhieuDatDTO()
                {
                    maNCC = Convert.ToInt32(cboNCC.SelectedValue),
                    ngayDat = dtpNgayLap.Value,
                    maNV = Convert.ToInt32(txtMaNV.Text),

                };

                if (PhieuDatBUS.Instance.ThemPhieuDat(pdMoi, out maPD))
                {
                    for (int i = 0; i < dgvDSDH.Rows.Count - 1; i++)
                    {
                        CTDH_DTO ctdh = new CTDH_DTO()
                        {
                            maPhieuDat = maPD,
                            maMH = Convert.ToInt32(dgvDSDH.Rows[i].Cells["colMaMatHang"].Value),
                            soLuong = Convert.ToInt32(dgvDSDH.Rows[i].Cells["colSoLuong"].Value),
                            maLoai = Convert.ToInt32(cboLoaiHang.SelectedValue)
                        };
                        
                        bool kq = PhieuDatBUS.Instance.ThemCTDH(ctdh);
                    }
                }

                
                frmXemPhieuDatHang frm = new frmXemPhieuDatHang(maPD, cboNCC.Text);
                frm.ShowDialog();
                frm.TopLevel = false;
                frm.Parent = this;
            }
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cboNCC.SelectedValue.ToString());
        }

        private void cboNCC_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cboNCC.SelectedValue.ToString());
        }
    }
}
