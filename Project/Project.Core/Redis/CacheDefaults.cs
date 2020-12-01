using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Infrastructure.Core.Redis
{
    public static class CacheDefaults
    {
        /// <summary>
        /// 默认过期时间
        /// </summary>
        public static int CacheTime => 86400;
    }
}
