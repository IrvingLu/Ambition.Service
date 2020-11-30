using MediatR;
using Project.Infrastructure.Core.Abstractions;
using Project.Infrastructure.Core.BaseDto;
using Project.Infrastructure.Core.Entities;

namespace Project.Web.Application.ProductApp.Commands

{
    public class PageProductCommand: PageEntity, IRequest<PagedResultDto>
    {
        public string NameQuery { get; set; }
    }
}
