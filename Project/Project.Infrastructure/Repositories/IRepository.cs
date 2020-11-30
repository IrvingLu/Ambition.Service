
using Project.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(object id);
        Task DeleteEnumerableAsync(IEnumerable<TEntity> entities);
        Task DeleteSoftByIdAsync(object id);
        Task<TEntity> GetByIdAsync(object id);
        Task InsertAsync(TEntity entity);
        Task InsertEnumerableAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateEnumerableAsync(IEnumerable<TEntity> entities);
    }
}
