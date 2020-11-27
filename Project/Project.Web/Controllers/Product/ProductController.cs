using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Core.ApiResult;
using Project.Web.Application.ProductApp.Commands;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Project.Web.Controllers.Product
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("Products")]
        public async Task<IActionResult> GetAllAsync([FromQuery]PageProductCommand  pageProductCommand)
        {
           var result= await _mediator.Send(pageProductCommand);
            return Ok(new DataListResult((int)HttpStatusCode.OK, "Success",result.Data,result.TotalCount));
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new DetailCuustomerCommand(id));
            return Ok(new DataResult((int)HttpStatusCode.OK, "Success", result));
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync(CreateProductCommand createProductCommand)
        {
            await _mediator.Send(createProductCommand);
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }

        /// <summary>
        /// 删除单条
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok(new BaseResult((int)HttpStatusCode.OK, "Success"));
        }

    }
}
