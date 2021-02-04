using Project.Core;

namespace Project.Web.Application.Auth.ReturnDto
{
    /// <summary>
    /// 功能描述    ：token
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class TokenDto:BaseResult
    {
        /// <summary>
        /// token（如果验证通过返回token）
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// token类型
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string Error { get; set; }
    }
}
