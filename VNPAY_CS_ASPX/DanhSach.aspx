<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="DanhSach.aspx.cs" Inherits="PJWebNC.DanhSach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">
    <title>Danh sách sản phẩm</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <link rel="stylesheet" href="DanhSach.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">
<!-- Content -->
        <div class="Content" style="height:auto;">
            <p style="font-size: 50px; text-align:center">Shop</p>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel  ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="Content1" style="height: auto;">
                
                <div class="c-left">
                
                <div class="dsGioiTinh" >
                    <h2>GIỚI TÍNH</h2>
                    <div style="margin-left: 55px; margin-top: 20px">
                        <asp:CheckBox ID="cbNam" Width="65" Text="Nam" runat="server" OnCheckedChanged="cbNam_CheckedChanged" AutoPostBack="true" />
                        <asp:CheckBox ID="cbNu" Text="Nữ" Width="55" runat="server" OnCheckedChanged="cbNu_CheckedChanged"  AutoPostBack="true"/>
                        <asp:CheckBox ID="cbUnisex" Text="Unisex" runat="server" OnCheckedChanged="cbUnisex_CheckedChanged"  AutoPostBack="true"/>
                    </div>
                </div>
                <div class="dsMua">
                    <h2>MÙA</h2>
                    <div style="margin-left: 55px; margin-top: 25px">

                        <asp:CheckBox ID="cbXuan" Text="Xuân" Width="55" runat="server" OnCheckedChanged="cbXuan_CheckedChanged" AutoPostBack="true"/>
                        <asp:CheckBox ID="cbHa" Width="40" runat="server" Text="Hạ" OnCheckedChanged="cbHa_CheckedChanged" AutoPostBack="true"/>
                        <asp:CheckBox ID="cbThu" Width="50" runat="server" Text="Thu"  OnCheckedChanged="cbThu_CheckedChanged" AutoPostBack="true"/>
                        <asp:CheckBox ID="cbDong" Width="55" runat="server" Text="Đông"  OnCheckedChanged="cbDong_CheckedChanged" AutoPostBack="true"/>
                    </div>
                </div>
                <div class="dsGiaTien">
                    <h2>GIÁ TIỀN</h2>
                    <div style="margin-left: 65px; margin-top: 25px">
                        <asp:CheckBox ID="cbThap" Text="Thấp" Width="55" runat="server" OnCheckedChanged="cbThap_CheckedChanged" AutoPostBack="True" />
                        <asp:CheckBox ID="cbTrungBinh" Text="Trung bình" Width="90" runat="server" OnCheckedChanged="cbTrungBinh_CheckedChanged" AutoPostBack="True" />
                        <asp:CheckBox ID="cbCao" Text="Cao" Width="55" runat="server" OnCheckedChanged="cbCao_CheckedChanged" AutoPostBack="True" />


                    </div>
                </div>
                    <div class="d-flex justify-content-evenly">
                        <asp:Button runat="server" ID="bLoc" Text="Áp dụng" OnClick="bLoc_Click" ForeColor="White" BackColor="Black"/>
                        <asp:Button runat="server" ID="bHuyLoc" Text="Hủy" OnClick="bHuyLoc_Click" ForeColor="White" BackColor="Black"/>

                    </div>
                </div>
                
                    
                        <div class="c-right">

                            <asp:DataList ID="dtlDanhSachSanPham" RepeatColumns="5" RepeatDirection="Horizontal" runat="server">
                                <ItemTemplate>
                                    <a href="ChiTietSanPham.aspx?id=<%# Eval("IDSanPham") %>">
                                        <div class="itemProduct1">
                                            <div class="picProduct1">
                                                <asp:Image ID="Image1" runat="server" Width="100%" Height="100%" ImageUrl='<%# "Admin/SqlPic/" + Eval("Anh") %>' />
                                            </div>
                                            <h3 class="HangSX1"><%# Eval("TenThuongHieu") %>
                                            </h3>
                                            <h3 class="nameProduct1" style="text-align: center;"><%# Eval("TenSP") %>
                                            </h3>
                                            <h3 class="nameProduct1"><%# Eval("GiaBan", "{0:N0} VND") %>
                                            </h3>
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </asp:DataList>


                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <!-- Content -->
</asp:Content>
