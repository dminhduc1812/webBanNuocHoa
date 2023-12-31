<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="PJWebNC.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">
    <link rel="stylesheet" type="text/css" href="DangNhap.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <style>
        .nav-link  active{
            background-color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">
    <div class="loginPanel">
        <div class="loginContent">
            <ul class="nav nav-pills" id="myTab" role="tablist">
                <li class="nav-item" role="presentation">
                    <%--<asp:Button ID="home-tab" runat="server" Text="Button" data-bs-toggle="tab" CssClass="nav-link active"  data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true" />--%>
                    <button class="nav-link active" id="home-tab"  data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true">Đăng nhập</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="profile-tab"  data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile"  aria-selected="false">Đăng ký</button>
                </li>
                
            </ul>
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active" id="home"  role="tabpanel" aria-labelledby="home-tab">
                    <div class="login">
                        <h5 style="font-size: 18px">Tài khoản</h5>
                        <asp:TextBox ID="tbTaiKhoandn" Width="400" runat="server" AutoComplete="off"></asp:TextBox>
                        <h5 style="font-size: 18px; margin-top: 20px">Mật khẩu</h5>
                        <asp:TextBox ID="tbMatKhaudn" TextMode="Password" Width="400" runat="server" AutoComplete="off"></asp:TextBox>
                        <div style="height: 20px"></div>
                        <asp:Button ID="bDangNhap"  Width="100" Height="55" runat="server" Text="Đăng nhập" OnClick="bDangNhap_Click" ForeColor="White" BackColor="Black" BorderWidth="0"/>
                    </div>
                </div>
                <div class="tab-pane fade" id="profile"  role="tabpanel" aria-labelledby="profile-tab">
                    <div class="login">
                        <h5 style="font-size: 18px">Tài khoản</h5>
                        <asp:TextBox ID="tbTaiKhoandk" Width="400" AutoComplete="off" runat="server"></asp:TextBox>
                        <h5 style="font-size: 18px; margin-top: 20px; ">Mật khẩu</h5>
                        <asp:TextBox ID="tbMatKhaudk" TextMode="Password" AutoComplete="off" Width="400" runat="server"></asp:TextBox>
                        <h5 style="font-size: 18px; margin-top: 20px">Nhập lại mật khẩu</h5>
                        <asp:TextBox ID="tbReMatKhaudk" TextMode="Password" AutoComplete="off" Width="400" runat="server"></asp:TextBox>
                        <h5 style="font-size: 18px; margin-top: 20px">Họ và tên</h5>
                        <asp:TextBox ID="tbFullNamedk" AutoComplete="off" Width="400" runat="server"></asp:TextBox>
                        <asp:Label ID="Check" runat="server" Text="test"></asp:Label>
                        <div style="height: 20px"></div>
                        <asp:Button ID="bDangky" Width="100" Height="55" runat="server" Text="Đăng ký" OnClick="bDangky1_Click" ForeColor="White" BackColor="Black" BorderWidth="0"/>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</asp:Content>
