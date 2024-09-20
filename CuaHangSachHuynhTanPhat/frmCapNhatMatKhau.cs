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

namespace CuaHangSachHuynhTanPhat
{
    public partial class frmCapNhatMatKhau : Form
    {
        //Khai bao
        public string maTaiKhoan;

        static frmDangNhap frm = new frmDangNhap();
        public static string connectionString = @"Data Source=.;Initial Catalog=QLiCuaHangSach;Integrated Security=True";

        SqlConnection conn = new SqlConnection(connectionString);

        public frmCapNhatMatKhau(string maTaiKhoan)
        {
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
        }

        public frmCapNhatMatKhau()
        {
            InitializeComponent();
            this.maTaiKhoan = string.Empty;
        }


        //Neu nguoi dung dong form, ung dung se dung hoan toan
        private void frmCapNhatMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Su kien nut Doi
        private void btnDoi_Click(object sender, EventArgs e)
        {

            
            //Mo ket noi
            conn.Open();

            //Tao cau truy van lay ra mat khau dua tren ma tai khoan
            string query = string.Format("SELECT matKhau FROM TAIKHOAN WHERE maTaiKhoan = '{0}'", this.maTaiKhoan);

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            string matKhau = "";

            while (reader.Read())
            {
                matKhau = reader["matKhau"].ToString();
            }

            
            matKhau = matKhau.Trim(); //Luoc bo di khoang trang
           
            //Dong ket noi
            conn.Close();

            //Kiem tra xem nguoi dung da nhap dung mat khau hien tai chua
            if (txtMatKhauHienTai.Text != matKhau)
            {
                lbError.Visible = true;
                lbError2.Visible = false;
                lbError3.Visible = false;
                
            }
            else
            {   //Kiem tra xem nguoii dung da nhap mat khau moi chưa
                if(string.IsNullOrEmpty(txtMatKhauMoi.Text) && string.IsNullOrEmpty(txtXacNhan.Text))
                {
                    lbError.Visible = false;
                    lbError2.Visible = false;
                    lbError3.Visible = true;
                }
                else if (txtMatKhauMoi.Text != txtXacNhan.Text)
                {
                    lbError.Visible = false;
                    lbError2.Visible = true;
                    lbError3.Visible = false;
                    
                }
                //Nguoc lai nguoi dung da nhap dung va day du thong tin
                else
                {
                    conn.Open();

                    string query_2 = string.Format("UPDATE TAIKHOAN SET matKhau = '{0}' WHERE maTaiKhoan = {1}", txtXacNhan.Text, this.maTaiKhoan);
                    
                    SqlCommand cmd_2 = new SqlCommand(query_2, conn);
                    
                    int count = cmd_2.ExecuteNonQuery();
                    
                    if(count > 0)
                    {
                        //Neu doi mk thanh cong thi hien thi cau thong bao thanh cong va quay ve man hinh chinh
                        DialogResult rs = MessageBox.Show("Cập nhật mật khẩu mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(rs == DialogResult.OK)
                        {
                            frmMainAdmin frmAD = new frmMainAdmin();
                            this.Dispose();
                            frmAD.Show();
                        }
                    }
                    else
                    {
                        //NGuoc lai thi hien thi thong bao that bai
                        MessageBox.Show("Cập nhật mật khẩu mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    conn.Close();

                }
            }

            

            

        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            Image coverImg = Properties.Resources.cover_password;
            Image showImg = Properties.Resources.show_password;

            if (txtMatKhauHienTai.PasswordChar == '\0')
            {
                // Nếu mật khẩu đang được hiển thị, thì đặt lại thành ký tự ẩn
                txtMatKhauHienTai.PasswordChar = '*';
                txtMatKhauMoi.PasswordChar= '*';
                txtXacNhan.PasswordChar= '*';
                btnShowPassword.Image = showImg;
            }
            else
            {
                // Nếu mật khẩu đang ẩn, thì hiển thị nó
                txtMatKhauHienTai.PasswordChar = '\0';
                txtMatKhauMoi.PasswordChar = '\0';
                txtXacNhan.PasswordChar = '\0';
                btnShowPassword.Image = coverImg;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMainAdmin frmAD = new frmMainAdmin();
            this.Dispose();
            frmAD.Show();
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.Length > 15)
            {
                txtMatKhauMoi.Text = txtMatKhauMoi.Text.Substring(0, 10);
                txtMatKhauMoi.SelectionStart = txtMatKhauMoi.Text.Length;
            }
        }
    }
}
