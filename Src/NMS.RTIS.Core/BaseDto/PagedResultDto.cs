/**********************************************************************
* 命名空间：NMS.RTIS.Core.BaseDto
*
* 功  能：分页返回对象
* 类  名：PagedResultDto
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

namespace NMS.RTIS.Core.BaseDto
{
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
