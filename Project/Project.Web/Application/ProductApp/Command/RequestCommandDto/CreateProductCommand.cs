using MediatR;
using Project.Core.BaseDto;

namespace Project.Web.Application.ProductApp.Command.RequestCommandDto
{
    /// <summary>
    /// 功能描述    ：新建产品
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class CreateProductCommand : EntityDto, IRequest 
    {
        public string Name { get; set; }
    }
}
