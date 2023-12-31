using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJWebNC.Entity
{
    public class NguoiDung
    {
        public int UserID { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int VaiTro { get; set; }
        public string FullName { get; set; }
        public string TenVaiTro  { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}