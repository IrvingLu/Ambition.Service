namespace NMS.RTIS.Core.ApiResult
{
    /// <summary>
    /// 功能描述    ：基础数据封装
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/4 9:40:56 
    /// </summary>
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
