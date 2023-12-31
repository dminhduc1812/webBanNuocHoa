using PJWebNC.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PJWebNC.Dao
{
    public class DaoDacDiem
    {
        public static List<DacDiem> getAll()
        {
            List<DacDiem> lstDacDiem = new List<DacDiem>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT IDDacDiem, DacDiem.IDSanPham,TenSP, PhatHanh, DoTuoi, DoLuuMui from DacDiem, SanPham where SanPham.IDSanPham = DacDiem.IDSanPham";
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
                DacDiem objDacDiem = null;
                while (sqlDataReader.Read())
                {
                    objDacDiem = new DacDiem();
                    objDacDiem.IDDacDiem = Convert.ToInt32(sqlDataReader["IDDacDiem"]);
                    objDacDiem.IDSanPham = Convert.ToInt32(sqlDataReader["IDSanPham"]);
                    objDacDiem.PhatHanh = Convert.ToInt32(sqlDataReader["PhatHanh"]);
                    objDacDiem.DoTuoi = Convert.ToInt32(sqlDataReader["DoTuoi"]);
                    objDacDiem.DoLuuMui = Convert.ToInt32(sqlDataReader["DoLuuMui"]);
                    objDacDiem.TenSP = Convert.ToString(sqlDataReader["TenSP"]);
                    lstDacDiem.Add(objDacDiem);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstDacDiem;

            }
        }

        public static DacDiem getOneID(string _id)
        {
            DacDiem objDacDiem = null;

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string sql = "Select IDDacDiem, IDSanPham, PhatHanh, DoTuoi, DoLuuMui from DacDiem where IDDacDiem = '" + _id + "' ";

            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objDacDiem = new DacDiem();
                    objDacDiem.IDDacDiem = Convert.ToInt32(reader["IDDacDiem"]);
                    objDacDiem.IDSanPham = Convert.ToInt32(reader["IDSanPham"]);
                    objDacDiem.PhatHanh = Convert.ToInt32(reader["PhatHanh"]);
                    objDacDiem.DoTuoi = Convert.ToInt32(reader["DoTuoi"]);
                    objDacDiem.DoLuuMui = Convert.ToInt32(reader["DoLuuMui"]);

                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objDacDiem;
            }
        }
    }
}