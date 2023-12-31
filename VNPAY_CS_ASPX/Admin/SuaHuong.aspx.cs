using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC.Admin
{
    public partial class SuaHuong : System.Web.UI.Page
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

            Huong th = Dao.DaoHuong.getOneID(pID);
            tbIDHuong.Text = Convert.ToString(th.IDHuong);
            tbIDSanPham.Text = Convert.ToString(th.IDSanPham);
            tbToneHuong.Text = th.ToneHuong;
            tbHuongDau.Text = th.HuongDau;
            tbHuongGiua.Text = th.HuongGiua;
            tbHuongCuoi.Text = th.HuongCuoi;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update [Huong] Set IDSanPham = @IDSanPham, ToneHuong = @ToneHuong, HuongDau = @HuongDau, HuongGiua = @HuongGiua, HuongCuoi = @HuongCuoi where IDHuong = @IDHuong", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@IDHuong", pID.ToString());
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