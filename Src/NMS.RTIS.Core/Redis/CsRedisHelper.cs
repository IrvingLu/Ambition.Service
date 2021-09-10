using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMS.RTIS.Core.Redis
{
    /// <summary>
    /// 功能描述    ：redis
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class CsRedisHelper : ICsRedisHelper
    {
        /// <summary>
        /// 获取缓存（如果没有直接设置）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        public T Get<T>(string key, Func<T> acquire)
        {
            //异步进行redis查询，增大吞吐量        
            if (RedisHelper.Exists(key))
            {
                return RedisHelper.Get<T>(key);
            }
            var result = acquire();
            RedisHelper.Set(key, result, CacheDefaults.CacheTime);
            return result;
        }
    }
}
