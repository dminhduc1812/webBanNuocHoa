<%@ Page Title='' Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PJWebNC.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css" />
    <link rel="stylesheet" href="TrangChu.css" />
    <style>
        .nav-pills .nav-link.active {
            background-color: white;
            color: black;
            text-decoration: underline;
        }

        .nav-pills .nav-link {
            background-color: none;
            color: gray;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">
    <!-- content -->
        <div class="Content">
            <!-- brand -->
            <div class="brand">
                <p>Thương hiệu nổi tiếng</p>
                <div class="logoBrand" style="border: none">

                    <div class="brand1">
                        
                        <div class="brand1">
                        <asp:DataList ID="DataList1" RepeatColumns="6" RepeatDirection="Horizontal" runat="server">
                            <ItemTemplate>
                                <a href="DanhSach.aspx?id=<%#Eval("MaThuongHieu") %>">
                                    <div class="itemBrand" style="display:flex; justify-content:center; align-items:center">
                                    <asp:Image ID="LogoBrandLabel" runat="server" Width="160" MaxHeight="160" ImageUrl='<%#"Admin/SqlPic/Logo/"+ Eval("LogoBrand") %>' />
                                </div>
                                </a>
                            </ItemTemplate>
                        </asp:DataList>
                        </div>
                        
                        
                    </div>
                </div>
                
            </div>
            <!-- brand -->

            <!--hotProduct  -->
            <div class="hotProduct">
                <p>Sản phẩm nổi bật</p>
                <div class="typeProduct">
                    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                        <li class="nav-item" style="background-color:white" role="presentation">
                            <button class="nav-link active hover" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">
                                <h3>Nước hoa nam</h3>
                            </button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="pills-profile-tab" data-bs-toggle="pill" data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile" aria-selected="false"><h3>Nước hoa nữ</h3></button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="pills-contact-tab" data-bs-toggle="pill" data-bs-target="#pills-contact" type="button" role="tab" aria-controls="pills-contact" aria-selected="false"><h3>Unisex</h3></button>
                        </li>
                    </ul>
                </div>
                <div class="tab-content mt-5" id="pills-tabContent">
                        <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                            <div class="Product">
                                
                                <asp:DataList ID="SanPham" runat="server" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <a href="ChiTietSanPham.aspx?id=<%#Eval("IDSanPham") %>">
                                            
                                            <div class="itemProduct">
                                                <div class="picProduct">
                                                    <asp:Image ID="img1" runat="server" Width="200" Height="250" ImageUrl='<%# "Admin/SqlPic/" + Eval("Anh") %>' />
                                                </div>
                                                <p class="HangSX"><%# Eval("TenThuongHieu") %></p>

                                                <p><%# Eval("TenSP") %></p>

                                                <h4 style="text-align: center"><%#Eval("GiaBan", "{0:N0}") %> đ</h4>
                                            </div>
                                               
                                        </a>
                                    </ItemTemplate>
                                </asp:DataList>
                                    
                            </div>
                        </div>
                        <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                            <div class="Product">

                                <asp:DataList ID="dtlTopNu" runat="server" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <a href="ChiTietSanPham.aspx?id=<%#Eval("IDSanPham") %>">
                                            <div class="itemProduct">
                                                <div class="picProduct">
                                                    <asp:Image ID="img1" runat="server" Width="200" Height="250" ImageUrl='<%# "Admin/SqlPic/" + Eval("Anh") %>' />
                                                </div>
                                                <p class="HangSX"><%# Eval("TenThuongHieu") %></p>

                                                <p style="text-align:center;"><%# Eval("TenSP") %></p>

                                                <h4 style="text-align: center"><%#Eval("GiaBan", "{0:N0}") %> đ</h4>
                                            </div>
                                        </a>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">
                                <div class="Product">

                                <asp:DataList ID="dtlTopUni" runat="server" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <a href="ChiTietSanPham.aspx?id=<%#Eval("IDSanPham") %>">
                                            <div class="itemProduct">
                                                <div class="picProduct">
                                                    <asp:Image ID="img1" runat="server" Width="200" Height="250" ImageUrl='<%# "Admin/SqlPic/" + Eval("Anh") %>' />
                                                </div>
                                                <p class="HangSX"><%# Eval("TenThuongHieu") %></p>

                                                <p style="text-align:center"><%# Eval("TenSP") %></p>

                                                <h4 style="text-align: center"><%#Eval("GiaBan", "{0:N0}") %> đ</h4>
                                            </div>
                                        </a>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                


            </div>
            <!--hotProduct  -->
            
            <!--Video  -->
            <p>Perfume bar đầu tiên tại Việt Nam</p>
            <iframe width="1200" height="675" src="https://www.youtube.com/embed/Fiycfl4sJYE" title="Perfume Bar Đầu Tiên Tại Việt Nam! | Đập Hộp Nút Bạc Youtube | Hoàng XXIV"
             frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen="true"></iframe>
            <!--Video  -->


            <!-- Li do chon -->
            <p style="margin-top: 100px;">Tại sao chọn xxiv store</p>
            <div class="LiDoChon">
                <div class="reason">
                    <div class="iconWhy">
                        <img src="Icon/grommet-icons_shield-security.png" alt="">
                    </div>
                    <p style="font-size: 24px;">sản phẩm chính hãng</p>
                    <p style="font-size: 18px;">sản phẩm nước hoa được mua trực tiếp tại store ở pháp, cam kết chính hãng</p>
                </div>
                <div class="reason">
                    <div class="iconWhy">
                        <img src="Icon/free-ship.png" alt="">
                    </div>
                    <p style="font-size: 24px;">free ship toàn quốc</p>
                    <p style="font-size: 18px;">xxiv áp dụng freeship cho tất cả các khách hàng trên toàn quốc. chúng tôi chưa áp dụng hình thức giao hàng quốc tế tại thời điểm này</p>
                
                </div>
                <div class="reason">
                    <div class="iconWhy">
                        <img src="Icon/gift.png" alt="">
                    </div>
                    <p style="font-size: 24px;">thành viên thân thiết</p>
                    <p style="font-size: 18px;">thành viên vàng sẽ được giảm 5% / đơn hàng. với thành viên bạc khách được giảm 3% / đơn hàng.</p>
                
                </div>
            </div>
            <!-- Li do chon -->
            

            <!-- info -->
            <p>xxiv store</p>
            <h3>Số 25 Ngõ Thái Hà, Đống Đa, Hà Nội | 525/44 Tô Hiến Thành, P14, Q10, TP. Hồ Chí Minh</h3>
            <h3>090 721 9889| 093 194 8668</h3>
            <h3>Giờ mở cửa: Các ngày trong tuần từ 9:00 – 21:00</h3>
            <!-- info -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>
        </div>

        <!-- content -->
</asp:Content>
