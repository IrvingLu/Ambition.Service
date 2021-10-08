using IdentityModel.Client;
using MediatR;
using Microsoft.Extensions.Configuration;
using NMS.RTIS.Web.Application.Auth.Command;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.Application.Auth
{
    /// <summary>
    /// 功能描述    ：登录认证
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class AuthCommandHandler : IRequestHandler<LoginCommand, TokenResponse>
    {
        private readonly IConfiguration _configuration;

        public AuthCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = request.TokenAddress,
                ClientId = "password",
                ClientSecret = "secret",
                Scope = "api",
                UserName = request.UserName,
                Password = request.Password
            }, cancellationToken: cancellationToken);

            return response;
        }
    }
}
