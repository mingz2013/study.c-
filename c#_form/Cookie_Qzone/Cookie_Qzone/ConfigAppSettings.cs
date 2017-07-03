using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

using System.Configuration;// 需要引用system.configuration.dll

namespace Qzone_Add_Friend
{
    /// <summary>
    /// 对exe.Config文件中的appSettings段进行读写配置操作
    /// 注意：调试时，写操作将写在vhost.exe.config文件中
    /// 需要注意的是，在IDE调试时，写入的配置文件其实是写在了.vshost.exe.config文件中，
    /// 所以你在.exe.config中是看不到的。只有直接运行exe文件时，才会正确写入到.exe.config中。
    /// </summary>
    public class ConfigAppSettings
    {  
        // 写入值  
        public static void SetValue(string key, string value)
        {
            //增加的内容写在appSettings段下 <add key="RegCode" value="0"/>  
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");//重新加载新的配置文件   
        }
        // 读取指定key的值  
        public static string GetValue(string key)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                return "";
            else
                return config.AppSettings.Settings[key].Value;
        }  

    }
}
