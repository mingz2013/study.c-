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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            Form_create form_create = new Form_create();
            form_create.Show();
        }

        private void button_join_Click(object sender, EventArgs e)
        {
           // Form_join form_join = new Form_join();
            //form_join.Show();


            //客户端对象
            TcpClient client = null;
            //记录服务端ip和端口
            string[] args;
            string strHost = args[0];
            ushort uiPort = Convert.ToUInt16(args[1]);
            String command;
            //生成通信指令字符串



            


        }
    }
}
