using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangSachHuynhTanPhat
{
    public class FUNCTION
    {


        /// <summary>
        /// Kiểm tra xem một phần tử đã tồn tại trong DataGridView hay chưa
        /// </summary>
        /// <param name="text">Chuỗi cần kiểm tra</param>
        /// <param name="dgv">DataGridView cần kiểm tra</param>
        /// <param name="cell_index">Vị trí cột của phần tử đó</param>
        /// <returns>Trả về true nếu phần tử đó đã tồn tại, ngược lại trả về false</returns>
        public static bool daTonTai(string text, DataGridView dgv, int cell_index)
        {

            if (!string.IsNullOrEmpty(text))
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    string item = text;
                    if (item == dgv.Rows[i].Cells[cell_index].Value.ToString().Trim())
                    {
                       
                        return true;
                    }
                }

            }
            return false;

        }
        /// <summary>
        /// Hiển thị 1 label trong thời gian nhất định của Timer
        /// </summary>
        /// <param name="lb">Label cần hiển thị</param>
        /// <param name="timer">Timer dùng để set thời gian</param>
        public static void hienThongBao(Label lb, Timer timer, string cauThongBao = null)
        {
            // Hiển thị Label và bắt đầu Timer
            if(cauThongBao != null)
                lb.Text = cauThongBao;
            lb.Visible = true;
            timer.Start();
        }

        public static bool laChuSo(char c)
        {
            if (!char.IsDigit(c) && !char.IsControl(c))
                return true;
            else
                return false;

        }

    }   
}
