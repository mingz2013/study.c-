using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;


namespace sendGroupMsg
{
    class WebQQ
    {
        #region 变量声明
        HttpMethod httpMethod;
        private string qqNumber = "";
        private string pwd = null;
        private string textCode = null;// 文字验证码
        private string textCode_Write = null;// 输入的验证码
        private string pt_uin = null; // 
        private string nick = null;
        private string check_sig_Url = null;
        private string clientid = null;
        private string ptwebqq = null;
        private string vfwebqq = null;
        private string psessionid = null;
        private int msg_id;
        private int fileid ;
        private string gface_key;// 发送图片用的
        private string gface_sig;

        //private JArray gmasklist = null;
        private JArray gnamelist = null;
        private JArray gmarklist = null;
        //private List<JObject> GroupInfoList = null;// 群信息和群好友列表 的列表
        private JObject groupinfoItem = null;   // 单个群信息和群好友列表
        private JArray poll2Message = null;  // 收到的消息 集合 
        #endregion
        #region 公开变量方法
        public string QQNumber
        {
            set { qqNumber = value; }
            get { return qqNumber; }
        }
        public string Pwd
        {
            set { pwd = value; }
            get { return pwd; }
        }
        public string Nick
        {
            set { nick = value; }
            get { return nick; }
        }
        public string TextCode
        {
            set { textCode = value; }
            get { return textCode; }
        }
        public string TextCode_Write
        {
            set { textCode_Write = value; }
            get { return textCode_Write; }
        }
        public JArray GNameList
        {
            set { gnamelist = value; }
            get { return gnamelist; }
        }
        public JObject GroupInfoItem
        {
            set { groupinfoItem = value; }
            get { return groupinfoItem; }
        }
        public JArray Poll2Message
        {
            set { poll2Message = value; }
            get { return poll2Message; }
        }
        #endregion
        // 构造函数
        public WebQQ()
        {
            httpMethod = new HttpMethod();
            msg_id = 87000001;
            fileid = 1;
        }
        #region 和服务器交互的方法
        // get方法，获取文字验证码，成功返回true失败返回false
        public bool getCheck()
        {
            textCode = null;// 文字验证码
            pt_uin = null; // 
            string strUrl = "https://ssl.ptlogin2.qq.com/check?uin=" + qqNumber + "&appid=1003903&js_ver=10037&js_type=0&login_sig=a5plBY*dGrO823Rz7isbMqfxGbtHb2CcVcpsjAyXzt-2g6PIgmhXuPq1O71Cesqw&u1=http%3A%2F%2Fweb2.qq.com%2Floginproxy.html&r=0." + Tools.getRandString(Tools.getRandInt(15, 16));// 15 或 16位随机数
            httpMethod.AddCookie("chkuin", qqNumber, "/", ".ptlogin2.qq.com");
            string content = httpMethod.SendDataByGETtoString(strUrl);
            Debug.WriteLine("content----->" + content);
            //ptui_checkVC('0','!WDE','\x00\x00\x00\x00\x12\x37\x24\x51');
            textCode = Tools.getMidOfTwoText(content, "','", "','");
            Debug.WriteLine("textCode----->" + textCode);
            pt_uin = content.Substring(content.LastIndexOf("','") + 3, 32);
            Debug.WriteLine("pt_uin----->" + pt_uin);
            if (textCode.Length > 0) { return true; }
            else { return false; }
        }
        // 获取验证码图片
        public Image getImage()
        {
            string strUrl = "https://ssl.captcha.qq.com/getimage?aid=1003903&r=0." + Tools.getRandString(17) + "&uin=" + qqNumber;
            Stream myResponseStream = httpMethod.SendDataByGETtoStream(strUrl);
            Image image = Image.FromStream(myResponseStream);
            myResponseStream.Close();
            return image;
        }
        // getlogin
        private bool getLogin()
        {
            string verifycode;
            if (textCode.Length == 4) { verifycode = textCode; }
            else { verifycode = textCode_Write; }
            string[] _params = { pwd, verifycode, pt_uin };
            string md5_pwd = Tools.runJS(@"JS/QQ.js", "func", _params);
            if (md5_pwd == null) { Debug.WriteLine("密码加密失败"); return false; }
            // url 
            string strUrl = "https://ssl.ptlogin2.qq.com/login?u=" + qqNumber + "&p=" + md5_pwd + "&verifycode=" + verifycode + "&webqq_type=10&remember_uin=1&login2qq=1&aid=1003903&u1=http%3A%2F%2Fweb2.qq.com%2Floginproxy.html%3Flogin2qq%3D1%26webqq_type%3D10&h=1&ptredirect=0&ptlang=2052&daid=164&from_ui=1&pttype=1&dumy=&fp=loginerroralert&action=1-11-11722&mibao_css=m_webqq&t=1&g=1&js_type=0&js_ver=10038&login_sig=FHtWnWD4qzo7PYp*3mDJtPxsYzwUAp9SFO0HlDBzsV5iDmqoldIny4NSmA3NRTwj";
            string content = httpMethod.SendDataByGETtoString(strUrl);
            Debug.WriteLine(content);
            // ptuiCB('0','0','http://ptlogin4.web2.qq.com/check_sig?pttype=1&uin=xxx&service=login&nodirect=0&ptsig=KNTchh0YK-7DRnUFau5U8OQtSOsNWWUB6wFjCYtKniU_&s_url=http%3A%2F%2Fweb2.qq.com%2Floginproxy.html%3Flogin2qq%3D1%26webqq_type%3D10&f_url=&ptlang=2052&ptredirect=100&aid=1003903&daid=164&j_later=0&low_login_hour=0&regmaster=0','0','登录成功！', '小晶');
            Debug.WriteLine(content.Contains("登录成功！"));
            if (!content.Contains("登录成功！")) { Debug.WriteLine("登陆失败"); return false; }
            nick = Tools.getMidOfTwoText(content, "登录成功！', '", "');");
            Debug.WriteLine(nick);
            check_sig_Url = Tools.getMidOfTwoText(content, "ptuiCB('0','0','", "','0','登录成功");
            Debug.WriteLine(check_sig_Url);
            return true;
        }
        private bool getCheck_sig()
        {
            string strUrl = check_sig_Url;
            string content = httpMethod.SendDataByGETtoString(strUrl);
            Debug.WriteLine("getCheck_sig------>" + content);
            if (!content.Contains("登录成功，跳转中...")) { Debug.WriteLine("登陆失败"); return false; }
            return true;
        }
        private bool postLogin2()
        {
            string strUrl = "http://d.web2.qq.com/channel/login2";
            clientid = Tools.getRandString(Tools.getRandInt(7, 8));
            Debug.WriteLine("clientid--------->" + clientid);
            ptwebqq = httpMethod.getCookieValue("ptwebqq", "https://ssl.ptlogin2.qq.com/login");
            Debug.WriteLine("ptwebqq--------->" + ptwebqq);
            if (ptwebqq == null) { Debug.WriteLine("获取ptwebqq失败"); return false; }
            string strPostData = "r=%7B%22status%22%3A%22online%22%2C%22ptwebqq%22%3A%22" + ptwebqq + "%22%2C%22passwd_sig%22%3A%22%22%2C%22clientid%22%3A%22" + clientid + "%22%2C%22psessionid%22%3Anull%7D&clientid=" + clientid + "&psessionid=null";

            Debug.WriteLine("strPostData----->" + strPostData);
            string referer = "http://d.web2.qq.com/proxy.html?v=20110331002&callback=1&id=2";
            string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
            Debug.WriteLine(content);

            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
            int retcode = (int)obj["retcode"];
            if (retcode != 0) { Debug.WriteLine("postLogin2 出错"); return false; }
            JObject result = (JObject)obj["result"];
            Debug.WriteLine(result);

            vfwebqq = result["vfwebqq"].ToString();
            psessionid = result["psessionid"].ToString();
            Debug.WriteLine("vfwebqq--->" + vfwebqq);
            Debug.WriteLine("psessionid--->" + psessionid);

            return true;
        }
        // poll数据，线程
        public int postPoll2()
        {
            string strUrl = "http://d.web2.qq.com/channel/poll2";
            string strPostData = "r=%7B%22clientid%22%3A%22" + clientid + "%22%2C%22psessionid%22%3A%22" + psessionid + "%22%2C%22key%22%3A0%2C%22ids%22%3A%5B%5D%7D&clientid=" + clientid + "&psessionid=" + psessionid;
            Debug.WriteLine("strPostData------>" + strPostData);
            string referer = "http://d.web2.qq.com/proxy.html?v=20110331002&callback=1&id=2";
            string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
            Debug.WriteLine(content);

            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
            int retcode = (int)obj["retcode"];
            switch (retcode)
            {
                case 0:
                    {
                        JArray result = (JArray)obj["result"];
                        Debug.WriteLine(result);
                        poll2Message = result;
                        break;
                    }
                case 102: { Debug.WriteLine("正常连接，没有消息..."); break; }
                case 121: { Debug.WriteLine("QQ已掉线..."); break; }
                default: { Debug.WriteLine("postLogin2 出错"); break; }
            }
            return retcode;
        }
        // 获取群列表
        private bool postGet_Group_Name_List_Mask2()
        {
            string strUrl = "http://s.web2.qq.com/api/get_group_name_list_mask2";
            string strPostData = "r=%7B%22vfwebqq%22%3A%22" + vfwebqq + "%22%7D";
            string referer = "http://s.web2.qq.com/proxy.html?v=20110412001&callback=1&id=3";
            string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
            Debug.WriteLine(content);

            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
            int retcode = (int)obj["retcode"];
            if (retcode != 0) { Debug.WriteLine("postLogin2 出错"); return false; }
            JObject result = (JObject)obj["result"];
            Debug.WriteLine(result);

            gmarklist = (JArray)result["gmasklist"];
            gnamelist = (JArray)result["gnamelist"];
            gmarklist = (JArray)result["gmarklist"];

            return true;
        }
        // 获取群信息和群好友列表
        public bool getGet_Group_Info_Ext2(string code)
        {
            groupinfoItem = null;
            string strUrl = "http://s.web2.qq.com/api/get_group_info_ext2?gcode=" + code + "&cb=undefined&vfwebqq=" + vfwebqq + "&t=" + Tools.getCurrentTimeStamp();
            string referer = "http://s.web2.qq.com/proxy.html?v=20110412001&callback=1&id=3";
            string content = httpMethod.SendDataByGETtoString(strUrl, referer);
            Debug.WriteLine(content);

            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
            int retcode = (int)obj["retcode"];
            if (retcode != 0) { Debug.WriteLine("Getget_Group_Info_Ext2 出错"); return false; }
            JObject result = (JObject)obj["result"];
            Debug.WriteLine(result);

            //GroupInfoList.Add(result);
            groupinfoItem = result;

            return true;
        }
        // 获取好友QQ号 或群号
        public string getGet_Friend_Uin2(string uin, string type)
        {
            string strUrl = "http://s.web2.qq.com/api/get_friend_uin2?tuin=" + uin + "&verifysession=&type=" + type + "&code=&vfwebqq=" + vfwebqq + "&t=" + Tools.getCurrentTimeStamp();
            string referer = "http://s.web2.qq.com/proxy.html?v=20110412001&callback=1&id=3";
            string content = httpMethod.SendDataByGETtoString(strUrl, referer);
            Debug.WriteLine(content);

            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
            int retcode = (int)obj["retcode"];
            if (retcode != 0) { Debug.WriteLine("Getget_Group_Info_Ext2 出错"); return null; }
            JObject result = (JObject)obj["result"];
            Debug.WriteLine(result);
            string num = result["account"].ToString();
            Debug.WriteLine(num);
            return num;
        }
        /**
        *给群发送消息
        **/
        public bool post_send_qun_msg2(string Msg, string group_uin)
        {
            // url
            string strUrl = "http://d.web2.qq.com/channel/send_qun_msg2";
            string strPostData = "r=%7B%22group_uin%22%3A"+group_uin+"%2C%22content%22%3A%22%5B%5C%22"+Msg+"%5C%22%2C%5C%22%5C%5Cn%E3%80%90%E6%8F%90%E7%A4%BA%EF%BC%9A%E6%AD%A4%E7%94%A8%E6%88%B7%E6%AD%A3%E5%9C%A8%E4%BD%BF%E7%94%A8Q%2B%20Web%EF%BC%9Ahttp%3A%2F%2Fweb2.qq.com%2F%E3%80%91%5C%22%2C%5B%5C%22font%5C%22%2C%7B%5C%22name%5C%22%3A%5C%22%E5%AE%8B%E4%BD%93%5C%22%2C%5C%22size%5C%22%3A%5C%2210%5C%22%2C%5C%22style%5C%22%3A%5B0%2C0%2C0%5D%2C%5C%22color%5C%22%3A%5C%22000000%5C%22%7D%5D%5D%22%2C%22msg_id%22%3A"+msg_id+"%2C%22clientid%22%3A%22"+clientid+"%22%2C%22psessionid%22%3A%22"+psessionid+"%22%7D&clientid="+clientid+"&psessionid=" + psessionid;
            string referer = "http://d.web2.qq.com/proxy.html?v=20110331002&callback=1&id=2";
            string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
            Debug.WriteLine(content);
            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
            int retcode = (int)obj["retcode"];
            if (retcode != 0) { Debug.WriteLine("post_send_qun_msg2 出错"); return false; }
            //JObject result = (JObject)obj["result"];
            //Debug.WriteLine(result);
            return true;
        }
        // 有图片的
        public bool post_send_qun_msg2(string Msg, string group_uin, string group_code, string image)
        {
            try
            {
                // url
                string strUrl = "http://d.web2.qq.com/channel/send_qun_msg2";
                Debug.WriteLine("group_uin---->" + group_uin);
                Debug.WriteLine("group_code---->" + group_code);
                Debug.WriteLine("gface_key----->" + gface_key);
                Debug.WriteLine("gface_sig----->" + gface_sig);
                Debug.WriteLine("image--------->" + image);
                Debug.WriteLine("Msg------>" + Msg);
                string strPostData = "r=%7B%22group_uin%22%3A"+group_uin+"%2C%22group_code%22%3A"+group_code+"%2C%22key%22%3A%22"+gface_key+"%22%2C%22sig%22%3A%22"+gface_sig+"%22%2C%22content%22%3A%22%5B%5B%5C%22cface%5C%22%2C%5C%22group%5C%22%2C%5C%22"+image+"%5C%22%5D%2C%5C%22"+Msg+"%5C%5Cn%5C%22%2C%5B%5C%22font%5C%22%2C%7B%5C%22name%5C%22%3A%5C%22%E5%AE%8B%E4%BD%93%5C%22%2C%5C%22size%5C%22%3A%5C%2210%5C%22%2C%5C%22style%5C%22%3A%5B0%2C0%2C0%5D%2C%5C%22color%5C%22%3A%5C%22000000%5C%22%7D%5D%5D%22%2C%22clientid%22%3A%22"+clientid+"%22%2C%22psessionid%22%3A%22"+psessionid+"%22%7D&clientid="+clientid+"&psessionid=" + psessionid;
                string referer = "http://d.web2.qq.com/proxy.html?v=20110331002&callback=1&id=2";
                string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
                Debug.WriteLine(content);
                JObject obj = (JObject)JsonConvert.DeserializeObject(content);
                int retcode = (int)obj["retcode"];
                if (retcode != 0) { Debug.WriteLine("post_send_qun_msg2 出错"); return false; }
                //JObject result = (JObject)obj["result"];
                //Debug.WriteLine(result);
                return true;
            }
            catch (Exception ee) 
            {
                Debug.WriteLine(ee.ToString());
                return false;
            }
        }
        // 上传图片
        public string post_Cface_Upload(string facepath)
        {
            string strUrl = "http://up.web2.qq.com/cgi-bin/cface_upload?time=" + Tools.getCurrentTimeStamp();
            string referer = "http://web2.qq.com/webqq.html";

            string Poststr = "from=control&f=EQQ.Model.ChatMsg.callbackSendPicGroup&vfwebqq="+vfwebqq+"&fileid=" + fileid.ToString();
            string fileformname = "custom_face";
            string content = httpMethod.SendImgByPOSTtoString(strUrl, Poststr,fileformname, facepath, referer);
            //<head><script type="text/javascript">document.domain='qq.com';parent.EQQ.Model.ChatMsg.callbackSendPicGroup({'ret':0,'msg':'44F133F2847CB6BA59BE03E22DDAC14E.jPg'});</script></head><body></body>
            //<head><script type="text/javascript">document.domain='qq.com';parent.EQQ.Model.ChatMsg.callbackSendPicGroup({'ret':4,'msg':'F20E3D64788A823FBAE9995DCF65D93F.gIf -6102 upload cface failed'});</script></head><body></body>
            Debug.WriteLine(content);
            string left = "callbackSendPicGroup(";
            string right = ");";
            int left_index = content.IndexOf(left);
            int right_index = content.IndexOf(right);
            int left_length = left.Length;
            
            string c = content.Substring(left_index + left_length, right_index - left_length - left_index);
            Debug.WriteLine("c---------->" + c);
            JObject obj = (JObject)JsonConvert.DeserializeObject(c);
            int ret = (int)obj["ret"];
            string msg = obj["msg"].ToString();
            string image = null;
            switch (ret)
            {
                case 0: { image = msg; fileid++; Debug.WriteLine("图片上传成功..."); break; }
                case 4: { image = msg.Substring(0, msg.IndexOf(" -6102")); ;Debug.WriteLine("图片重复上传..."); break; }
                default: { break; }
            }

            Debug.WriteLine("image------->" + image);
            return image;
        }
        // 获取发送群图片所需要的东西
        public bool get_gface_sig2()
        {
            string strUrl = "http://d.web2.qq.com/channel/get_gface_sig2?clientid="+clientid+"&psessionid="+psessionid+"&t=" + Tools.getCurrentTimeStamp();
            string referer = "http://d.web2.qq.com/proxy.html?v=20110331002&callback=1&id=2";
            string content = httpMethod.SendDataByGETtoString(strUrl, referer);
            Debug.WriteLine(content);

            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
            int retcode = (int)obj["retcode"];
            if (retcode != 0) { Debug.WriteLine("Getget_Group_Info_Ext2 出错"); return false; }
            JObject result = (JObject)obj["result"];
            Debug.WriteLine(result);
            gface_key = result["gface_key"].ToString();
            gface_sig = result["gface_sig"].ToString();
            if (gface_key == null || gface_sig == null) { return false; }
            return true;
        }
        #endregion
        // 登陆 getLogin getcheck_sig postlogin2 postget_group_name_list_mask2
        public bool Login()
        {
            if (!getLogin()) { Debug.WriteLine("getLogin 出错"); return false; }
            if (!getCheck_sig()) { Debug.WriteLine("getCheck_sig 出错"); return false; }
            if (!postLogin2()) { Debug.WriteLine("postLogin2 出错"); return false; }
            if (!postGet_Group_Name_List_Mask2()) { Debug.WriteLine("postGet_Group_Name_List_Mask2 出错"); return false; }

            return true;
        }
    }
}
