using CuaHangSachHuynhTanPhatBUS;
using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatDTO;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmHoaDon : Form
    {
        private int maNV;
        private int maMH;
        
        public frmHoaDon()
        {
            InitializeComponent();
        }

        public frmHoaDon(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        //Hàm chỉ cho phép nhập số
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {

            cboGioiTinh.SelectedIndex = 0; 

            txtMaNV.Text = maNV.ToString();
            txtTenNV.Text = TaiKhoanBUS.Instance.LayTenNV(maNV.ToString());

            cboLoaiHang.DataSource = LoaiBUS.Instance.LayDSLoai();
            cboLoaiHang.DisplayMember = "tenLoai";
            cboLoaiHang.ValueMember = "maLoai";
            

            dtpNgayLap.MaxDate= DateTime.Now.Date;
            dtpNgayLap.MinDate = DateTime.Now.Date.Date;

            txtSDT.ShortcutsEnabled = false;

            

           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonMatHang_Click(object sender, EventArgs e)
        {
            
            ChonMatHang frm = new ChonMatHang(cboLoaiHang.Text);
            DialogResult rs = frm.ShowDialog();
            frm.TopLevel = false;
            frm.Parent = this;


            if(rs == DialogResult.OK)
            {
                txtTenMatHang.Text = frm.tenMH;
                maMH = frm.maMH;
                nudSoLuong.Maximum = MatHangBUS.Instance.LayTonKho(maMH);
                txtGia.Text = HoaDonBUS.Instance.LayGiaMatHang(maMH).ToString();

            }
           
        }

        private void lamMoiKH()
        {
            txtTenKhachHang.Text = string.Empty;
            txtSDT.Text= string.Empty;
            txtDiaChi.Text = string.Empty;
            cboGioiTinh.SelectedIndex= 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }
        private void lamMoiHD()
        {
            cboLoaiHang.SelectedIndex = 0;
            txtTenMatHang.Text= string.Empty;
            txtGia.Text = string.Empty;
            nudSoLuong.Value = nudSoLuong.Minimum;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            KhachHangDTO KHMoi = new KhachHangDTO()
            {
                tenKH = txtTenKhachHang.Text,
                gioiTinh = cboGioiTinh.Text,
                SDT = txtSDT.Text,
                diaChi = txtDiaChi.Text
            };
            int maLoi = 0;
            if (KhachHangBUS.Instance.ThemKhachHang(KHMoi, out maLoi))
            {
               
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm khách hàng thành công");
                lamMoiKH();
            }
            else
            {
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm khách hàng thất bại");
            }


        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = FUNCTION.laChuSo(e.KeyChar);
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            bool tonTai = false;
            //Kiểm tra xem nhập đủ dữ liệu chưa
            if (string.IsNullOrEmpty(txtTenMatHang.Text) || string.IsNullOrEmpty(txtGia.Text))
                return;
            if(nudSoLuong.Value < 1) return;

            double tongTien = Convert.ToInt32(nudSoLuong.Value.ToString()) * Convert.ToInt32(txtGia.Text);

            foreach (DataGridViewRow row in dgvDSHD.Rows)
            {
                //Nếu maMH đã tồn tại thì cộng dồn số lượng và tiền
                if (row.Cells["colmaMH"].Value != null && row.Cells["colmaMH"].Value.ToString().Equals(maMH.ToString()))
                {
                    tonTai = true;
                    if (row.Cells["colSoLuong"].Value != null)
                    {
                        int SL = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        SL += Convert.ToInt32(nudSoLuong.Value);
                        row.Cells["colSoLuong"].Value = SL.ToString();
                        row.Cells["colThanhTien"].Value = (Convert.ToInt32(row.Cells["colThanhTien"].Value) + tongTien).ToString();
                       
                    }
                }
                
            }

           
            if (!tonTai)
            {
                dgvDSHD.Rows.Add(maMH.ToString(), txtTenMatHang.Text, cboLoaiHang.Text, txtGia.Text, nudSoLuong.Value.ToString(), tongTien.ToString());
            }
           


            int thanhTien = 0;
            for (int i = 0;i < dgvDSHD.Rows.Count;i++) 
            {

                thanhTien += Convert.ToInt32(dgvDSHD.Rows[i].Cells[5].Value);
            }

            lbTong.Text = thanhTien.ToString();

            lamMoiHD();
           
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtTenMatHang.Text = dgvDSHD.Rows[e.RowIndex].Cells[1].Value.ToString();
            cboLoaiHang.Text = dgvDSHD.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGia.Text = dgvDSHD.Rows[e.RowIndex].Cells[3].Value.ToString();
            nudSoLuong.Text = dgvDSHD.Rows[e.RowIndex].Cells[4].Value.ToString();
            lbTong.Text = "0";
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if(dgvDSHD.SelectedRows.Count == 0) return;

            dgvDSHD.Rows[dgvDSHD.SelectedRows[0].Index].Cells[1].Value = txtTenMatHang.Text;
            dgvDSHD.Rows[dgvDSHD.SelectedRows[0].Index].Cells[2].Value = cboLoaiHang.Text;
            dgvDSHD.Rows[dgvDSHD.SelectedRows[0].Index].Cells[3].Value = txtGia.Text;
            dgvDSHD.Rows[dgvDSHD.SelectedRows[0].Index].Cells[4].Value = nudSoLuong.Value.ToString();
            double tongTien = Convert.ToInt32(nudSoLuong.Value.ToString()) * Convert.ToInt32(txtGia.Text);
            dgvDSHD.Rows[dgvDSHD.SelectedRows[0].Index].Cells[5].Value = tongTien.ToString();
            int thanhTien = 0;
            for (int i = 0; i < dgvDSHD.Rows.Count; i++)
            {

                thanhTien += Convert.ToInt32(dgvDSHD.Rows[i].Cells[5].Value);
            }

            lbTong.Text = thanhTien.ToString();

            lamMoiHD();



        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvDSHD.SelectedRows)
                {
                    dgvDSHD.Rows.RemoveAt(item.Index); 
                }

                //Tính tổng tiền lại
                int thanhTien = 0;
                for (int i = 0; i < dgvDSHD.Rows.Count; i++)
                {

                    thanhTien += Convert.ToInt32(dgvDSHD.Rows[i].Cells[5].Value);
                }

                lbTong.Text = thanhTien.ToString();

                lamMoiHD();
            }
               
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            lamMoiHD();
            dgvDSHD.Rows.Clear();
            lamMoiKH();
            lbTong.Text = "0";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xuất hóa đơn này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {

                int maHD;
                HoaDonDTO hdMoi = new HoaDonDTO()
                {
                    tongTien = Convert.ToDouble(lbTong.Text),
                    ngayLap = dtpNgayLap.Value,
                    maNV = Convert.ToInt32(txtMaNV.Text),

                };

                if (HoaDonBUS.Instance.ThemHoaDon(hdMoi, out maHD))
                {
                    for (int i = 0; i < dgvDSHD.Rows.Count - 1; i++)
                    {
                        CTHD_DTO cthd = new CTHD_DTO()
                        {
                            maHD = maHD,
                            maMH = Convert.ToInt32(dgvDSHD.Rows[i].Cells["colmaMH"].Value),
                            soLuongBan = Convert.ToInt32(dgvDSHD.Rows[i].Cells["colSoLuong"].Value),
                        };
                        MatHangDTO mh = new MatHangDTO()
                        {
                            maMH = Convert.ToInt32(dgvDSHD.Rows[i].Cells["colmaMH"].Value),
                            tonKho = MatHangBUS.Instance.LayTonKho(Convert.ToInt32(dgvDSHD.Rows[i].Cells["colmaMH"].Value)) - Convert.ToInt32(dgvDSHD.Rows[i].Cells["colSoLuong"].Value),
                            
                        };
                        bool kq = HoaDonBUS.Instance.ThemCTHD(cthd);
                        kq = MatHangBUS.Instance.SuaTonKhoMatHang(mh);
                    }
                }

                int tong = Convert.ToInt32(lbTong.Text);
                frmXemHoaDonXuat frm = new frmXemHoaDonXuat(maHD, txtTenKhachHang.Text, txtDiaChi.Text, lbTong.Text);
                frm.ShowDialog();
                frm.TopLevel = false;
                frm.Parent = this;
            }
            lamMoiHD();
            dgvDSHD.Rows.Clear();
            lamMoiKH();
        }

        private void txtTenMatHang_TextChanged(object sender, EventArgs e)
        {
            nudSoLuong.Maximum = MatHangBUS.Instance.LayTonKho(maMH);
            
        }
    }
}
