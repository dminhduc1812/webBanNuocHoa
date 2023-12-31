using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PJWebNC.Dao
{
    public class DaoSanPham
    {

        public static List<SanPham> getAllToGrid()
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select IDSanPham, TenSP, TenThuongHieu, GiaBan, GioiTinh.GioiTinh, Season.Season, Anh from SanPham, GioiTinh, ThuongHieu, Season where SanPham.GioiTinh = GioiTinh.MaGioiTinh and SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu and SanPham.GioiTinh = GioiTinh.MaGioiTinh and SanPham.Season = Season.MaSeason";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.GioiTinh = Convert.ToString(sqlDataReader["GioiTinh"]);
                    objSP.Season = Convert.ToString(sqlDataReader["Season"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getAllbyHangSX(string _mahsx)
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT IDSanPham, TenThuongHieu, TenSP, Anh, GiaBan FROM SanPham, ThuongHieu where SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu and ThuongHieu.MaThuongHieu = '"+_mahsx+"'";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getAll()
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT IDSanPham, TenThuongHieu, TenSP, Anh, GiaBan FROM SanPham, ThuongHieu where SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getAllHot()
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT IDSanPham, TenThuongHieu, TenSP, Anh, GiaBan FROM SanPham, ThuongHieu where SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu and SanPham.Hot = 1";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static SanPham getOneById(string _name)
        {
            SanPham lstSP = new SanPham();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT TenThuongHieu, TenSP, Anh, GiaBan, SanPham.Season FROM SanPham, ThuongHieu, Season where SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu and SanPham.Season = Season.MaSeason and  TenSP = '" + _name + "'";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    objSP.Season = Convert.ToString(sqlDataReader["Season"]);

                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }

        public static SanPham getOne(string _id)
        {
            SanPham objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "SELECT MaGioiTinh, ThuongHieu.MaThuongHieu, MaSeason, GioiTinh.GioiTinh, TenThuongHieu, TenSP, Anh, GiaBan, SanPham.Season FROM SanPham, ThuongHieu, GioiTinh, Season where GioiTinh.MaGioiTinh = SanPham.GioiTinh and SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu and SanPham.Season = Season.MaSeason and IDSanPham = '" + _id+"'";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new SanPham();
                    objND.GioiTinh = Convert.ToString(reader["GioiTinh"]);
                    objND.TenSP = Convert.ToString(reader["TenSP"]);
                    objND.TenThuongHieu = Convert.ToString(reader["TenThuongHieu"]);
                    objND.Anh = Convert.ToString(reader["Anh"]);
                    objND.GiaBan = Convert.ToInt32(reader["GiaBan"]);
                    objND.Season = Convert.ToString(reader["Season"]);
                    objND.MaSeason = Convert.ToInt32(reader["MaSeason"]);
                    objND.MaThuongHieu = Convert.ToInt32(reader["MaThuongHieu"]);
                    objND.MaGioiTinh = Convert.ToInt32(reader["MaGioiTinh"]);

                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static List<SanPham> getTop5New()
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT TOP 5 IDSanPham, TenThuongHieu, TenSP, Anh, GiaBan FROM SanPham, ThuongHieu where SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getTop5related(string _mathuonghieu, string _tensp)
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT TOP 5 IDSanPham, TenThuongHieu, TenSP, Anh, GiaBan FROM SanPham, ThuongHieu where SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu and ThuongHieu.TenThuongHieu = '"+_mathuonghieu+ "' and IDSanPham NOT IN ('" + _tensp + "')";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static SanPham getDacDiem(string _id)
        {
            SanPham objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select IDSanPham, PhatHanh, DoTuoi, DoLuuMui from DacDiem where IDSanPham = '" + _id + "'";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new SanPham();
                    
                    objND.PhatHanh = Convert.ToInt32(reader["PhatHanh"]);
                    objND.DoLuuMui = Convert.ToInt32(reader["DoLuuMui"]);
                    objND.DoTuoi = Convert.ToInt32(reader["DoTuoi"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static SanPham getHuong(string _id)
        {
            SanPham objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select IDSanPham, ToneHuong, HuongDau, HuongGiua, HuongCuoi from Huong where IDSanPham =  '" + _id + "'";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new SanPham();

                    objND.ToneHuong = Convert.ToString(reader["ToneHuong"]);
                    objND.HuongDau = Convert.ToString(reader["HuongDau"]);
                    objND.HuongGiua = Convert.ToString(reader["HuongGiua"]);
                    objND.HuongCuoi = Convert.ToString(reader["HuongCuoi"]);
                    
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
        public static List<SanPham> getTop5Nam()
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select TOP 5 Anh, IDSanPham, TenSP, GiaBan, TenThuongHieu, GioiTinh.GioiTinh from ThuongHieu, GioiTinh, SanPham  where GioiTinh.MaGioiTinh = SanPham.GioiTinh and ThuongHieu.MaThuongHieu = SanPham.MaThuongHieu and GioiTinh.MaGioiTinh = 1 order by DaMua DESC";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getTop5Nu()
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select TOP 5 Anh, IDSanPham, TenSP, GiaBan, TenThuongHieu, GioiTinh.GioiTinh from ThuongHieu, GioiTinh, SanPham  where GioiTinh.MaGioiTinh = SanPham.GioiTinh and ThuongHieu.MaThuongHieu = SanPham.MaThuongHieu and GioiTinh.MaGioiTinh = 2 order by DaMua DESC ";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getTop5Uni()
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select TOP 5 Anh, IDSanPham, TenSP, GiaBan, TenThuongHieu, GioiTinh.GioiTinh from ThuongHieu, GioiTinh, SanPham  where GioiTinh.MaGioiTinh = SanPham.GioiTinh and ThuongHieu.MaThuongHieu = SanPham.MaThuongHieu and GioiTinh.MaGioiTinh = 3 order by DaMua DESC";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getSPGioiTinh(int _magioitinh)
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select Anh, IDSanPham, TenSP, GiaBan, TenThuongHieu, GioiTinh.GioiTinh from ThuongHieu, GioiTinh, SanPham  where GioiTinh.MaGioiTinh = SanPham.GioiTinh and ThuongHieu.MaThuongHieu = SanPham.MaThuongHieu and GioiTinh.MaGioiTinh = '"+ _magioitinh + "' ";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getSPSeason(int _tenss)
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select Anh, IDSanPham, TenSP, GiaBan, TenThuongHieu, Season.Season from ThuongHieu, Season, SanPham  where Season.MaSeason = SanPham.Season and ThuongHieu.MaThuongHieu = SanPham.MaThuongHieu and Season.MaSeason = '" + _tenss + "' ";
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
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static List<SanPham> getSPprice(int _gia1, int _gia2)
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select Anh, IDSanPham, TenSP, GiaBan, TenThuongHieu, Season.Season from ThuongHieu, Season, SanPham  where Season.MaSeason = SanPham.Season and ThuongHieu.MaThuongHieu = SanPham.MaThuongHieu and GiaBan > '"+_gia1+"' and GiaBan < '"+_gia2+"' ";
            //Định nghĩa đối tượng nnection
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                //Khởi tạo đối tượng Command
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                //Sử dụng đối tượng DataReader để đọc dữ liệu
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }

        public static List<SanPham> getAllFilter(
            string sqlgioitinh="", 
            string sqlgia1="", 
            string sqlgia2="",
            string sqlseason=""

            )
        {
            List<SanPham> lstSP = new List<SanPham>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "select Anh, IDSanPham, TenSP, GiaBan, TenThuongHieu, Season.Season from SanPham, ThuongHieu, Season, GioiTinh where GioiTinh.MaGioiTinh = SanPham.GioiTinh and SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu and Season.MaSeason = SanPham.Season "+" " + sqlgioitinh + " " + sqlseason + " " + sqlgia1 + " "+ sqlgia2;
            //Định nghĩa đối tượng nnection
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                //Khởi tạo đối tượng Command
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                //Sử dụng đối tượng DataReader để đọc dữ liệu
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                SanPham objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new SanPham();
                    objSP.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objSP.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Anh = Convert.ToString(sqlDataReader["Anh"]);
                    objSP.GiaBan = Convert.ToInt32(sqlDataReader["GiaBan"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }
        public static SanPham getSoLuong()
        {
            SanPham objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "select count(TenSP) as SoLuongSanPham from SanPham ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new SanPham();
                    objND.SoLuongSanPham = Convert.ToInt32(reader["SoLuongSanPham"]);
                    
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }

    }
}