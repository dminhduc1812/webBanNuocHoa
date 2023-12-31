<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="QLyDiaChi.aspx.cs" Inherits="PJWebNC.QLyDiaChi" %>
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
                                    <li class="menu-QuanLyTaiKhoan-navigation-link menu-QuanLyTaiKhoan-navigation-link--edit-address">
                                        <a href="QlyDiaChi.aspx">Địa chỉ</a>
                                    </li>
                                    <li class="menu-QuanLyTaiKhoan-navigation-link menu-QuanLyTaiKhoan-navigation-link--edit-account">
                                        <a href="TaiKhoan.aspx">Đổi tên người dùng</a>
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
                                <div class="menu-QuanLyTaiKhoan-navigation-wrapper">
                                    <p>Các địa chỉ bên dưới mặc định sẽ được sử dụng ở trang thanh toán sản phẩm.</p>
                                    <div class="menu-QuanLyTaiKhoan-Addresses ">
                                        <div class="menu-QuanLyTaiKhoan-Address-1">
                                            <header class="menu-QuanLyTaiKhoan-Address-title title">
                                                <h3>Địa chỉ giao hàng mặc định</h3>
                                                <a href="" class="edit">Thêm</a>
                                            </header>
                                            <p>Bạn vẫn chưa thêm địa chỉ nào.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
