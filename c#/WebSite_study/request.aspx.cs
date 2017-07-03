using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class request : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //get方式
        //string name = Request.QueryString["name"];  
        //string age = Request.QueryString["age"];
        //Response.Write(name + "<br>" + age + "<br>");

        //post方式
        string aa = Request.Form["name"];
        string bb = Request.Form["age"];
        Response.Write(aa + "<br>" + bb + "<br>");

        // 两种方式
        //Request.Params["name"];
        //Request.Params["age"];

        //Request["name"];
        //Request["age"];

        Response.Write("您使用的是" + Request.RequestType + "方式传送数据<br>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<br>当前网页虚拟路径是：" + Request.ServerVariables["url"]);
        Response.Write("<br>当前网页虚拟路径是：" + Request.RawUrl);
        Response.Write("<br>实际路径：" + Request.ServerVariables["path_translated"]);
        Response.Write("<br>实际路径：" + Request.PhysicalPath);
        Response.Write("<br>服务器名：" + Request.ServerVariables["server_name"]);
        Response.Write("<br>服务器IP: " + Request.UserHostAddress);


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<br>这个浏览器是否支持背景音乐：" + Request.Browser.BackgroundSounds);
        Response.Write("<br>这个浏览器是否支持框架:" + Request.Browser.Frames);
        Response.Write("<br>客户用的系统：" + Request.Browser.Platform);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        HttpCookie nc = new HttpCookie("newcookie");
        nc.Values["name"] = "明子";
        nc.Values["age"] = "23";
        nc.Values["dt"] = DateTime.Now.ToString();
        Response.Cookies.Add(nc);
        Response.Write("<br>cookies写入成功<br>");

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        HttpCookie getcookie = Request.Cookies["newcookie"];
        Response.Write("<br>" + getcookie.Values["name"]);
        Response.Write("<br>" + getcookie.Values["age"]);
        Response.Write("<br>" + getcookie.Values["dt"]);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}