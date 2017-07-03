using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qzone
{
    class Qzone
    {
        #region 变量声明
        private HttpMethod httpMethod;
        private string qqNumber = null;
        private string password = null;
        private string verifycode = null;
        #endregion
        #region 属性访问器
        public string QQNumber
        { set { qqNumber = value; }
            get { return qqNumber; }
        }
        public string Password
        {
            set { password = value; } 
        }
        public string Verifycode
        { set { verifycode = value; } }
        #endregion 
        // 构造函数
        public Qzone()
        {
            httpMethod = new HttpMethod();
        }
    }
}
