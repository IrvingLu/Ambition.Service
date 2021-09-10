namespace NMS.RTIS.Core.Abstractions
{
    /// <summary>
    /// 功能描述    ：分页实体
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public abstract class PageEntity
    {
        /// <summary>
        /// 第几个页面
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页面显示多少
        /// </summary>
        public int PageSize { get; set; }
    }
}
