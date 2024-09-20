using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSachHuynhTanPhatDTO
{
    public class MatHangDTO
    {
        public int maMH { get; set; }
        public string tenMH { get; set; }
        public double giaBan { get; set; }
        public int tonKho { get; set; }
        public int maLoai { get; set; }
        public string tenLoai { get; set; }

        public bool trangThai { get; set; }

    }
}
