<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="PJWebNC.ChiTietSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tieude" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="ChiTietSanPham.css" />
    <title><%Response.Write(TenSP.Text);%></title>
    <script type="text/javascript">
    function showAlert(message) {
        alert(message);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">
    <div class="Content">
            <div class="detail">
                <div class="c-left">
                    <div class="imgProduct">
                        <div class="imgTop">
                            <asp:Image runat="server" ID="image1" Width="400px" Height="400px" />
                        </div>
                        <%--<div class="imgBot">
                            <asp:Image runat="server" ID="image2" Width="100px" Height="100px"  />
                            
                        </div>--%>
                    </div>
                    <h3 style="font-size: 33px; margin: 20px 0px;">MÔ TẢ</h3>
                    <p style="font-size: 18px;">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas adipisci quasi facere repellat quod nesciunt, perferendis, minus laudantium repudiandae soluta facilis blanditiis eius itaque corrupti, in debitis vero perspiciatis illum.</p>
                </div>
                <div class="c-right">
                    
                    <span style="font-size: 18px; margin-bottom: 25px; margin-top: 30px;"><asp:label ID="ThuongHieu" runat="server" ></asp:label></span>
                    <span style="font-size: 40px; margin-bottom: 25px;"><asp:label ID="TenSP" runat="server" ></asp:label></span>
                    <span style="font-size: 18px; margin-bottom: 25px;"><asp:label ID="GioiTinh" runat="server" ></asp:label></span>
                    <span style="font-size: 25px; margin-bottom: 40px;"><asp:label ID="GiaBan" runat="server" ></asp:label> VND</span>
                    <span style="font-size: 18px; margin-bottom: 20px;">Lorem, ipsum.</span>
                    
                    <div class="chucnang">
                       
                        <asp:TextBox ID="Soluong" Width="170" TextMode="Number" Text="1" min="1" runat="server"></asp:TextBox> 
                        <asp:Button ID="ThemCart" Width="420" runat="server" BackColor="black" ForeColor="white" Text="THÊM VÀO GIỎ HÀNG" OnClick="ThemCart_Click" BorderWidth="0"/>
                    </div>
    
                    <div class="panel">
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item" role="presentation">
                                <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true">Hương</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="false">Đặc điểm</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="contact-tab" data-bs-toggle="tab" data-bs-target="#contact" type="button" role="tab" aria-controls="contact" aria-selected="false">Khuyên dùng</button>
                            </li>
                        </ul>
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                <div class="toneHuong">
                                    <ul>
                                        <li class="fs-5">Tone hương: 
                                            <asp:Label ID="ToneHuong" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                        </li>
                                        <li class="fs-5">Hương đầu: 
                                            <asp:Label ID="HuongDau" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                        </li>
                                        <li class="fs-5">Hương giữa: 
                                            <asp:Label ID="HuongGiua" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                        </li>
                                        <li class="fs-5">Hương cuối: 
                                            <asp:Label ID="HuongCuoi" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                    <div class="toneHuong">
                                        <ul>
                                            <li class="fs-5">Phát hành: 
                                                <asp:Label ID="PhatHanh" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                            </li>
                                            <li class="fs-5">Giới tính: 
                                                <asp:Label ID="gioitinh1" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                            </li>
                                            <li class="fs-5">Độ tuổi: 
                                                <asp:Label ID="DoTuoi" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                            </li>
                                            <li class="fs-5">Độ lưu mùi: 
                                                <asp:Label ID="DoLuuMui" runat="server" Text="Chưa có dữ liệu"></asp:Label>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">
                                <div class="toneHuong" style="display:flex; flex-direction: row">
                                    <%--<p class="fs-5" style="margin-left:20px">Mùa:</p> --%>
                                    <ul class="" >
                                        <li class="fs-5">Ngày: /10</li>
                                        <li class="fs-5">Đêm: /10</li>
                                        
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="newProduct">
                <p class="tieude">Sản phẩm mới nhất</p>
                <div class="ProductShow">
                    <asp:DataList ID="dtlNew" runat="server" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <a class="linkHover" href="ChiTietSanPham.aspx?id=<%#Eval("IDSanPham") %>">
                                <div class="itemShow">
                                    <div class="picProduct">
                                        <asp:Image ID="imgg" Width="200" Height="230" runat="server" ImageUrl=<%# "Admin/SqlPic/"+ Eval("Anh") %> />
                                    </div>
                                    <p class="HangSX"><%#Eval("TenThuongHieu") %></p>

                                    <p style="text-align:center;"><%#Eval("TenSP") %></p>

                                    <h4><%#Eval("GiaBan", "{0:N0} VND") %></h4>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:DataList>
                    
                </div>
            </div>
            <div class="newProduct">
                <p class="tieude">Sản phẩm liên quan</p>
                <div class="ProductShow">
                    <asp:DataList ID="dtlRelated" runat="server" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <a href="ChiTietSanPham.aspx?id=<%#Eval("IDSanPham") %>">
                                <div class="itemShow">
                                    <div class="picProduct">
                                        <asp:Image ID="imgg" Width="200" Height="230" runat="server" ImageUrl=<%# "Admin/SqlPic/"+ Eval("Anh") %> />
                                    </div>
                                    <p class="HangSX"><%#Eval("TenThuongHieu") %></p>

                                    <p style="text-align:center;"><%#Eval("TenSP") %></p>

                                    <h4><%#Eval("GiaBan", "{0:N0} VND") %></h4>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:DataList>
                    
                </div>
            </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
        </div>
</asp:Content>
