using IdentityModel.Client;
using MediatR;

namespace Project.Web.Application.AuthApp.Commands
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
