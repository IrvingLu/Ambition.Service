/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：Project.Infrastructure.Repositories
/// 文件名称    ：IRepository.cs
/// =================================
/// 创 建 者    ：鲁岩奇
/// 创建日期    ：2020/4/13 11:45:57 
/// 功能描述    ：
/// 使用说明    ：
/// =================================
/// 修改者    ：
/// 修改日期    ：
/// 修改内容    ：
/// =================================
///
/// ***********************************************************************

using Project.Infrastructure.Core.Entities;
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
