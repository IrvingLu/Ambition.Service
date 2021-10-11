/**********************************************************************
* 命名空间：NMS.RTIS.Core.Configuration
*
* 功  能：Mongodb配置
* 类  名：ValueObject
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

namespace NMS.RTIS.Core.Configuration
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
