using MediatR;
using Project.Core.DataResult;
using Project.Core.Entities;
using Project.Web.Application.CustomerApp.Dto;

namespace Project.Web.Application.CustomerApp.Commands

{
    public class PageCustomerCommand: PageEntity, IRequest<PagedResultDto<CustomersDto>>
    {
        public string NameQuery { get; set; }
    }
}
