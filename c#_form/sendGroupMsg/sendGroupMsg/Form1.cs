using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace sendGroupMsg
{
    public partial class Form1 : Form
    {
        private delegate void FlushClient();//代理

        private InitForm masterForm;
        private WebQQ webQQ;
        Thread poll2thread;
        Thread sendMsgthread;

        public InitForm MasterForm
        { set { masterForm = value; } }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webQQ = new WebQQ();

            poll2thread = new Thread(poll2ThreadFunc);
            poll2thread.IsBackground = true;
            sendMsgthread = new Thread(sendMsgtoAllGroupFunc);
            sendMsgthread.IsBackground = true;
        }
        private void setLog(string Msg)
        {
            textBox_Log.AppendText(Msg + "\n");
            Debug.WriteLine(Msg);
        }
        private void textBox_QQNumber_Leave(object sender, EventArgs e)
        {
            textBox_QQNumber.Text = textBox_QQNumber.Text.Trim();
            if (webQQ.QQNumber == textBox_QQNumber.Text) { setLog("QQ号没有改变"); return; }// qq号没有改变
            webQQ.QQNumber = textBox_QQNumber.Text;
            if (!webQQ.getCheck()) { setLog("QQ号有误..."); return; }
            if (webQQ.TextCode.Length == 4)
            {
                setLog("不需要验证码...");
                return;
            }
            setLog("需要输入验证码...");
            setLog("正在获取验证码图片...");
            Image image = webQQ.getImage();
            pictureBox_verifycode.Image = image;

        }

        private void pictureBox_verifycode_Click(object sender, EventArgs e)
        {
            setLog("正在获取验证码图片...");
            Image image = webQQ.getImage();
            pictureBox_verifycode.Image = image;
            setLog("已获取验证码图片...");
        }

        private void linkLabel_verify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLog("正在获取验证码图片...");
            Image image = webQQ.getImage();
            pictureBox_verifycode.Image = image;
            setLog("已获取验证码图片...");
        }

        private void textBox_Pwd_Leave(object sender, EventArgs e)
        {
            webQQ.Pwd = textBox_Pwd.Text;
        }

        private void textBox_verifycode_Leave(object sender, EventArgs e)
        {
            webQQ.TextCode_Write = textBox_verifycode.Text;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // login
            setLog("登录中...");
            if (!webQQ.Login()) { setLog("登录失败..."); return; }
            //--------------------- 登陆成功，界面处理，显示昵称--------
            setLog("登陆成功!");
            setLog("昵称：" + webQQ.Nick);

            textBox_QQNumber.Enabled = false;
            textBox_Pwd.Enabled = false;
            button_login.Enabled = false;

            // 这里启动线程poll2
            setLog("启动poll2线程...");
            poll2thread.Start();
            getGroupInfoFunc();
            if (!webQQ.get_gface_sig2()) { setLog("获取图片相关信息失败..."); }

        }

        // 获取群消息函数
        private void getGroupInfoFunc()
        {
            //---------------------------------------------------------
            setLog("正在获取群列表和群信息...");
            listView_GroupList.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
            for (int row = 0; row < webQQ.GNameList.Count; row++)
            {
                JObject obj = (JObject)webQQ.GNameList[row];
                // 这里显示群列表
                ListViewItem item = new ListViewItem();
                //item.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标  
                item.Text = row.ToString();
                item.SubItems.Add(obj["name"].ToString());

                item.Tag = obj;

                //item.SubItems.Add("第3列,第"+i+"行");  

                /*/ 获取群xin息和群好友列表
                string code = obj["code"].ToString();
                for (int Time_Count = 1; Time_Count <= TIME_COUNT; Time_Count++)
                {
                    setLog("第" + Time_Count + "次尝试...");
                    if (!webQQ.getGet_Group_Info_Ext2(code))
                    {
                        Debug.WriteLine("getGet_Group_Info_Ext2 出错");
                        setLog("获取群信息出错...\ncode:" + code);
                    }
                    else
                    {
                        setLog("成功获取群信息...");
                        break;
                    }
                    if (Time_Count == TIME_COUNT)
                    {
                        setLog("网络状态不好，请检查网络连接...");
                        setLog("程序退出，请检查网络连接后重新登陆...");
                        this.Close();
                        return;
                    }
                }
                // 这里为列表绑定群信息和群好友列表
                item.Tag = webQQ.GroupInfoItem;
                */
                listView_GroupList.Items.Add(item);
                Thread.Sleep(1000);
            }
            listView_GroupList.EndUpdate();
            setLog("等待接收消息...");

        }

        // poll2线程函数
        private void poll2ThreadFunc()
        {
            int retcode = webQQ.postPoll2();
            Debug.WriteLine("retcode--->" + retcode);
            Thread.Sleep(1000);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
           // string filename = @"Example.rtf";

            //richTextBox_Msg.SaveFile(filename);
            sendMsgthread.Start();
            //sendMsgtoAllGroupFunc();

        }

        private void sendMsgtoAllGroupFunc()
        {
            FlushClient fc = delegate()
            {
                int succnum = 0;
                int failnum = 0;
                for (int row = 0; row != listView_GroupList.Items.Count; row++)
                {
                    ListViewItem item = listView_GroupList.Items[row];
                    JObject obj = (JObject)item.Tag;
                    string gid = obj["gid"].ToString();



                    string image = (string)richTextBox_Msg.Tag;
                    bool success;
                    if (image == null)
                    {
                        success = webQQ.post_send_qun_msg2(richTextBox_Msg.Text, gid);
                    }
                    else
                    {
                        string Name = this.openFileDialog_openimage.FileName;
                        //string content = Tools.readFile(Name);

                        string imageName = webQQ.post_Cface_Upload(Name);
                        if (imageName == null) { setLog("上传图片失败..."); }
                        setLog("上传图片成功...");
                        richTextBox_Msg.Tag = imageName;


                        string code = obj["code"].ToString();
                        success = webQQ.post_send_qun_msg2(richTextBox_Msg.Text, gid, code, image);
                    }
                    Debug.WriteLine(richTextBox_Msg.Text);
                    if (success)
                    {
                        succnum++;
                        setLog("发送成功...");
                        setLog("成功个数：" + succnum);
                    }
                    else
                    {
                        failnum++;
                        setLog("发送失败...");
                        setLog("成功个数：" + succnum);
                    }
                    Thread.Sleep(5000);
                }
                setLog("成功个数：" + succnum);
                setLog("失败个数：" + failnum);
            };
            listView_GroupList.Invoke(fc);
        }

        private void button_Picture_Click(object sender, EventArgs e)
        {
            this.openFileDialog_openimage.Filter = "*.png|*.png|所有文件(*.*)|*.*";
            if (this.openFileDialog_openimage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    setLog("导入中，请稍后...");
                    string Name = this.openFileDialog_openimage.FileName;
                    //string content = Tools.readFile(Name);
                    
                    string imageName = webQQ.post_Cface_Upload(Name);
                    if (imageName == null) { setLog("上传图片失败..."); }
                    setLog("上传图片成功...");
                    richTextBox_Msg.Tag = imageName;
                    bool b = richTextBox_Msg.ReadOnly;
                    Image img = Image.FromFile(Name);
                    Clipboard.SetDataObject(img);
                    richTextBox_Msg.ReadOnly = false;
                    richTextBox_Msg.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
                    richTextBox_Msg.ReadOnly = b;


                    setLog("导入完毕...");
                }
                catch (Exception ee) { setLog(ee.ToString()); }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            setLog("终止poll2线程...");
            poll2thread.Abort();// 终止线程



            this.masterForm.Show();
            this.Dispose();
        }

    }
}
