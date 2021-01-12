using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Dapper
{
    /// <summary>
    /// 功能描述    ：Dapper封装
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2020/12/29 16:33:12 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2020/12/29 16:33:12 
    /// </summary>
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
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        public async Task<IEnumerable<dynamic>> QueryAsync(string sql, object param)
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            return await con.QueryAsync(sql);
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
