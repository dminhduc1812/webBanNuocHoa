 using PJWebNC.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PJWebNC
{
    public partial class TaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }

        }

        protected void CheckTextBox()
        {
            string message = "Bạn vừa cập nhật ";

            if (!string.IsNullOrEmpty(tbTen.Text))
            {
                message +=  "tên thành " + tbTen.Text;
                Page.Session["FullName"] = tbTen.Text;

            }

            if (!string.IsNullOrEmpty(tbDiaChi.Text))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    message += " ";
                }

                message += "địa chỉ là " + tbDiaChi.Text;
                    Page.Session["DiaChi"] = tbDiaChi.Text;

            }

            if (!string.IsNullOrEmpty(tbSDT.Text))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    message += " ";
                }

                message += "SĐT là " + tbSDT.Text;
                Session["SoDienThoai"] = tbSDT.Text;
            }

            if (string.IsNullOrEmpty(message))
            {
                message = "Không có thông tin nào được cập nhật.";
            }

            // Sử dụng chuỗi message trong các xử lý tiếp theo, ví dụ:
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('" + message + "');", true);

        }
        protected void UpdateUserInfo()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE NguoiDung SET";
                List<string> updateFields = new List<string>();
                SqlCommand cmd = new SqlCommand();

                if (!string.IsNullOrEmpty(tbTen.Text))
                {
                    updateFields.Add("FullName = @FullName");
                    cmd.Parameters.AddWithValue("@FullName", tbTen.Text);
                }

                if (!string.IsNullOrEmpty(tbDiaChi.Text))
                {
                    updateFields.Add("DiaChi = @DiaChi");
                    cmd.Parameters.AddWithValue("@DiaChi", tbDiaChi.Text);
                }

                if (!string.IsNullOrEmpty(tbSDT.Text))
                {
                    updateFields.Add("SoDienThoai = @SDT");
                    cmd.Parameters.AddWithValue("@SDT", tbSDT.Text);
                }

                if (updateFields.Count > 0)
                {
                    sql += " " + string.Join(", ", updateFields.ToArray());
                    sql += " WHERE UserID = @UserID";

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]); // Thay thế userID bằng giá trị UserID của người dùng cần cập nhật

                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void bLuu_Click(object sender, EventArgs e)
        {
            UpdateUserInfo();
            Session["FullName"] = tbTen.Text;
            CheckTextBox();

            ////Response.Redirect("QlyTaiKhoan.aspx");
        }
    }
}