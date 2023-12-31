using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC.Admin
{
    public partial class ThemThuongHieu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("insert into [ThuongHieu] (TenThuongHieu, Hot) values (@TenThuongHieu, @Hot)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@TenThuongHieu", tbThuongHieu.Text);
                cmd.Parameters.AddWithValue("@Hot", tbHot.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlySanPham.aspx");
            }
        }
    }
}