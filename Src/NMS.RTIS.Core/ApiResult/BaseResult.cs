/**********************************************************************
* 命名空间：NMS.RTIS.Core.ApiResult
*
* 功  能：基础api数据封装
* 类  名：BaseResult
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

namespace NMS.RTIS.Core.ApiResult
{
    public class BaseResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        public BaseResult()
        {

        }

        public BaseResult(int code, string message)
        {
            Code = code;
            Msg = message;
        }
    }
}
