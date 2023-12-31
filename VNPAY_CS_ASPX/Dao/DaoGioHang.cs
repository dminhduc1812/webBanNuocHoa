using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PJWebNC.Dao
{
    public class DaoGioHang
    {
        public static List<Entity.GioHang> getToHoaDon(int _userid)
        {
            List<Entity.GioHang> lstSP = new List<Entity.GioHang>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select ROW_NUMBER() OVER (ORDER BY GiaBan ,TenSP, SoLuong, GioHang.IDSanPham) AS STT, GiaBan, TenSP, SoLuong, GioHang.IDSanPham, SUM(GiaBan*SoLuong) As Gia  From  SanPham, GioHang where SanPham.IDSanPham = GioHang.IDSanPham and UserID = '" + _userid+ "'  group by TenSP, SoLuong, GioHang.IDSanPham, GiaBan";
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
                Entity.GioHang objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new Entity.GioHang();
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.SoLuong = Convert.ToInt32(sqlDataReader["SoLuong"]);
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TongTien = Convert.ToInt32(sqlDataReader["Gia"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    objSP.IDGioHang = Convert.ToInt32(sqlDataReader["STT"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<Entity.GioHang> getAllByUser(int _userid)
        {
            List<Entity.GioHang> lstSP = new List<Entity.GioHang>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select GioHang.IDSanPham, Anh, TenSP, GiaBan, SoLuong from SanPham, NguoiDung, GioHang where SanPham.IDSanPham = GioHang.IDSanPham and NguoiDung.UserID = GioHang.UserID and GioHang.UserID = '"+_userid+"'";
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
                Entity.GioHang objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new Entity.GioHang();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    //objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    objSP.SoLuong = Convert.ToInt32(sqlDataReader["SoLuong"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static Entity.GioHang TongTien(int _userid)
        {
            Entity.GioHang objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select  UserID, SUM(GiaBan * SoLuong) as TongTien from SanPham, GioHang where GioHang.IDSanPham = SanPham.IDSanPham and UserID = '" + _userid + "' group by UserID";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new Entity.GioHang();
                    objND.TongTien = Convert.ToInt32(reader["TongTien"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static Entity.GioHang CheckGiohang(int _userid, int _tensp)
        {
            Entity.GioHang objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select GioHang.IDSanPham, TenSP, SoLuong from GioHang, SanPham where GioHang.IDSanPham = SanPham.IDSanPham and UserID = '"+_userid+"' and SanPham.IDSanPham = '"+ _tensp +"'";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new Entity.GioHang();
                    objND.IDSanPham = Convert.ToInt32(reader["IDSanPham"]);
                    objND.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }

        public static List<Entity.GioHang> getAll()
        {
            List<Entity.GioHang> lstGioHang = new List<Entity.GioHang>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT IDGioHang, GioHang.UserID, GioHang.IDSanPham, SoLuong, FullName, TenSP from GioHang, NguoiDung, SanPham where NguoiDung.UserID = GioHang.UserID and SanPham.IDSanPham = GioHang.IDSanPham";
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
                Entity.GioHang objGioHang = null;
                while (sqlDataReader.Read())
                {
                    objGioHang = new Entity.GioHang();
                    objGioHang.IDGioHang = Convert.ToInt32(sqlDataReader["IDGioHang"]);
                    objGioHang.UserID = Convert.ToInt32(sqlDataReader["UserID"]);
                    objGioHang.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objGioHang.SoLuong = Convert.ToInt32(sqlDataReader["SoLuong"]);
                    objGioHang.FullName = Convert.ToString(sqlDataReader["FullName"]);
                    objGioHang.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    lstGioHang.Add(objGioHang);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstGioHang;

            }
        }

        public static Entity.GioHang getOneID(string _id)
        {
            Entity.GioHang objGioHang = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select IDGioHang, UserID, IDSanPham, SoLuong from GioHang where IDGioHang = '" + _id + "' ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objGioHang = new Entity.GioHang();
                    objGioHang.IDGioHang = Convert.ToInt32(reader["IDGioHang"]);
                    objGioHang.UserID = Convert.ToInt32(reader["UserID"]);
                    objGioHang.IDSanPham = Convert.ToInt32(reader["IDSanPham"]);
                    objGioHang.SoLuong = Convert.ToInt32(reader["SoLuong"]);

                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objGioHang;
            }
        }
    
    }
}