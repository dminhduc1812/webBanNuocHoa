using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace VNPAY_CS_ASPX
{
    public partial class HoaDon : System.Web.UI.Page
    {
        private static readonly ILog log =
           LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string get_response;
        string get_TransactionStatus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("default.aspx");
            }
            DiaChi.InnerText = Session["DiaChi"].ToString();
            SDT.InnerText = Session["SoDienThoai"].ToString() ;
            FullName.InnerText = Session["FullName"].ToString();


            

            log.InfoFormat("Begin VNPAY Return, URL={0}", Request.RawUrl);
            if (Request.QueryString.Count > 0)
            {
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat
                var vnpayData = Request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();

                foreach (string s in vnpayData)
                {
                    //get all querystring data
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(s, vnpayData[s]);
                    }
                }
                //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
                //vnp_TransactionNo: Ma GD tai he thong VNPAY
                //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
                //vnp_SecureHash: HmacSHA512 cua du lieu tra ve

                long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                get_response = vnpay.GetResponseData("vnp_ResponseCode");
                get_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                String vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
                String TerminalID = Request.QueryString["vnp_TmnCode"];
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                String bankCode = Request.QueryString["vnp_BankCode"];

                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    {
                        //Thanh toan thanh cong
                        //displayMsg.InnerText = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                        log.InfoFormat("Thanh toan thanh cong, OrderId={0}, VNPAY TranId={1}", orderId, vnpayTranId);
                        //thêm vào bảng đặt hàng để tiến hành admin xử lý
                        string time = DateTime.Now.ToString("yyyy/MM/dd");
                        string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                        int pID1 = Convert.ToInt32(Page.Request.QueryString["id"]);
                        using (SqlConnection conn = new SqlConnection(strConnection))
                        {
                            SqlCommand cmd = new SqlCommand(
                                "insert into DatHang ( MaDonHang, UserID,MaGiaoDich, SoTienThanhToan, TrangThai, NgayGD ) values ( @MaDonHang,  @UserID, @MaGiaoDich, @SoTienThanhToan, @TrangThai, @NgayGD)", conn);
                            conn.Open();
                            cmd.Parameters.AddWithValue("@MaDonHang", orderId);
                            cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                            cmd.Parameters.AddWithValue("@SoTienThanhToan", vnp_Amount);
                            cmd.Parameters.AddWithValue("@MaGiaoDich", vnpayTranId);
                            cmd.Parameters.AddWithValue("@TrangThai", 1);
                            cmd.Parameters.AddWithValue("@NgayGD", time);
                            cmd.ExecuteNonQuery();
                        }


                    }
                    else
                    {
                        //Thanh toan khong thanh cong. Ma loi: vnp_ResponseCode
                        //displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý.Mã lỗi: " + vnp_ResponseCode;
                        log.InfoFormat("Thanh toan loi, OrderId={0}, VNPAY TranId={1},ResponseCode={2}", orderId, vnpayTranId, vnp_ResponseCode);

                        // Tìm thẻ HTML cần chỉnh sửa class
                        XacNhan.InnerText = "Thanh toán thất bại";
                        XacNhan.Attributes["class"] = "badge bg-danger font-size-12 ms-2";
                    }
                    //displayTmnCode.InnerText = "Mã Website (Terminal ID):" + TerminalID;
                    //displayTxnRef.InnerText = "Mã giao dịch thanh toán:" + orderId.ToString();
                    //displayVnpayTranNo.InnerText = "Mã giao dịch tại VNPAY:" + vnpayTranId.ToString();
                    //displayAmount.InnerText = "Số tiền thanh toán (VND):" + vnp_Amount.ToString();
                    //displayBankCode.InnerText = "Ngân hàng thanh toán:" + bankCode;

                }
                else
                {
                    log.InfoFormat("Invalid signature, InputData={0}", Request.RawUrl);
                    //displayMsg.InnerText = "Có lỗi xảy ra trong quá trình xử lý";

                }
                PJWebNC.Entity.DatHang data = PJWebNC.Dao.DaoDatHang.getOneID(vnpayTranId);
                if(data != null)
                {
                    NgayGD.InnerText = data.NgayGD.ToString("dd/MM/yyyy");
                    MaGD.InnerText = data.MaGiaoDich.ToString();
                    //PJWebNC.Entity.GioHang money = PJWebNC.Dao.DaoGioHang.TongTien((int)Session["UserID"]);
                    //string hehe = money.TongTien.ToString("#,#");
                }    
                else
                {
                    MaGD.InnerText = "Giao dịch thất bại";
                    NgayGD.InnerText = DateTime.Now.ToString("yyyy/MM/dd");
                }
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (get_response == "00" && get_TransactionStatus == "00")
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                //xóa khi thực hiện thành công
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(
                        "delete from GioHang where UserID = @UserID", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            
        }
    }
}