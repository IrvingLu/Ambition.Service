using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Cache
{
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
        T GetData<T>(string key);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="redisType"></param>
        /// <returns></returns>
        Task DelAsync(string key, string field = "", RedisType redisType = RedisType.String);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Task DelAsync(string[] keys);

        /// <summary>
        ///写入缓存，注意：缓存过期时间手动设置随机值，防止所有key同一时间大面积失效，造成缓存雪崩！！！
        /// 通过RedisType判断使用redis哪种存储类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="field"></param>
        /// <param name="cacheTime"></param>
        /// <param name="redisType"></param>
        /// <returns></returns>
        Task Set(string key, string field, string value, RedisType redisType, int cacheTime = 0);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field">可为null</param>
        /// <param name="redisType">默认String</param>
        /// <returns></returns>
        Task<T> Get<T>(string key, string field, RedisType redisType);

        void Set<T>(string key, T list);
        Task<Dictionary<string, T>> GetAllAsync<T>(string key);

    }
}
