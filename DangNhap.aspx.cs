using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan
{
    public partial class DangNhap : System.Web.UI.Page
    {
        public string TB = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void KTDangNhap(string taikhoan, string matkhau)
        {
            // Kết nối CSDL
            string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM KhachHang WHERE EmailKH = @EmailKH AND MatKhau = @MatKhau";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmailKH", taikhoan);
                    command.Parameters.AddWithValue("@MatKhau", matkhau);
                    int count = (int)command.ExecuteScalar();
                    try
                    {
                        if (count > 0)
                        {
                            TB = "<div class=\"alert alert-success fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thành công!</strong> Đăng nhập.</div>";
                            Session["tk"] = taikhoan;
                            Response.Redirect("/TrangChu.aspx");
                        }
                        else
                        {
                            TB = "<div class=\"alert alert-danger fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thất bại!</strong> Đăng nhập.</div>";
                        }
                    }
                    catch (Exception)
                    {
                        TB = "<div class=\"alert alert-warning fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Lưu ý!</strong> Phát hiện lỗi đăng nhập.</div>";
                    }
                }
                connection.Close();
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string taikhoan = txtEmailKH.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();
                if (string.IsNullOrEmpty(taikhoan) || string.IsNullOrEmpty(matkhau))
                {
                    TB = "<div class=\"alert alert-warning fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thông báo!</strong> Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.</div>";
                }
                //string mhmatkhau = MHMatKhau(matkhau);
                KTDangNhap(taikhoan, matkhau);

            }
            catch (Exception)
            {
                TB = "<div class=\"alert alert-danger fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thất bại!</strong> Đăng ký thành viên.</div>";
            }
        }
    }
}