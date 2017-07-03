using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class suoyinzhishiqi : System.Web.UI.Page
{
    public class arr // 创建一个类，做容器
    {
        private string[] myarr;// 声明一个字符串数组

        private int szmax; // 这是为重载做的

        public arr(int size)// 利用构造函数初始化数组
        {
            szmax = size;  // 初始化重载的数组长度

            myarr = new string[size];
            for (int i = 0; i < size; i++)
            {
                myarr[i] = "空值";
            }
        }

        // 下面构造索引指示器
        public string this[int j] // j是位置参数，参数类型 是 数组元素的位置，整型的
        {
            get {
                return myarr[j];
            }
            set {
                myarr[j] = value;
            }
        }

        // 下面做索引器重载的例题
        public string this[string val]  // 重载的参数是字符串类型的，用于传入数组值
        {
            get
            {
                int count = 0; // 声明一个整型变量，用于记录当前数组中和传来值相同的个数
                for (int i = 0; i < szmax; i++)
                {
                    if (myarr[i] == val)
                    {
                        count++;
                    }
                }
                return count.ToString();  // 返回 相同元素 的 个数
            }
            set {
                for (int i = 0; i < szmax; i++)
                {
                    if (myarr[i] == val)
                    {
                        myarr[i] = value;
                    }
                }
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        int size = 15;
        arr WRITE = new arr(size);
        WRITE[1] = "mingxi";
        WRITE[2] = "MIngZx";
        WRITE[8] = "qwe";
        for (int i = 0; i < size; i++)
        {
            Response.Write(WRITE[i] + "<br>"); // 打印出每一项的值
        }

        Response.Write("<p>空值的个数：" + WRITE["空值"] + "</p>"); // 空值的个数

        WRITE["空值"] = "抽支烟先"; // 把所有空值改为“抽支烟先”

        for (int i = 0; i < size; i++)
        {
            Response.Write(WRITE[i] + "<br>"); // 打印出每一项的值
        }



    }
}