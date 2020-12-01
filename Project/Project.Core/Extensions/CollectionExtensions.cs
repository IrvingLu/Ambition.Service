using System;
using System.Collections.Generic;

namespace Project.Web.Core.Extensions
{
    /// <summary>
    /// 集合扩展
    /// </summary>
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
