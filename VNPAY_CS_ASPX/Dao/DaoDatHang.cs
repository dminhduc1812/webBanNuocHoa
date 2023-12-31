using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace PJWebNC.Dao
{
    public class DaoDatHang
    {
        public static DatHang getOneToHoaDon(string _id)
        {
            DatHang objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select top 1 MaGiaoDich, IDDatHang, DatHang.UserID, SoTienThanhToan, TrangThai.TrangThai, FullName, NgayGD, IDTrangThai, SoDienThoai from DatHang, NguoiDung, TrangThai where NguoiDung.UserID = DatHang.UserID and TrangThai.IDTrangThai = DatHang.TrangThai and NguoiDung.UserID = '"+_id+"' order by IDDatHang desc";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new DatHang();
                    objND.IDDatHang = Convert.ToInt32(reader["IDDatHang"]);
                    objND.IDTrangThai = Convert.ToInt32(reader["IDTrangThai"]);
                    objND.UserID = Convert.ToString(reader["UserID"]);
                    objND.SoTienThanhToan = Convert.ToInt32(reader["SoTienThanhToan"]);
                    objND.TrangThai = Convert.ToString(reader["TrangThai"]);
                    objND.NgayGD = Convert.ToDateTime(reader["NgayGD"]);
                    objND.FullName = Convert.ToString(reader["FullName"]);
                    objND.SoDienThoai = Convert.ToString(reader["SoDienThoai"]);
                    objND.MaGiaoDich = Convert.ToInt32(reader["MaGiaoDich"]);

                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static DatHang getOneID(long _id)
        {
            DatHang objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select MaGiaoDich, IDDatHang, DatHang.UserID, SoTienThanhToan, TrangThai.TrangThai, FullName, NgayGD, IDTrangThai, SoDienThoai from DatHang, NguoiDung, TrangThai where NguoiDung.UserID = DatHang.UserID and TrangThai.IDTrangThai = DatHang.TrangThai and MaGiaoDich = '"+_id+"'";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new DatHang();
                    objND.IDDatHang = Convert.ToInt32(reader["IDDatHang"]);
                    objND.IDTrangThai = Convert.ToInt32(reader["IDTrangThai"]);
                    objND.UserID = Convert.ToString(reader["UserID"]);
                    objND.SoTienThanhToan = Convert.ToInt32(reader["SoTienThanhToan"]);
                    objND.TrangThai = Convert.ToString(reader["TrangThai"]);
                    objND.NgayGD = Convert.ToDateTime(reader["NgayGD"]);
                    objND.FullName = Convert.ToString(reader["FullName"]);
                    objND.SoDienThoai = Convert.ToString(reader["SoDienThoai"]);
                    objND.MaGiaoDich = Convert.ToInt32(reader["MaGiaoDich"]);

                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static List<Entity.DatHang> getAll()
        {
            List<Entity.DatHang> lstGioHang = new List<Entity.DatHang>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT DiaChi, SoDienThoai, IDDatHang, DatHang.UserID, SoTienThanhToan, TrangThai.TrangThai, FullName, NgayGD, MaGiaoDich from DatHang, NguoiDung, TrangThai where NguoiDung.UserID = DatHang.UserID and TrangThai.IDTrangThai = DatHang.TrangThai and DatHang.TrangThai != 3";
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
                Entity.DatHang objGioHang = null;
                while (sqlDataReader.Read())
                {
                    objGioHang = new Entity.DatHang();
                    objGioHang.IDDatHang = Convert.ToInt32(sqlDataReader["IDDatHang"]);
                    objGioHang.MaGiaoDich = Convert.ToInt32(sqlDataReader["MaGiaoDich"]);
                    objGioHang.FullName = Convert.ToString(sqlDataReader["FullName"]);
                    objGioHang.SoTienThanhToan = Convert.ToInt32(sqlDataReader["SoTienThanhToan"]);
                    objGioHang.TrangThai = Convert.ToString(sqlDataReader["TrangThai"]);
                    objGioHang.SoDienThoai = Convert.ToString(sqlDataReader["SoDienThoai"]);
                    objGioHang.DiaChi = Convert.ToString(sqlDataReader["DiaChi"]);
                    objGioHang.NgayGD = Convert.ToDateTime(sqlDataReader["NgayGD"]);


                    lstGioHang.Add(objGioHang);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstGioHang;

            }
        }
        public static Entity.DatHang TongTien()
        {
            Entity.DatHang objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select SUM(SoTienThanhToan) as TongTien from DatHang ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new Entity.DatHang();
                    objND.TongTien = Convert.ToInt32(reader["TongTien"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static Entity.DatHang SlDonHang()
        {
            Entity.DatHang objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select COUNT(IDDatHang) as TongTien from DatHang ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new Entity.DatHang();
                    objND.TongTien = Convert.ToInt32(reader["TongTien"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static Entity.DatHang SlChuaHT()
        {
            Entity.DatHang objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select COUNT(MaDonHang) as TongTien from DatHang where TrangThai != 3 ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new Entity.DatHang();
                    objND.TongTien = Convert.ToInt32(reader["TongTien"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static List<Entity.DatHang> getAllbyID(int _id)
        {
            List<Entity.DatHang> lstGioHang = new List<Entity.DatHang>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT IDDatHang, DatHang.UserID, SoTienThanhToan, TrangThai.TrangThai, FullName, NgayGD from DatHang, NguoiDung, TrangThai where NguoiDung.UserID = DatHang.UserID and TrangThai.IDTrangThai = DatHang.TrangThai and DatHang.UserID = '"+_id+"'";
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
                Entity.DatHang objGioHang = null;
                while (sqlDataReader.Read())
                {
                    objGioHang = new Entity.DatHang();
                    objGioHang.IDDatHang = Convert.ToInt32(sqlDataReader["IDDatHang"]);
                    objGioHang.FullName = Convert.ToString(sqlDataReader["FullName"]);
                    objGioHang.SoTienThanhToan = Convert.ToInt32(sqlDataReader["SoTienThanhToan"]);
                    objGioHang.TrangThai = Convert.ToString(sqlDataReader["TrangThai"]);
                    objGioHang.NgayGD = Convert.ToDateTime(sqlDataReader["NgayGD"]);


                    lstGioHang.Add(objGioHang);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstGioHang;

            }
        }
    }
}