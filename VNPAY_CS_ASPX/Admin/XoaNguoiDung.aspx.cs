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
    public partial class XoaNguoiDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("delete from NguoiDung where UserID = @UserID", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@UserID", pID.ToString());
                //cmd.Parameters.AddWithValue("@Anh", upAnh.FileName);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlyNguoiDung.aspx");

            }
        }
    }
}