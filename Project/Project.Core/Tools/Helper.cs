using System;
using System.Reflection;
using System.Text;

namespace Project.Infrastructure.Core.Tools
{
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
    }
}
