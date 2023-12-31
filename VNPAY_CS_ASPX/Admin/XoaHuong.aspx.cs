using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC.Admin
{
    public partial class XoaHuong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("delete from Huong where IDHuong = @IDHuong", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@IDHuong", pID.ToString());
                //cmd.Parameters.AddWithValue("@Anh", upAnh.FileName);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlyHuong.aspx");

            }
        }
    }
}