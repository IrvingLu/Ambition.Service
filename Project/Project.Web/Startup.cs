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
using Project.Core.Domain.Identity;
using Project.Infrastructure;
using Project.Infrastructure.EntityFrameworkCore;
using Project.Web.Appliccation.SignalrRHub;
using Project.Web.Infrastructure;
using Project.Web.StartupExtensions;
using System.Text;

namespace Project.Web
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
            //解决.netcore 编码问题
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            IdentityModelEventSource.ShowPII = true;//显示错误的详细信息并查看问题
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            //跨域配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSameDomain",
                    policy => policy.SetIsOriginAllowed(origin => true)
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials());
            });
            ///redis配置
            RedisHelper.Initialization(new CSRedis.CSRedisClient(Configuration.GetConnectionString("CsRedisCachingConnectionString")));
            ////配置hangfire定时任务
            //services.AddHangfire(x => x.UseStorage(new MySqlStorage(Configuration.GetConnectionString("MySql") + ";Allow User Variables=true", new MySqlStorageOptions
            //{
            //    TablePrefix = "Hangfire"
            //})));
            services.AddConfig(Configuration);//配置文件
            //services.AddApplicationDbContext(Configuration);//DbContext上下文
            services.AddIdentityOptions();//身份认证配置
            services.AddAutoMapper(typeof(Startup));//automapper
            services.AddMediatR(typeof(Startup));//CQRS
            services.AddHealthChecks();//健康检查
        
            services.AddSignalR();//SignalR
            services.AddApiVersion();//api版本
            services.AddController();//api控制器
            services.AddIdentity<ApplicationUser,ApplicationRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();//Identity 注入
            services.AddAuthService(Configuration);//认证服务
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
            app.UseCors("AllowSameDomain");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHealthChecks("/health");
            app.UseApiVersioning();
            app.UseLog4net();
            app.UseErrorHandling();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ProjectHub>("/project").RequireCors(t => t.WithOrigins(new string[] { "null" }).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            //app.UseHangfireServer(new BackgroundJobServerOptions
            //{
            //    WorkerCount = 1
            //});
            RegisterJobs();
            //初始化数据
            DbContextSeed.SeedAsync(app.ApplicationServices).Wait();
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        private static void RegisterJobs()
        {
            //15
           // RecurringJob.AddOrUpdate<IHanfireTaskService>("OrderReceivedConfirmAuto", job => job.OrderReceivedConfirmAuto(15), Cron.Minutely);//"0 */1 * * * ?"
        }
        /// <summary>
        /// autofac依赖注入
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegistrar());
        }
    }

}
