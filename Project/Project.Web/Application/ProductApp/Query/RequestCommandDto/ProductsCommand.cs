using MediatR;
using Project.Domain;
using Project.Core.BaseDto;

namespace Project.Web.Application.ProductApp.Query.RequestCommandDto
{
    /// <summary>
    /// 功能描述    ：产品列表
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class ProductsCommand : PageEntity, IRequest<PagedResultDto>
    {
        public string NameQuery { get; set; }
    }
}
