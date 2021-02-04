namespace Project.Core.Configuration
{
    /// <summary>
    /// 功能描述    ：Mongodb配置
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/4 9:40:56 
    /// </summary>
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
