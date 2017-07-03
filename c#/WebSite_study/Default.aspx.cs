using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 编码 解码
        Response.Write(Server.HtmlDecode(Server.HtmlEncode("<script>alert('弹出一个对话框')</script>;")));

        string aa = Server.MapPath("~/XMLFile.xml").ToString();// 实际路径 转成 虚拟路径
        Response.WriteFile(aa);

    }
}