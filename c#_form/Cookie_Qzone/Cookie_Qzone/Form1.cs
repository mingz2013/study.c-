using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cookie_Qzone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setLog(string Msg)
        {
            Debug.WriteLine(Msg);

            textBox_ShowLog.AppendText(Msg + "\n");

        }

        private void button_OpenCookies_Click(object sender, EventArgs e)
        {
            this.openFileDialog_Cookie.Filter = "*.txt|*.txt|所有文件(*.*)|*.*";
            string[] strArray;
            if (this.openFileDialog_Cookie.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    setLog("导入中，请稍后...");
                    string Name = this.openFileDialog_Cookie.FileName;
                    //textBox_FileName.Text = Name;
                    string content = Tools.readFile(Name);

                    strArray = content.Split('\n');
                    //listView_COOKIE_List.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                    for (int i = 0; i != strArray.Length; i++)
                    {
                        string[] str = System.Text.RegularExpressions.Regex.Split(strArray[i], "----", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        ListViewItem it = new ListViewItem(i.ToString());
                        //it.SubItems.Add(i.ToString());
                        it.SubItems.Add(str[0]);
                        it.SubItems.Add(str[1]);
                        it.SubItems.Add("未使用...");
                        listView_QQList.Items.Add(it);
                        listView_QQList.Items[listView_QQList.Items.Count - 1].EnsureVisible();// 最后一行一直可见
                    }
                    //listView_COOKIE_List.EndUpdate();
                    setLog("导入完毕...");
                }
                catch (Exception ee) { setLog("导入出错..."); Debug.WriteLine(ee.ToString()); }
            }
        }

        private void button_Begin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i != listView_QQList.Items.Count; i++)
            {
                bool success = Qzone.post_emotion_cgi_publish_v6(listView_QQList.Items[1].Text, listView_QQList.Items[2].Text, textBox_Content.Text);
                if (success) { setLog("成功..."); listView_QQList.Items[3].Text = "成功..."; }
                else { setLog("失败..."); listView_QQList.Items[3].Text = "失败...";}
            }
        }
        

        
    }
}
