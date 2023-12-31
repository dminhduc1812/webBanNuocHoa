using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["UserID"] == null)
                //{
                //    Response.Redirect("../DangNhap.aspx");
                //}
                if (Session["VaiTro"] == null)
                {
                    Response.Redirect("../DangNhap.aspx");

                }
                else if ((int)Session["VaiTro"] != 1)
                {
                    Response.Redirect("../default.aspx");

                }
            }
            string ss = (string)Session["FullName"];
            nameLogin.InnerText = ss;

        }
    }
}