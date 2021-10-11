using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(object id);
        Task SoftDeleteAsync(object id);
    }
}
