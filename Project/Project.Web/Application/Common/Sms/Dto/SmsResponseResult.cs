namespace Project.Web.Application.Common.Sms.Dto
{
    /// <summary>
    /// 功能描述    ：短信服务接口
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class SmsResponseResult
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string Code { get; set; }
    }
}
