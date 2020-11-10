using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DataResult;
using Project.Web.Application.UserApp.Commands;
using System.Net;
using System.Threading.Tasks;

namespace Project.Web.Controllers.User
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
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }
    }
}
