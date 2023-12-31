<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QlyDacDiem.aspx.cs" Inherits="PJWebNC.Admin.QlyDacDiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

                    <!-- Page Heading -->
                    <h1 class="h3 mb-2 text-gray-800">Tables</h1>
                    

                    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bảng đặc điểm </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>ID đặc điểm</th>
                                            <th>Tên sản phẩm</th>
                                            <th>Phát hành</th>
                                            <th>Độ tuổi</th>
                                            <th>Độ lưu mùi</th>
                                            <th>Sửa</th>
                                            <th>Xóa</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                        <%foreach (var item in PJWebNC.Dao.DaoDacDiem.getAll())
                                            {  %>
                                        <tr>
                                            <td><%= item.IDDacDiem %></td>
                                            <td><%= item.TenSP %></td>
                                            <td><%= item.PhatHanh %></td>
                                            <td><%= item.DoTuoi %></td>
                                            <td><%= item.DoLuuMui %></td>
                                            <td>
                                                <a href="SuaDacDiem.aspx?id=<%= item.IDDacDiem %>" class="btn btn-success btn-circle">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="XoaDacDiem.aspx?id=<%= item.IDDacDiem %>" class="btn btn-danger btn-circle">
                                                    <i class="fas fa-minus"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                                <a href="ThemDacDiem.aspx" class="btn btn-success btn-icon-split">
                                    <span class="icon text-white-50">
                                        <i class="fas fa-plus"></i>
                                    </span>
                                    <span class="text">Thêm đặc điểm</span>
                                </a>
                            </div>
                        </div>
                    </div>

    </div>
</asp:Content>
