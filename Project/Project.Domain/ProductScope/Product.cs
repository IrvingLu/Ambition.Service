namespace Project.Domain.Product
{
    /// <summary>
    /// 功能描述    ：产品聚合根表
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class Product: Entity,IAggregateRoot
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品图片地址
        /// </summary>
        public string PicPath { get; set; }
    }


}
