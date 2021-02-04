using System;

namespace Project.Core.Redis
{
    /// <summary>
    /// 功能描述    ：redis
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public interface ICsRedisHelper
    {
        /// <summary>
        /// 获取缓存（如果没有直接设置）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        T Get<T>(string key, Func<T> acquire);
    }
}
