using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Infrastructure.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        IUnitOfWork UnitOfWork { get; }
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(object id);
    }
}
