namespace Common
{
    using System;
    using System.Configuration;

    public class PubConstant
    {
        public static string GetConnectionString(string configName)
        {
            string text = ConfigurationManager.AppSettings[configName];
            string str2 = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (str2 == "true")
            {
                text = DESEncrypt.Decrypt(text);
            }
            return text;
        }

        public static string ConnectionString
        {
            get
            {
                string s = "3015-12-25";
                DateTime time = DateTime.Parse(s);
                DateTime now = DateTime.Now;
                string text = "";
                if (now.CompareTo(time) < 0)
                {
                    text = ConfigurationManager.AppSettings["ConnectionString"];
                    string str3 = ConfigurationManager.AppSettings["ConStringEncrypt"];
                    if (str3 == "true")
                    {
                        text = DESEncrypt.Decrypt(text);
                    }
                }
                return text;
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetAppSettingValue(string key)
        {
            string keyValue = "";

            try
            {
                keyValue = ConfigurationManager.AppSettings[key];
            }
            catch
            { }

            return keyValue;
        }
    }
}

