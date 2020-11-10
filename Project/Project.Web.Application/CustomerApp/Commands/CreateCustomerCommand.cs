

using MediatR;
using Project.Core.BaseDto;

namespace Project.Web.Application.CustomerApp.Commands
{
    public class CreateCustomerCommand : EntityDto, IRequest 
    {
        public string Name { get; set; }
    }
}
