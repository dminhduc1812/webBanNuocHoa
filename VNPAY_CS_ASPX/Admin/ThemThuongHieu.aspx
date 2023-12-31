<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ThemThuongHieu.aspx.cs" Inherits="PJWebNC.Admin.ThemThuongHieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; justify-content:center; align-items:center; flex-direction:column;">
        <%-- Tên thương hiệu --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Thương hiệu:" ID="lb1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbThuongHieu" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">
        
        <%-- Hot --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Hot:" ID="lb2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbHot" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

        <%-- Nút thêm --%>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-icon-split" Text="Thêm thương hiệu" OnClick="Button1_Click" Width="100" />
     </div>
</asp:Content>
