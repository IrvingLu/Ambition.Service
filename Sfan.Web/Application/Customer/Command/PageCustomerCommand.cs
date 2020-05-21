using MediatR;
using Sfan.Core;
using Sfan.Core.DataResult;
using Sfan.Core.Entities;
using Sfan.Web.Application.Command.Customer.Dto;

namespace Sfan.Web.Application.Command.Customer

{
    public class PageCustomerCommand: PageEntity, IRequest<PagedResultDto<CustomersDto>>
    {
        public string NameQuery { get; set; }
    }
}
