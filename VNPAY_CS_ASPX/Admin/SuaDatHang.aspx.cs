using PJWebNC.Entity;
using PJWebNC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace PJWebNC.Admin
{
    public partial class SuaDatHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                BindData((pID));

            }
        }
        protected void BindData(long pID)
        {
            DatHang data = Dao.DaoDatHang.getOneID(pID);
            string money = data.SoTienThanhToan.ToString("#,#");
            //tbIDDatHang.Text = Convert.ToString(data.IDDatHang);
            tbFullName.Text = data.FullName;
            tbMaGD.Text = data.NgayGD.ToString("dd/MM/yyyy");
            tbThanhToan.Text = money;
            tbSDT.Text = data.SoDienThoai;
            TrangThai.SelectedIndex = data.IDTrangThai - 1;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update [DatHang] Set TrangThai = @TrangThai where MaGiaoDich = @MaGiaoDich", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@MaGiaoDich", pID.ToString());
                cmd.Parameters.AddWithValue("@TrangThai", TrangThai.SelectedIndex + 1);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("QlyDatHang.aspx");
            }
        }
    }
}