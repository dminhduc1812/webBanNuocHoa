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
    public partial class ThemSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (upAnh.HasFile)
            {
                string fileName = Path.GetFileName(upAnh.PostedFile.FileName);
                string filePath = Server.MapPath("SqlPic/" + fileName);
                upAnh.SaveAs(filePath);
            } 
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("insert into [SanPham] (TenSP, MaThuongHieu, GiaBan, GioiTinh, Season, Anh) values (@TenSP, @MaThuongHieu, @GiaBan, @GioiTinh, @Season, @Anh)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@TenSP", tbTenSP.Text);
                cmd.Parameters.AddWithValue("@MaThuongHieu", ThuongHieu.SelectedValue);
                cmd.Parameters.AddWithValue("@GiaBan", tbGiaBan.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh.SelectedValue);
                cmd.Parameters.AddWithValue("@Season", Season.SelectedValue);
                cmd.Parameters.AddWithValue("@Anh", upAnh.FileName);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlySanPham.aspx");
            }
        }

    }
}