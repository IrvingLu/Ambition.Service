/**********************************************************************
* 命名空间：NMS.RTIS.Core.BaseDto
*
* 功  能：分页基础实体
* 类  名：PageEntity
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

namespace NMS.RTIS.Core.BaseDto
{
    public abstract class PageEntityDto
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
