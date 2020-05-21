using Autofac;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Sfan.Core.Domain.Identity;
using Sfan.Infrastructure;
using Sfan.Infrastructure.EntityFrameworkCore;
using Sfan.Web.Infrastructure;
using Sfan.Web.Infrastructure.StartupExtensions;

namespace Sfan.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //加载http上下文
            services.AddHttpContextAccessor();
            IdentityModelEventSource.ShowPII = true;//显示错误的详细信息并查看问题
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddApplicationDbContext(Configuration);//DbContext上下文
            services.AddIdentityOptions();
            services.AddAutoMapper(typeof(Startup));//autoap
            services.AddMediatR(typeof(Startup));//CQRS
            services.AddHealthChecks();//健康检查
            services.AddAuthService(Configuration);//认证服务
            services.AddApiVersion();//api版本
            services.AddController();//api控制器
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();//Identity 注入

        }
        /// <summary>
        /// 中间件管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHealthChecks("/health");
            app.UseApiVersioning();
            app.UseLog4net();
            app.UseErrorHandling();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //初始化数据
            DbContextSeed.SeedAsync(app.ApplicationServices).Wait();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegistrar());
        }
    }

}
