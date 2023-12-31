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
    public partial class SuaSanPham : System.Web.UI.Page
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

            SanPham sp = Dao.DaoSanPham.getOne(pID);
            tbTenSP.Text = sp.TenSP;
            
            tbGiaBan.Text = sp.GiaBan.ToString("#,#");
            
            ThuongHieu.SelectedIndex = sp.MaThuongHieu - 1;

            GioiTinh.SelectedIndex = sp.MaGioiTinh - 1 ;

            Season.SelectedIndex = sp.MaSeason - 1;


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (upAnh.HasFile)
            {
                string fileName = Path.GetFileName(upAnh.PostedFile.FileName);
                string filePath = Server.MapPath("SqlPic/" + fileName);
                upAnh.SaveAs(filePath);

                int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                        ("update [SanPham] Set TenSP = @TenSP, MaThuongHieu = @MaThuongHieu, Giaban = @GiaBan, GioiTinh = @GioiTinh, Season = @Season, Anh = @Anh where IDSanPham = @IDSanPham", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@IDSanPham", pID.ToString());
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
            else
            {
                int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                    string dirty = tbGiaBan.Text;
                string clean = dirty.Replace(",", "");
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                        ("update [SanPham] Set TenSP = @TenSP, MaThuongHieu = @MaThuongHieu, Giaban = @GiaBan, GioiTinh = @GioiTinh, Season = @Season where IDSanPham = @IDSanPham", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@IDSanPham", pID.ToString());
                    cmd.Parameters.AddWithValue("@TenSP", tbTenSP.Text);
                    cmd.Parameters.AddWithValue("@MaThuongHieu", ThuongHieu.SelectedValue);
                    cmd.Parameters.AddWithValue("@GiaBan", clean);
                    cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh.SelectedValue);
                    cmd.Parameters.AddWithValue("@Season", Season.SelectedValue);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("QlySanPham.aspx");
                }
            }

            
        }
    }
}