using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Extensions
{
    /// <summary>
    /// 功能描述    ：MediatRExtension  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/2/5 14:31:54 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/5 14:31:54 
    /// </summary>
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, Entity ctx)
        {

            var domainEvents = ctx.DomainEvents.ToArray();

            //var domainEntities = ctx.ChangeTracker
            //    .Entries<Entity>()
            //    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            //var domainEvents = domainEntities
            //    .SelectMany(x => x.Entity.DomainEvents)
            //    .ToList();

            //domainEntities.ToList()
            //    .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
