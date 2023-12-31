<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoaDon.aspx.cs" Inherits="VNPAY_CS_ASPX.HoaDon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        body {
            margin-top: 20px;
            background-color: #eee;
        }

        .card {
            box-shadow: 0 20px 27px 0 rgb(0 0 0 / 5%);
        }

        .card {
            position: relative;
            display: flex;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-color: #fff;
            background-clip: border-box;
            border: 0 solid rgba(0,0,0,.125);
            border-radius: 1rem;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.1/css/all.min.css" integrity="sha256-2XFplPlrFClt0bIdPgpz8H7ojnk10H69xRqd9+uTShA=" crossorigin="anonymous" />
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="invoice-title">
                                <h4 class="float-end font-size-15"><span class="badge bg-success font-size-12 ms-2" runat="server" id="XacNhan">Paid</span></h4>
                                <div class="mb-4">
                                    <h2 class="mb-1 text-muted">PerfumeShop.com</h2>
                                </div>
                                <div class="text-muted">
                                    <p class="mb-1">123 Hà Nội</p>
                                    <p><i class="uil uil-phone me-1"></i>012-345-6789</p>
                                </div>
                            </div>
                            <hr class="my-4">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="text-muted">
                                        <h5 class="font-size-16 mb-3">Người nhận:</h5>
                                        <h5 class="font-size-15 mb-2" runat="server" id="FullName">Preston Miller</h5>
                                        <p class="mb-1" runat="server" id="DiaChi">4068 Post Avenue Newfolden, MN 56738</p>
                                        <p runat="server" id="SDT">001-234-5678</p>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="text-muted text-sm-end">        
                                        <div class="mt-4">
                                            <h5 class="font-size-15 mb-1">Ngày giao dịch:</h5>
                                            <p runat="server" id="NgayGD"></p>
                                        </div>
                                        <div class="mt-4">
                                            <h5 class="font-size-15 mb-1">Mã giao dịch:</h5>
                                            <p runat="server" id="MaGD">#1123456</p>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="py-2">
                                <h5 class="font-size-15">Danh sách sản phẩm</h5>
                                <div class="table-responsive">
                                    <table class="table align-middle table-nowrap table-centered mb-0">
                                        <thead>
                                            <tr>
                                                <th style="width: 70px;">No.</th>
                                                <th>Sản phẩm</th>
                                                <th>Đơn giá</th>
                                                <th>Số lượng</th>
                                                <th class="text-end" style="width: 120px;">Tổng tiền</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%foreach (var item in PJWebNC.Dao.DaoGioHang.getToHoaDon((int)Session["UserID"])) { %>
                                            <tr>
                                                <th scope="row"><%=item.IDGioHang %></th>
                                                <td>
                                                    <div>
                                                        <h5 class="text-truncate font-size-14 mb-1"><%= item.TenSP %></h5>
                                                    </div>
                                                </td>
                                                <td><%=item.GiaBan.ToString("#,#")+ " VND" %></td>
                                                <td><%=item.SoLuong %></td>
                                                <td class="text-end"><%=item.TongTien.ToString("#,#") + " VND" %></td>
                                            </tr>
                                            <%} %>

                                            <tr>
                                                <th scope="row" colspan="4" class="border-0 text-end">Tổng cộng</th>
                                                <td class="border-0 text-end">
                                                    <h4 class="m-0 fw-semibold">
                                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                                <div class="d-print-none mt-4">
                                    <div class="float-end">
                                        <a href="javascript:window.print()" class="btn btn-success me-1"><i class="fa fa-print"></i></a>
                                        <a href="default.aspx" class="btn btn-primary w-md">Hoàn thành</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script data-cfasync="false" src="/cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js"></script>
        <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
        <script type="text/javascript">

</script>
    </form>
</body>
</html>
