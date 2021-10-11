using System;
using System.Reflection;
using System.Text;

namespace NMS.RTIS.Core.Tools
{
    /// <summary>
    /// 功能描述    ：静态类
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 获取对象属性名称和值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>用&拼接的结果</returns>
        public static string GetPropertyNameAndValue(object obj)
        {
            if (obj == null) { return string.Empty; }
            StringBuilder result = new StringBuilder();
            try
            {
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    object valueObj = pi.GetValue(obj, null);
                    if (valueObj == null) { continue; }
                    Type valueType = valueObj.GetType();
                    if (valueType != typeof(object) && Type.GetTypeCode(valueType) == TypeCode.Object)//判断是自定义类
                    {
                        PropertyInfo[] classProperty = valueType.GetProperties();
                        foreach (PropertyInfo property in classProperty)
                        {
                            object childValueObj = property.GetValue(valueObj, null);
                            if (childValueObj == null) { continue; }
                            result.Append(pi.Name + "." + property.Name + "=" + childValueObj.ToString() + "&");
                        }
                    }
                    else
                    {
                        result.Append(pi.Name + "=" + valueObj.ToString() + "&");
                    }
                }
            }
            catch (Exception)
            {
            }
            return result.ToString().TrimEnd('&');
        }
        /// <summary>
        /// 获取6位随机数
        /// </summary>
        /// <returns></returns>
        public static int GetSmsCode()
        {
            Random rd = new Random();
            int num = rd.Next(100000, 1000000);
            return num;
        }
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}
