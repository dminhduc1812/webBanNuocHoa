<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="DoiMK.aspx.cs" Inherits="PJWebNC.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">

    <link rel="stylesheet" href="TaiKhoan.css" type="text/css"/>
    <script type="text/javascript">
    function showAlert(message) {
        alert(message);
    }
    </script>
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

                            <div class="tab-pane fade" id="v-pills-settings" role="tabpanel" aria-labelledby="v-pills-settings-tab">
                                <div class="menu-QuanLyTaiKhoan-navigation-wrapper"></div>
                                <form class="EditAccountForm edit-account">

                                    <fieldset style="border: 1px solid; padding: 10px; width:682px">
                                        <legend>Thay đổi mật khẩu</legend>

                                        <p class="AccountForm-form-row AccountForm-form-row--wide form-row form-row-wide">
                                            <label for="password_current">Mật khẩu hiện tại </label>
                                            <span class="password-input">
                                            <asp:TextBox ID="tbCurrentPass" CssClass="AccountForm-Input AccountForm-Input--password input-text" runat="server" TextMode="Password"></asp:TextBox>
                                        </p>
                                        <p class="AccountForm-form-row AccountForm-form-row--wide form-row form-row-wide">
                                            <label for="password_1">Mật khẩu mới </label>
                                            <span class="password-input">
                                            <asp:TextBox ID="tbNewPass" CssClass="AccountForm-Input AccountForm-Input--password input-text" runat="server" TextMode="Password"></asp:TextBox>
                                        </p>
                                        <p class="AccountForm-form-row AccountForm-form-row--wide form-row form-row-wide">
                                            <label for="password_2">Xác nhận mật khẩu mới</label>
                                            <span class="password-input">
                                            <asp:TextBox ID="tbRePass" CssClass="AccountForm-Input AccountForm-Input--password input-text" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:Label ID="lbMessage" runat="server"  ></asp:Label>
                                        </p>
                                    </fieldset>
                                    <div class="clear"></div>
                                    <p>
                                        <asp:Button ID="bLuu" runat="server" CssClass="AccountForm-Button button" Text="Save" OnClick="bLuu_Click"/>

                                        <input type="hidden" name="action" value="save_account_details">
                                    </p>
                                </form>
                            </div>

                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
