using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class QLyTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            lbTen.Text = (string)Session["FullName"];
            if ((int)Session["VaiTro"] != 1)
            {
                bHref.Visible = false;
            }
        }

        protected void bHref_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin");
        }
    }
}