using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            
        }
        protected bool Validatetb()
        {
            string message = "";
            if (tbCurrentPass.Text == null || tbNewPass.Text == null || tbRePass.Text == null)
            {
                message = "vui lòng nhập dữ liệu!!";
                return false; 
            }

            return true;
        }
        protected void bLuu_Click(object sender, EventArgs e)
        {
            string message;
            if (tbCurrentPass.Text == "")
            {
                message = "Hãy nhập đủ thông tin";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('" + message + "');", true);


            }
            else if (tbNewPass.Text == "" && tbRePass.Text == "")
            {
                message = "Vui lòng đủ thông tin";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('" + message + "');", true);

            }
            else if(tbNewPass.Text != tbRePass.Text)
            {
                message = "Nhập lại mật khẩu mới chưa chính xác";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('" + message + "');", true);


            }
            else if (tbCurrentPass.Text != (string)Session["MatKhau"])
            {
                message = "Mật khẩu cũ chưa chính xác";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('" + message + "');", true);


            }
            else if(tbCurrentPass.Text == (string)Session["MatKhau"] && tbNewPass.Text != "" && tbRePass.Text != "" )
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    // Tạo command để thực hiện truy vấn update
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE NguoiDung SET MatKhau = @MatKhau WHERE UserID = @UserID", conn);

                    // Mở kết nối đến CSDL
                    conn.Open();

                    // Truyền tham số vào command
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    cmd.Parameters.AddWithValue("@MatKhau", tbNewPass.Text);

                    // Thực hiện truy vấn update
                    cmd.ExecuteNonQuery();

                    // Đóng kết nối
                    conn.Close();
                }
                message = "Thay đổi mật khẩu thành công";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('" + message + "');", true);
                Session["MatKhau"] = tbNewPass.Text;
            }

            Response.Redirect("DoiMK.aspx");
        }
    }
}