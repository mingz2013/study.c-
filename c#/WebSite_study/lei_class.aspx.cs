using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lei_class : System.Web.UI.Page
{
    public class book
    {// 定义书类

        // 定义三个私有变量
        string title;// 标题
        int num;// 库存
        double price;// 价格

        public delegate void TitleChengHendler();//事先声明一个委托，也可以在类的外部声明委托类型
        public event TitleChengHendler TitleCheng;//声明一个事件，并指定它的委托类型


        // 定义两个函数
        public book()
        {
        }

        public book(string ntitle, int nnum, double nprice)
        {
            title = ntitle;
            num = nnum;
            price = nprice;
        }

        //定义三个可读可写的属性
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                TitleCheng();// 通过这里修改了这个标题，就会触发这个事件
            }
        }
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        // 一个方法
        public string BookInfo()
        {
            string Html = "书名是：" + title + "<br>库存：" + num + "本<br>价格是：" + price + "元/本";
            return Html;

        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        book shu = new book();
        shu.TitleCheng += new book.TitleChengHendler(shu_TitleCheng);
        
        shu.Title = "mingxi";
        shu.Num = 30;
        shu.Price = 12.3;

        Response.Write(shu.BookInfo());

    }
    void shu_TitleCheng()
    {
        Response.Write("事件执行了<br>");
    }
}