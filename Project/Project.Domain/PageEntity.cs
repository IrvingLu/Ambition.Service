namespace Project.Domain
{

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
