using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJWebNC.Entity
{
    public class DacDiem
    {
        public int IDDacDiem { get; set; }
        public int IDSanPham { get; set; }
        public int PhatHanh { get; set; }
        public int DoTuoi { get; set; }
        public int DoLuuMui { get; set; }
        public string TenSP { get; set; }
    }
}