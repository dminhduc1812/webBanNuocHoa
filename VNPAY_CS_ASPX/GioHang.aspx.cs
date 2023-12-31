using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["DiaChi"] == null)
                {
                    string message = "Vui lòng đăng nhập để dùng tính năng này ";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('" + message + "');", false);
                    Response.Redirect("DangNhap.aspx");
                }
                      
                BindData();
                List<Entity.GioHang> lst = Dao.DaoGioHang.getAllByUser((int)Session["UserID"]);
                dtlGioHang.DataSource = lst;
                DataBind();
            }
        }
        protected void BindData()
        {
            Entity.GioHang data = Dao.DaoGioHang.TongTien((int)Session["UserID"]);
            //TongTien.Text = data.TongTien.ToString("C0", new CultureInfo("vi-VN"));
            
            if(data != null)
            {
                int money = data.TongTien;
                TongTien.Text = money.ToString("#,# VNĐ");
            }
            else
            {
                lbTieuDe.Text = "Giỏ hàng hiện tại chưa có gì hãy đi mua sắm nào";
                
                hidden1.InnerText = "";
                hidden2.InnerText = "";
                bThanhToan.Visible = false;
            }
        }
        protected void bXoa_Click(object sender, EventArgs e)
        {
            
        }

        protected void bCapNhap_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("DanhSach.aspx");
            
        }
        protected void dtlGioHang_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Xoa")
            {
                string id = e.CommandArgument.ToString();
                //code xóa sản phẩm theo ID
                //ví dụ: MyDataAccess.DeleteSanPham(id);
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(
                        "delete from GioHang where IDSanPham = @IDSanPham and UserID = @UserID", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@IDSanPham", id);
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    BindData();
                    List<Entity.GioHang> lst = Dao.DaoGioHang.getAllByUser((int)Session["UserID"]);
                    dtlGioHang.DataSource = lst;
                    DataBind();
                    Response.Redirect("GioHang.aspx");

                }
            }
            if(e.CommandName == "Update")
            {
                string id = e.CommandArgument.ToString();
                TextBox tbSoLuong = (TextBox)e.Item.FindControl("tbSoLuong");
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(
                        "update GioHang set SoLuong = @SoLuong where UserID = @UserID and IDSanPham = @IDSanPham", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@IDSanPham", id);
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    cmd.Parameters.AddWithValue("@SoLuong", tbSoLuong.Text);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("GioHang.aspx");
                }
            }
            
        }

        protected void bThanhToan_Click(object sender, EventArgs e)
        {

                int ss = (int)Session["UserID"];
                string dc = (string)Session["DiaChi"];
                string pID = "id=" + ss;
                
                Response.Redirect("vnpay_pay.aspx?" + pID +"&dc=" + dc);
        }
    }
}