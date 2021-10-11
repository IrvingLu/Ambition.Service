/**********************************************************************
* 命名空间：NMS.RTIS.Core.Redis
*
* 功  能：Redis配置文件
* 类  名：CacheDefaults
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

namespace NMS.RTIS.Core.Redis
{
    public static class CacheDefaults
    {
        /// <summary>
        /// 默认过期时间
        /// </summary>
        public static int CacheTime => 86400;
    }
}
