/**********************************************************************
* 命名空间：NMS.RTIS.Web.Controllers
*
* 功  能：登录api
* 类  名：AuthController
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NMS.RTIS.Core.Middleware;
using NMS.RTIS.Service.Auth.Command;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.Controllers.Auth
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthController : BaseController
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods

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
                throw new InternalException(result.ErrorDescription);
            }
            return Success(result.AccessToken);
        }

        #endregion

    }
}
