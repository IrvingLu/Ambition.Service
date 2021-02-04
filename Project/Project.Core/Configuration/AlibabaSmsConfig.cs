using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Configuration
{
    /// <summary>
    /// 功能描述    ：AlibabaSmsConfig  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/2/4 14:28:16 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/4 14:28:16 
    /// </summary>
    public class AlibabaSmsConfig
    {
        /// <summary>
        /// Key
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Secret 
        /// </summary>
        public string AccessSecret { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }
}
