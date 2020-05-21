/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：User.Infrastructure.Data
/// 文件名称    ：UserDbContext.cs
/// =================================
/// 创 建 者    ：鲁岩奇
/// 创建日期    ：2019/10/28 10:08:18 
/// 功能描述    ：
/// 使用说明    ：
/// =================================
/// 修改者    ：
/// 修改日期    ：
/// 修改内容    ：
/// =================================
///
/// ***********************************************************************

using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sfan.Core.Domain;
using Sfan.Core.Domain.Documents;
using Sfan.Core.Domain.Identity;
using Sfan.Core.Domain.Leaves;
using Sfan.Core.Domain.Reimbursements;
using Sfan.Core.Domain.Seals;
using Sfan.Core.Domain.Project;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sfan.Infrastructure.EntityFrameworkCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IMediator _mediator;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options) 
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="service"></param>
        /// <returns></returns>



        #region 数据库

        public DbSet<Customer> Customer { get; set; }
        public DbSet<ProjectMain> ProjectMain { get; set; }
        public DbSet<CashArrears> CashArrears { get; set; }
        public DbSet<DebtPaying> DebtPaying { get; set; }
        public DbSet<Enclosure> Enclosure { get; set; }
        public DbSet<Mortgage> Mortgage { get; set; }
        public DbSet<Receivables> Receivables { get; set; }
        public DbSet<RepaymentPlan> RepaymentPlan { get; set; }
        public DbSet<CollateralInformation> CollateralInformation { get; set; }
        public DbSet<DebtRepaymentInformation> DebtRepaymentInformation { get; set; }
        public DbSet<Audit> Audit { get; set; }
        public DbSet<ReviewProcess> ReviewProcess { get;set; }

        public DbSet<Seal> Seal { get; set; }
        public DbSet<SealApply> SealApply { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentApply> DocumentApply { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Reimbursement> Reimbursement { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }

        private class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.HasKey(p => p.Id);
            }
        }
    }
}
