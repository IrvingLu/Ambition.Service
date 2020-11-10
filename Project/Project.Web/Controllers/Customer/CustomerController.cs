using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DataResult;
using Project.Web.Application.CustomerApp.Commands;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Project.Web.Controllers.Customer
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("customers")]
        public async Task<IActionResult> GetAllAsync([FromQuery]PageCustomerCommand  pageCustomerCommand)
        {
           var result= await _mediator.Send(pageCustomerCommand);
            return Ok(new DataListResultDto((int)HttpStatusCode.OK, "Success",result.Items,result.TotalCount));
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new DetailCuustomerCommand(id));
            return Ok(new DataResultDto((int)HttpStatusCode.OK, "Success", result));
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync(CreateCustomerCommand createCustomerCommand)
        {
            await _mediator.Send(createCustomerCommand);
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }

        /// <summary>
        /// 删除单条
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }

    }
}
