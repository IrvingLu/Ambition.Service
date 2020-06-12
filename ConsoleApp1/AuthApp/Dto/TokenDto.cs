using Project.Core.DataResult;

namespace Project.Web.Application.AuthApp.Dto
{
    public class TokenDto:BaseResultDto
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
