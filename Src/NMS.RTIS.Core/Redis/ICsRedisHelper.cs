/**********************************************************************
* 命名空间：NMS.RTIS.Core.Redis
*
* 功  能：Redis接口
* 类  名：ICsRedisHelper
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System;

namespace NMS.RTIS.Core.Redis
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
    }
}
