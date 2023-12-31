using PJWebNC.Entity;
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
    public partial class SuaND : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                BindData(Convert.ToString(pID));

            }
        }
        protected void BindData(string pID)
        {

            NguoiDung sp = Dao.DaoNguoiDung.getOneID(pID);
            tbTaiKhoan.Text = sp.TaiKhoan;
            tbMatKhau.Text = sp.MatKhau;
            tbFullName.Text = sp.FullName;
            VaiTro.SelectedIndex = sp.VaiTro - 1;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update [NguoiDung] Set TaiKhoan = @TaiKhoan, MatKhau = @MatKhau, FullName = @FullName, VaiTro = @VaiTro where UserID = @UserID", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@UserID", pID.ToString());
                cmd.Parameters.AddWithValue("@TaiKhoan", tbTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MatKhau", tbMatKhau.Text);
                cmd.Parameters.AddWithValue("@FullName", tbFullName.Text);
                cmd.Parameters.AddWithValue("@VaiTro", VaiTro.SelectedIndex + 1);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlyNguoiDung.aspx");
            }
        }
    }
}