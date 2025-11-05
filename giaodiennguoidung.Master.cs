using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan
{
    public partial class giaodiennguoidung : System.Web.UI.MasterPage
    {
        public string TB = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TB = "<li><a href=\"/DangKyThanhVien.aspx\"><span class=\"glyphicon glyphicon-user\"></span> Đăng ký</a></li><li><a href=\"/DangNhap.aspx\"><span class=\"glyphicon glyphicon-log-in\"></span> Đăng nhập</a></li>";
            if (!IsPostBack)
            {
                if (Session["tk"] != null)
                {
                    TB = "";
                    string tk = Session["tk"].ToString();
                    string url = Request.Url.LocalPath;
                    TB += "<li><a href=\"" + url + "#\"><span class=\"glyphicon glyphicon-user\"></span> " + tk + "</a></li>";
                    TB += "<li><a href=\"/DangXuat.aspx\"><span class=\"glyphicon glyphicon-log-out\"></span> Đăng xuất</a></li>";
                }
            }
        }
    }
}