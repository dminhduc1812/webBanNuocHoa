using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PJWebNC.Dao
{
    public class DaoHuong
    {
        public static List<Huong> getAll()
        {
            List<Huong> lstHuong = new List<Huong>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT IDHuong, Huong.IDSanPham,TenSP, ToneHuong, HuongDau, HuongGiua, HuongCuoi  from Huong, SanPham where SanPham.IDSanPham = Huong.IDSanPham";
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
                Huong objHuong = null;
                while (sqlDataReader.Read())
                {
                    objHuong = new Huong();
                    objHuong.IDHuong = Convert.ToInt32(sqlDataReader["IDHuong"]);
                    objHuong.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objHuong.ToneHuong = Convert.ToString(sqlDataReader["ToneHuong"]);
                    objHuong.HuongDau = Convert.ToString(sqlDataReader["HuongDau"]);
                    objHuong.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    objHuong.HuongGiua = Convert.ToString(sqlDataReader["HuongGiua"]);
                    objHuong.HuongCuoi = Convert.ToString(sqlDataReader["HuongCuoi"]);
                    lstHuong.Add(objHuong);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstHuong;

            }
        }

        public static Huong getOneID(string _id)
        {
            Huong objHuong = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select IDHuong, IDSanPham, ToneHuong, HuongDau, HuongGiua, HuongCuoi from Huong where IDHuong = '" + _id + "' ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objHuong = new Huong();
                    objHuong.IDHuong = Convert.ToInt32(reader["IDHuong"]);
                    objHuong.IDSanPham = Convert.ToInt32(reader["IDSanPham"]);
                    objHuong.ToneHuong = Convert.ToString(reader["ToneHuong"]);
                    objHuong.HuongDau = Convert.ToString(reader["HuongDau"]);
                    objHuong.HuongGiua = Convert.ToString(reader["HuongGiua"]);
                    objHuong.HuongCuoi = Convert.ToString(reader["HuongCuoi"]);

                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objHuong;
            }
        }
    }
}