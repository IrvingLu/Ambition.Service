/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：Sfan.Infrastructure.Repositories
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

using Sfan.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sfan.Infrastructure.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }

        Task DeleteAsync(T entity);
        Task DeleteAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T entity);
        Task InsertAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity, params string[] excludeColumnNames);
        Task UpdateAsync(IEnumerable<T> entities);
    }
}
