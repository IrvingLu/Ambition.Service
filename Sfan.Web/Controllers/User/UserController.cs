using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sfan.Core.DataResult;
using Sfan.Web.Application.Command.Customer;
using Sfan.Web.Application.User.Command;
using System.Net;
using System.Threading.Tasks;

namespace Sfan.Web.Controllers.User
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController: BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync(CreateUserCommand createUserCommand)
        {
            await _mediator.Send(createUserCommand);
            return Ok(new BaseResultDto((int)HttpStatusCode.OK, "Success"));
        }
    }
}
