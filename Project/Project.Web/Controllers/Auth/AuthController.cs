using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Web.Application.Auth.RequestCommandDto;
using Project.Web.Application.Auth.ReturnDto;
using System.Net;
using System.Threading.Tasks;

namespace Project.Web.Controllers.Auth
{
    /// <summary>
    /// 功能描述    ：登录认证授权
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController: BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// 用户密码登录
        /// </summary>
        /// <param name="validate"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginCommand  loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            if (result.AccessToken == null)
            {
                //登录失败,具体原因参照Message
                return Ok(new TokenDto { Code = InvokeHttp702(), Message = result.ErrorDescription, Error = result.Error });
            }
            return Ok(new TokenDto { Code = (int)HttpStatusCode.OK, Message = "验证通过", AccessToken = result.AccessToken, TokenType = result.TokenType});
        }
    }
}
