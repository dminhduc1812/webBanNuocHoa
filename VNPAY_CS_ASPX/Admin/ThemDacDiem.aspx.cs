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
    public partial class ThemDacDiem : System.Web.UI.Page
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
                    ("insert into [DacDiem] ( IDSanPham, PhatHanh, DoTuoi, DoLuuMui) values ( @IDSanPham, @PhatHanh, @DoTuoi, @DoLuuMui)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@IDSanPham", tbIDSanPham.Text);
                cmd.Parameters.AddWithValue("@PhatHanh", tbPhatHanh.Text);
                cmd.Parameters.AddWithValue("@DoTuoi", tbDoTuoi.Text);
                cmd.Parameters.AddWithValue("@DoLuuMui", tbDoLuuMui.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlyDacDiem.aspx");
            }
        }
    }
}