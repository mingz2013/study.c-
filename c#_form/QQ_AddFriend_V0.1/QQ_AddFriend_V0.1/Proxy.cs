using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace QQ_AddFriend_V0._1
{
    class Proxy
    {
        /*
        public static string readFile(string filename)
        {
            // 读取文件的源路径及其读取流
            //string strReadFilePath = @"..\..\data\ReadLog.txt";
            string text = null;
            StreamReader srReadFile = null;
            try
            {
                srReadFile = new StreamReader(filename);
                *//*/ 读取流直至文件末尾结束
                while (!srReadFile.EndOfStream)
                {
                    string strReadLine = srReadFile.ReadLine(); //读取每行数据
                    Console.WriteLine(strReadLine); //屏幕打印每行数据
                }
                 * *//*
                text = srReadFile.ReadToEnd();
            }
            catch
            {
                Debug.WriteLine("找不到文件");

            }
            finally
            {
                // 关闭读取流文件
                srReadFile.Close();
            }
            return text;
        }
*/
        /*
        public static string checkProxy(string IP, int port)
        {
            bool isok = true;
            string rs = null;
            while (isok)
            {
                try
                {
                    //设置代理IP
                    WebProxy proxyObject = new WebProxy(IP, port);
                    //向指定地址发送请求
                    HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("http://www.baidu.com");
                    HttpWReq.Proxy = proxyObject;
                    HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                    //HttpWReq.Timeout = 10000;
                    StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
                    string xmlContent = sr.ReadToEnd().Trim();
                    sr.Close();
                    HttpWResp.Close();
                    HttpWReq.Abort();
                    rs = xmlContent;
                    isok = false;
                }
                catch (Exception)
                {
                    isok = false;
                    rs = "Error";
                }
            }
            return rs;
        }
*/
        #region 代理IP检测

        /// <summary>
        /// 代理IP检测
        /// </summary>
        /// <param name="sIP"></param>
        /// <param name="iTimeOut"></param>
        /// <returns></returns>
        public static bool checkProxy(string sIP,int port, int iTimeOut = 2000)
        {
            /*------------------------------*/
            /* 变量定义                        */
            /*------------------------------*/
            string sUrl;
            HttpWebRequest request;
            WebProxy webPro;
            if (sIP != null && sIP.Trim().Length > 0)
            {
                webPro = new WebProxy(sIP, port);
            }
            else
            {
                //webPro = new WebProxy();
                return false;
            }
            
            DateTime dBegTime = DateTime.Now;


            /*------------------------------*/
            /* 赋值                              */
            /*------------------------------*/
            sUrl = "http://www.google.com";
            request = (HttpWebRequest)HttpWebRequest.Create(sUrl);
         /*   if (sIP != null && sIP.Trim().Length > 0)
            {
                //代理设置  
                webPro.Address = new Uri("http://" + sIP);
                webPro.
            }
           */ 



            /*------------------------------*/
            /*发送请求                         */
            /*------------------------------*/
            try
            {
                request.Timeout = iTimeOut;
                request.ReadWriteTimeout = iTimeOut;
                request.ContentType = "text/xml";
                if (sIP != null && sIP.Trim().Length > 0)
                {
                    request.Proxy = webPro;
                }
                request.GetResponse();
                DateTime dEndTime = DateTime.Now;
            }
            catch
            {
                request.Abort();
                return false;
            }

            request.Abort();
            return true;

        }
        #endregion
        /*
        public static bool setProxy(string IP, int port)
        {

            return true;
        }
        public static bool stopProxy()
        {
            return true;
        }
         * */
    }
}
