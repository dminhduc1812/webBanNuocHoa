using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace PJWebNC.Dao
{
    public class DaoNguoiDung
    {
        public static List<NguoiDung> getAll()
        {
            List<NguoiDung> lstSP = new List<NguoiDung>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT UserID, TaiKhoan, MatKhau, FullName ,TenvaiTro from NguoiDung, VaiTro where VaiTro.IDVaiTro = NguoiDung.VaiTro";
            //Định nghĩa đối tượng Connection
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                //Khởi tạo đối tượng Command
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                //Sử dụng đối tượng DataReader để đọc dữ liệu
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                NguoiDung objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new NguoiDung();
                    objSP.UserID = Convert.ToInt32(sqlDataReader["UserID"]);
                    objSP.TaiKhoan = Convert.ToString(sqlDataReader["TaiKhoan"]);
                    objSP.MatKhau = Convert.ToString(sqlDataReader["MatKhau"]);
                    objSP.FullName = Convert.ToString(sqlDataReader["FullName"]);
                    objSP.TenVaiTro = Convert.ToString(sqlDataReader["TenVaiTro"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static NguoiDung getOne(string _taikhoan, string _matkhau)
        {
            NguoiDung objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select UserID, TaiKhoan, MatKhau, FullName, VaiTro, DiaChi, SoDienThoai from [NguoiDung] where TaiKhoan = @taikhoan and MatKhau = @matkhau";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.Add("@taikhoan", System.Data.SqlDbType.VarChar).Value = _taikhoan;
                sqlCommand.Parameters.Add("@matkhau", System.Data.SqlDbType.VarChar).Value = _matkhau;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new NguoiDung();
                    objND.UserID = Convert.ToInt32(reader["UserID"]);
                    objND.TaiKhoan = Convert.ToString(reader["TaiKhoan"]);
                    objND.MatKhau = Convert.ToString(reader["MatKhau"]);
                    objND.FullName = Convert.ToString(reader["FullName"]);
                    objND.SoDienThoai = Convert.ToString(reader["SoDienThoai"]);
                    objND.DiaChi = Convert.ToString(reader["DiaChi"]);
                    objND.VaiTro = Convert.ToInt32(reader["VaiTro"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static NguoiDung getExits(string _taikhoan)
        {
            NguoiDung objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select UserID, TaiKhoan, MatKhau, FullName, VaiTro from [NguoiDung] where TaiKhoan = @taikhoan ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.Add("@taikhoan", System.Data.SqlDbType.VarChar).Value = _taikhoan;
                
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new NguoiDung();
                    objND.UserID = Convert.ToInt32(reader["UserID"]);
                    objND.TaiKhoan = Convert.ToString(reader["TaiKhoan"]);
                    objND.MatKhau = Convert.ToString(reader["MatKhau"]);
                    objND.FullName = Convert.ToString(reader["FullName"]);
                    objND.VaiTro = Convert.ToInt32(reader["VaiTro"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static NguoiDung getOneID(string _id)
        {
            NguoiDung objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select UserID, TaiKhoan, MatKhau, TenVaiTro, FullName, VaiTro from NguoiDung, VaiTro where UserID = '"+_id+"' and NguoiDung.VaiTro = VaiTro.IDVaiTro";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new NguoiDung();
                    objND.FullName = Convert.ToString(reader["FullName"]);
                    objND.TaiKhoan = Convert.ToString(reader["TaiKhoan"]);
                    objND.MatKhau = Convert.ToString(reader["MatKhau"]);
                    objND.TenVaiTro = Convert.ToString(reader["MatKhau"]);
                    objND.VaiTro = Convert.ToInt32(reader["VaiTro"]);
                    
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
    }
}