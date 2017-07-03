using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageshijian : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)// 初始化.页面加载前
    {
        DropDownList1.Items.Add("aaaaaa");
        DropDownList1.Items.Add("bbbbbbbb");
 
    }
    protected void Page_Load(object sender, EventArgs e)// 页面加载时
    {
        if (!IsPostBack)// 首次加载
        {
            DropDownList1.Items.Add("aaaaaa");
            DropDownList1.Items.Add("bbbbbbbb");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DropDownList1.Items.Add(TextBox1.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("click 是老大<br>");
    }
    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        Response.Write("command 是老大<br>");
        
    }
   
}

      

