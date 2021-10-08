using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Infrastructure.Core;
using NMS.RTIS.Infrastructure.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected virtual ApplicationDbContext DbContext { get; set; }
        public virtual IUnitOfWork UnitOfWork => (IUnitOfWork)DbContext;
        /// <summary>
        /// 列表
        /// </summary>
        public virtual IQueryable<TEntity> Table => DbContext.Set<TEntity>();
        /// <summary>
        ///列表 AsNoTracking
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => DbContext.Set<TEntity>().AsNoTracking();
        private DbSet<TEntity> _entities;
        protected virtual DbSet<TEntity> Entities => _entities ??= DbContext.Set<TEntity>();

        public Repository(ApplicationDbContext context)
        {
            this.DbContext = context;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            entity.CreateTime = System.DateTime.Now;
            await Entities.AddAsync(entity);
        }
        /// <summary>
        /// 多条新增
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task AddEnumerableAsync(IEnumerable<TEntity> entities)
        {
            await Entities.AddRangeAsync(entities);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task UpdateAsync(TEntity entity)
        {
            entity.UpdateTime = System.DateTime.Now;
            return Task.FromResult(Entities.Update(entity));
        }
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task RemoveAsync(TEntity entity)
        {
            entity.UpdateTime = System.DateTime.Now;
            return Task.FromResult(Entities.Remove(entity));
        }
    }
}
