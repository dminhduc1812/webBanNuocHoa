using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
      
        protected void bDangky1_Click(object sender, EventArgs e)
        {
            
                if (Validate1())
                {
                if (CheckTrung() == true)
                {
                    string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(strConnection))
                    {
                        SqlCommand cmd = new SqlCommand
                            ("insert into [NguoiDung] (TaiKhoan, MatKhau, FullName, VaiTro) values (@TaiKhoan, @MatKhau, @FullName,@VaiTro)", conn);
                        conn.Open();
                        cmd.Parameters.AddWithValue("@TaiKhoan", tbTaiKhoandk.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", tbMatKhaudk.Text);
                        cmd.Parameters.AddWithValue("@FullName", tbFullNamedk.Text);
                        cmd.Parameters.AddWithValue("@VaiTro", 2);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("<script>alert('Đăng ký tài khoản thành công ') </script>");

                    }
                }
                }
        }
        bool CheckTrung()
        {
            NguoiDung nd = Dao.DaoNguoiDung.getOne(tbTaiKhoandk.Text, tbMatKhaudk.Text);
            if(nd == null)
            {
                return true;
            }
            else
            {
                Check.Text = "Tài khoản đã tồn tại vui lòng nhập lại!!!";
                return false;
            }
            
        }
        bool Validate1()
        {

            if (tbMatKhaudk.Text != tbReMatKhaudk.Text)
            {
                Response.Write("<script>alert('Mật khẩu nhập vào không trùng khớp ') </script>");
                Response.Redirect("DangNhap.aspx");
                return false;
            }
            else if (tbTaiKhoandk.Text == "" || tbMatKhaudk.Text == "" || tbReMatKhaudk.Text == "")
            {
                Response.Write("<script>alert('Nhập đủ thông tin trước khi đăng ký ') </script>");
                Response.Redirect("DangNhap.aspx");

                return false;
            }
            else
            {
                return true;
            }

        }

        protected void bDangNhap_Click(object sender, EventArgs e)
        {
            if(tbTaiKhoandn.Text == null && tbMatKhaudn.Text == null)
            {
                Response.Write("<script>alert('Vui lòng nhập đủ tài khoản mật khẩu!!!: ') </script>");
                Response.Redirect("DangNhap.aspx");

            }
            else
            {
                NguoiDung ND = Dao.DaoNguoiDung.getOne(tbTaiKhoandn.Text, tbMatKhaudn.Text);
                if (ND == null)
                {
                    Response.Write("<script>alert('Tài khoản hoặc mật khẩu của bạn chưa đúng!!!: ') </script>");
                    Response.Redirect("DangNhap.aspx");
                }
                else
                {
                    Page.Session["FullName"] = ND.FullName;
                    Page.Session["UserID"] = ND.UserID;
                    Page.Session["VaiTro"] = ND.VaiTro;
                    Page.Session["TaiKhoan"] = ND.TaiKhoan;
                    Page.Session["MatKhau"] = ND.MatKhau;
                    Page.Session["DiaChi"] = ND.DiaChi;
                    Page.Session["SoDienThoai"] = ND.SoDienThoai;
                    Response.Redirect("default.aspx");
                }
            }
        }
    }
}