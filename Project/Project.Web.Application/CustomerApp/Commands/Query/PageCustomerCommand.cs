using MediatR;
using Project.Core.BaseDto;
using Project.Core.Entities;

namespace Project.Web.Application.CustomerApp.Commands

{
    public class PageCustomerCommand: PageEntity, IRequest<PagedResultDto>
    {
        public string NameQuery { get; set; }
    }
}
