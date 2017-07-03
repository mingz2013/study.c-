using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Consum_System
{
    public partial class Form_Index : Form
    {
        public Form_Index()
        {
            InitializeComponent();
        }

        private void linkLabel_Nick_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_UserInfo userInfo_Form = new Form_UserInfo();
            userInfo_Form.Show();
        }

        private void linkLabel_Login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Login login_Form = new Form_Login();
            login_Form.Show();
        }

        private void linkLabel_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Register register_Form = new Form_Register();
            register_Form.Show();
        }

        private void linkLabel_Goods_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_GoodsInfo goodsInfo_Form = new Form_GoodsInfo();
            goodsInfo_Form.Show();
        }

       

    
       

        

      

       

       
    }
}
