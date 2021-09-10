namespace NMS.RTIS.Core.BaseDto
{
    /// <summary>
    /// 功能描述    ：分页返回
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/4 9:40:56 
    /// </summary>
    public class PagedResultDto
    {
        public int TotalCount { get; set; }

        public object Data { get; set; }

        public PagedResultDto()
        {

        }
        public PagedResultDto(int totalCount, object data)
        { 
            TotalCount = totalCount;
            Data = data;
        }
    }
}
