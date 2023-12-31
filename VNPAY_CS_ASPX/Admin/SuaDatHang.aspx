<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaDatHang.aspx.cs" Inherits="PJWebNC.Admin.SuaDatHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="display:flex; justify-content:center; align-items:center; flex-direction:column;">
          <%-- IDDatHang --%>
        <%--<div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="ID đặt hàng:" ID="lb1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbIDDatHang" ReadOnly="true" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>--%>
        <hr class="sidebar-divider">
         <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Họ và tên:" ID="Label2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbFullName" ReadOnly="true" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
         <%-- Ngày đặt --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Ngày đặt:" ID="lb2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbMaGD" ReadOnly="true" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
         <%-- SoTienThanhToan --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Số tiền thanh toán:" ID="Label1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbThanhToan" ReadOnly="true" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
          <%-- SoTienThanhToan --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Số điện thoại:" ID="Label3" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbSDT" ReadOnly="true" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
         <%--  --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Trạng thái:" ID="Label4" runat="server" Width="120"></asp:Label>
            <asp:DropDownList ID="TrangThai" runat="server" DataSourceID="getTrangThai" DataTextField="TrangThai" DataValueField="IDTrangThai" CssClass="form-control form-control-user" Width="250"></asp:DropDownList>
            <asp:SqlDataSource ID="getTrangThai" runat="server" ConnectionString="<%$ ConnectionStrings:ConnDB %>" SelectCommand="SELECT [IDTrangThai], [TrangThai] FROM [TrangThai]"></asp:SqlDataSource>
        </div>
        <hr class="sidebar-divider">

         <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-icon-split" Text="Thay đổi" OnClick="Button1_Click" Width="100" />
     </div>
</asp:Content>
