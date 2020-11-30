using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Infrastructure.Core.Configuration
{
   public class MongodbHostConfig
    {
        /// <summary>
        /// 连接地址
        /// </summary>
        public string Connection { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public string DataBase { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        public string Table { get; set; }
    }
}
