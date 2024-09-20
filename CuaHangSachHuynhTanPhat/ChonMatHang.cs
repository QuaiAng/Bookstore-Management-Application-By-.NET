using CuaHangSachHuynhTanPhatBUS;
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
    public partial class ChonMatHang : Form
    {
        private string tenLoai;
        public int maMH;
        public string tenMH;
        public ChonMatHang()
        {
            InitializeComponent();
        }

        public ChonMatHang(string tenLoai)
        {
            InitializeComponent();
            this.tenLoai = tenLoai;
          
        }
        private void ChonMatHang_Load(object sender, EventArgs e)
        {
            dgvDSMH.AutoGenerateColumns = false;
            dgvDSMH.DataSource = MatHangBUS.Instance.LayDSMatHangTheoLoai(tenLoai);

        }

        private void dgvDSMH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            maMH = Convert.ToInt32(dgvDSMH.Rows[e.RowIndex].Cells[0].Value.ToString());
            tenMH = dgvDSMH.Rows[e.RowIndex].Cells[1].Value.ToString();


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvDSMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            maMH = Convert.ToInt32(dgvDSMH.Rows[e.RowIndex].Cells[0].Value.ToString());
            tenMH = dgvDSMH.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text)) 
            {
                dgvDSMH.DataSource = MatHangBUS.Instance.LayDSMatHangTheoLoai(tenLoai);
            }
            else
            {
                dgvDSMH.DataSource = MatHangBUS.Instance.TimKiemMatHangTheoTen(txtTimKiem.Text, tenLoai);
            }
            
        }
    }
}
