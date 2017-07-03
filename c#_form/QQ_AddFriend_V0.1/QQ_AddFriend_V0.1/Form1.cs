using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;

namespace QQ_AddFriend_V0._1
{
    public partial class Form1 : Form
    {
        private delegate void FlushClient();//代理
        private InitForm masterForm;
        private string need_add_QQ = "";
        private string[] strArray;
        private Thread thread;

        public InitForm MasterForm { set { masterForm = value; } }

        public Form1()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(CrossThreadFlush));
        }

        private void setLog(string Msg)
        {
            textBox_Show.AppendText(Msg + "\n");
            Debug.WriteLine(Msg);
            
        }

        // 刷新线程
        private void CrossThreadFlush()
        {
            FlushClient fc = delegate()
            {
                threadfunc();
            };
            this.listView_QQ_List.Invoke(fc);
            this.textBox_Show.Invoke(fc);
        }
        private void threadfunc()
        {
            int sucessnumber = 0;
            for (int i = 0; i != listView_QQ_List.Items.Count; i++)
            {
                listView_QQ_List.Items[i].SubItems[3].Text = "执行中...";
                Debug.WriteLine("QQ号：" + listView_QQ_List.Items[i].SubItems[1].Text + "   密码：" + listView_QQ_List.Items[i].SubItems[2].Text);
                if (!Qzone_Login_AddFriend(listView_QQ_List.Items[i].SubItems[1].Text, listView_QQ_List.Items[i].SubItems[2].Text))
                {
                    listView_QQ_List.Items[i].SubItems[3].Text = "失败...";
                    continue;
                }
                sucessnumber++;
                listView_QQ_List.Items[i].SubItems[3].Text = "成功...";
                setLog("成功个数：" + sucessnumber);
                Thread.Sleep(1000);
            }
            setLog("成功个数：" + sucessnumber);
 
        }
        // 空间登陆 和 加好友
        private bool Qzone_Login_AddFriend(string qqNumber, string Pwd) 
        {
            Qzone qzone = new Qzone();
            
            if (!qzone.get_Ui_Login()) { setLog("网络不好..."); return false; }
            qzone.QQNumber = qqNumber;
            
            if (qzone.get_Check()){ setLog("需要验证码..."); return false; }
            qzone.Pwd = Pwd;
            if (!qzone.get_Login()) { setLog("登陆失败..."); return false; }
            if (!qzone.get_Friend_Authfriend(need_add_QQ)) { setLog("加好友失败..."); return false; }
            setLog("加好友成功");

            return true;
        }
        private void button_open_Click(object sender, EventArgs e)
        {
            this.openFileDialog_QQList.Filter = "*.txt|*.txt|所有文件(*.*)|*.*";
            if (this.openFileDialog_QQList.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    setLog("导入中，请稍后...");
                    string Name = this.openFileDialog_QQList.FileName;
                    this.textBox_FileName.Text = Name;
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
                        listView_QQ_List.Items.Add(it);
                        listView_QQ_List.Items[listView_QQ_List.Items.Count - 1].EnsureVisible();// 最后一行一直可见
                    }
                    //listView_COOKIE_List.EndUpdate();
                    setLog("导入完毕...");
                }
                catch (Exception ee) { System.Diagnostics.Debug.WriteLine(ee.ToString()); }
            }
        }

        private void button_begin_Click(object sender, EventArgs e)
        {
            if (need_add_QQ == "") { setLog("请输入被加的QQ..."); return; }
            thread.Start();

        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }

        private void textBox_QQ_Need_Add_Leave(object sender, EventArgs e)
        {
            textBox_QQ_Need_Add.Text = textBox_QQ_Need_Add.Text.Trim();
            need_add_QQ = textBox_QQ_Need_Add.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            setLog("终止poll2线程...");
            thread.Abort();// 终止线程

            

            this.masterForm.Show();
            this.Dispose();
        }
    }
}
