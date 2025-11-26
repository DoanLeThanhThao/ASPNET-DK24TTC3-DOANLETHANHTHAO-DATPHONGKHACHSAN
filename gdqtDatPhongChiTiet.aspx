<%@ Page Title="" Language="C#" MasterPageFile="~/giaodienquantri.Master" AutoEventWireup="true" CodeBehind="gdqtDatPhongChiTiet.aspx.cs" Inherits="aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan.gdqtDatPhongChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="tuade">Đặt Phòng</h4>
    <div class="form-group btn-buttontopchitiet">
        <div class="col-sm-12">
            <asp:Button ID="btnTroVeDatPhong" class="btn btn-default" runat="server" Text="Trở về" OnClick="btnTroVeDatPhong_Click" />
            <asp:Button ID="btnXemTongTien" class="btn btn-warning" runat="server" Text="Xem Tổng Tiền" OnClick="btnXemTongTien_Click" />
            <asp:Button ID="btnLuuDatPhong" class="btn btn-primary" runat="server" Text="Lưu" OnClick="btnLuuDatPhong_Click" />
        </div>
    </div>
    <%=TB%>
    <div class="form-group">
        <asp:Label ID="lblKhachSan" class="control-label col-sm-offset-6 col-sm-2" runat="server" Text="Khách sạn"></asp:Label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlKhachSan" class="form-control" runat="server" OnSelectedIndexChanged="ddlKhachSan_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <asp:Label ID="lblKH" class="control-label col-sm-2" runat="server" Text="Khách hàng"></asp:Label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlKhachHang" class="form-control" runat="server"></asp:DropDownList>
        </div>
        <asp:Label ID="lblPhong" class="control-label col-sm-2" runat="server" Text="Phòng"></asp:Label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlPhong" class="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <asp:Label ID="lblNgayNhanPhong" class="control-label col-sm-2" runat="server" Text="Ngày nhận phòng"></asp:Label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtNgayNhanPhong" type="date" class="form-control" placeholder="Ngày nhận phòng" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNgayNhanPhong" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtNgayNhanPhong"></asp:RequiredFieldValidator>
        </div>
        <asp:Label ID="lblNgayTraPhong" class="control-label col-sm-2" runat="server" Text="Ngày trả phòng"></asp:Label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtNgayTraPhong" type="date" class="form-control" placeholder="Ngày trả phòng" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNgayTraPhong" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtNgayTraPhong"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <asp:Label ID="lblSoLuongKhach" class="control-label col-sm-2" runat="server" Text="Số lượng khách"></asp:Label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlSoLuongKhach" class="form-control" runat="server"></asp:DropDownList>
        </div>
        <asp:Label ID="lblTongTien" class="control-label col-sm-2" runat="server" Text="Tổng tiền (x1000VNĐ)"></asp:Label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtTongTien" class="form-control" placeholder="Tổng tiền" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <asp:Label ID="lblNgayDatPhong" class="control-label col-sm-2" runat="server" Text="Ngày đặt phòng"></asp:Label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtNgayDatPhong" class="form-control" placeholder="Ngày đặt phòng" type="date" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNgayDatPhong" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtNgayDatPhong"></asp:RequiredFieldValidator>
        </div>
        <asp:Label ID="lblTrangThai" class="control-label col-sm-2" runat="server" Text="Trạng thái"></asp:Label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlTrangThai" class="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>
</asp:Content>
