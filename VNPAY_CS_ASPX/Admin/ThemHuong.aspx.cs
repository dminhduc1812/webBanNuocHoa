using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC.Admin
{
    public partial class ThemHuong : System.Web.UI.Page
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
                    ("insert into [Huong] ( IDSanPham, ToneHuong, HuongDau, HuongGiua, HuongCuoi) values ( @IDSanPham, @ToneHuong, @HuongDau, @HuongGiua, @HuongCuoi)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@IDSanPham", tbIDSanPham.Text);
                cmd.Parameters.AddWithValue("@ToneHuong", tbToneHuong.Text);
                cmd.Parameters.AddWithValue("@HuongDau", tbHuongDau.Text);
                cmd.Parameters.AddWithValue("@HuongGiua", tbHuongGiua.Text);
                cmd.Parameters.AddWithValue("@HuongCuoi", tbHuongCuoi.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlyHuong.aspx");
            }
        }
    }
}