<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="QLyTaiKhoan.aspx.cs" Inherits="PJWebNC.QLyTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

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
        
            <div class="grid-bot-TaiKhoan" style="width:1200px">
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
                                <p> Xin chào <strong>
                                    <asp:Label ID="lbTen" runat="server" Text=""></asp:Label></strong> (không phải bạn <strong></strong>? Hãy <a href="#" style="color:blue;">thoát ra</a> và đăng nhập vào tài khoản của bạn)</p>
                            
                                <p> Từ trang quản lý tài khoản bạn có thể xem <a href="QLyDonHang.aspx" style="color:blue">đơn hàng mới</a>, quản lý <a href="QLyDiaChi.aspx">địa chỉ giao hàng và thanh toán</a>, and <a href="https://xxivstore.com/my-account/edit-account/">sửa mật khẩu và thông tin tài khoản</a>.</p>

                                <asp:Button ID="bHref" OnClick="bHref_Click" runat="server" Text="Chuyển tới trang quản lý" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
