using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan
{
    public partial class gdqtDatPhongChiTiet : System.Web.UI.Page
    {
        public string TB = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IDDP = Request.QueryString["IDDP"];
                if (IDDP != "")
                {
                    // Cập nhật đặt phòng
                    LayDDLKhachHang_IDDP(IDDP);
                    LayDDLKhachSan_IDDP(IDDP);
                    int IDKS = int.Parse(ddlKhachSan.SelectedValue);
                    LayDDLPhong_IDDP(IDKS, IDDP);
                    LayDDLSoLuongKhach_IDDP(IDDP);
                    LayDDLTrangThai_IDDP(IDDP);
                    LayNgay_TongTien_IDDP(IDDP);
                    TinhTongTien();
                } else
                {
                    // Thêm mới đặt phòng
                    LayDDLKhachHang();
                    LayDDLSoLuongKhach();
                    LayDDLTrangThai();
                    LayDDLKhachSan();
                    int IDKS = int.Parse(ddlKhachSan.SelectedValue);
                    LayDDLPhong(IDKS);
                }
            }
        }

        public int LayIDDP()
        {
            int IDDP = 100;
            // Kết nối CSDL
            string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Lấy IDDP từ cơ sở dữ liệu
                    string query = "SELECT MAX(IDDP) FROM DatPhong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object ketqua = command.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            IDDP = Convert.ToInt32(ketqua) + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi lấy dữ liệu Khách Sạn: {ex.Message}");
                }
                connection.Close();
            }
            return IDDP;
        }

        public void LayNgay_TongTien_IDDP(string IDDP)
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy NgayNhanPhong, NgayTraPhong, NgayDatPhong từ cơ sở dữ liệu
                    string NgayNhanPhong = "";
                    string queryNgayNhanPhong = "SELECT NgayNhanPhong FROM DatPhong WHERE IDDP = @IDDP";
                    using (SqlCommand commandNgayNhanPhong = new SqlCommand(queryNgayNhanPhong, connection))
                    {
                        commandNgayNhanPhong.Parameters.AddWithValue("@IDDP", IDDP);
                        object ketquaNgayNhanPhong = commandNgayNhanPhong.ExecuteScalar();
                        if (ketquaNgayNhanPhong != null && ketquaNgayNhanPhong != DBNull.Value)
                        {
                            NgayNhanPhong = Convert.ToString(ketquaNgayNhanPhong);
                        }
                    }
                    txtNgayNhanPhong.Text = DateTime.Parse(NgayNhanPhong).ToString("yyyy-MM-dd");

                    string NgayTraPhong = "";
                    string queryNgayTraPhong = "SELECT NgayTraPhong FROM DatPhong WHERE IDDP = @IDDP";
                    using (SqlCommand commandNgayTraPhong = new SqlCommand(queryNgayTraPhong, connection))
                    {
                        commandNgayTraPhong.Parameters.AddWithValue("@IDDP", IDDP);
                        object ketquaNgayTraPhong = commandNgayTraPhong.ExecuteScalar();
                        if (ketquaNgayTraPhong != null && ketquaNgayTraPhong != DBNull.Value)
                        {
                            NgayTraPhong = Convert.ToString(ketquaNgayTraPhong);
                        }
                    }
                    txtNgayTraPhong.Text = DateTime.Parse(NgayTraPhong).ToString("yyyy-MM-dd");

                    string NgayDatPhong = "";
                    string queryNgayDatPhong = "SELECT NgayDatPhong FROM DatPhong WHERE IDDP = @IDDP";
                    using (SqlCommand commandNgayDatPhong = new SqlCommand(queryNgayDatPhong, connection))
                    {
                        commandNgayDatPhong.Parameters.AddWithValue("@IDDP", IDDP);
                        object ketquaNgayDatPhong = commandNgayDatPhong.ExecuteScalar();
                        if (ketquaNgayDatPhong != null && ketquaNgayDatPhong != DBNull.Value)
                        {
                            NgayDatPhong = Convert.ToString(ketquaNgayDatPhong);
                        }
                    }
                    txtNgayDatPhong.Text = DateTime.Parse(NgayDatPhong).ToString("yyyy-MM-dd");

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Số Lượng Khách: {ex.Message}");
            }
        }

        public void LayDDLKhachHang()
        {
            // Kết nối CSDL
            string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Lấy DDLKhachHang từ cơ sở dữ liệu
                    string query = "SELECT IDKH, CONCAT_WS(' ', HoKH, TenKH, '-', EmailKH) AS HoTenEmailKH FROM KhachHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ddlKhachHang.Items.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlKhachHang.AppendDataBoundItems = true;
                        ddlKhachHang.DataSource = dt;
                        ddlKhachHang.DataTextField = "HoTenEmailKH";
                        ddlKhachHang.DataValueField = "IDKH";
                        ddlKhachHang.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi lấy dữ liệu Khách Sạn: {ex.Message}");
                }
                connection.Close();
            }
        }

        public void LayDDLKhachHang_IDDP(string IDDP)
        {
            // Kết nối CSDL
            string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Lấy DDLKhachHang từ cơ sở dữ liệu
                    string query = "SELECT DP.IDKH, CONCAT_WS(' ', HoKH, TenKH, '-', EmailKH) AS HoTenEmailKH FROM KhachHang KH, DatPhong DP WHERE KH.IDKH = DP.IDKH AND DP.IDDP = @IDDP";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ddlKhachHang.Items.Clear();
                        command.Parameters.AddWithValue("@IDDP", IDDP);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlKhachHang.AppendDataBoundItems = true;
                        ddlKhachHang.DataSource = dt;
                        ddlKhachHang.DataTextField = "HoTenEmailKH";
                        ddlKhachHang.DataValueField = "IDKH";
                        ddlKhachHang.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi lấy dữ liệu Khách Sạn: {ex.Message}");
                }
                connection.Close();
            }
        }

        public void LayDDLKhachSan()
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Lấy DDLKhachSan từ cơ sở dữ liệu
                    string query = "SELECT IDKS, TenKS FROM KhachSan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ddlKhachSan.Items.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlKhachSan.AppendDataBoundItems = true;
                        ddlKhachSan.DataSource = dt;
                        ddlKhachSan.DataTextField = "TenKS";
                        ddlKhachSan.DataValueField = "IDKS";
                        ddlKhachSan.DataBind();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Phòng: {ex.Message}");
            }
        }

        public void LayDDLKhachSan_IDDP(string IDDP)
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy IDKS từ cơ sở dữ liệu
                    string IDKS = "";
                    string queryIDKS = "SELECT KS.IDKS FROM KhachSan KS, Phong P, DatPhong DP WHERE KS.IDKS = P.IDKS AND P.IDPhong = DP.IDPhong AND DP.IDDP = @IDDP";
                    using (SqlCommand commandIDKS = new SqlCommand(queryIDKS, connection))
                    {
                        commandIDKS.Parameters.AddWithValue("@IDDP", IDDP);
                        object ketqua = commandIDKS.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            IDKS = Convert.ToString(ketqua);
                        }
                    }

                    // Lấy DDLKhachSan từ cơ sở dữ liệu
                    string query = "SELECT IDKS, TenKS FROM KhachSan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ddlKhachSan.Items.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlKhachSan.AppendDataBoundItems = true;
                        ddlKhachSan.DataSource = dt;
                        ddlKhachSan.DataTextField = "TenKS";
                        ddlKhachSan.DataValueField = "IDKS";
                        ddlKhachSan.SelectedValue = IDKS;
                        ddlKhachSan.DataBind();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Phòng: {ex.Message}");
            }
        }

        public void LayDDLPhong(int IDKS)
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Lấy DDLPhong từ cơ sở dữ liệu
                    string query = "SELECT IDPhong, SoPhong FROM Phong WHERE IDKS = @IDKS";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ddlPhong.Items.Clear();
                        command.Parameters.AddWithValue("@IDKS", IDKS);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPhong.AppendDataBoundItems = true;
                        ddlPhong.DataSource = dt;
                        ddlPhong.DataTextField = "SoPhong";
                        ddlPhong.DataValueField = "IDPhong";
                        ddlPhong.DataBind();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Phòng: {ex.Message}");
            }
        }

        public void LayDDLPhong_IDDP(int IDKS, string IDDP)
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy IDPhong từ cơ sở dữ liệu
                    string IDPhong = "";
                    string queryIDPhong = "SELECT P.IDPhong FROM Phong P, DatPhong DP WHERE P.IDPhong = DP.IDPhong AND DP.IDDP = @IDDP";
                    using (SqlCommand commandIDPhong = new SqlCommand(queryIDPhong, connection))
                    {
                        commandIDPhong.Parameters.AddWithValue("@IDDP", IDDP);
                        object ketqua = commandIDPhong.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            IDPhong = Convert.ToString(ketqua);
                        }
                    }

                    // Lấy DDLPhong từ cơ sở dữ liệu
                    string query = "SELECT IDPhong, SoPhong FROM Phong WHERE IDKS = @IDKS";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ddlPhong.Items.Clear();
                        command.Parameters.AddWithValue("@IDKS", IDKS);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlPhong.AppendDataBoundItems = true;
                        ddlPhong.DataSource = dt;
                        ddlPhong.DataTextField = "SoPhong";
                        ddlPhong.DataValueField = "IDPhong";
                        ddlPhong.SelectedValue = IDPhong;
                        ddlPhong.DataBind();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Phòng: {ex.Message}");
            }
        }

        public void LayDDLSoLuongKhach()
        {
            try
            {
                ddlSoLuongKhach.Items.Clear();
                ddlSoLuongKhach.Items.Add(new ListItem("1 Người", "1"));
                ddlSoLuongKhach.Items.Add(new ListItem("2 Người", "2"));
                ddlSoLuongKhach.Items.Add(new ListItem("3 Người", "3"));
                ddlSoLuongKhach.Items.Add(new ListItem("4 Người", "4"));
                ddlSoLuongKhach.Items.Add(new ListItem("5 Người", "5"));
                ddlSoLuongKhach.Items.Add(new ListItem("6 Người", "6"));
                ddlSoLuongKhach.Items.Add(new ListItem("7 Người", "7"));
                ddlSoLuongKhach.Items.Add(new ListItem("8 Người", "8"));
                ddlSoLuongKhach.Items.Add(new ListItem("9 Người", "9"));
                ddlSoLuongKhach.Items.Add(new ListItem("10 Người", "10"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Số Lượng Khách: {ex.Message}");
            }
        }

        public void LayDDLSoLuongKhach_IDDP(string IDDP)
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy SoLuongKhach từ cơ sở dữ liệu
                    string SoLuongKhach = "";
                    string querySoLuongKhach = "SELECT SoLuongKhach FROM DatPhong WHERE IDDP = @IDDP";
                    using (SqlCommand commandSoLuongKhach = new SqlCommand(querySoLuongKhach, connection))
                    {
                        commandSoLuongKhach.Parameters.AddWithValue("@IDDP", IDDP);
                        object ketqua = commandSoLuongKhach.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            SoLuongKhach = Convert.ToString(ketqua);
                        }
                    }

                    ddlSoLuongKhach.Items.Clear();
                    ddlSoLuongKhach.Items.Add(new ListItem("1 Người", "1"));
                    ddlSoLuongKhach.Items.Add(new ListItem("2 Người", "2"));
                    ddlSoLuongKhach.Items.Add(new ListItem("3 Người", "3"));
                    ddlSoLuongKhach.Items.Add(new ListItem("4 Người", "4"));
                    ddlSoLuongKhach.Items.Add(new ListItem("5 Người", "5"));
                    ddlSoLuongKhach.Items.Add(new ListItem("6 Người", "6"));
                    ddlSoLuongKhach.Items.Add(new ListItem("7 Người", "7"));
                    ddlSoLuongKhach.Items.Add(new ListItem("8 Người", "8"));
                    ddlSoLuongKhach.Items.Add(new ListItem("9 Người", "9"));
                    ddlSoLuongKhach.Items.Add(new ListItem("10 Người", "10"));
                    ddlSoLuongKhach.SelectedValue = SoLuongKhach;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Số Lượng Khách: {ex.Message}");
            }
        }

        public void LayDDLTrangThai()
        {
            try
            {
                ddlTrangThai.Items.Clear();
                ddlTrangThai.Items.Add(new ListItem("Đang chờ", "Đang chờ"));
                ddlTrangThai.Items.Add(new ListItem("Đã xác nhận", "Đã xác nhận"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Trạng Thái: {ex.Message}");
            }
        }

        public void LayDDLTrangThai_IDDP(string IDDP)
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy TrangThai từ cơ sở dữ liệu
                    string TrangThai = "";
                    string queryTrangThai = "SELECT TrangThai FROM DatPhong WHERE IDDP = @IDDP";
                    using (SqlCommand commandTrangThai = new SqlCommand(queryTrangThai, connection))
                    {
                        commandTrangThai.Parameters.AddWithValue("@IDDP", IDDP);
                        object ketqua = commandTrangThai.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            TrangThai = Convert.ToString(ketqua);
                        }
                    }

                    ddlTrangThai.Items.Clear();
                    ddlTrangThai.Items.Add(new ListItem("Đang chờ", "Đang chờ"));
                    ddlTrangThai.Items.Add(new ListItem("Đã xác nhận", "Đã xác nhận"));
                    ddlTrangThai.SelectedValue = TrangThai;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Trạng Thái: {ex.Message}");
            }
        }

        public decimal LayGiaPhong()
        {
            decimal giaphong = 100;
            // Kết nối CSDL
            string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Lấy Giá từ cơ sở dữ liệu
                    string query = "SELECT Gia FROM Phong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object ketqua = command.ExecuteScalar();
                        if (ketqua != null && ketqua != DBNull.Value)
                        {
                            giaphong = Convert.ToDecimal(ketqua);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi lấy Giá Phòng: {ex.Message}");
                }
                connection.Close();
            }
            return giaphong;
        }

        public void TinhTongTien()
        {
            string strngaynhan = txtNgayNhanPhong.Text;
            string strngaytra = txtNgayTraPhong.Text;
            DateTime ngaynhan;
            DateTime ngaytra;
            DateTime.TryParseExact(strngaynhan, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaynhan);
            DateTime.TryParseExact(strngaytra, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaytra);
            if (ngaynhan <= ngaytra)
            {
                TimeSpan songay = ngaytra.Subtract(ngaynhan);
                int ngaythucte = songay.Days;
                decimal tongtien = LayGiaPhong() * ngaythucte;
                txtTongTien.Text = tongtien.ToString();
            }
            else
            {
                TB = "<div class=\"alert alert-danger fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Ngày trả phòng!</strong> Phải lớn hơn Ngày nhận phòng.</div>";
            }
        }

        protected void btnLuuDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                string CapNhatIDDP = Request.QueryString["IDDP"];
                if (CapNhatIDDP != "")
                {
                    TinhTongTien();
                    // Kết nối CSDL
                    string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        // Cập nhật Đặt phòng
                        string query = "UPDATE DatPhong SET IDKH = @IDKH, IDPhong = @IDPhong, NgayNhanPhong = @NgayNhanPhong, NgayTraPhong = @NgayTraPhong, SoLuongKhach = @SoLuongKhach, TongTien = @TongTien, NgayDatPhong = @NgayDatPhong, TrangThai = @TrangThai WHERE IDDP = @IDDP";
                        
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDDP", CapNhatIDDP);
                            command.Parameters.AddWithValue("@IDKH", ddlKhachHang.SelectedValue);
                            command.Parameters.AddWithValue("@IDPhong", ddlPhong.SelectedValue);
                            command.Parameters.AddWithValue("@NgayNhanPhong", txtNgayNhanPhong.Text);
                            command.Parameters.AddWithValue("@NgayTraPhong", txtNgayTraPhong.Text);
                            command.Parameters.AddWithValue("@SoLuongKhach", ddlSoLuongKhach.SelectedValue);
                            command.Parameters.AddWithValue("@TongTien", txtTongTien.Text);
                            command.Parameters.AddWithValue("@NgayDatPhong", txtNgayDatPhong.Text);
                            command.Parameters.AddWithValue("@TrangThai", ddlTrangThai.SelectedValue);
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }

                    TB = "<div class=\"alert alert-success fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thành công!</strong> Cập nhật đặt phòng.</div>";
                } else
                {
                    TinhTongTien();
                    int IDDP = LayIDDP();
                    // Kết nối CSDL
                    string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        // Thêm Đặt phòng
                        string query = "INSERT INTO DatPhong (IDDP, IDKH, IDPhong, NgayNhanPhong, NgayTraPhong, SoLuongKhach, TongTien, NgayDatPhong, TrangThai) VALUES (@IDDP, @IDKH, @IDPhong, @NgayNhanPhong, @NgayTraPhong, @SoLuongKhach, @TongTien, @NgayDatPhong, @TrangThai)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDDP", IDDP);
                            command.Parameters.AddWithValue("@IDKH", ddlKhachHang.SelectedValue);
                            command.Parameters.AddWithValue("@IDPhong", ddlPhong.SelectedValue);
                            command.Parameters.AddWithValue("@NgayNhanPhong", txtNgayNhanPhong.Text);
                            command.Parameters.AddWithValue("@NgayTraPhong", txtNgayTraPhong.Text);
                            command.Parameters.AddWithValue("@SoLuongKhach", ddlSoLuongKhach.SelectedValue);
                            command.Parameters.AddWithValue("@TongTien", txtTongTien.Text);
                            command.Parameters.AddWithValue("@NgayDatPhong", txtNgayDatPhong.Text);
                            command.Parameters.AddWithValue("@TrangThai", ddlTrangThai.SelectedValue);
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }

                    TB = "<div class=\"alert alert-success fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thành công!</strong> Đặt thêm phòng.</div>";
                }
                
            }
            catch (Exception ex)
            {
                TB = "<div class=\"alert alert-danger fade in alert-dismissible\" style=\"margin-top:18px;\"><a href = \"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\" title=\"close\">×</a><strong>Thất bại!</strong> Đặt thêm phòng.</div>";
                Console.WriteLine($"Lỗi lấy Tổng Tiền: {ex.Message}");
            }
        }

        protected void btnTroVeDatPhong_Click(object sender, EventArgs e)
        {
            Response.Redirect("/gdqtDatPhong.aspx");
        }

        protected void btnXemTongTien_Click(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        protected void ddlKhachSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDKS = int.Parse(ddlKhachSan.SelectedValue);
            LayDDLPhong(IDKS);
        }
    }
}