<%@ Page Title="" Language="C#" MasterPageFile="~/giaodiennguoidung.Master" AutoEventWireup="true" CodeBehind="DangKyThanhVien.aspx.cs" Inherits="aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan.DangKyThanhVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="dangkythanhvien">
    <div class="panel panel-default">
        <div class="panel-heading"><h4>Đăng ký thành viên</h4></div>
        <div class="panel-body">
        <%=TB%>
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-4">
            <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Họ"></asp:Label>
                <asp:TextBox ID="txtHoKH" class="form-control" placeholder="Họ" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="rfvHoKH" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtHoKH"></asp:RequiredFieldValidator>
            <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Tên"></asp:Label>
                <asp:TextBox ID="txtTenKH" class="form-control" placeholder="Tên" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtTenKH"></asp:RequiredFieldValidator>
            <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmailKH" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
            </div>    
            <asp:RequiredFieldValidator ID="rfvEmailKH" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtEmailKH"></asp:RequiredFieldValidator>
            <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Mật khẩu"></asp:Label>
                <asp:TextBox ID="txtMatKhau" TextMode="Password" class="form-control" placeholder="Mật khẩu" runat="server"></asp:TextBox>
            </div>    
            <asp:RequiredFieldValidator ID="rfvMatKhau" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtMatKhau"></asp:RequiredFieldValidator>
            <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Nhập lại mật khẩu"></asp:Label>
                <asp:TextBox ID="txtNhapLaiMatKhau" TextMode="Password" class="form-control" placeholder="Nhập lại mật khẩu" runat="server"></asp:TextBox>
            </div>
            <asp:CompareValidator ID="cvNhapLaiMatKhau" runat="server" ErrorMessage="(*) Nhập lại mật khẩu không đúng" ForeColor="Red" ControlToValidate="txtNhapLaiMatKhau" ControlToCompare="txtMatKhau" Operator="Equal" Type="String" Display="Static"></asp:CompareValidator>
            <div class="input-group">
                <asp:Label class="input-group-addon" runat="server" Text="Điện thoại"></asp:Label>
                <asp:TextBox ID="txtDienThoaiKH" class="form-control" placeholder="Điện thoại" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="rfvDienThoaiKH" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtDienThoaiKH"></asp:RequiredFieldValidator>
            <div class="input-group">
                Bạn đã có tài khoản? <a href="/DangNhap.aspx">Đăng nhập</a>
            </div>
            <asp:Button ID="btnDangKy" class="btn btn-primary" OnClick="btnDangKy_Click" runat="server" Text="Đăng ký" />
            </div>
        </div>

        </div>
    </div>
</div>
</asp:Content>
