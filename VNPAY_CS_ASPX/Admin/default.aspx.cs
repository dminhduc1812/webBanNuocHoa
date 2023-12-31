using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace PJWebNC.Admin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entity.SanPham sl = Dao.DaoSanPham.getSoLuong();
            SoLuong.InnerText = Convert.ToString(sl.SoLuongSanPham);

            Entity.DatHang dh = Dao.DaoDatHang.TongTien();
            DoanhThuu.InnerText = dh.TongTien.ToString("#,#") + " VND";

            Entity.DatHang dl = Dao.DaoDatHang.SlDonHang();
            slDon.InnerText = dl.TongTien.ToString();

            Entity.DatHang slcht = Dao.DaoDatHang.SlChuaHT();
            ChuaHoanThanh.InnerText = slcht.TongTien.ToString();

        }
    }
}