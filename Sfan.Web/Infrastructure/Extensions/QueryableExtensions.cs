using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sfan.Web.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 分页扩展
        /// </summary>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }


        /// <summary>
        /// 过滤扩展
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the query</param>
        /// <returns>Filtered or not filtered query based on <paramref name="condition"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition
                ? query.Where(predicate)
                : query;
        }

        public static IQueryable<T> WhereByString<T>(
            this IQueryable<T> query,
            string str,
            Expression<Func<T, bool>> exp)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return query;
            }

            return query.Where(exp);
        }

        public static IQueryable<T> WhereByNullable<T, V>(
            this IQueryable<T> query,
            V? v,
            Expression<Func<T, bool>> exp) where V : struct
        {
            if (v == null)
            {
                return query;
            }
            return query.Where(exp);
        }

        public static IQueryable<T> WhereByNullable<T, Object>(
            this IQueryable<T> query,
            Object v,
            Expression<Func<T, bool>> exp)
        {
            if (v == null)
            {
                return query;
            }

            return query.Where(exp);
        }
    }
}
