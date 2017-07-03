using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        Test Test=new Test();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test Test;
            Test.getx(2);

            Test.gety(2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int text = Test.readd();
           textBox1.Text = text.ToString();



        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
    public class Test
    {
        int x;
        int y;
        public int readd()
        {
            return x + y;

        }
        public void getx(int a)
        {
            x = a;

        }
        public void gety(int b)
        {
            y = b;
        }
    }
}
