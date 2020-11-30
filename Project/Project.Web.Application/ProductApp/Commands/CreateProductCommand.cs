

using MediatR;
using Project.Infrastructure.Core.BaseDto;

namespace Project.Web.Application.ProductApp.Commands
{
    public class CreateProductCommand : EntityDto, IRequest 
    {
        public string Name { get; set; }
    }
}
