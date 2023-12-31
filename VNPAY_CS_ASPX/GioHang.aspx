<%@ Page Title="Giỏ hàng" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="PJWebNC.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">
    <link rel="stylesheet" href="GioHang.css"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script type="text/javascript">
    function showAlert(message) {
        alert(message);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">

    <!-- Content -->
    <div class="Content">
        
        <!-- c-left -->
        <div class="c-left" >
            <h2>
                <asp:Label ID="lbTieuDe" runat="server" Text="Sản phẩm đã chọn"></asp:Label></h2>
            
            <asp:DataList ID="dtlGioHang" runat="server" Width="100%" DataKeyField="IDSanPham" OnItemCommand="dtlGioHang_ItemCommand" >
                <ItemTemplate>
                    <div class="product-grid ">
                        <div class="imgPD">
                            <img src='<%# "Admin/SqlPic/" + Eval("Anh") %>' alt="">
                        </div>
                        <div class="tenPD d-flex justify-content-center align-items-lg-center">
                            <h2> 
                                <%#Eval("TenSP") %> </h2>
                           
                            <h2><%#Eval("GiaBan", "{0:N0}") %></h2>
                        </div>
                        <div class="inputPD" style="display: flex; justify-content: space-evenly; align-items: center; flex-direction: column;">
                            <asp:TextBox ID="tbSoLuong" runat="server" Width="100" TextMode="Number" Min="1" Text='<%#Eval("SoLuong") %>'></asp:TextBox>
                            <asp:Button ID="bCapNhap" runat="server" Text="Cập nhập" ForeColor="White" BackColor="Black" CommandName="Update" CommandArgument='<%# Eval("IDSanPham") %>' />
                            <asp:Button ID="bXoa" runat="server" Text="Xóa sản phẩm" Width="120" Height="30" CommandName="Xoa" CommandArgument='<%# Eval("IDSanPham") %>' ForeColor="White" BackColor="Black" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <div class="" style="width:100%; display:flex; justify-content:center;">
                <asp:Button ID="bBackStore" OnClick="bCapNhap_Click" runat="server" Text="Quay lại cửa hàng" Width="150" Height="50" ForeColor="White" BackColor="Black" />
            </div>

        </div>
        <!-- c-left -->

        <!-- c-right -->
        <div class="c-right">
            <h2 id="hidden1" runat="server">Phiếu thanh toán</h2>

            <div class="TongTien" style="display:flex; flex-direction:row; justify-content:space-between">
                <h3 style="font-size: 25px; text-align:left;margin-left:30px" id="hidden2" runat="server">Tạm tính: </h3>
                <h3 style="font-size: 25px;" >
                    <asp:Label ID="TongTien"  runat="server" Text=""></asp:Label></h3>
            </div>

            <div class="buttonChucNang d-flex justify-content-center m-lg-5">
                
                <asp:Button ID="bThanhToan" runat="server" Text="MUA NGAY" Height="65" Width="300" OnClick="bThanhToan_Click" BorderWidth="0" ForeColor="White" BackColor="Red" />
            </div>
        </div>
        <!-- c-right -->
    </div>
    <!-- Content -->

</asp:Content>
