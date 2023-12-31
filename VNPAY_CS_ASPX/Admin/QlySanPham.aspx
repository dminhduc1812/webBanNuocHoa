<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QlySanPham.aspx.cs" Inherits="PJWebNC.Admin.QlySanPham1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

                    <!-- Page Heading -->
                   <%-- <h1 class="h3 mb-2 text-gray-800">Tables</h1>--%>
                    

                    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bảng người dùng </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive"  >
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Tên sản phẩm</th>
                                            <th>Tên thương hiệu</th>
                                            <th>Ảnh</th>
                                            <th>Giá bán</th>
                                            <th>Giới tính</th>
                                            <th>Mùa</th>
                                            <th>Sửa</th>
                                            <th>Xóa</th>
                                            
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                        <%foreach (var item in PJWebNC.Dao.DaoSanPham.getAllToGrid())
                                            {  %>
                                        <tr>
                                            <td><%=item.IDSanPham %></td>
                                            <td><%= item.TenSP %></td>
                                            <td><%= item.TenThuongHieu %></td>
                                            <td style="display:flex; justify-content:center">
                                                <img src='<%="SqlPic/" + item.Anh %>' alt="" style="width:100px"/>
                                            </td>
                                            <td><%= item.GiaBan.ToString("N0") %>đ</td>
                                            <td><%= item.GioiTinh %></td>
                                            <td><%= item.Season %></td>
                                            <td>
                                                <a href="SuaSanPham.aspx?id=<%= item.IDSanPham %>" class="btn btn-success btn-circle">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="XoaSanPham.aspx?id=<%= item.IDSanPham %>" class="btn btn-danger btn-circle">
                                                    <i class="fas fa-minus"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                                <a href="ThemSanPham.aspx" class="btn btn-success btn-icon-split">
                                    <span class="icon text-white-50">
                                        <i class="fas fa-plus"></i>
                                    </span>
                                    <span class="text">Thêm sản phẩm</span>
                                </a>
                            </div>
                        </div>
                    </div>

                </div>
</asp:Content>
