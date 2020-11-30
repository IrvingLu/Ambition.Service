using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Infrastructure.Core.Redis
{
    public static class CacheDefaults
    {
        /// <summary>
        /// Gets the default cache time in minutes
        /// </summary>
        public static int CacheTime => 86400;
    }
}
