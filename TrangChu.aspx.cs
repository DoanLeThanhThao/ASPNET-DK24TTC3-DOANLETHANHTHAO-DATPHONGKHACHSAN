using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan
{
    public partial class TrangChu : System.Web.UI.Page
    {
        public string TB = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDDLTinhThanh();
                LayDDLSoLuongKhach();
                LayDLKhachSan();
            }
        }

        public void LayDDLTinhThanh()
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Lấy ddlTinhThanh
                    string query = "SELECT DISTINCT TinhThanh FROM KhachSan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        ddlTinhThanh.Items.Clear();
                        ddlTinhThanh.Items.Add(new ListItem("-- Chọn Tỉnh thành --", ""));
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlTinhThanh.AppendDataBoundItems = true;
                        ddlTinhThanh.DataSource = dt;
                        ddlTinhThanh.DataTextField = "TinhThanh";
                        ddlTinhThanh.DataValueField = "TinhThanh";
                        ddlTinhThanh.DataBind();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Tỉnh Thành: {ex.Message}");
            }
        }

        public void LayDDLSoLuongKhach()
        {
            try
            {
                // Tạo ddlSoLuongKhach
                ddlSoLuongKhach.Items.Clear();
                ddlSoLuongKhach.Items.Add(new ListItem("-- Chọn Số khách --", "0"));
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

        public void LayDLKhachSan()
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Lấy ddlKhachSan
                    string query = "SELECT IDKS, TenKS, EmailKS, DienThoaiKS, DiaChiKS, TinhThanh, MoTaKS, HinhAnhKS, XepHang FROM KhachSan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dlKhachSan.DataSource = dt;
                        dlKhachSan.DataBind();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Khách Sạn: {ex.Message}");
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối CSDL
                string connectionString = ConfigurationManager.ConnectionStrings["datphongkhachsanketnoisql"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    StringBuilder queryBuilder = new StringBuilder("SELECT KS.IDKS, KS.TenKS, KS.EmailKS, KS.DienThoaiKS, KS.DiaChiKS, KS.TinhThanh, KS.MoTaKS, KS.HinhAnhKS, KS.XepHang FROM KhachSan KS INNER JOIN Phong P ON KS.IDKS = P.IDKS INNER JOIN DatPhong DP ON P.IDPhong = DP.IDPhong WHERE 1=1");
                    List<string> conditions = new List<string>();
                    
                    string NgayNhanPhong = txtNgayNhanPhong.Text;
                    if (NgayNhanPhong != "")
                    {
                        conditions.Add("DP.NgayNhanPhong = @NgayNhanPhong");
                    }
                    int SoLuongKhach = int.Parse(ddlSoLuongKhach.SelectedValue);
                    if (SoLuongKhach > 0)
                    {
                        conditions.Add("DP.SoLuongKhach = @SoLuongKhach");
                    }
                    string TinhThanh = ddlTinhThanh.SelectedItem.ToString();
                    if (TinhThanh != "")
                    {
                        conditions.Add("KS.TinhThanh = @TinhThanh");
                    }
                    if (conditions.Count > 0)
                    {
                        queryBuilder.Append(" AND ");
                        queryBuilder.Append(string.Join(" AND ", conditions));
                    }
                    string query = queryBuilder.ToString();
                    TB = query;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (NgayNhanPhong != "")
                        {
                            command.Parameters.AddWithValue("@NgayNhanPhong", NgayNhanPhong);
                        }
                        if (SoLuongKhach > 0)
                        {
                            command.Parameters.AddWithValue("@SoLuongKhach", SoLuongKhach);
                        }
                        if (TinhThanh != "")
                        {
                            command.Parameters.AddWithValue("@TinhThanh", TinhThanh);
                        }
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dlKhachSan.DataSource = dt;
                        dlKhachSan.DataBind();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Khách Sạn theo điều kiện: {ex.Message}");
            }
        }

        protected void dlKhachSan_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DatPhongKhachSan")
            {
                string IDKS = dlKhachSan.DataKeys[e.Item.ItemIndex].ToString();
                Response.Redirect("/DatPhong.aspx?IDKS=" + IDKS);
            }
        }
    }
}