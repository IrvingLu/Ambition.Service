using Project.Core.Abstractions;
using Project.Domain;
using Project.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Application.ProductApp.DomainEventHandlers
{
    public class CreateProductEventHandler : IDomainEventHandler<CreateProductEvent>
    {
        public Task Handle(CreateProductEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
