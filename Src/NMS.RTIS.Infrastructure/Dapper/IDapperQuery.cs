using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Dapper
{
    /// <summary>
    /// 功能描述    ：IDapperQuery  
    /// 创 建 者    ：Seven
    /// 创建日期    ：2020/12/30 9:48:48 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2020/12/30 9:48:48 
    /// </summary>
    public interface IDapperQuery
    {
        Task<int> ExecuteAsync(string sql);
        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param);
        Task<TEntity> QueryFirstAsync<TEntity>(string sql, object param);
    }
}
