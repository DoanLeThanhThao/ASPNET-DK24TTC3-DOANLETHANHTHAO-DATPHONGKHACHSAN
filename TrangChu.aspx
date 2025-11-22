<%@ Page Title="" Language="C#" MasterPageFile="~/giaodiennguoidung.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan.TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="trangchu">
    <div class="panel panel-default">
        <div class="panel-heading"><h4>Đặt phòng ngay hôm nay nhận nhiều ưu đãi hấp dẫn!</h4></div>
        <div class="panel-body">
        <%=TB%>
        <div class="form-group timkiem">
            <div class="col-sm-3">
                <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Ngày nhận phòng"></asp:Label>
                <asp:TextBox ID="txtNgayNhanPhong" class="form-control" type="date" placeholder="Ngày nhận phòng" runat="server" AutoPostBack="False"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Số lượng khách"></asp:Label>
                <asp:DropDownList ID="ddlSoLuongKhach" class="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Tỉnh thành"></asp:Label>
                <asp:DropDownList ID="ddlTinhThanh" class="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="input-group">
                <asp:Button ID="btnTimKiem" class="btn btn-primary" OnClick="btnTimKiem_Click" runat="server" Text="Tìm kiếm"/>
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:DataList ID="dlKhachSan" class="col-sm-12" runat="server" DataKeyField="IDKS" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%" OnItemCommand="dlKhachSan_ItemCommand">
                <HeaderTemplate>
                    <div class="dataListHeader">
                        Điểm đến phổ biến được nhiều người yêu thích
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="danhsach">
                    <asp:Image ID="imgHinhAnhKS" runat="server"
                                   ImageUrl='<%# Eval("HinhAnhKS") %>'
                                   AlternateText='<%# Eval("TenKS") %>' />
                        <div class="danhsach-ten ">
                            <%# Eval("TenKS") %>
                        </div>
                        <div class="danhsach-diachi">
                            Đ/c: <%# Eval("DiaChiKS") %>
                        </div>
                        <div class="danhsach-dienthoai">
                            <%--Giá: <%# Eval("Price", "{0:C}") %>--%>
                            SĐT: <%# Eval("DienThoaiKS") %>
                        </div>
                        <div class="danhsach-mota">
                            Mô tả: <%# Eval("MoTaKS") %>
                        </div>
                        <asp:Button ID="btnDatPhong" class="btn btn-primary" runat="server" Text="Đặt phòng" CommandName="DatPhongKhachSan" CommandArgument='<%# Eval("IDKS") %>' />
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="danhsach">
                        <asp:Image ID="imgHinhAnhKSALT" runat="server"
                                   ImageUrl='<%# Eval("HinhAnhKS") %>'
                                   AlternateText='<%# Eval("TenKS") %>' />
                        <div class="danhsach-ten">
                            <%# Eval("TenKS") %>
                        </div>
                        <div class="danhsach-diachi">
                            Đ/c: <%# Eval("DiaChiKS") %>
                        </div>
                        <div class="danhsach-dienthoai">
                            SĐT: <%# Eval("DienThoaiKS") %>
                        </div>
                        <div class="danhsach-mota">
                            Mô tả: <%# Eval("MoTaKS") %>
                        </div>
                        <asp:Button ID="btnDatPhongALT" class="btn btn-primary" runat="server" Text="Đặt phòng" CommandName="DatPhongKhachSan" CommandArgument='<%# Eval("IDKS") %>' />
                    </div>
                </AlternatingItemTemplate>
                <SeparatorTemplate>
                    <hr class="dataListSeparator" />
                </SeparatorTemplate>
                <FooterTemplate>
                    <div class="dataListFooter">
                        Tổng số sản phẩm: <%# dlKhachSan.Items.Count %>
                    </div>
                </FooterTemplate>
            </asp:DataList>
        </div>
        </div>
    </div>
</div>
</asp:Content>
