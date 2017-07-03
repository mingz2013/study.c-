using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace setProxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "*.txt|*.txt|所有文件(*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    setLog("导入中，请稍后...");
                    string Name = this.openFileDialog1.FileName;
                    
                    string content = Proxy.readFile(Name);

                    string[] strArray = content.Split('\n');
                    //listView_COOKIE_List.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                    for (int i = 0; i != strArray.Length; i++)
                    {
                        string[] str = System.Text.RegularExpressions.Regex.Split(strArray[i], "----", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        ListViewItem it = new ListViewItem(i.ToString());
                        //it.SubItems.Add(i.ToString());
                        it.SubItems.Add(str[0]);
                        it.SubItems.Add(str[1]);
                        it.SubItems.Add("未验证...");
                        listView_Proxy.Items.Add(it);
                        listView_Proxy.Items[listView_Proxy.Items.Count - 1].EnsureVisible();// 最后一行一直可见
                    }
                    //listView_COOKIE_List.EndUpdate();
                    setLog("导入完毕...");
                }
                catch (Exception ee) { System.Diagnostics.Debug.WriteLine(ee.ToString()); }
            }
        }

        private void setLog(string Msg)
        {
            textBox_Show.AppendText(Msg + "\n");
            Debug.WriteLine("log:" + Msg);
        }

        private void button_CheckProxy_Click(object sender, EventArgs e)
        {

        }
    }
}
