﻿using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Core.Extensions;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Infrastructure.Core;
using NMS.RTIS.Infrastructure.EntityTypeConfiguration;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.EntityFrameworkCore
{
    /// <summary>
    /// 功能描述    ：数据库上下文
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
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
            modelBuilder.ApplyConfiguration(new PatientEntityTypeConfiguration());
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
            var result = await base.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(this);
            return true;
        }
        #endregion
    }
}
