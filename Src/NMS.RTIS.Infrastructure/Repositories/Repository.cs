using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Core.Tools;
using NMS.RTIS.Infrastructure.Core;
using NMS.RTIS.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected virtual ApplicationDbContext DbContext { get; set; }
        public virtual IUnitOfWork UnitOfWork => DbContext;
        /// <summary>
        /// 列表
        /// </summary>
        public virtual IQueryable<TEntity> Table => DbContext.Set<TEntity>().Where(c => !c.IsDelete);
        /// <summary>
        ///列表 AsNoTracking
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => DbContext.Set<TEntity>().AsNoTracking().Where(c => !c.IsDelete);
        private DbSet<TEntity> _entities;
        protected virtual DbSet<TEntity> Entities => _entities ??= DbContext.Set<TEntity>();

        public Repository(ApplicationDbContext context)
        {
            DbContext = context;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }
        /// <summary>
        /// 多条新增
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
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
            return Task.FromResult(Entities.Update(entity));
        }
        /// <summary>
        /// 多条新增
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
            await Task.CompletedTask;
        }
        /// <summary>
        /// 单条删除(物理删除)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(object id)
        {
            var entity = await Entities.FindAsync(id);
            Entities.Remove(entity);
        }
        /// <summary>
        /// 单条删除(逻辑删除)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task SoftDeleteAsync(object id)
        {
            var entity = await Entities.FindAsync(id);
            entity.IsDelete = true;
            await UpdateAsync(entity);
        }
    }
}
