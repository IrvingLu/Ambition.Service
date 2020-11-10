/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：Order.Infrastructure.Repository.Dapper
/// 文件名称    ：DapperRepository.cs
/// =================================
/// 创 建 者    ：鲁岩奇
/// 创建日期    ：2019/12/3 9:39:43 
/// 功能描述    ：
/// 使用说明    ：
/// =================================
/// 修改者    ：
/// 修改日期    ：
/// 修改内容    ：
/// =================================
///
/// ***********************************************************************

using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Dapper
{
    public class DapperQuery<TEntity> : IDapperQuery<TEntity> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        public DapperQuery(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        private MySqlConnection GetSqlConnection()
        {
            var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return connection;
        }
        /// <summary>
        /// 基础查询    
        /// </summary>
        /// <returns></returns>
        public async Task<TEntity> QueryAsync(string sql)
        {
            using var connection = GetSqlConnection();
            var result = await connection.QueryAsync<TEntity>(sql);
            return result.FirstOrDefault();
        }
        /// <summary>
        /// 提交语句,返回影响的行数   
        /// </summary>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql)
        {
            using var connection = GetSqlConnection();
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="detailSql"></param>
        /// <returns></returns>
        public async Task<TEntity> DetailAsync(Guid Id, string detailSql)
        {
            using var connection = GetSqlConnection();
            return await connection.QueryFirstOrDefaultAsync<TEntity>(detailSql, new { Id });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteSql"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid Id, string deleteSql)
        {
            using var connection = GetSqlConnection();
            await connection.ExecuteAsync(deleteSql, new
            {
                Id
            });
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="insertSql"></param>
        /// <returns></returns>
        public async Task InsertAsync(TEntity entity, string insertSql)
        {
            using var connection = GetSqlConnection();
            await connection.ExecuteAsync(insertSql, entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateSql"></param>
        /// <returns></returns>
        public async Task Update(TEntity entity, string updateSql)
        {
            using var connection = GetSqlConnection();
            await connection.ExecuteAsync(updateSql, entity);
        }
        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> ExecQuerySP(string SPName)
        {
            using var connection = GetSqlConnection();
            return await Task.Run(() => connection.Query<TEntity>(SPName, null, null, true, null, CommandType.StoredProcedure).ToList());
        }
    }
}
