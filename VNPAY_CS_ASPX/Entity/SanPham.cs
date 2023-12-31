using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJWebNC.Entity
{
    public class SanPham
    {
        public int IDSanPham { get; set; }
        public string TenSP { get; set; }
        public int MaThuongHieu { get; set; }
        public int GiaBan { get; set; }
        public int MaGioiTinh { get; set; }
        public string GioiTinh { get; set; }
        public string Season { get; set; }
        public int MaSeason { get; set; }
        public string Anh { get; set; }
        public int Hot { get; set; }
        public int Huong { get; set; }
        public int DacDiem { get; set; }
        public int KhuyenDung { get; set; }

        public string TenThuongHieu { get; set; }
        public int DoTuoi { get; set; }
        public int PhatHanh { get; set; }
        public int DoLuuMui { get; set; }

        public string ToneHuong { get; set; }
        public string HuongDau { get; set; }
        public string HuongGiua { get; set; }
        public string HuongCuoi { get; set; }

        public int SoLuongSanPham { get; set; }
    }
}