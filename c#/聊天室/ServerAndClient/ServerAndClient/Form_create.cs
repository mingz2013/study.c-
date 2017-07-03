using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net.Sockets;


namespace ServerAndClient
{
    public partial class Form_create : Form
    {
        public Form_create()
        {
            InitializeComponent();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            //监听端口10000
            TcpListener listener;
            try
            {
                listener = new TcpListener(10000);
            }
            catch
            {
                //弹出窗口，提示失败？？？？？？？？？
                return;
            }
            //开始监听
            listener.Start();


        }
    }
}
