using MediatR;
using Project.Core.Abstractions;
using Project.Core.BaseDto;
using Project.Core.Entities;

namespace Project.Web.Application.ProductApp.Commands

{
    public class PageProductCommand: PageEntity, IRequest<PagedResultDto>
    {
        public string NameQuery { get; set; }
    }
}
