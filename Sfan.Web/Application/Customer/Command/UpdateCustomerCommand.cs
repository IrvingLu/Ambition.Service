using MediatR;
using Sfan.Core.Entities;

namespace Sfan.Web.Application.Command.Customer
{
    public class UpdateCustomerCommand : EntityDto, IRequest
    {

        public string Name { get;  set; }
    }
}
