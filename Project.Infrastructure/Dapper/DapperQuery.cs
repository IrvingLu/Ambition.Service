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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Project.Core.Entities;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infrastructure.Dapper
{
    public class DapperQuery<TEntity> : IDapperQuery<TEntity> where TEntity :class, IEntity
    {
        private readonly IConfiguration _configuration;
        public DapperQuery(IConfiguration Configuration)
        {
            _configuration = Configuration;
         
        }


        /// <summary>
        /// 查询    
        /// </summary>
        /// <returns></returns>
        public async Task<TEntity> QueryAsync(string sql)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QueryAsync<TEntity>(sql);
            return result.FirstOrDefault();
        }
    }
}
