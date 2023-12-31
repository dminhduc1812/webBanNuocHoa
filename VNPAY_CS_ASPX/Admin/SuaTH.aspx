<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SuaTH.aspx.cs" Inherits="PJWebNC.Admin.SuaTH" %>
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

