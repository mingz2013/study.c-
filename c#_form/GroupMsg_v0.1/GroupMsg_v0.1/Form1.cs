using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace GroupMsg_v0._1
{
    public partial class Form1 : Form
    {
        #region 变量声明
        private static int REPLACE_MINUTE = 6;// 多少分钟内重复数据不上传
        private static int TIME_COUNT = 10;  // 获取群消息出错重复尝试的次数
        private InitForm masterForm = null;// 窗口切换用
        private WebQQ webQQ;
        private HttpMethod httpMethod;
        Thread poll2thread;
        //Thread getGroupInfoThread;
        //private string QQNumber;
        //private string Pwd;
        private int length_low; // 最低位
        private int length_high;// 最高位
        private string[] key_list; // 关键字列表
        private string[] hackword_list;// 黑名单列表
        private string replease_word = ""; // 用于替换的词
        private string[] replease_List; // 被替换的关键字列表
        private string[,] Tel_List;// 电话列表
        private string host;// 域名
        private string Msg_Code;// 城市
        #endregion
        private delegate void FlushClient();//代理
        private delegate void poll2Client();


        public InitForm MasterForm
        { set { masterForm = value; } }

        public Form1()
        {
            InitializeComponent();
        }
        // 界面被载入
        private void Form1_Load(object sender, EventArgs e)
        {
            setLog("系统正在初始化...");
            webQQ = new WebQQ();
            httpMethod = new HttpMethod();
            poll2thread = new Thread(poll2Flush);
            poll2thread.IsBackground = true;
            //getGroupInfoThread = new Thread(new ThreadStart(getGroupInfoThreadFlush));
            // getGroupInfoThread.IsBackground = true;
            Tel_List = new string[5000, 2];

            setLog("读取配置文件...");
            textBox_QQNumber.Text = ConfigAppSettings.GetValue("QQNumber");
            textBox_pwd.Text = ConfigAppSettings.GetValue("Pwd");
            numericUpDown_low.Value = Convert.ToDecimal(ConfigAppSettings.GetValue("length_low"));
            numericUpDown_high.Value = Convert.ToDecimal(ConfigAppSettings.GetValue("length_high"));
            textBox_keyWordList.Text = ConfigAppSettings.GetValue("key_list");
            textBox_blackWordList.Text = ConfigAppSettings.GetValue("hackword_list");
            textBox_replaceWord.Text = ConfigAppSettings.GetValue("replease_word");
            textBox_replaceList.Text = ConfigAppSettings.GetValue("replease_List");
            textBox_TelList.Text = ConfigAppSettings.GetValue("Tel_List");
            textBox_host.Text = ConfigAppSettings.GetValue("host");
            textBox_city.Text = ConfigAppSettings.GetValue("Msg_Code");


            length_low = (int)numericUpDown_low.Value;
            length_high = (int)numericUpDown_high.Value;
            key_list = textBox_keyWordList.Text.Split(',');
            hackword_list = textBox_blackWordList.Text.Split(',');
            replease_word = textBox_replaceWord.Text;
            replease_List = textBox_replaceList.Text.Split(',');
            host = textBox_host.Text;
            Msg_Code = textBox_city.Text;
            string[] Tel = textBox_TelList.Text.Split('\n');
            //Debug.WriteLine(textBox_TelList.Text);
            Debug.WriteLine("Tellength--->" + Tel.Length);
            for (int i = 0; i < Tel.Length; i++)
            {
                Debug.WriteLine(Tel[i]);
                string[] t = Tel[i].Split(',');
                Debug.WriteLine(t[0]);
                Debug.WriteLine(t[1]);
                Tel_List[i, 0] = t[0];
                Tel_List[i, 1] = t[1];
            }
            //-------- 界面处理------------------------------------------------------
            needVerifyCode(false);
            /*
            textBox_replaceWord.Enabled = false;
            textBox_replaceList.Enabled = false;
            textBox_blackWordList.Enabled = false;
            textBox_TelList.Enabled = false;
            textBox_keyWordList.Enabled = false;
            textBox_host.Enabled = false;
            textBox_city.Enabled = false;
            numericUpDown_low.Enabled = false;
            numericUpDown_high.Enabled = false;
            */
            //-----------------------------------------------------------------------
            // 获取QQ号
            if (textBox_QQNumber.Text != "")
            {
                setLog("QQ号不空...");
                webQQ.QQNumber = textBox_QQNumber.Text;
                // 获取文字验证码
                if (!webQQ.getCheck()) { Debug.WriteLine("QQ号错误，获取文字验证码失败"); setLog("QQ号有误..."); return; }
                // 获取验证码图片
                if (webQQ.TextCode.Length == 4)
                {
                    setLog("不需要验证码...");
                    Debug.WriteLine("不需要获取验证码图片");
                    needVerifyCode(false);
                }
                else
                {
                    setLog("需要输入验证码...");
                    setLog("正在获取验证码图片...");
                    needVerifyCode(true);
                    Image image = webQQ.getImage();
                    pictureBox_verifyimage.Image = image;
                }
            }
            else
            {
                Debug.WriteLine("QQ号为空...");
                setLog("QQ号为空...");
            }
            setLog("获取密码...");
            webQQ.Pwd = textBox_pwd.Text;
            setLog("初始化完毕...");
        }
        // 关闭前的动作
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            setLog("终止poll2线程...");
            poll2thread.Abort();// 终止线程

            setLog("保存配置中...");
            ConfigAppSettings.SetValue("QQNumber", textBox_QQNumber.Text);
            ConfigAppSettings.SetValue("Pwd", textBox_pwd.Text);
            ConfigAppSettings.SetValue("length_low", numericUpDown_low.Value.ToString());
            ConfigAppSettings.SetValue("length_high", numericUpDown_high.Value.ToString());
            ConfigAppSettings.SetValue("key_list", textBox_keyWordList.Text);
            ConfigAppSettings.SetValue("hackword_list", textBox_blackWordList.Text);
            ConfigAppSettings.SetValue("replease_word", textBox_replaceWord.Text);
            ConfigAppSettings.SetValue("replease_List", textBox_replaceList.Text);
            ConfigAppSettings.SetValue("Tel_List", textBox_TelList.Text);
            ConfigAppSettings.SetValue("host", textBox_host.Text);
            ConfigAppSettings.SetValue("Msg_Code", textBox_city.Text);

            this.masterForm.Show();
            this.Dispose();
        }
        // 图片控件被单击
        private void pictureBox_verifyimage_Click(object sender, EventArgs e)
        {
            setLog("正在获取验证码图片...");
            Image image = webQQ.getImage();
            pictureBox_verifyimage.Image = image;
            setLog("已获取验证码图片...");
        }
        // 切换图片被单击
        private void linkLabel_verifyChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setLog("正在获取验证码图片...");
            Image image = webQQ.getImage();
            pictureBox_verifyimage.Image = image;
            setLog("已获取验证码图片...");
        }
        // 登陆按钮被单击
        private void button_login_Click(object sender, EventArgs e)
        {
            // login
            setLog("登录中...");
            if (!webQQ.Login()) { Debug.WriteLine("登陆出错"); setLog("登录失败..."); return; }
            //--------------------- 登陆成功，界面处理，显示昵称--------
            setLog("登陆成功!");
            setLog("昵称：" + webQQ.Nick);
            textBox_nick_Show.AppendText("登陆成功!\n");
            textBox_nick_Show.AppendText("\n");
            textBox_nick_Show.AppendText("昵称:" + webQQ.Nick + "\n");
            textBox_QQNumber.Enabled = false;
            textBox_pwd.Enabled = false;
            button_login.Enabled = false;
            needVerifyCode(false);
            // 这里启动线程poll2
            setLog("启动poll2线程...");
            poll2thread.Start();
            //setLog("获取群信息线程...");
            //getGroupInfoThread.Start();
            getGroupInfoFunc();

            // 其他一些处
        }
        /*/ 刷新线程
        private void getGroupInfoThreadFlush()
        {
            FlushClient fc = delegate()
            {
                getGroupInfoFunc();
            };
            this.textBox_programLog.Invoke(fc);
            this.listView_QQGroupList.Invoke(fc);
        }*/
        // 获取群消息函数
        private void getGroupInfoFunc()
        {
            //---------------------------------------------------------
            setLog("正在获取群列表和群信息...");
            listView_QQGroupList.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
            for (int row = 0; row < webQQ.GNameList.Count; row++)
            {
                JObject obj = (JObject)webQQ.GNameList[row];
                // 这里显示群列表
                ListViewItem item = new ListViewItem();
                //item.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标  
                item.Text = obj["name"].ToString();
                //item.SubItems.Add("第2列,第"+i+"行");  
                //item.SubItems.Add("第3列,第"+i+"行");  

                // 获取群xin息和群好友列表
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

                listView_QQGroupList.Items.Add(item);
                Thread.Sleep(1000);
            }
            listView_QQGroupList.EndUpdate();
            setLog("等待接收消息...");

        }
        // 消息显示函数
        private void setLog(string message)
        {
            textBox_programLog.AppendText(Tools.getTimeNow() + ":" + message + "\n");
            textBox_Show.Text = message;
        }
        // 需要验证码时处理界面
        private void needVerifyCode(bool need)
        {
            textBox_verifycode.Enabled = need;
            pictureBox_verifyimage.Enabled = need;
            linkLabel_verifyChange.Enabled = need;
        }
        private void poll2Flush()
        {
            while (true)
            {
                Thread.Sleep(2000);
                poll2ThreadFunc();

            }
            //Debug.WriteLine("线程已退出...");
            //setLog("线程已退出...");
        }
        // poll2线程函数
        private void poll2ThreadFunc()
        {
            int retcode = webQQ.postPoll2();

            if (this.textBox_programLog.InvokeRequired)//等待异步
            {
                poll2Client fc = new poll2Client(poll2ThreadFunc);
                this.Invoke(fc);//通过代理调用刷新方法

            }
            else
            {
                switch (retcode)
                {
                    case 0:
                        {
                            setLog("收到消息...");
                            Debug.WriteLine(webQQ.Poll2Message);
                            Thread doMessagethread = new Thread(new ParameterizedThreadStart(CrossThreadFlush));
                            doMessagethread.IsBackground = true;
                            setLog("处理消息...");
                            doMessagethread.Start(webQQ.Poll2Message);
                            break;
                        }
                    case 102: { Debug.WriteLine("正常连接，没有消息..."); setLog("正常连接，没有消息..."); break; }
                    case 108: { Debug.WriteLine("QQ已掉线..."); setLog("QQ已掉线..."); break; }
                    case 114: { Debug.WriteLine("QQ已掉线..."); setLog("QQ已掉线..."); break; }
                    case 121: { Debug.WriteLine("QQ已掉线..."); setLog("QQ已掉线..."); break; }
                    default: { Debug.WriteLine("postPoll2 出错..."); setLog("postPoll2 出错...code:" + retcode); break; }
                }
            }



        }
        // 刷新线程
        private void CrossThreadFlush(object poll2Message)
        {
            FlushClient fc = delegate()
            {
                doMessageThreadFunc(poll2Message);
            };
            this.listView_postLog.Invoke(fc);
            //this.textBox_programLog.Invoke(fc);
        }
        // 处理收到的数据
        private void doMessageThreadFunc(object poll2Message)
        {
            JArray message = (JArray)poll2Message;
            // 一个message中有多条消息
            for (int row = 0; row < message.Count; row++)
            {
                JObject item = (JObject)message[row];
                string poll_type = item["poll_type"].ToString();
                if (poll_type != "group_message") { Debug.WriteLine("不是群消息"); setLog("不是群消息..."); continue; }
                JObject item_value = (JObject)item["value"];

                // 接收到群消息，写日志，把消息提交到服务器
                JArray contentArray = (JArray)item_value["content"];
                string content_text = contentArray.Last().ToString();
                Debug.WriteLine(content_text);
                setLog("群消息：" + content_text);
                setLog("处理群消息...");
                // 获取uin
                string send_uin = item_value["send_uin"].ToString();
                string from_uin = item_value["from_uin"].ToString();
                // 获取昵称
                string friend_nick = send_uin;
                // 昵称
                //要先获取群好友列表，里面有昵称 和 uin的对应关系，遍历此列表，根据send_uin对应关系，获取nick
                // 获取群好友列表 需要gcode
                // 找到群号有列表 首先需要 from_uin 选择列表，然后再用send_uin选择对象，然后从对象中提取昵称
                //for()
                foreach (ListViewItem item_ in listView_QQGroupList.Items)
                {
                    JObject GroupInfoItem = (JObject)item_.Tag;
                    JObject ginfo = (JObject)GroupInfoItem["ginfo"];
                    if (ginfo["gid"].ToString() == from_uin)
                    {
                        JArray array_minfo = (JArray)GroupInfoItem["minfo"];
                        for (int i = 0; i != array_minfo.Count; i++)
                        {
                            JObject infoObj = (JObject)array_minfo[i];
                            if (infoObj["uin"].ToString() == send_uin)
                            {
                                friend_nick = infoObj["nick"].ToString();
                                break;
                            }
                        }
                        break;
                    }
                }
                // 获取QQ号
                string friend_QQ_number = webQQ.getGet_Friend_Uin2(send_uin, "1");
                // 获取群gid
                string group_code = item_value["group_code"].ToString();
                Debug.WriteLine("group_code---------->" + group_code);
                // 获取群号码
                string Group_number = webQQ.getGet_Friend_Uin2(group_code, "4");

                /*/ 填写发布日志
                int row = ui->tableWidget_sendlog->rowCount();
                ui->tableWidget_sendlog->insertRow(row);// 插入一行
                ui->tableWidget_sendlog->setItem(row, 0, new QTableWidgetItem(Tools::getTimeNow()));
                ui->tableWidget_sendlog->setItem(row, 1, new QTableWidgetItem(Group_number));// 这里要QQ群号
                ui->tableWidget_sendlog->setItem(row, 2, new QTableWidgetItem(friend_nick + "("+friend_QQ_number+")"));// 这里要昵称 和 QQ号 明子(xxx)
                ui->tableWidget_sendlog->setItem(row, 3, new QTableWidgetItem(content_text));// 只要群消息
                */
                ListViewItem listViewItem = new ListViewItem();
                //listViewItem.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标  
                listViewItem.Text = Tools.getTimeNow();

                listViewItem.SubItems.Add(Group_number);
                listViewItem.SubItems.Add(friend_nick + "(" + friend_QQ_number + ")");
                listViewItem.SubItems.Add(content_text);
                listViewItem.Tag = DateTime.UtcNow;

                listView_postLog.Items.Add(listViewItem);
                listView_postLog.Items[listView_postLog.Items.Count - 1].EnsureVisible();// 最后一行一直可见


                // 长度判断
                if (content_text.Length <= length_low || content_text.Length >= length_high)
                {
                    setLog("长度不适...");
                    Debug.WriteLine("长度不合适");
                    listViewItem.SubItems.Add("长度不适");// 如果此条消息可以发布，则打对号
                    listViewItem.SubItems.Add("");
                    return;
                }
                // 关键字判断
                if (key_list.Length != 0)
                {
                    // 设置了关键字，包含关键字的过
                    bool havekey = false;
                    for (int i = 0; i != key_list.Length; i++)
                    {
                        if (content_text.Contains(key_list[i]))
                        {
                            havekey = true;
                            break;
                        }
                    }
                    if (!havekey)
                    {
                        // 不包含关键字
                        setLog("不包含关键字...");
                        listViewItem.SubItems.Add("不包含关键字");// 如果此条消息可以发布，则打对号
                        listViewItem.SubItems.Add("");
                        return;
                    }
                }
                else
                {
                    // 没有设置关键字，全部过
                }
                // 黑名单判断
                for (int i = 0; i != hackword_list.Length; i++)
                {
                    if (content_text.Contains(hackword_list[i]))
                    {
                        setLog("包含黑名单词汇...");
                        listViewItem.SubItems.Add("有黑名单字符");// 如果此条消息可以发布，则打对号
                        listViewItem.SubItems.Add("");
                        return;
                    }
                }
                //-------------------该判断的判断完了，对消息进行处理

                setLog("替换关键字处理...");
                if (replease_word == "") { replease_word = " "; }
                for (int i = 0; i != replease_List.Length; i++)
                {
                    content_text = content_text.Replace(replease_List[i], replease_word);
                }
                // ---------------------最后判断6分钟内有没有重复----------------------
                setLog("判断是否重复...");
                DateTime now = DateTime.UtcNow;
                TimeSpan s = new DateTime(2013, 9, 8, 0, REPLACE_MINUTE, 0, 0) - new DateTime(2013, 9, 8, 0, 0, 0, 0);
                long g = Convert.ToInt64(s.TotalSeconds);
                for (int i = listView_postLog.Items.Count - 2; i >= 0; i--)
                {
                    ListViewItem it = listView_postLog.Items[i];
                    Debug.WriteLine("i------>" + i);
                    Debug.WriteLine("it.SubItems[0].Text->" + it.SubItems[0].Text);
                    Debug.WriteLine("it.SubItems[1].Text->" + it.SubItems[1].Text);
                    Debug.WriteLine("it.SubItems[2].Text->" + it.SubItems[2].Text);
                    Debug.WriteLine("it.SubItems[3].Text->" + it.SubItems[3].Text);
                    Debug.WriteLine("it.SubItems[4].Text->" + it.SubItems[4].Text);
                    Debug.WriteLine("it.SubItems[5].Text->" + it.SubItems[5].Text);
                    Debug.WriteLine("it.SubItems[5].Text->" + it.SubItems[5].Text);
                    if (it.SubItems[5].Text == "发布成功")
                    {
                        TimeSpan ts = now - (DateTime)it.Tag;
                        long l = Convert.ToInt64(ts.TotalSeconds);// 时间间隔
                        if (l < g)
                        {// 时间间隔没有超过6分钟
                            // 判断是否重复
                            if (content_text == it.SubItems[3].Text)
                            {
                                // 重复了，不能发布，
                                setLog(REPLACE_MINUTE + "分钟内有重复...");
                                listViewItem.SubItems.Add(REPLACE_MINUTE + "分钟内有重复...");// 如果此条消息可以发布，则打对号
                                listViewItem.SubItems.Add("");
                                return;
                            }
                        }
                        else { break; }
                    }
                }

                setLog("可发布...");
                listViewItem.SubItems.Add("可以发布");// 如果此条消息可以发布，则打对号
                Debug.WriteLine("上传的消息：" + content_text);
                setLog("获取电话信息...");
                string tel = "-";
                for (int i = 0; i < Tel_List.Length - 1; i++)
                {
                    if (Tel_List[i, 0] == null) { setLog("电话列表已经遍历..."); break; }
                    Debug.WriteLine("length-------->" + Tel_List.Length);
                    Debug.WriteLine("i--------->" + i);
                    Debug.WriteLine("Tel_List[i,1]--------->" + Tel_List[i, 1]);
                    Debug.WriteLine("Tel_List[i,0]--------->" + Tel_List[i, 0]);
                    Debug.WriteLine("Tel_List[i,0]--------->" + Tel_List[i, 0]);
                    Debug.WriteLine("friend_QQ_number----- >" + friend_QQ_number);
                    if (Tel_List[i, 0] == friend_QQ_number)
                    {
                        // 附加上电话信息
                        tel = Tel_List[i, 1];
                        setLog("Tel:" + tel);
                        break;
                    }
                }
                if (tel == "-") { setLog("未找到电话信息..."); }
                setLog("发布信息...");
                //setLog("发送信息的跳过...");

                bool send_sucess;

                //    setLog("第" + (i + 1) + "次尝试...");
                try
                {
                    send_sucess = get_send_to_website(content_text, tel, friend_nick, friend_QQ_number);
                }
                catch (Exception e)
                {
                    send_sucess = false;
                    setLog(e.ToString());
                }
                //这里要有个判断，判断是否发布成功
                if (send_sucess)
                {
                    setLog("发布成功...");
                    listViewItem.SubItems.Add("发布成功");// 如果发布成功则打对号
                    break;
                }
                else
                {
                    setLog("发布失败...");
                    listViewItem.SubItems.Add("发布失败");// 如果发布成功则打对号
                }


                //listViewItem.SubItems.Add("发布成功");
            }
        }
        // 发送到网站
        private bool get_send_to_website(string Msg_Content, string Msg_Tel, string Msg_Company, string friend_QQ_number)
        {
            Debug.WriteLine("Msg_Content--------->" + Msg_Content);
            Debug.WriteLine("Msg_Code--------->" + Msg_Code);
            Debug.WriteLine("Msg_Company--------->" + Msg_Company);
            Debug.WriteLine("Msg_Tel--------->" + Msg_Tel);
            string Content = Msg_Content;
            char EnterChar = (char)13;
            if (Content.IndexOf(EnterChar.ToString()) > -1)
            {

                Content = Content.Replace(EnterChar, ' ');

            }

            Content = Tools.UrlEncode(Content);
            string Code = Tools.UrlEncode(Msg_Code);
            string Company = Tools.UrlEncode(Msg_Company + " QQ：" + friend_QQ_number);
            string Tel = Msg_Tel;
            if (Tel.IndexOf(EnterChar.ToString()) > -1)
            {

                Tel = Tel.Replace(EnterChar, ' ');

            }
            Tel = Tools.UrlEncode(Tel);
            Debug.WriteLine("Msg_Content--------->" + Content);
            Debug.WriteLine("Msg_Code--------->" + Code);
            Debug.WriteLine("Msg_Company--------->" + Company);
            Debug.WriteLine("Msg_Tel--------->" + Tel);

            // url
            string strUrl = host + "/estar/shareinfo/info_uploadQQ.asp?action=QQTeam_AddInfo&user=555&pwd=777&Msg_Code=" + Code + "&Msg_Type=0&Msg_Content=" + Content + "&Msg_Tel=" + Tel + "&Msg_Area=" + Code + "&Msg_StartCity=" + Code + "&Msg_Company=" + Company;
            Debug.WriteLine("strUrl----->" + strUrl);
            string content = null;

            setLog("发送数据到网站...");

            // setLog("第" + (i + 1) + "次尝试...");
            content = httpMethod.SendDataByGETtoString(strUrl, null);

            //Debug.WriteLine(e.ToString());
            //setLog(e.ToString());
            //content = "Error";

            Debug.WriteLine("content----------->" + content);
            if (content == "AddOK") { return true; }
            setLog("发送失败...");

            return false;

        }

       

        #region 用于各个控件 失去焦点事件
        private void textBox_QQNumber_Leave(object sender, EventArgs e)
        {
            Debug.WriteLine("QQhao输入失去焦点");
            textBox_QQNumber.Text = textBox_QQNumber.Text.Trim();// 去除首尾空
            if (webQQ.QQNumber == textBox_QQNumber.Text) { Debug.WriteLine("QQ号没有改变"); return; }// qq号没有改变
            webQQ.QQNumber = textBox_QQNumber.Text;
            if (!webQQ.getCheck()) { Debug.WriteLine("QQ号错误，获取文字验证码失败"); setLog("QQ号有误..."); return; }
            if (webQQ.TextCode.Length == 4)
            {
                setLog("不需要验证码...");
                Debug.WriteLine("不需要获取验证码图片");
                needVerifyCode(false);
                return;
            }
            setLog("需要输入验证码...");
            setLog("正在获取验证码图片...");
            needVerifyCode(true);
            Image image = webQQ.getImage();
            pictureBox_verifyimage.Image = image;
        }
        private void textBox_pwd_Leave(object sender, EventArgs e)
        {
            webQQ.Pwd = textBox_pwd.Text;
        }
        private void textBox_verifycode_Leave(object sender, EventArgs e)
        {
            webQQ.TextCode_Write = textBox_verifycode.Text;
        }
        private void textBox_replaceWord_Leave(object sender, EventArgs e)
        {
            replease_word = textBox_replaceWord.Text;
        }
        private void textBox_replaceList_Leave(object sender, EventArgs e)
        {
            replease_List = textBox_replaceList.Text.Split(',');
        }
        private void textBox_blackWordList_Leave(object sender, EventArgs e)
        {
            hackword_list = textBox_blackWordList.Text.Split(',');
        }
        private void textBox_TelList_Leave(object sender, EventArgs e)
        {
            string[] Tel = textBox_TelList.Text.Split('\n');
            for (int i = 0; i < Tel.Length; i++)
            {
                string[] t = Tel[i].Split(',');
                Tel_List[i, 0] = t[0];
                Tel_List[i, 1] = t[1];
                Debug.WriteLine(t);
            }
        }
        private void textBox_keyWordList_Leave(object sender, EventArgs e)
        {
            key_list = textBox_keyWordList.Text.Split(',');
        }
        private void textBox_host_Leave(object sender, EventArgs e)
        {
            host = textBox_host.Text;
        }
        private void numericUpDown_low_Leave(object sender, EventArgs e)
        {
            length_low = (int)numericUpDown_low.Value;
        }
        private void numericUpDown_high_Leave(object sender, EventArgs e)
        {
            length_high = (int)numericUpDown_high.Value;
        }
        private void textBox_city_Leave(object sender, EventArgs e)
        {
            Msg_Code = textBox_city.Text;
        }
        #endregion

        #region 编辑锁定与解锁按钮
        private void button_lock_repleace_Click(object sender, EventArgs e)
        {
            if (textBox_replaceWord.ReadOnly)
            {
                textBox_replaceList.ReadOnly = false;
                textBox_replaceWord.ReadOnly = false;
                button_lock_repleace.Text = "编辑解锁";
            }
            else
            {
                textBox_replaceList.ReadOnly = true;
                textBox_replaceWord.ReadOnly = true;
                button_lock_repleace.Text = "编辑锁定";
            }
        }

        private void button_lock_hack_Click(object sender, EventArgs e)
        {
            if (textBox_blackWordList.ReadOnly)
            {
                textBox_blackWordList.ReadOnly = false;
                button_lock_hack.Text = "编辑解锁";
            }
            else
            {
                textBox_blackWordList.ReadOnly = true;
                button_lock_hack.Text = "编辑锁定";
            }
        }

        private void button_lock_Tel_Click(object sender, EventArgs e)
        {
            if (textBox_TelList.ReadOnly)
            {
                textBox_TelList.ReadOnly = false;
                button_lock_Tel.Text = "编辑解锁";
            }
            else
            {
                textBox_TelList.ReadOnly = true;
                button_lock_Tel.Text = "编辑锁定";
            }
        }

        private void button_lock_keyword_Click(object sender, EventArgs e)
        {
            if (textBox_keyWordList.ReadOnly)
            {
                textBox_keyWordList.ReadOnly = false;
                button_lock_keyword.Text = "编辑解锁";
            }
            else
            {
                textBox_keyWordList.ReadOnly = true;
                button_lock_keyword.Text = "编辑锁定";
            }
        }

        private void button_lock_other_Click(object sender, EventArgs e)
        {
            // 测试代码
            //get_send_to_website("蛇口招170尖头车司机一名，需证照齐全，有两年以上货柜车驾驶经验，熟悉珠三角路线，有意请电18948189702  ", "-", "深圳", "xxx");
            if (textBox_host.ReadOnly)
            {
                textBox_host.ReadOnly = false;
                textBox_city.ReadOnly = false;
                numericUpDown_low.ReadOnly = false;
                numericUpDown_high.ReadOnly = false;
                button_lock_other.Text = "编辑解锁";
            }
            else
            {
                textBox_host.ReadOnly = true;
                textBox_city.ReadOnly = true;
                numericUpDown_low.ReadOnly = true;
                numericUpDown_high.ReadOnly = true;
                button_lock_other.Text = "编辑锁定";
            }
        }
        #endregion

       
    }
}