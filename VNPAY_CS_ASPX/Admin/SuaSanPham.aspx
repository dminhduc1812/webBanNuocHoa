<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaSanPham.aspx.cs" Inherits="PJWebNC.Admin.SuaSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; justify-content:center; align-items:center; flex-direction:column;">
        <%-- Tên sản phẩm --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Tên sản phẩm:" ID="lb1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbTenSP" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
        <%-- Tên thương hiệu --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Thương hiệu:" ID="Label1" runat="server" Width="120"></asp:Label>
           
            <asp:DropDownList ID="ThuongHieu"  runat="server" CssClass="form-control form-control-user" DataSourceID="getThuongHieu" Width="250" DataTextField="TenThuongHieu" DataValueField="MaThuongHieu"></asp:DropDownList>
            <asp:SqlDataSource ID="getThuongHieu" runat="server" ConnectionString="<%$ ConnectionStrings:ConnDB %>" SelectCommand="SELECT [MaThuongHieu], [TenThuongHieu] FROM [ThuongHieu]"></asp:SqlDataSource>
        </div>
        <hr class="sidebar-divider">
        <%-- Giá bán --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Giá bán:" ID="Label2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbGiaBan" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
        <%-- Giới tính --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Giới tính:" ID="Label3" runat="server" Width="120"></asp:Label>
           
            <asp:DropDownList ID="GioiTinh" CssClass="form-control form-control-user" Width="250" runat="server" DataSourceID="getGioiTinh" DataTextField="GioiTinh" DataValueField="MaGioiTinh"></asp:DropDownList>
            <asp:SqlDataSource ID="getGioiTinh" runat="server" ConnectionString="<%$ ConnectionStrings:ConnDB %>" SelectCommand="SELECT [MaGioiTinh], [GioiTinh] FROM [GioiTinh]"></asp:SqlDataSource>
        </div>
        <hr class="sidebar-divider">
        <%-- Mùa sử dụng --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Mùa dùng:" ID="Label4" runat="server" Width="120"></asp:Label>
            <%--<asp:TextBox ID="TextBox4" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>--%>
            <asp:DropDownList ID="Season" runat="server" DataSourceID="getSeason" DataTextField="Season" DataValueField="MaSeason" CssClass="form-control form-control-user" Width="250"></asp:DropDownList>
            <asp:SqlDataSource ID="getSeason" runat="server" ConnectionString="<%$ ConnectionStrings:ConnDB %>" SelectCommand="SELECT [MaSeason], [Season] FROM [Season]"></asp:SqlDataSource>
        </div>
        <hr class="sidebar-divider">
        <%-- File upload --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Ảnh:" ID="Label5" runat="server" Width="40" ></asp:Label>
            <asp:FileUpload ID="upAnh" runat="server" />
            
        </div>
        <hr class="sidebar-divider">
        <%-- Nút thêm --%>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-icon-split" Text="Thay đổi" OnClick="Button1_Click" Width="100" />
        </div>
</asp:Content>
