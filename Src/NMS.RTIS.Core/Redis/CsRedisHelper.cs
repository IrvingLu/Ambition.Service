/**********************************************************************
* 命名空间：NMS.RTIS.Core.Redis
*
* 功  能：Redis
* 类  名：CsRedisHelper
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System;

namespace NMS.RTIS.Core.Redis
{
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
