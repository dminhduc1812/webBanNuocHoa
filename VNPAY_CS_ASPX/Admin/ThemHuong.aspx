<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ThemHuong.aspx.cs" Inherits="PJWebNC.Admin.ThemHuong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; justify-content:center; align-items:center; flex-direction:column;">
        
        <%-- IDSanPham --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="ID Sản Phẩm:" ID="lb2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbIDSanPham" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- ToneHuong --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Tone Hương:" ID="lb3" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbToneHuong" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- HuongDau --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Hương đầu:" ID="lb4" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbHuongDau" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- HuongGiua --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Hương Giữa:" ID="lb5" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbHuongGiua" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- HuongCuoi --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Hương cuối:" ID="lb6" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbHuongCuoi" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

        <%-- Nút thêm --%>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-icon-split" Text="Thêm hương" OnClick="Button1_Click" Width="100" />
      </div>
</asp:Content>
