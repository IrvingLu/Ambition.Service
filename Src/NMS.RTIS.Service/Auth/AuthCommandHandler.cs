/**********************************************************************
* 命名空间：NMS.RTIS.Service.Auth
*
* 功  能：登录认证逻辑类
* 类  名：AuthCommandHandler
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using IdentityModel.Client;
using MediatR;
using NMS.RTIS.Service.Auth.Command;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Service.Auth
{
    public class AuthCommandHandler : IRequestHandler<LoginCommand, TokenResponse>
    {
        /// <summary>
        /// 登录（用户名密码）
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
