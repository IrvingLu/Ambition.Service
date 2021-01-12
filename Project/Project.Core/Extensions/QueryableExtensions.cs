using Microsoft.EntityFrameworkCore;
using Project.Core.BaseDto;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Web.Core.Extensions
{
    /// <summary>
    /// 功能描述    ：linq扩展
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 异步分页
        /// </summary>
        public async static Task<PagedResultDto> ToPageListAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            return new PagedResultDto()
            {
                TotalCount = await query.CountAsync(),
                Data = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }
        /// <summary>
        /// 分页扩展
        /// </summary>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// 过滤
        /// </summary>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }
        /// <summary>
        /// 空字符串过滤
        /// </summary>
        public static IQueryable<T> WhereByString<T>(this IQueryable<T> query,string str,Expression<Func<T, bool>> predicate)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return query;
            }
            return query.Where(predicate);
        }
    }
}
