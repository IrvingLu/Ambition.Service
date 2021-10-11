/**********************************************************************
* 命名空间：NMS.RTIS.Core.Extensions
*
* 功  能：linq扩展方法
* 类  名：QueryableExtensions
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.BaseDto;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.Core.Extensions
{
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
