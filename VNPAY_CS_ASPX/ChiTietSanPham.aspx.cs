using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                BindData(Convert.ToString(pID));

            }

            List<SanPham> lstSPNew = Dao.DaoSanPham.getTop5New();
            dtlNew.DataSource = lstSPNew;
            DataBind();

            List<SanPham> lstRelated = Dao.DaoSanPham.getTop5related(ThuongHieu.Text, Convert.ToString(pID));
            dtlRelated.DataSource = lstRelated;
            DataBind();
        }
        public void BindData(string pID)
        {
            SanPham sp = Dao.DaoSanPham.getOne(pID);
            SanPham dd = Dao.DaoSanPham.getDacDiem(pID);
            SanPham h = Dao.DaoSanPham.getHuong(pID);

            int money = sp.GiaBan;
            //CultureInfo culture = CultureInfo.CreateSpecificCulture("vi-VN");
            GiaBan.Text = money.ToString("#,#");
            ThuongHieu.Text = sp.TenThuongHieu.ToString();
            TenSP.Text = sp.TenSP.ToString();
            GioiTinh.Text = sp.GioiTinh.ToString();
            gioitinh1.Text = sp.GioiTinh.ToString();
            
            image1.ImageUrl = "Admin/SqlPic/" + sp.Anh;


            if (dd != null)
            {
                PhatHanh.Text = dd.PhatHanh.ToString();
                DoTuoi.Text = dd.DoTuoi.ToString();
                DoLuuMui.Text = dd.DoLuuMui.ToString();
            }

            if (h != null)
            {
                ToneHuong.Text = h.ToneHuong;
                HuongDau.Text = h.HuongDau;
                HuongGiua.Text = h.HuongGiua;
                HuongCuoi.Text = h.HuongCuoi;
            }
        }
        protected void ThemCart_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            
            else
            {
                int pID = Convert.ToInt32(Page.Request.QueryString["id"]);
                Entity.GioHang data = Dao.DaoGioHang.CheckGiohang((int)Session["UserID"], pID);
                if (data == null)
                {
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                    int pID1 = Convert.ToInt32(Page.Request.QueryString["id"]);
                    using (SqlConnection conn = new SqlConnection(strConnection))
                    {
                        SqlCommand cmd = new SqlCommand(
                            "insert into GioHang ( IDSanPham, UserID,SoLuong ) values ( @IDSanPham,  @UserID, @SoLuong)", conn);
                        conn.Open();
                        cmd.Parameters.AddWithValue("@IDSanPham", pID1);
                        cmd.Parameters.AddWithValue("UserID", Session["UserID"]);
                        cmd.Parameters.AddWithValue("@SoLuong", Soluong.Text);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("GioHang.aspx");
                    }
                }
                else
                {
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                    int pID1 = Convert.ToInt32(Page.Request.QueryString["id"]);
                    using (SqlConnection conn = new SqlConnection(strConnection))
                    {
                        SqlCommand cmd = new SqlCommand(
                            //"update GioHang ( IDSanPham, UserID,SoLuong ) values ( @IDSanPham,  @UserID, @SoLuong)", conn);
                            "update GioHang  set SoLuong = SoLuong + @SoLuong where IDSanPham = @IDSanPham and UserID = @UserID", conn);

                        conn.Open();
                        cmd.Parameters.AddWithValue("@IDSanPham", pID1);
                        cmd.Parameters.AddWithValue("UserID", Session["UserID"]);
                        cmd.Parameters.AddWithValue("@SoLuong", Soluong.Text);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("GioHang.aspx");
                    }
                }
            }
        }
    }
}