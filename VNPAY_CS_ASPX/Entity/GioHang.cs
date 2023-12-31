using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJWebNC.Entity
{
    public class GioHang
    {
        public int IDGioHang { get; set; }
        public int UserID { get; set; }
        public int IDSanPham { get; set; }
        public int SoLuong { get; set; }
        public string Anh { get; set; }
        public int GiaBan { get; set; }
        public string TenSP { get; set; }
        public int TongTien { get; set; }
        public string FullName { get; set; }
    }
}