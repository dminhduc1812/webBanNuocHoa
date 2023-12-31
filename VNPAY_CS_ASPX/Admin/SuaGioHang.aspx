<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaGioHang.aspx.cs" Inherits="PJWebNC.Admin.SuaGioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; justify-content:center; align-items:center; flex-direction:column;">
        
        <%-- UserID --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="UserID:" ID="lb1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbUserID" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- IDSanPham --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="ID Sản Phẩm:" ID="lb2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbIDSanPham" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- SoLuong --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Số Lượng:" ID="lb3" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbSoLuong" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">


        <%-- Nút thêm --%>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-icon-split" Text="Sửa giỏ hàng" OnClick="Button1_Click" Width="100" />
      </div>
</asp:Content>
