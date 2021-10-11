/**********************************************************************
* 命名空间：NMS.RTIS.Infrastructure.Dapper
*
* 功  能：Dapper封装接口
* 类  名：IDapperQuery
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Dapper
{
    public interface IDapperQuery
    {
        Task<int> ExecuteAsync(string sql);
        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param);
        Task<TEntity> QueryFirstAsync<TEntity>(string sql, object param);
    }
}
