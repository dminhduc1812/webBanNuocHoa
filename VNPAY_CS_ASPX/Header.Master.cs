using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FullName"] != null)
            {
                Page.Title = "Xin chào " + Session["FullName"].ToString();
            }
            else
            {
                
                Page.Title ="Trang chủ" ;
            }
        }
    }
}