<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QlyGioHang.aspx.cs" Inherits="PJWebNC.Admin.QlyGioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

                    <!-- Page Heading -->
                    <h1 class="h3 mb-2 text-gray-800">Tables</h1>
                    

                    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bảng giỏ hàng </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <%--<th>ID giỏ hàng</th>--%>
                                            <th>Tên người mua</th>
                                            <th>Tên sản phẩm</th>
                                            <th>Số lượng</th>
                                            <th>Sửa</th>
                                            <th>Xóa</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                        <%foreach (var item in PJWebNC.Dao.DaoGioHang.getAll())
                                            {  %>
                                        <tr>
                                            <%--<td><%= item.IDGioHang %></td>--%>
                                            <td><%= item.FullName %></td>
                                            <td><%= item.TenSP %></td>
                                            <td><%= item.SoLuong %></td>
                                            <td>
                                                <a href="SuaGioHang.aspx?id=<%= item.IDGioHang %>" class="btn btn-success btn-circle">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="XoaGioHang.aspx?id=<%= item.IDGioHang %>" class="btn btn-danger btn-circle">
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
</asp:Content>
