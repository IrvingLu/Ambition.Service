/**********************************************************************
* 命名空间：NMS.RTIS.Infrastructure.Dapper
*
* 功  能：Dapper封装
* 类  名：DapperQuery
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Dapper
{
    public class DapperQuery: IDapperQuery
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public DapperQuery(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("MySql");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql)
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            return await con.ExecuteAsync(sql);
        }
        /// <summary>
        /// 查询列表带参数
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param)
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            return await con.QueryAsync<TEntity>(sql, param);
        }
        /// <summary>
        /// 查询一条带参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<TEntity> QueryFirstAsync<TEntity>(string sql, object param)
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            return await con.QueryFirstOrDefaultAsync<TEntity>(sql, param);
        }
    }
}
