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
    public partial class SuaTH : System.Web.UI.Page
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

            HangSX th = Dao.DaoHangSX.getOneID(pID);
            tbThuongHieu.Text = th.TenThuongHieu;
            tbHot.Text = Convert.ToString(th.Hot);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (upAnh.HasFile)
            {
                string fileName = Path.GetFileName(upAnh.PostedFile.FileName);
                string filePath = Server.MapPath("SqlPic/Logo/" + fileName);
                upAnh.SaveAs(filePath);

                int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                        ("update [ThuongHieu] Set TenThuongHieu = @TenThuongHieu, Hot = @Hot, LogoBrand = @LogoBrand where MaThuongHieu = @MaThuongHieu ", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaThuongHieu", pID.ToString());
                    cmd.Parameters.AddWithValue("@TenThuongHieu", tbThuongHieu.Text);
                    cmd.Parameters.AddWithValue("@Hot", tbHot.Text);
                    cmd.Parameters.AddWithValue("@LogoBrand", upAnh.FileName);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("QlyThuongHieu.aspx");
                }
            }
            else
            {
                int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                        ("update [ThuongHieu] Set TenThuongHieu = @TenThuongHieu, Hot = @Hot where MaThuongHieu = @MaThuongHieu", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaThuongHieu", pID.ToString());
                    cmd.Parameters.AddWithValue("@TenThuongHieu", tbThuongHieu.Text);
                    cmd.Parameters.AddWithValue("@Hot", tbHot.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("QlyThuongHieu.aspx");
                }
            
            }
        }
    }
}