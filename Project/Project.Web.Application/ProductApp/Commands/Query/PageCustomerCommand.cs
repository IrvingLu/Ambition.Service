using MediatR;
using Project.Domain;
using Project.Infrastructure.Core.BaseDto;

namespace Project.Web.Application.ProductApp.Commands

{
    public class PageProductCommand: PageEntity, IRequest<PagedResultDto>
    {
        public string NameQuery { get; set; }
    }
}
