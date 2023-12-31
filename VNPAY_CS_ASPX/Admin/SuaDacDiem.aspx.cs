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
    public partial class SuaDacDiem : System.Web.UI.Page
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

            DacDiem th = Dao.DaoDacDiem.getOneID(pID);
            tbIDSanPham.Text = Convert.ToString(th.IDSanPham);
            tbPhatHanh.Text = Convert.ToString(th.PhatHanh);
            tbDoTuoi.Text = Convert.ToString(th.DoTuoi);
            tbDoLuuMui.Text = Convert.ToString(th.DoLuuMui);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update [DacDiem] Set IDSanPham = @IDSanPham, PhatHanh = @PhatHanh, DoTuoi = @DoTuoi, DoLuuMui = @DoLuuMui where IDDacDiem = @IDDacDiem", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@IDDacDiem", pID.ToString());
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