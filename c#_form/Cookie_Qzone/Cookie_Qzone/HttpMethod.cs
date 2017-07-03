using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using System.Diagnostics;

namespace Cookie_Qzone
{
    class HttpMethod
    {
        private CookieContainer cookieContainer;

        // 构造函数
        public HttpMethod()
        {
            cookieContainer = new CookieContainer();
        }
        // set cookie
        public void AddCookie(string strKey, string strValue, string strPath, string strDomain)
        {
            cookieContainer.Add(new Cookie(strKey, strValue, strPath, strDomain));
        }
        // 获取cookie的值
        public string getCookieValue(string strKey, string strDomain)
        {
            string str = cookieContainer.GetCookieHeader(new Uri(strDomain));
            Debug.WriteLine(str);
            string[] strArray = str.Split(' ');
            ﻿﻿for (int i = 0; i < strArray.Length; i++)
              {
                  if (strArray[i].Contains(strKey))
                  {
                      string[] strArray2 = strArray[i].Split('=');
                      Debug.WriteLine("skey----->" + strArray2[1]);// @aXn9enPgS;  多了个分号  晕
                      string skey = strArray2[1].Substring(0, strArray2[1].Length - 1);
                      return skey;
                  }
              }
              return null;
        }
        // 获取所有的cookie
        public string getCookieAll()
        {
            return cookieContainer.GetCookieHeader(new Uri("http://qq.com")) + cookieContainer.GetCookieHeader(new Uri("http://qzone.qq.com")) + cookieContainer.GetCookieHeader(new Uri("http://user.qzone.qq.com"));
        }
        // 通过POST方式发送数据
        public string SendDataByPost(string strUrl, string postDataStr, string referer = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            if (cookieContainer.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookieContainer = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookieContainer;
            }
            if (referer != null)
            {
                request.Referer = referer;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //ASCIIEncoding dataEncode = new ASCIIEncoding();
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] byteArray = encoding.GetBytes(postDataStr); //转化
            request.ContentLength = byteArray.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(byteArray, 0, byteArray.Length);//写入参数本文来
            // StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            //myStreamWriter.Write(byteArray);
            //myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string cc = response.Headers.Get("Set-Cookie");
            if (cc != null)
            {
                cookieContainer.SetCookies(new Uri(strUrl), cc);
            }
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        // 通过GET方式发送数据
        public Stream SendDataByGETtoStream(string strUrl, string referer = null)
        {
            Stream myResponseStream = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            if (cookieContainer.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookieContainer = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookieContainer;
            }
            if (referer != null)
            {
                request.Referer = referer;
            }
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string cc = response.Headers.Get("Set-Cookie");
            if (cc != null)
            {
                cookieContainer.SetCookies(new Uri(strUrl), cc);
            }
            myResponseStream = response.GetResponseStream();

            return myResponseStream;
        }
        // 通过GET方式发送数据
        public string SendDataByGETtoString(string strUrl, string referer = null, string encoding = "utf-8")
        {
            string retString;

            Stream myResponseStream = SendDataByGETtoStream(strUrl, referer);
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(encoding));
            retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        // 通过POST方式发送数据
        public static string SendDataByPost(string strUrl, string postDataStr, string cookies, string referer = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);


            request.CookieContainer = new CookieContainer();
            CookieContainer cookieContainer = request.CookieContainer;
            cookieContainer.SetCookies(new Uri(strUrl), cookies);
            request.CookieContainer = cookieContainer;

            if (referer != null)
            {
                request.Referer = referer;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //ASCIIEncoding dataEncode = new ASCIIEncoding();
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] byteArray = encoding.GetBytes(postDataStr); //转化
            request.ContentLength = byteArray.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(byteArray, 0, byteArray.Length);//写入参数本文来
            // StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            //myStreamWriter.Write(byteArray);
            //myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string cc = response.Headers.Get("Set-Cookie");
            if (cc != null)
            {
                cookieContainer.SetCookies(new Uri(strUrl), cc);
            }
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

    }
}
