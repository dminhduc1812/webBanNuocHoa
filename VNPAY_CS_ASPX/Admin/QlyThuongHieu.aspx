<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QlyThuongHieu.aspx.cs" Inherits="PJWebNC.Admin.QlyThuongHieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

                    <!-- Page Heading -->
                    <h1 class="h3 mb-2 text-gray-800">Tables</h1>
                    

                    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bảng thương hiệu </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>Mã thương hiệu</th>
                                            <th>Tên thương hiệu</th>
                                            <th>Hot</th>
                                            <th>LogoBrand</th>
                                            <th>Sửa</th>
                                            <th>Xóa</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                        <%foreach (var item in PJWebNC.Dao.DaoHangSX.getAll())
                                            {  %>
                                        <tr>
                                            <td><%= item.MaThuongHieu %></td>
                                            <td><%= item.TenThuongHieu %></td>
                                            <td><%= item.Hot %></td>
                                            <td style="display:flex; justify-content:center">
                                                <img src='<%="SqlPic/Logo/" + item.LogoBrand %>' alt="" style="width:100px"/>
                                            </td>
                                            <td>
                                                <a href="SuaTH.aspx?id=<%= item.MaThuongHieu %>" class="btn btn-success btn-circle">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="XoaThuongHieu.aspx?id=<%= item.MaThuongHieu %>" class="btn btn-danger btn-circle">
                                                    <i class="fas fa-minus"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                                <a href="ThemThuongHieu.aspx" class="btn btn-success btn-icon-split">
                                    <span class="icon text-white-50">
                                        <i class="fas fa-plus"></i>
                                    </span>
                                    <span class="text">Thêm thương hiệu</span>
                                </a>
                            </div>
                        </div>
                    </div>

    </div>
</asp:Content>
