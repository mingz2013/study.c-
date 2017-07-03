using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace form_02_httpPrc
{
    public partial class Form1 : Form
    {
        WebClient client = new WebClient();
        HttpMethod http = new HttpMethod();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String html = client.OpenRead("http://www.baidu.com");
            webBrowser1.DocumentText = html;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CookieContainer cc=new CookieContainer();
            
            //cc.Add(new System.Uri("http://www.baidu.com "), new Cookie("PHPSESSID", "xx"));

            string content = http.SendDataByGET("http://www.baidu.com", "", "http://www.baidu.com");

            webBrowser1.DocumentText = content;
            
            //http.SendDataByGET("http://www.baidu.com", "", 
        }
    }
}
