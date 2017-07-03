using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QQ_AddFriend_V0._1
{
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            
            
            f.MasterForm = this;
            TimeSpan ts = DateTime.UtcNow - new DateTime(2013, 10, 7, 0, 0, 0, 0);
            long l = Convert.ToInt64(ts.TotalSeconds);
            if (l < 0)
            {
                textBox1.AppendText("****************************************\n");
                textBox1.AppendText("载入中,请稍等...\n");
                f.Show();
                this.Hide();
                //this.Dispose();
            }
            else 
            {
                textBox1.AppendText("****************************************\n");
                textBox1.AppendText("试用期结束，请购买正版软件...\n");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
            textBox1.AppendText("****************************************\n");
            textBox1.AppendText("作者：明子\n");
            textBox1.AppendText(" Q Q：xxx\n");
            textBox1.AppendText("说明：此为试用版...\n");
        }
    }
}
