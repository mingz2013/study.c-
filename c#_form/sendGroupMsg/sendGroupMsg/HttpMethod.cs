using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using System.Diagnostics;
using System.Collections.Specialized;

namespace sendGroupMsg
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
                      //Debug.WriteLine("skey----->" + strArray2[1]);// @aXn9enPgS;  多了个分号  晕
                      string value = strArray2[1].ToString();

                      if (value.Substring(strArray2[1].Length - 1) == ";")
                      {
                          value = value.Substring(0, strArray2[1].Length - 1);
                      }
                      return value;
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

        public string SendDataByPost(string strUrl, byte[] postDataByte, string referer = null, string ContentType = "application/x-www-form-urlencoded")
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
            request.ContentType = ContentType;
            //ASCIIEncoding dataEncode = new ASCIIEncoding();
            //Encoding encoding = Encoding.GetEncoding("UTF-8");
            //byte[] byteArray = encoding.GetBytes(postDataStr); //转化
            request.ContentLength = postDataByte.Length;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postDataByte, 0, postDataByte.Length);//写入参数本文来
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
        public string SendDataByPost(string strUrl, string postDataStr, string referer = null, string ContentType = "application/x-www-form-urlencoded")
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] byteArray = encoding.GetBytes(postDataStr); //转化
            string retString = SendDataByPost(strUrl, byteArray, referer, ContentType);
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


        /// <summary> 
        /// 上传图片文件 
        /// </summary> 
        /// <param name="url">提交的地址</param> 
        /// <param name="poststr">发送的文本串   比如：user=eking&pass=123456  </param> 
        /// <param name="fileformname">文本域的名称  比如：name="file"，那么fileformname=file  </param> 
        /// <param name="filepath">上传的文件路径  比如： c:\12.jpg </param> 
        /// <param name="cookie">cookie数据</param> 
        /// <param name="refre">头部的跳转地址</param> 
        /// <returns></returns> 
        public string SendImgByPOSTtoString(string strUrl, string poststr,string fileformname, string filepath, string referer)
        {
            // 这个可以是改变的，也可以是下面这个固定的字符串 
            string boundary = "---------------------------" + Tools.getRandString(14);
            
            // 创建request对象 
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
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";

            

            // 构造发送数据
            StringBuilder sb = new StringBuilder();

            // 文本域的数据，将user=eking&pass=123456  格式的文本域拆分 ，然后构造 
            foreach (string c in poststr.Split('&'))
            {
                string[] item = c.Split('=');
                if (item.Length != 2)
                {
                    break;
                }
                string name = item[0];
                string value = item[1];
                sb.Append("--" + boundary);
                sb.Append("\r\n");
                sb.Append("Content-Disposition: form-data; name=\"" + name + "\"");
                sb.Append("\r\n\r\n");
                sb.Append(value);
                sb.Append("\r\n");
                Debug.WriteLine(name + "------------------" + value);
            }

            // 文件域的数据
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"" + fileformname + "\"; filename=\"" + filepath.Split('\\').Last() + "\"");
            sb.Append("\r\n");

            sb.Append("Content-Type: ");
            sb.Append("image/" + filepath.Split('.').Last());
            sb.Append("\r\n\r\n");

            string postHeader = sb.ToString();
            Debug.WriteLine("postheader------->" + postHeader);
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

            //构造尾部数据 
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            Debug.WriteLine("boundaryBytes--->" + boundaryBytes);
            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            request.ContentLength = length;

            Stream requestStream = request.GetRequestStream();

            // 输入头部数据 
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // 输入文件流数据 
            byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);

            // 输入尾部数据 
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            WebResponse responce = request.GetResponse();
            myResponseStream = responce.GetResponseStream();
            StreamReader sr = new StreamReader(myResponseStream);

            // 返回数据流(源码) 
            return sr.ReadToEnd();
        }

        /*
        public string HttpUploadFile(string url, string file, string paramName, string referer, NameValueCollection nvc)
        {
            string result = string.Empty;
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.Referer = referer;
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string contentType = "image/" + file.Split('.').Last();
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);

                result = reader2.ReadToEnd();
            }
            catch (Exception ex)
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }

            return result;
        }
        */
    }
}
