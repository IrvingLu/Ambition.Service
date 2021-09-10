using MediatR;
using Project.Core.BaseDto;
using System;

namespace Project.Web.Application.ProductApp.Command.RequestCommandDto
{
    /// <summary>
    /// 功能描述    ：删除产品
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class DeleteProductCommand : EntityDto, IRequest
    {

        public DeleteProductCommand(Guid id) {

            this.Id = id;
        }
    }
}
