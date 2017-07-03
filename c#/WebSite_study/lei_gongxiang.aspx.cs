using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lei_gongxiang : System.Web.UI.Page
{
    public class User
    {
        private static int count;// 统计有多少个对象
        private static string name;// 定义每个对象的用户名字

        public User()// 默认构造函数，只做简单的累加
        {
            count++;
        }

        static User()// 静态构造函数，主要用于初始化静态变量的值，这里还可以对静态变量做绑定检查和有效性检查
        {
            count = 0;
            name = "初始值";
        }

        public string Name// 姓名属性外漏
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        public static string OneName // 做一个静态的属性，没什么用，只是为了显示初始值
        {
            get
            {
                return name;
            }
        }
        public static int Count // 做一个静态的属性
        {
            get 
            {
                return count;// read
            }
        }
        public static string Mn(string nname)// 一个静态方法，把传进来的值加工后再返回出去
        {
            return "个对象，共享方法后的结果是：" + nname;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("目前是：" + User.Count + "个对象，初始名字是：" + User.OneName);

        User u1 = new User();
        u1.Name = "明子1";
        Response.Write("<br>目前这是：" + User.Count + User.Mn(u1.Name));

        User u2 = new User();
        u2.Name = "明子2";
        Response.Write("<br>目前这是：" + User.Count + User.Mn(u2.Name));

        User u3 = new User();
        u3.Name = "明子3";
        Response.Write("<br>目前这是：" + User.Count + User.Mn(u3.Name));




    }
}