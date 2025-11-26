using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan
{
    public partial class gdqtDatPhong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (gvDatPhong != null)
                {
                    if (gvDatPhong.Columns.Count > 0)
                    {
                        gvDatPhong.Columns[0].HeaderText = "STT";
                        gvDatPhong.Columns[1].HeaderText = "Khách hàng";
                        gvDatPhong.Columns[2].HeaderText = "Phòng";
                        gvDatPhong.Columns[3].HeaderText = "Ngày nhận";
                        gvDatPhong.Columns[4].HeaderText = "Ngày trả";
                        gvDatPhong.Columns[5].HeaderText = "Số lượng khách";
                        gvDatPhong.Columns[6].HeaderText = "Tổng tiền";
                        gvDatPhong.Columns[7].HeaderText = "Ngày đặt";
                        gvDatPhong.Columns[8].HeaderText = "Trạng thái";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dữ liệu Khách Sạn: {ex.Message}");
            }
        }

        protected void btnThemDatPhong_Click(object sender, EventArgs e)
        {
            Response.Redirect("/gdqtDatPhongChiTiet.aspx");
        }

        protected void gvDatPhong_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("/gdqtDatPhongChiTiet.aspx?IDDP=" + gvDatPhong.DataKeys[e.NewEditIndex].Value);
        }
    }
}