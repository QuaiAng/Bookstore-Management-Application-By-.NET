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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CuaHangSachHuynhTanPhatDTO;
using CuaHangSachHuynhTanPhatDAO;
using CuaHangSachHuynhTanPhatBUS;

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmNhaCungCap : Form
    {

        private string maNCC;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

       
        private List<NhaCungCapDTO> LayDSNhaCungCap()
        {
            return NhaCungCapBUS.Instance.LayDSNhaCungCap();
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvDSNCC.AutoGenerateColumns = false;
            dgvDSNCC.DataSource = LayDSNhaCungCap();
            dgvDSNCC.ClearSelection();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {

            NhaCungCapDTO nccMoi = new NhaCungCapDTO()
            {
                tenNCC = txtTenNCC.Text,
            };

            int maLoi = 0;

            if (NhaCungCapBUS.Instance.ThemNCC(nccMoi, out maLoi))
            {
                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Thêm thành công");
                dgvDSNCC.DataSource = LayDSNhaCungCap();
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
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Nhà cung cấp này đã tồn tại");

                    return;
                }

            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {

            NhaCungCapDTO NCC = new NhaCungCapDTO();
            if (dgvDSNCC.SelectedRows.Count == 0 || string.IsNullOrEmpty(maNCC))
            {
                NCC = null;
            }
            else
            {
                NCC.maNCC = Convert.ToInt32(maNCC);
                NCC.tenNCC = txtTenNCC.Text;
            }


            int maLoi = 0;

            if (NhaCungCapBUS.Instance.SuaNCC(NCC, out maLoi))
            {

                lbThongBao.ForeColor = Color.Green;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Sửa thành công");
                dgvDSNCC.DataSource = LayDSNhaCungCap();
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
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Tên nhà cung cấp này đã tồn tại");

                    return;
                }

            }
        }
        

        private void btnXoa_Click(object sender, EventArgs e)
        {

            NhaCungCapDTO NCC = new NhaCungCapDTO();
            if (dgvDSNCC.SelectedRows.Count == 0 || string.IsNullOrEmpty(maNCC))
            {
                lbThongBao.ForeColor = Color.Red;
                FUNCTION.hienThongBao(lbThongBao, timer1, "Bạn chưa chọn mục nào để xóa");
                return;
            }
            else
            {
                NCC.maNCC = Convert.ToInt32(maNCC);

            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (NhaCungCapBUS.Instance.XoaNCC(NCC))
                {
                    
                    lbThongBao.ForeColor= Color.Green;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Xóa thành công");
                    dgvDSNCC.DataSource = LayDSNhaCungCap();
                    LamMoi();

                }
                else
                {
                    lbThongBao.ForeColor = Color.Red;
                    FUNCTION.hienThongBao(lbThongBao, timer1, "Xóa thành công");
                    return;
                }

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbThongBao.Visible = false;
            timer1.Stop();
        }

        
        private void dgvDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            maNCC = dgvDSNCC.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            txtTenNCC.Text = dgvDSNCC.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
        }

       
        private void LamMoi()
        {
            txtTenNCC.Text = string.Empty;
            maNCC = string.Empty;
            dgvDSNCC.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                dgvDSNCC.DataSource = LayDSNhaCungCap();
            }
            else
            {
                dgvDSNCC.DataSource = NhaCungCapBUS.Instance.TimNhaCungCapTheoTen(txtTimKiem.Text);
            }
        }
    }
}
