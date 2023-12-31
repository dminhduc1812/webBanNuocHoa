<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QlyDatHang.aspx.cs" Inherits="VNPAY_CS_ASPX.Admin.QlyDatHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

                    <!-- Page Heading -->
                    <h1 class="h3 mb-2 text-gray-800">Tables</h1>
                    

                    <!-- DataTales Example -->
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Bảng đặt hàng </h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <%--<th>ID đặt hàng</th>--%>
                                            <th>Tên người mua</th>
                                            <th>Số điện thoại</th>
                                            <th>Địa chỉ</th>
                                            <th>Ngày giao dịch</th>
                                            <th>Số tiền</th>
                                            <th>Trạng thái đơn hàng</th>
                                            <th>Duyệt</th>
                                            <th>Hủy</th>
                                        </tr>
                                    </thead>
                                    
                                    <tbody>
                                        <%foreach (var item in PJWebNC.Dao.DaoDatHang.getAll())
                                            {
                                                string money = item.SoTienThanhToan.ToString("#,#");%>
                                        <tr>
                                            <%--<td><%= item.IDDatHang %></td>--%>
                                            <td><%= item.FullName %></td>
                                            <td><%= item.SoDienThoai %></td>
                                            <td><%= item.DiaChi %></td>
                                            <td><%= item.NgayGD.ToString("dd/MM/yyyy") %></td>
                                            <td><%= money %></td>
                                            <td><%= item.TrangThai %></td>
                                            <td>
                                                <a href="SuaDatHang.aspx?id=<%= item.MaGiaoDich %>" class="btn btn-success btn-circle">
                                                    <i class="fas fa-edit"></i>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="XoaDatHang.aspx?id=<%= item.IDDatHang %>" class="btn btn-danger btn-circle">
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
