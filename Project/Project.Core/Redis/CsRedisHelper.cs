using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Core.Redis
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

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetData<T>(string key)
        {
            //异步进行redis查询，增大吞吐量        
            if (RedisHelper.Exists(key))
            {
                return RedisHelper.Get<T>(key);
            }
            else
            {
                return default;
            }
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public async Task DelAsync(string[] keys)
        {
            await RedisHelper.DelAsync(keys);
        }


        /// <summary>
        /// 写入缓存，注意：缓存过期时间手动设置随机值，防止所有key同一时间大面积失效，造成缓存雪崩！！！
        /// 通过RedisType判断使用redis哪种存储类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        /// <param name="redisType"></param>
        /// <returns></returns>
        public async Task Set(string key, string field, string value, RedisType redisType, int cacheTime = 0)
        {
            switch (redisType)
            {
                case RedisType.Set:
                    await RedisHelper.HSetAsync(key, field, value);
                    if (cacheTime != 0)
                    {
                        var time = new TimeSpan(DateTime.Now.Ticks + cacheTime);
                        var cacheMinutes = TimeSpan.FromMinutes(cacheTime);
                        await RedisHelper.ExpireAsync(key, time + cacheMinutes);
                    }
                    break;
                case RedisType.String:
                default:
                    if (RedisHelper.Exists(key))
                    {
                        await RedisHelper.DelAsync(key);
                    }
                    await RedisHelper.SetAsync(key, value, cacheTime);
                    break;
            }
        }



        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="redisType"></param>
        /// <returns></returns>
        public async Task DelAsync(string key, string field = "", RedisType redisType = RedisType.String)
        {
            switch (redisType)
            {
                case RedisType.String:
                    await RedisHelper.DelAsync(key);
                    break;
                case RedisType.Set:
                    await RedisHelper.HDelAsync(key, field);
                    break;
                default:
                    break;
            }

        }
        public void Set<T>(string key, T list)
        {
            if (RedisHelper.Exists(key))
            {
                RedisHelper.Del(key);
            }
            RedisHelper.Set(key, list, 0);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="redisType"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string key, string field, RedisType redisType)
        {
            switch (redisType)
            {
                case RedisType.Set:
                    return await RedisHelper.HGetAsync<T>(key, field);
                case RedisType.String:
                default:
                    return await RedisHelper.GetAsync<T>(key);

            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, T>> GetAllAsync<T>(string key)
        {
            return await RedisHelper.HGetAllAsync<T>(key);
        }
    }

    public enum RedisType
    {
        String,
        Set
    }
}
