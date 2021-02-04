using MediatR;
using Project.Core.BaseDto;
using Project.Web.Application.ProductApp.Query.ReturnDto;
using System;

namespace Project.Web.Application.ProductApp.Query.RequestCommandDto
{
    /// <summary>
    /// 功能描述    ：详情
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class ProductCommand : EntityDto, IRequest<ProductDto>
    {

        public ProductCommand(Guid id)
        {

            this.Id = id;
        }
    }
}
