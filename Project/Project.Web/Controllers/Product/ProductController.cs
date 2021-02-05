using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Extensions;
using Project.Web.Application.ProductApp.Command.RequestCommandDto;
using Project.Web.Application.ProductApp.Query.RequestCommandDto;
using System;
using System.Threading.Tasks;

namespace Project.Web.Controllers.Product
{
    /// <summary>
    /// 功能描述    ：产品相关接口
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        #region Ctor
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Get
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("Products")]
        public async Task<IActionResult> GetAllAsync([FromQuery] ProductsCommand pageProductCommand)
        {
            var id = User.GetUserId();
            var result = await _mediator.Send(pageProductCommand);
            return Success(result.Data, result.TotalCount);
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new ProductCommand(id));
            return Success(result);
        }

        #endregion

        #region Post
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("insert")]
        [AllowAnonymous]
        public async Task<IActionResult> InsertAsync(CreateProductCommand createProductCommand)
        {
            await _mediator.Send(createProductCommand);
            return Success();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return Success();
        }

        /// <summary>
        /// 删除单条
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Success();
        }

        #endregion
    }
}
