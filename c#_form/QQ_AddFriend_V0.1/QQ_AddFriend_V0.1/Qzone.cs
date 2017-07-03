using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Drawing;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QQ_AddFriend_V0._1
{
    class Qzone
    {
        #region 变量
        private HttpMethod httpMethod;
        private string qqNumber;
        private string pwd;
        private string nick;
        private string textCode;
        private string verify;
        private string pt_uin;
        private string js_ver;
        private string login_sig;
        private string g_tk;
        private string skey;
        private string pgv_pvid;
        #endregion
        #region 访问器
        public string QQNumber
        {
            set { qqNumber = value; }
            get { return qqNumber; }
        }
        public string Pwd
        {
            set { pwd = value; }
        }
        public string Verify
        { set { verify = value; } }
        public string Nick
        { get { return nick; } }
        #endregion
        public Qzone()
        {
            httpMethod = new HttpMethod();
            //appid = "549000912";
            js_ver = "10043";
        }
        #region 交互方法
        // 初始化
        public bool get_Ui_Login()
        {
            string strUrl = "http://ui.ptlogin2.qq.com/cgi-bin/login?hide_title_bar=1&low_login=0&qlogin_auto_login=1&no_verifyimg=1&link_target=blank&appid=549000912&style=12&target=self&s_url=http%3A//qzs.qq.com/qzone/v5/loginsucc.html?para=izone&pt_qr_app=%CA%D6%BB%FAQQ%BF%D5%BC%E4&pt_qr_link=http%3A//z.qzone.com/download.html&self_regurl=http%3A//qzs.qq.com/qzone/v6/reg/index.html&pt_qr_help_link=http%3A//z.qzone.com/download.html";
            string referer = "http://qzone.qq.com/";
            httpMethod.AddCookie("_qz_referrer", "qzone.qq.com", "/", ".qq.com");
            string content = httpMethod.SendDataByGETtoString(strUrl,referer);
           // Debug.WriteLine("content----------->" + content);

            int left_index = content.IndexOf("login_sig:\"");
            int left_length = ("login_sig:\"").Length;
            login_sig = content.Substring(left_index + left_length, content.IndexOf("\",", left_index) - left_index - left_length);
            Debug.WriteLine("login_sig------>" + login_sig);
            if (login_sig.Length < 0) { Debug.WriteLine("get login_sig wrong"); return false; }
            if (!getPgvInfo()) { Debug.WriteLine("get pgv_info wrong"); return false; }
            if (!getPgvPvid()) { Debug.WriteLine("get pgv_pvid wrong"); return false; }
            httpMethod.AddCookie("ptui_version", "10045", "/", "ui.ptlogin2.qq.com");
            
            return true;
        }
        // 检查是否需要验证码
        public bool get_Check()
        {
            try
            {
                string strUrl = "http://check.ptlogin2.qq.com/check?regmaster=&uin=" + qqNumber + "&appid=549000912&js_ver=" + js_ver + "&js_type=1&login_sig=" + login_sig + "&u1=http%3A%2F%2Fqzs.qq.com%2Fqzone%2Fv5%2Floginsucc.html%3Fpara%3Dizone&r=0." + Tools.getRandString(15);
                Debug.WriteLine("strUrl-获取验证码-->" + strUrl);
                string referer = "http://ui.ptlogin2.qq.com/cgi-bin/login?hide_title_bar=1&low_login=0&qlogin_auto_login=1&no_verifyimg=1&link_target=blank&appid=549000912&style=12&target=self&s_url=http%3A//qzs.qq.com/qzone/v5/loginsucc.html?para=izone&pt_qr_app=%CA%D6%BB%FAQQ%BF%D5%BC%E4&pt_qr_link=http%3A//z.qzone.com/download.html&self_regurl=http%3A//qzs.qq.com/qzone/v6/reg/index.html&pt_qr_help_link=http%3A//z.qzone.com/download.html";
                string content = httpMethod.SendDataByGETtoString(strUrl, referer);
                //ptui_checkVC('0','!MXB','\x00\x00\x00\x00\x40\x58\x0f\xa7');
                Debug.WriteLine("content----->" + content);
                //ptui_checkVC('0','!WDE','\x00\x00\x00\x00\x12\x37\x24\x51');
                textCode = Tools.getMidOfTwoText(content, "','", "','");
                Debug.WriteLine("textCode----->" + textCode);
                pt_uin = content.Substring(content.LastIndexOf("','") + 3, 32);
                Debug.WriteLine("pt_uin----->" + pt_uin);
                httpMethod.AddCookie("ptui_loginuin", "xxx", "/", "qq.com");
                if (textCode.Length == 4) { return false; }
                return true;
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); return false; }
        }
        // 获取验证码图片
        public Image get_Image()
        {
            string strUrl = "http://captcha.qq.com/getimage?uin=" + qqNumber + "&aid=549000912&0." + Tools.getCurrentTimeStamp();
            string referer = "http://ui.ptlogin2.qq.com/cgi-bin/login?hide_title_bar=1&low_login=0&qlogin_auto_login=1&no_verifyimg=1&link_target=blank&appid=549000912&style=12&target=self&s_url=http%3A//qzs.qq.com/qzone/v5/loginsucc.html?para=izone&pt_qr_app=%CA%D6%BB%FAQQ%BF%D5%BC%E4&pt_qr_link=http%3A//z.qzone.com/download.html&self_regurl=http%3A//qzs.qq.com/qzone/v6/reg/index.html&pt_qr_help_link=http%3A//z.qzone.com/download.html";
            Stream myResponseStream = httpMethod.SendDataByGETtoStream(strUrl, referer);
            Image image = Image.FromStream(myResponseStream);
            myResponseStream.Close();
            return image;
        }
        // 登陆
        public bool get_Login()
        {
            try
            {
                string code;
                if (textCode.Length == 4) { code = textCode; }
                else { code = verify; }

                string[] argc = { pwd, code, pt_uin };
                string md5Pwd = Tools.runJS(@"JS/QQ.js", "func", argc);
                Debug.WriteLine("md5Pwd--->" + md5Pwd);
                Debug.WriteLine("code--->" + code);
                Debug.WriteLine("qqNumber--->" + qqNumber);
                Debug.WriteLine("login_sig--->" + login_sig);
                
                string strUrl = "http://ptlogin2.qq.com/login?u=" + qqNumber + "&p=" + md5Pwd + "&verifycode=" + code + "&aid=549000912&u1=http%3A%2F%2Fqzs.qq.com%2Fqzone%2Fv5%2Floginsucc.html%3Fpara%3Dizone&h=1&ptredirect=0&ptlang=2052&from_ui=1&dumy=&low_login_enable=0&regmaster=&fp=loginerroralert&action=4-52-1378898628282&mibao_css=&t=1&g=1&js_ver=" + js_ver + "&js_type=1&login_sig=" + login_sig;
                string referer = "http://ui.ptlogin2.qq.com/cgi-bin/login?hide_title_bar=1&low_login=0&qlogin_auto_login=1&no_verifyimg=1&link_target=blank&appid=549000912&style=12&target=self&s_url=http%3A//qzs.qq.com/qzone/v5/loginsucc.html?para=izone&pt_qr_app=%CA%D6%BB%FAQQ%BF%D5%BC%E4&pt_qr_link=http%3A//z.qzone.com/download.html&self_regurl=http%3A//qzs.qq.com/qzone/v6/reg/index.html&pt_qr_help_link=http%3A//z.qzone.com/download.html";
                string content = httpMethod.SendDataByGETtoString(strUrl, referer);
                // ptuiCB('0','0','http://qzs.qq.com/qzone/v5/loginsucc.html?para=izone','0','登录成功！', '小晶');
                Debug.WriteLine("content--->" + content);
                if (!content.Contains("登录成功！")) { Debug.WriteLine("登陆失败"); return false; }
                nick = Tools.getMidOfTwoText(content, "登录成功！', '", "');");
                Debug.WriteLine(nick);
                //check_sig_Url = Tools.getMidOfTwoText(content, "ptuiCB('0','0','", "','0','登录成功");
                //Debug.WriteLine(check_sig_Url);
                //if (!get_LoginSucc()) { Debug.WriteLine("获取loginsucc失败"); return false; }
                if (!get_HostPage()) { Debug.WriteLine("获取个人主页失败"); return false; }
                if (!getG_TK()) { Debug.WriteLine("get g_tk wrong"); return false; }

                return true;
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); return false; }

        }
        // 获取主页,这里要接收几个cookie，所以必须要
        private bool get_HostPage()
        {
            string strUrl = "http://user.qzone.qq.com/" + qqNumber;
            string referer = " http://qzs.qq.com/qzone/v5/loginsucc.html?para=izone";
            string content = httpMethod.SendDataByGETtoString(strUrl, referer);
            Debug.WriteLine("content----->" + content);
            if (!content.Contains("个人中心")) { Debug.WriteLine("获取个人主页失败"); return false; }

            httpMethod.AddCookie("randomSeed", Tools.getRandString(6), "/", "qzone.qq.com");
            httpMethod.AddCookie("cpu_performance", "3", "/", "qzone.qq.com");
            httpMethod.AddCookie("__Q_w_s__QZN_TodoMsgCnt", "1", "/", "qzone.qq.com");
            return true;
        }
        // 获取加好友的验证类型
        public bool get_Friend_Authfriend(string friendQQ)
        {
            
            string cookie = httpMethod.getCookieAll();
            Debug.WriteLine("cookie----->" + cookie);
            try
            {
                string strUrl = "http://w.cnc.qzone.qq.com/cgi-bin/tfriend/friend_authfriend.cgi?g_tk=" + g_tk;
                Debug.WriteLine("strUrl----->" + strUrl);
                string referer = "http://cnc.qzs.qq.com/qzone/v6/friend_manage/addfriend/index.html";
                string strPostData = "qzreferrer=http%3A%2F%2Fcnc.qzs.qq.com%2Fqzone%2Fv6%2Ffriend_manage%2Faddfriend%2Findex.html%23ouin%3D" + friendQQ + "%26sid%3D0%26from%3D9&sid=0&ouin=" + friendQQ + "&uin=" + qqNumber + "&fupdate=1";
                Debug.WriteLine("strPostData----->" + strPostData);
                string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
                Debug.WriteLine("content---->" + content);
                
                string right = "frameElement.callback(";
                string left = ");";
                int right_index = content.IndexOf(right);
                int left_index = content.IndexOf(left);
                string result = content.Substring(right_index + right.Length, left_index - right_index - right.Length);
                JObject obj = (JObject)JsonConvert.DeserializeObject(result);
                if ((int)obj["code"] != 0) { return false; }
                post_Friend_Addfriend(obj, friendQQ);
                return true;
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); return false; }
        }
        // 加好友
        private bool post_Friend_Addfriend(JObject obj, string friendQQ)
        {
            /**
                 * {
	                    "code":0,
	                    "subcode":0,
	                    "message":"",
	                    "default":0,
	                    "data":{"state":3,"question":"我的名字"}
                    }**/
            
            JObject data = (JObject)obj["data"];
            int state = (int)data["state"];
            /**
             * state
             *  0:直接加好友
             *  1：需要输入验证消息
             *  2：对方设置了权限，不能加好友
             *  3：需要回答验证问题
             *  **/
            string strUrl = "http://w.cnc.qzone.qq.com/cgi-bin/tfriend/friend_addfriend.cgi?g_tk=" + g_tk;
            string referer = "http://cnc.qzs.qq.com/qzone/v6/friend_manage/addfriend/index.html";
            int groupId = 0;
            switch (state)
            {
                case 0: 
                    {
                        //string Msg = "你好";
                        string strPostData = "qzreferrer=http%3A%2F%2Fcnc.qzs.qq.com%2Fqzone%2Fv6%2Ffriend_manage%2Faddfriend%2Findex.html%23ouin%3D" + friendQQ + "%26sid%3D0%26from%3D9&sid=0&ouin=" + friendQQ + "&uin=" + qqNumber + "&fupdate=1&rd=0." + Tools.getRandString(16) + "&flag=0&groupId=" + groupId + "&chat=&key=&im=0&g_tk=" + g_tk + "&from=9";
                        string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
                        if (!content.Contains("添加QQ好友成功")) { Debug.WriteLine("加好友失败"); return false; } 
                        break;
                    }
                case 1:
                    {
                        //return false;// 输入信息的跳过
                        string Msg = "你好";
                        string strPostData = "qzreferrer=http%3A%2F%2Fcnc.qzs.qq.com%2Fqzone%2Fv6%2Ffriend_manage%2Faddfriend%2Findex.html%23ouin%3D" + friendQQ + "%26sid%3D0%26from%3D9&sid=0&ouin=" + friendQQ + "&uin=" + qqNumber + "&fupdate=1&rd=0." + Tools.getRandString(16) + "&strmsg=" + Msg + "&flag=0&groupId=" + groupId + "&chat=&key=&im=0&g_tk=" + g_tk + "&from=9";
                        string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
                        if (!content.Contains("申请已发送，请等待对方在QQ上确认")) { Debug.WriteLine("加好友发送失败"); return false; }
                        break;
                    }
                case 2: { Debug.WriteLine("对方设置了权限，不能加好友"); return false; }
                case 3:
                    {
                       // return false;// 回答问题的跳过
                        string question = data["question"].ToString();
                        string Answer = "想交个朋友";
                        string strPostData = "qzreferrer=http%3A%2F%2Fcnc.qzs.qq.com%2Fqzone%2Fv6%2Ffriend_manage%2Faddfriend%2Findex.html%23ouin%3D" + friendQQ + "%26sid%3D0%26from%3D9&sid=0&ouin="+friendQQ+"&uin="+qqNumber+"&fupdate=1&rd=0."+Tools.getRandString(16)+"&ans0="+Answer+"&flag=0&groupId="+groupId+"&chat=&key=&im=0&g_tk="+g_tk+"&from=9";
                        string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
                        if (!content.Contains("申请已发送，请等待对方在QQ上确认")) { Debug.WriteLine("加好友发送失败"); return false; }
                        break;
                    }
                default: 
                    {
                        Debug.WriteLine("未知类型，code:" + state);
                        break;
                    }
            }
            return true;
        }
        // 发布说说
        public bool post_emotion_cgi_publish_v6(string Msg)
        {
            try
            {
                string strUrl = "http://taotao.qq.com/cgi-bin/emotion_cgi_publish_v6?g_tk=" + g_tk + "&g_tk=" + g_tk;
                string referer = "http://user.qzone.qq.com/" + qqNumber;
                string strPostData = "syn_tweet_verson=1&pic_template=&richtype=&richval=&special_url=&subrichtype=&who=1&con=" + Msg + "&feedversion=1&ver=1&ugc_right=1&to_tweet=0&to_sign=0&hostuin=" + qqNumber + "&code_version=1&format=fs&qzreferrer=http%3A%2F%2Fuser.qzone.qq.com%2F" + qqNumber;
                string content = httpMethod.SendDataByPost(strUrl, strPostData, referer);
                Debug.WriteLine(content);
                return true;
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); return false; }
        }
        #endregion
        #region JS
        private bool getG_TK()
        {
            try
            {
                skey = httpMethod.getCookieValue("skey", "http://qq.com");
                
                Debug.WriteLine("skey----->" + skey);
                string[] argc = {  skey};
                g_tk = Tools.runJS(@"JS/g_tk.js", "func", argc);
                Debug.WriteLine("g_tk----->" + g_tk);
                if (g_tk.Length > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }

        }
        private bool getPgvInfo()
        {
            try
            {


                string[] argc = { "1" };
                string pgv_info = Tools.runJS(@"JS/pgv_info.js", "func", argc);
                Debug.WriteLine("pgv_info----->" + pgv_info);
                if (pgv_info.Length > 0)
                {
                    httpMethod.AddCookie("pgv_info", pgv_info, "/", "qq.com");
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
        private bool getPgvPvid()
        {
            try
            {


                string[] argc = { "1" };
                pgv_pvid = Tools.runJS(@"JS/pgv_pvid.js", "func", argc);
                Debug.WriteLine("pgv_pvid----->" + pgv_pvid);
                if (pgv_pvid.Length > 0)
                {
                    httpMethod.AddCookie("pgv_pvid", pgv_pvid, "/", "qq.com");
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
        #endregion
    }
}
