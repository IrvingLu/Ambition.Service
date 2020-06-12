
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Core.Domain;
using Project.Core.Domain.Identity;
using Project.Infrastructure.EntityTypeConfiguration;
using System;

namespace Project.Infrastructure.EntityFrameworkCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IMediator _mediator;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options) 
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #region 数据库

        public DbSet<Customer> Customer { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }

   
    }
}
