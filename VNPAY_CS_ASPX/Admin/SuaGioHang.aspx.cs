using PJWebNC.Entity;
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
    public partial class SuaGioHang : System.Web.UI.Page
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

            Entity.GioHang th = Dao.DaoGioHang.getOneID(pID);
            tbUserID.Text = Convert.ToString(th.UserID);
            tbIDSanPham.Text = Convert.ToString(th.IDSanPham);
            tbSoLuong.Text = Convert.ToString(th.SoLuong);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update [GioHang] Set UserID = @UserID, IDSanPham = @IDSanPham, SoLuong = @SoLuong where IDGioHang = @IDGioHang", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@IDGioHang", pID.ToString());
                cmd.Parameters.AddWithValue("@UserID", tbUserID.Text);
                cmd.Parameters.AddWithValue("@IDSanPham", tbIDSanPham.Text);
                cmd.Parameters.AddWithValue("@SoLuong", tbSoLuong.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlyGioHang.aspx");
            }
        }
    }
}