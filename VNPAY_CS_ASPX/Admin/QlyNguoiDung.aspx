<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QlyNguoiDung.aspx.cs" Inherits="PJWebNC.Admin.QlySanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
                <div class="container-fluid">

                    <!-- Page Heading -->
                    <h1 class="h3 mb-2 text-gray-800">Tables</h1>
                    

                    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bảng người dùng </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Tài khoản</th>
                                            <th>Mật khẩu</th>
                                            <th>Họ và tên</th>
                                            <th>Vai trò</th>
                                            <th>Sửa</th>
                                            <th>Xóa</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                        <%foreach (var item in PJWebNC.Dao.DaoNguoiDung.getAll())
                                            {  %>
                                        <tr>
                                            <td><%= item.UserID %></td>
                                            <td><%= item.TaiKhoan %></td>
                                            <td><%= item.MatKhau %></td>
                                            <td><%= item.FullName %></td>
                                            <td><%= item.TenVaiTro %></td>
                                            <td>
                                                <a href="SuaND.aspx?id=<%= item.UserID %>" class="btn btn-success btn-circle">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="XoaNguoiDung.aspx?id=<%= item.UserID %>" class="btn btn-danger btn-circle">
                                                    <i class="fas fa-minus"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.container-fluid -->
</asp:Content>
