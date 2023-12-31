using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJWebNC.Entity
{
    public class Huong
    {
        public int IDHuong { get; set; }
        public int IDSanPham { get; set; }
        public string ToneHuong { get; set; }
        public string HuongDau { get; set; }
        public string HuongGiua { get; set; }
        public string HuongCuoi { get; set; }
        public string TenSP { get; set; }
    }
}