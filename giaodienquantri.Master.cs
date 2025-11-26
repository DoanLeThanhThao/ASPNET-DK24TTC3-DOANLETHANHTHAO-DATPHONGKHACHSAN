using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_dk24ttc3_doanlethanhthao_datphongkhachsan
{
    public partial class giaodienquantri : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tk"] == null)
            {
                Response.Redirect("/DangNhap.aspx");
            }
        }
    }
}