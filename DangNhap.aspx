<%@ Page Title="" Language="C#" MasterPageFile="~/giaodiennguoidung.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="dangnhap">
    <div class="panel panel-default">
            <div class="panel-heading"><h4>Đăng nhập</h4></div>
            <div class="panel-body">
            <%=TB%>
            <div class="form-group">
                <div class="col-sm-offset-4 col-sm-4">
                <div class="input-group">
                    <span class="input-group-addon">Tên đăng nhập</span>
                    <asp:TextBox ID="txtEmailKH" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="rfvEmailKH" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtEmailKH"></asp:RequiredFieldValidator>
                <div class="input-group">
                    <span class="input-group-addon">Mật khẩu</span>
                    <asp:TextBox ID="txtMatKhau" class="form-control" placeholder="Mật khẩu" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="rfvMatKhau" runat="server" ErrorMessage="(*) Không được bỏ trống" ForeColor="Red" ControlToValidate="txtMatKhau"></asp:RequiredFieldValidator>
                <div class="input-group">
                    <a href="#">Bạn quên mật khẩu? Bấm vào đây.</a>
                </div>
                <asp:Button ID="btnDangNhap" class="btn btn-primary" OnClick="btnDangNhap_Click" runat="server" Text="Đăng nhập" />
                </div>
            </div>
            </div>
    </div>
</div>
</asp:Content>
