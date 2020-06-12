using IdentityModel.Client;
using MediatR;
using Microsoft.Extensions.Configuration;
using Project.Web.Application.AuthApp.Commands;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Application.AuthApp
{
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
            var tokenAddress = $"{_configuration["ApplicationConfiguration:IdentityAddress"]}/connect/token";
            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = tokenAddress,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api",
                UserName = request.UserName,
                Password = request.Password
            });

            return response;
        }
    }
}
