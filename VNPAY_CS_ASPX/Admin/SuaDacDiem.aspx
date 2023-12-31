<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaDacDiem.aspx.cs" Inherits="PJWebNC.Admin.SuaDacDiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; justify-content:center; align-items:center; flex-direction:column;">
        
        <%-- IDSanPham --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="ID Sản Phẩm:" ID="lb1" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbIDSanPham" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- PhatHanh --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Phát hành:" ID="lb2" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbPhatHanh" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- DoTuoi --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Độ tuổi:" ID="lb3" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbDoTuoi" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

         <%-- DoLuuMui --%>
        <div style="display:flex; flex-direction:row; align-items:center">
            <asp:Label Text="Độ lưu mùi:" ID="lb4" runat="server" Width="120"></asp:Label>
            <asp:TextBox ID="tbDoLuuMui" CssClass="form-control form-control-user" runat="server" Width="250px"></asp:TextBox>
        </div>
        <hr class="sidebar-divider">

        <%-- Nút thêm --%>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-icon-split" Text="Sửa đặc điểm" OnClick="Button1_Click" Width="100" />
      </div>
</asp:Content>
