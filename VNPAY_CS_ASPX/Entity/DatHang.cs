using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJWebNC.Entity
{
    public class DatHang
    {
        public int IDDatHang { get; set; }
        public string UserID { get; set; }
        public DateTime NgayGD { get; set; }
        public int TongTien { get; set; }
        public string FullName { get; set; }
        public int SoTienThanhToan { get; set; }
        public string TrangThai { get; set; }
        public int IDTrangThai { get; set; }
        public string SoDienThoai { get; set; } 
        public string DiaChi { get; set; }
        public int DoanhThu { get; set; }
        public int MaGiaoDich { get; set; } 
    }
}