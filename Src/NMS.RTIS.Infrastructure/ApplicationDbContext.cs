/**********************************************************************
* 命名空间：NMS.RTIS.Infrastructure.EntityFrameworkCore
*
* 功  能：EF上下文
* 类  名：ApplicationDbContext
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Core.Extensions;
using NMS.RTIS.Core.Tools;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Infrastructure.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.EntityFrameworkCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IUnitOfWork, ITransaction
    {
        public IConfiguration Configuration { get; }
        protected IMediator _mediator;

        #region Ctor
        public ApplicationDbContext(IConfiguration configuration, IMediator mediator)
        {
            Configuration = configuration;
            _mediator = mediator;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        #region 数据库

        public DbSet<Domain.Patient.Patient> Patient { get; set; }
        public DbSet<Domain.Patient.PatientPlan> PatientPlan { get; set; }

        #endregion

        #region 数据库配置

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Postgresql"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            //modelBuilder.ApplyConfiguration(new PatientEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region ITransaction

        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;
            _currentTransaction = Database.BeginTransaction();
            return Task.FromResult(_currentTransaction);
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }




        #endregion

        #region UnitWork
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            var modifiedEntities = ChangeTracker.Entries().ToList();
            string userName = CallContext.GetData("userName").ToString();
            foreach (var entity in modifiedEntities)
            {
                if (entity.Entity is Entity model)
                {
                    if (entity.State == EntityState.Added)
                    {
                        model.CreateUserName = userName;
                        model.CreateTime = DateTime.Now;
                    }
                    if (entity.State == (EntityState.Modified | EntityState.Deleted))
                    {
                        model.UpdateUserName = userName;
                        model.UpdateTime = DateTime.Now;
                    }
                    ///乐观并发控制
                    var rowVersion = System.Text.Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
                    model.RowVersion = rowVersion;
                }
            }
            await base.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(this);
            return true;
        }
        #endregion
    }
}
