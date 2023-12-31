<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QlyHuong.aspx.cs" Inherits="PJWebNC.Admin.QlyHuong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

                    <!-- Page Heading -->
                    <h1 class="h3 mb-2 text-gray-800">Tables</h1>
                    

                    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bảng Hương </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>ID hương</th>
                                            <th>Tên sản phẩm</th>
                                            <th>Tone Hương</th>
                                            <th>Hương đầu</th>
                                            <th>Hương giữa</th>
                                            <th>Hương cuối</th>
                                            <th>Sửa</th>
                                            <th>Xóa</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                        <%foreach (var item in PJWebNC.Dao.DaoHuong.getAll())
                                            {  %>
                                        <tr>
                                            <td><%= item.IDHuong %></td>
                                            <td><%= item.TenSP %></td>
                                            <td><%= item.ToneHuong %></td>
                                            <td><%= item.HuongDau %></td>
                                            <td><%= item.HuongGiua %></td>
                                            <td><%= item.HuongCuoi %></td>
                                            <td>
                                                <a href="SuaHuong.aspx?id=<%= item.IDHuong %>" class="btn btn-success btn-circle">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="XoaHuong.aspx?id=<%= item.IDHuong %>" class="btn btn-danger btn-circle">
                                                    <i class="fas fa-minus"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                                <a href="ThemHuong.aspx" class="btn btn-success btn-icon-split">
                                    <span class="icon text-white-50">
                                        <i class="fas fa-plus"></i>
                                    </span>
                                    <span class="text">Thêm Hương</span>
                                </a>
                            </div>
                        </div>
                    </div>

    </div>
</asp:Content>
