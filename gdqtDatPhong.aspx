<%@ Page Title="" Language="C#" MasterPageFile="~/giaodienquantri.Master" AutoEventWireup="true" CodeBehind="gdqtDatPhong.aspx.cs" Inherits="aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan.gdqtDatPhong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="tuade">Đặt Phòng</h4>
    <div class="form-group btn-buttontop">
        <div class="col-sm-12">
            <asp:Button ID="btnThemDatPhong" class="btn btn-primary" runat="server" Text="Thêm" OnClick="btnThemDatPhong_Click" />
        </div>
    </div>
    <div class="form-group">
    <div class="col-sm-12">
        <asp:SqlDataSource ID="SqlDatPhong" runat="server" ConnectionString="<%$ ConnectionStrings:datphongkhachsanketnoisql %>"
            SelectCommand="SELECT IDDP, EmailKH, SoPhong, NgayNhanPhong, NgayTraPhong, SoLuongKhach, TongTien, NgayDatPhong, TrangThai FROM DatPhong, KhachHang, Phong WHERE DatPhong.IDKH = KhachHang.IDKH AND DatPhong.IDPhong = Phong.IDPhong"
            UpdateCommand="UPDATE DatPhong SET NgayNhanPhong = CONVERT(DATETIME, @NgayNhanPhong, 103), NgayTraPhong = CONVERT(DATETIME, @NgayTraPhong, 103), SoLuongKhach = @SoLuongKhach, TongTien = @TongTien, NgayDatPhong = CONVERT(DATETIME, @NgayDatPhong, 103), TrangThai = @TrangThai WHERE IDDP = @IDDP"
            DeleteCommand="DELETE FROM DatPhong WHERE IDDP = @IDDP">
        </asp:SqlDataSource>
        <asp:GridView ID="gvDatPhong" runat="server" DataKeyNames="IDDP" DataSourceID="SqlDatPhong" AllowDeleting="True" AllowPaging="True" Width="100%" class="gvdatphong" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" GridLines="Horizontal" OnRowEditing="gvDatPhong_RowEditing">
            <Columns>
                <asp:BoundField DataField="IDDP" HeaderText="STT" ReadOnly="True" SortExpression="IDDP" />
                <asp:BoundField DataField="EmailKH" HeaderText="Khách hàng" SortExpression="EmailKH" />
                <asp:BoundField DataField="SoPhong" HeaderText="Phòng" SortExpression="SoPhong" />
                <asp:BoundField DataField="NgayNhanPhong" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày nhận" SortExpression="NgayNhanPhong" />
                <asp:BoundField DataField="NgayTraPhong" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày trả" SortExpression="NgayTraPhong" />
                <asp:BoundField DataField="SoLuongKhach" HeaderText="Số lượng khách" SortExpression="SoLuongKhach" />
                <asp:BoundField DataField="TongTien" HeaderText="Tổng tiền" SortExpression="TongTien" />
                <asp:BoundField DataField="NgayDatPhong" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày đặt" SortExpression="NgayDatPhong" />
                <asp:BoundField DataField="TrangThai" HeaderText="Trạng thái" SortExpression="TrangThai" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkCapNhat" runat="server" CausesValidation="True" CommandName="Update" Text="Cập nhật"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkHuy" runat="server" CausesValidation="False" CommandName="Cancel" Text="Hủy"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkSua" runat="server" CausesValidation="False" CommandName="Edit" Text="Sửa"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkChon" runat="server" CausesValidation="False" CommandName="Select" Text="Chọn"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkXoa" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa bản ghi này không?');" Text="Xóa"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#CCCCCC" />
            <SortedDescendingHeaderStyle Font-Bold="True" Font-Overline="False" ForeColor="Silver" />
        </asp:GridView>
    </div>
    </div>
</asp:Content>
