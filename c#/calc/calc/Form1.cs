using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_jian_Click(object sender, EventArgs e)
        {

        }

        private void button_jia_Click(object sender, EventArgs e)
        {

        }

        private void button_c_Click(object sender, EventArgs e)
        {
            textBox_Show.Text = "0";
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            Numclick("7");
        }
        private void Numclick(string num)
        {
            if ("0" == textBox_Show.Text)
            {
                textBox_Show.Text = num;
            }
            else
            {
                textBox_Show.Text = textBox_Show.Text + num;
            }
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            Numclick("8");
        }
    }
}
