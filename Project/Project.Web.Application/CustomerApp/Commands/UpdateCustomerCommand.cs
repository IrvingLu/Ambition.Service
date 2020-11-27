using MediatR;
using Project.Core.BaseDto;

namespace Project.Web.Application.ProductApp.Commands
{
    public class UpdateProductCommand : EntityDto, IRequest
    {
        public string Name { get;  set; }
    }
}
