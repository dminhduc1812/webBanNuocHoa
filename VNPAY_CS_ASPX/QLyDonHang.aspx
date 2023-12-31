<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="QLyDonHang.aspx.cs" Inherits="PJWebNC.QLyDonHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <style>
        .table {
            width: 100%;
            border-collapse: collapse;
        }

            .table th, .table td {
                padding: 8px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .table th {
                background-color: #f2f2f2;
            }

            .table tr:hover {
                background-color: #f5f5f5;
            }

            .table td:first-child {
                width: 30%;
            }

            .table td:nth-child(2) {
                width: 40%;
            }

            .table td:last-child {
                width: 30%;
            }
            
    </style>
    <link rel="stylesheet" href="TaiKhoan.css" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">
    <div class="section-TaiKhoan">
        <div class="container-TaiKhoan">
            <div class="grid-top-TaiKhoan" >
                <div class="uk-first-column">
                    <div>     
                        <h1 class="TaiKhoan-title">Tài khoản của tôi</h1>
                    </div>
                </div>
            </div>
        
            <div class="grid-bot-TaiKhoan" style="width:1200px" >
                <div class="first-column-TaiKhoan">
                    <div>
                        <div class="menu-QuanLyTaiKhoan">
                            <nav class="menu-QuanLyTaiKhoan-navigation">
                                <ul>
                                    <li class="menu-QuanLyTaiKhoan-navigation-link menu-QuanLyTaiKhoan-navigation-link--dashboard is-active">
                                        <a href="QLyTaiKhoan.aspx">Trang tài khoản</a>
                                    </li>
                                    <li class="menu-QuanLyTaiKhoan-navigation-link menu-QuanLyTaiKhoan-navigation-link--orders">
                                        <a href="QLyDonHang.aspx">Đơn hàng</a>
                                    </li>
     
                                    <li class="menu-QuanLyTaiKhoan-navigation-link menu-QuanLyTaiKhoan-navigation-link--edit-account">
                                        <a href="TaiKhoan.aspx">Đổi thông tin người dùng</a>
                                    </li>
                                    <li class="menu-QuanLyTaiKhoan-navigation-link menu-QuanLyTaiKhoan-navigation-link--edit-account">
                                        <a href="DoiMK.aspx">Đổi mật khẩu</a>
                                    </li>
                                    <li class="menu-QuanLyTaiKhoan-navigation-link menu-QuanLyTaiKhoan-navigation-link--customer-logout">
                                        <a href="SignOut.aspx">Thoát</a>
                                    </li>
                                </ul>
                            </nav>

                            <div class="menu-QuanLyTaiKhoan-content">
                                <div class="menu-QuanLyTaiKhoan-navigation-wrapper"></div>
                                <div class="menu-QuanLyTaiKhoan-message">
                                    <table class="table">

                                        <tr>
                                            <th>Ngày giao dịch</th>
                                            <th>Số tiền thanh toán</th>
                                            <th>Trạng thái đơn</th>
                                        </tr>
                                        <%foreach (var item in PJWebNC.Dao.DaoDatHang.getAllbyID((int)Session["UserID"]))
                                            {  %>
                                        <tr>
                                            <td><%= item.NgayGD.ToString("dd/MM/yyyy") %></td>
                                            <td><%=item.SoTienThanhToan.ToString("#,#") %></td>
                                            <td><%= item.TrangThai %></td>
                                        </tr>
                                        <%} %>
                                        <!-- Thêm các hàng dữ liệu khác tương tự -->
                                    </table>	
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
