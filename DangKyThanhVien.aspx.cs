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
    public partial class DangKyThanhVien : System.Web.UI.Page
    {
        public string TB = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int LayIDKH()
        {

            int IDKH = 100;
            // Kết nối CSDL
            string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Lấy IDKH từ cơ sở dữ liệu
                    string query = "SELECT MAX(IDKH) FROM KhachHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object ketqua = command.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            IDKH = Convert.ToInt32(ketqua) + 1;
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi lấy dữ liệu ID Khách Hàng: {ex.Message}");
                }

            }
            return IDKH;
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                int IDKH = LayIDKH();
                DateTime ngaydangky = DateTime.Now;
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Thêm Khách Hàng
                    string query = "INSERT INTO KhachHang (IDKH, HoKH, TenKH, MatKhau, EmailKH, DienThoaiKH, DiaChiKH, NgayDangKy, KichHoat) VALUES (@IDKH, @HoKH, @TenKH, @MatKhau, @EmailKH, @DienThoaiKH, @DiaChiKH, CONVERT(DATETIME, @NgayDangKy, 103), @KichHoat)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDKH", IDKH);
                        command.Parameters.AddWithValue("@HoKH", txtHoKH.Text);
                        command.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                        command.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        command.Parameters.AddWithValue("@EmailKH", txtEmailKH.Text);
                        command.Parameters.AddWithValue("@DienThoaiKH", txtDienThoaiKH.Text);
                        command.Parameters.AddWithValue("@DiaChiKH", "");
                        command.Parameters.AddWithValue("@NgayDangKy", ngaydangky);
                        command.Parameters.AddWithValue("@KichHoat", 0);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                TB = "<div class=\"alert alert-success fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thành công!</strong> Đăng ký thành viên.</div>";
            }
            catch (Exception ex)
            {
                TB = "<div class=\"alert alert-danger fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thất bại!</strong> Đăng ký thành viên.</div>";
                Console.WriteLine($"Lỗi thêm dữ liệu Khách Hàng: {ex.Message}");
            }
        }
    }
}