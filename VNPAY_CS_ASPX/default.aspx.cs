using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<HangSX> lst = Dao.DaoHangSX.getHotHSX();
            DataList1.DataSource = lst;
            DataBind();

            List<SanPham> lstSanPham = Dao.DaoSanPham.getTop5Nam();
            List<SanPham> lstSanPham2 = Dao.DaoSanPham.getTop5Nu();
            List<SanPham> lstSanPham3 = Dao.DaoSanPham.getTop5Uni();
            SanPham.DataSource = lstSanPham;
            DataBind();
            dtlTopNu.DataSource= lstSanPham2;
            dtlTopNu.DataBind();   
            dtlTopUni.DataSource=lstSanPham3;
            dtlTopUni.DataBind();
        }
    }
}