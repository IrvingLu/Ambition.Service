
using Microsoft.EntityFrameworkCore;
using Project.Domain;
using Project.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    /// <summary>
    /// 功能描述    ：仓储类
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        private DbSet<TEntity> _entities;

        #endregion

        #region Ctor

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// 回滚
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry => entry.State = EntityState.Unchanged);
            }

            _context.SaveChanges();
            return exception.ToString();
        }

        #endregion

        #region Methods
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                entity.CreateTime = DateTime.Now;
                Entities.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        /// <summary>
        /// 多条新增
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task InsertEnumerableAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            try
            {
                entities = entities.Select(c => { c.CreateTime = DateTime.Now; return c; });
                Entities.AddRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                entity.UpdateTime = DateTime.Now;
                Entities.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// 多条更新
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task UpdateEnumerableAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                entities = entities.Select(c => { c.UpdateTime = DateTime.Now; return c; });
                Entities.UpdateRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// 主键删除(逻辑删除)
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task DeleteSoftByIdAsync(object id)
        {
            var entity = await Entities.FindAsync(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                entity.IsDelete = true;
                Entities.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        /// <summary>
        /// 主键删除(物理删除)
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task DeleteByIdAsync(object id)
        {
            var entity = await Entities.FindAsync(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                Entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        /// <summary>
        /// 实体删除
        /// </summary>
        /// <param name="entity">Entity</param>
        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
              await  _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="entities">Entities</param>
        public async Task DeleteEnumerableAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }


        #endregion

        #region Properties

        /// <summary>
        /// 列表
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;
        /// <summary>
        ///列表 AsNoTracking
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<TEntity> Entities => _entities ??= _context.Set<TEntity>();

        #endregion
    }
}
