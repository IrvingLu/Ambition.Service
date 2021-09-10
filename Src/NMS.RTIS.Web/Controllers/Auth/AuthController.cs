using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NMS.RTIS.Web.Application.Auth.Command;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.Controllers.Auth
{
    /// <summary>
    /// 功能描述    ：登录认证授权
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// 用户密码登录
        /// </summary>
        /// <param name="loginCommand"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginCommand loginCommand)
        {
            loginCommand.TokenAddress = HttpContext.Request.GetDisplayUrl().Split("api")[0] + "connect/token";
            var result = await _mediator.Send(loginCommand);
            if (result.AccessToken == null)
            {
                return Error(result.ErrorDescription);
            }
            return Success(result.AccessToken);
        }
    }
}
