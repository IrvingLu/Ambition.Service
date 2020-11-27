using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Core.Domain.Identity;
using Project.Domain.Product;
using Project.Infrastructure.EntityTypeConfiguration;

namespace Project.Infrastructure.EntityFrameworkCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        
        }
        #region 数据库

        public DbSet<Product> Product { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }

   
    }
}
