using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSScriptControl;
using System.IO;
using System.Diagnostics;

namespace sendGroupMsg
{
    class Tools
    {
        // 返回low与high之间的随机整数
        public static int getRandInt(int low, int high)
        {
            Random rand = new Random();
            int i = rand.Next() % (high - low + 1) + low;
            return i;
        }
        // 返回low与high之间的随机整数
        public static string getRandString(int low, int high)
        {
            int i = getRandInt(low, high);
            return i.ToString();
        }
        // 返回length长度的随机数
        public static string getRandString(int length)
        {
            Random rand = new Random();
            string str = null;
            for (int i = 0; i < length; i++)
            {
                int r = rand.Next() % 10;
                str = str + r.ToString();
            }
            return str;
        }
        // 取两字符串之间
        public static string getMidOfTwoText(string content, string left, string right)
        {
            return content.Substring(content.IndexOf(left) + left.Length, content.LastIndexOf(right) - content.IndexOf(left) - left.Length);
        }
        // 运行JS脚本
        public static string runJS(string filename, string funname, string[] argc)
        {
            int _paramsLen = argc.Length;
            object[] _params = new object[_paramsLen];   
            for(int i = 0; i < _paramsLen ;i++)//参数赋值   
            {   
                _params[i] = argc[i];   
            }   
            ScriptControlClass js = new ScriptControlClass();//使用ScriptControlClass  
            js.Language = "javascript";  
            js.Reset();
            string text = readFile(filename);
            if (text == null) { Debug.WriteLine("读取文件失败"); return null; }
            js.Eval(readFile(filename));//指向js脚本  @"JS/QQ.js"
            object result = js.Run("func", _params);//传入参数执行

            return result.ToString();
        }
        // 读取文件，返回文本
        public static string readFile(string filename)
        {
            // 读取文件的源路径及其读取流
            //string strReadFilePath = @"..\..\data\ReadLog.txt";
            string text = null;
            StreamReader srReadFile = null;
            try
            {
                srReadFile = new StreamReader(filename);
                /*/ 读取流直至文件末尾结束
                while (!srReadFile.EndOfStream)
                {
                    string strReadLine = srReadFile.ReadLine(); //读取每行数据
                    Console.WriteLine(strReadLine); //屏幕打印每行数据
                }
                 * */
                text = srReadFile.ReadToEnd();
                srReadFile.Close();
            }
            catch
            {
                Debug.WriteLine("找不到文件");
                
            }
            
            return text;

        }
        // 获取时间戳
        public static string getCurrentTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);  
            return Convert.ToInt64(ts.TotalSeconds).ToString();  

        }
        // 获取格式化时间
        public static string getTimeNow()
        {
            return DateTime.Now.ToString();
        }
        // 实现编码转换
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.GetEncoding("gb2312").GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }
        // 将图片转换成字节及
        public static byte[] GetBytesByImagePath(string strFile)
        {
            byte[] photo_byte = null;
            using (FileStream fs =
               new FileStream(strFile, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    photo_byte = br.ReadBytes((int)fs.Length);
                }
            }

            return photo_byte;
        }
        
    }
}
