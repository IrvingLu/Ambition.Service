/**********************************************************************
* 命名空间：NMS.RTIS.Core.Extensions
*
* 功  能：集合扩展方法
* 类  名：CollectionExtensions
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System.Collections.Generic;

namespace NMS.RTIS.Web.Core.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// 判断是否为空
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }
    }
}
