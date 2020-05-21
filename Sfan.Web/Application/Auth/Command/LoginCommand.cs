using IdentityModel.Client;
using MediatR;

namespace Sfan.Web.Application.Auth.Command
{
    public class LoginCommand: IRequest<TokenResponse>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
