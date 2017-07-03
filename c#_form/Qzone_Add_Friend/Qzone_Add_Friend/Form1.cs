using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace Qzone_Add_Friend
{
    public partial class Form1 : Form
    {

        private Qzone qzone;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qzone = new Qzone();
            needVerifyImage(false);
            if (!qzone.get_Ui_Login()) { setLog("get_Ui_Login Wrong"); }
        }

        private void textBox_QQNumber_Leave(object sender, EventArgs e)
        {
            textBox_QQNumber.Text = textBox_QQNumber.Text.Trim();
            if (textBox_QQNumber.Text == "") { setLog("QQ号为空"); return; }
            qzone.QQNumber = textBox_QQNumber.Text;
            if (!qzone.get_Check()) { setLog("不需要验证码"); needVerifyImage(false); return; }
            needVerifyImage(true);
            pictureBox_verify.Image = qzone.get_Image();
        }

        private void needVerifyImage(bool need)
        {
            if (need)
            {
                textBox_Verify.Enabled = true;
                pictureBox_verify.Enabled = true;
                linkLabel_Change_Verify.Enabled = true;
            }
            else {
                textBox_Verify.Enabled = false;
                pictureBox_verify.Enabled = false;
                linkLabel_Change_Verify.Enabled = false;
            }
 
        }

        private void setLog(string Msg) 
        {
            Debug.WriteLine(Msg);
            
            textBox_ShowLog.AppendText(Msg + "\n");

        }

        private void pictureBox_verify_Click(object sender, EventArgs e)
        {
            pictureBox_verify.Image = qzone.get_Image();
        }

        private void linkLabel_Change_Verify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox_verify.Image = qzone.get_Image();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if (textBox_Pwd.Text == "") { setLog("密码为空"); return; } 
            qzone.Pwd = textBox_Pwd.Text;
            if (textBox_Verify.Enabled)
            {
                if (textBox_Verify.Text == "") { setLog("验证码为空"); return; } 
                qzone.Verify = textBox_Verify.Text;
            }
            if (!qzone.get_Login()) { setLog("登陆失败"); return; }
            textBox_Nick.Text = "登陆成功，昵称：" + qzone.Nick;
        }

        private void button_AddFriend_Click(object sender, EventArgs e)
        {
            if (textBox_otherQQ.Text == "") { setLog("对方QQ为空"); return; }

            if (!qzone.get_Friend_Authfriend(textBox_otherQQ.Text)) { setLog("添加好友失败"); return; }

            setLog("已发出请求 或 已经加上好友");

        }

        private void textBox_otherQQ_Leave(object sender, EventArgs e)
        {
            textBox_otherQQ.Text = textBox_otherQQ.Text.Trim();
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            bool success = qzone.post_emotion_cgi_publish_v6(textBox_Msg.Text);
            if (!success) { setLog("发布说说失败"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string skey = textBox_skey.Text;
                Debug.WriteLine("skey----->" + skey);
                string[] argc = { skey };
                string g_tk = Tools.runJS(@"JS/g_tk.js", "func", argc);
                Debug.WriteLine("g_tk----->" + g_tk);
                if (g_tk.Length > 0)
                {
                    setLog("g_tk:" + g_tk);
                    return ;
                }
                else { return ; }
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.ToString());
                return ;
            }
        }

        

        

        

        
    }
}
