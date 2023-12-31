<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaND.aspx.cs" Inherits="PJWebNC.Admin.SuaND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; justify-content:center; align-items:center; flex-direction:column;">
        <%-- Tài khoản --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Tài khoản:" ID="lb1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbTaiKhoan" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
        <%-- Mật khẩu --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Mật khẩu:" ID="Label1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbMatKhau" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
        <%-- FullName --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Họ và tên:" ID="Label2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbFullName" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
        <%-- Vai trò --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Vai trò:" ID="Label3" runat="server" Width="120"></asp:Label>
           
            <asp:DropDownList ID="VaiTro" CssClass="form-control form-control-user" Width="250" runat="server" DataSourceID="getVaiTro" DataTextField="TenVaiTro" DataValueField="IDVaiTro"></asp:DropDownList>
            <asp:SqlDataSource ID="getVaiTro" runat="server" ConnectionString="<%$ ConnectionStrings:ConnDB %>" SelectCommand="SELECT [IDVaiTro], [TenVaiTro] FROM [VaiTro]"></asp:SqlDataSource>
        </div>
        <hr class="sidebar-divider">
        
        <hr class="sidebar-divider">
        <%-- Nút thêm --%>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-icon-split" Text="Thay đổi" OnClick="Button1_Click" Width="100" />
        </div>
</asp:Content>
