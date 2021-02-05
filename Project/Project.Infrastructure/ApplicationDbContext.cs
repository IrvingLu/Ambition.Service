using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Project.Core.Domain.Identity;
using Project.Domain.Abstractions;
using Project.Domain.Product;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Project.Infrastructure.EntityFrameworkCore
{
    /// <summary>
    /// 功能描述    ：数据库上下文
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IUnitOfWork
    {
        public IConfiguration _configuration { get; }
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        
        }
        #region 数据库

        public DbSet<Product> Product { get; set; }
        #endregion

        #region 数据库配置
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version(8, 0, 21))).UseLoggerFactory(efLogger);
            base.OnConfiguring(optionsBuilder);
        }
        public static readonly ILoggerFactory efLogger = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole();
        });
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            //modelBuilder.ApplyConfiguration(new ReservationEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }

        public IDbContextTransaction Transaction { get; private set; }

        public void Begin()
        {
            Transaction = Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
            if (Transaction != null)
            {
                await Transaction.CommitAsync();
                Transaction = null;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        #endregion


    }
}
