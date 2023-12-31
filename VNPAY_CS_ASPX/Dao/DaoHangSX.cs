using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PJWebNC.Dao
{
    public class DaoHangSX
    {
        public static List<HangSX> getHotHSX()
        {
            List<HangSX> lstHSX = new List<HangSX>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            
            string strSQL = "SELECT top 12 MaThuongHieu, LogoBrand from ThuongHieu where Hot = 1";
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
                HangSX objHSX = null;
                while (sqlDataReader.Read())
                {
                    objHSX = new HangSX();
                    objHSX.MaThuongHieu = Convert.ToInt32(sqlDataReader["MaThuongHieu"]);
                    objHSX.LogoBrand = Convert.ToString(sqlDataReader["LogoBrand"]);
                    lstHSX.Add(objHSX);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstHSX ;

            }
        }

        public static List<HangSX> getAll()
        {
            List<HangSX> lstSP = new List<HangSX>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT MaThuongHieu, TenThuongHieu, Hot, LogoBrand  from ThuongHieu";
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
                HangSX objSP = null;
                while (sqlDataReader.Read())
                {
                    objSP = new HangSX();
                    objSP.MaThuongHieu = Convert.ToInt32(sqlDataReader["MaThuongHieu"]);
                    objSP.TenThuongHieu = Convert.ToString(sqlDataReader["TenThuongHieu"]);
                    objSP.Hot = Convert.ToInt32(sqlDataReader["Hot"]);
                    objSP.LogoBrand = Convert.ToString(sqlDataReader["LogoBrand"]);
                    lstSP.Add(objSP);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstSP;

            }
        }

        public static HangSX getOneID(string _id)
        {
            HangSX objND = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select MaThuongHieu, TenThuongHieu, Hot, LogoBrand from ThuongHieu where MaThuongHieu = '" + _id + "' ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objND = new HangSX();
                    objND.MaThuongHieu = Convert.ToInt32(reader["MaThuongHieu"]);
                    objND.TenThuongHieu = Convert.ToString(reader["TenThuongHieu"]);
                    objND.Hot = Convert.ToInt32(reader["Hot"]);
                    objND.LogoBrand = Convert.ToString(reader["LogoBrand"]);

                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objND;
            }
        }
    }
}