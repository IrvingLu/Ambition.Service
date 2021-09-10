using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using NMS.RTIS.Core.Tools;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Infrastructure;
using NMS.RTIS.Infrastructure.Core;
using NMS.RTIS.Infrastructure.EntityFrameworkCore;
using NMS.RTIS.Web.Infrastructure;
using NMS.RTIS.Web.StartupExtensions;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace NMS.RTIS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 服务注入
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            RedisHelper.Initialization(new CSRedis.CSRedisClient(Configuration.GetConnectionString("CsRedisCachingConnectionString")));  //redis配置
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//解决.netcore 编码问题
            IdentityModelEventSource.ShowPII = true;//显示错误的详细信息并查看问题
            services.AddHttpContextAccessor();//加载http上下文
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;//允许读取文件流
            });
            services.AddScoped<IUnitOfWork>(m => m.GetService<ApplicationDbContext>());
            services.AddCorsConfig();//跨域配置
            services.AddConfig(Configuration);//配置文件
            services.AddIdentityOptions();//身份认证配置
            services.AddAutoMapper(typeof(Startup));//automapper
            services.AddMediatR(typeof(Startup));//CQRS
            services.AddHealthChecks();//健康检查
            services.AddSignalR();//SignalR
            services.AddController();//api控制器
            services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();//Identity 注入
            services.AddAuthService(Configuration);//认证服务
            services.AddSwaggerGen(c =>
            {
                typeof(ApiVersionEnum).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = $"{typeof(Startup).Namespace}",
                        Version = version,
                        Description = $"{version} 版本，可根据需要选择",
                        Contact = new OpenApiContact
                        {
                            Name = "东软医疗系统股份有限公司",
                            Email = "nms-admin@neusoftmedical.com",
                            Url = new Uri("http://www.neusoftmedical.com/")
                        },
                    });
                });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Namespace}" + ".xml");
                c.IncludeXmlComments(xmlPath, true);
            });
        }
        /// <summary>
        /// 中间件管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("AllowSameDomain");//跨域
            app.UseAuthentication();//认证
            app.UseAuthorization();//授权
            app.UseHealthChecks("/health");//健康检查
            app.UseErrorHandling();//异常处理
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                typeof(ApiVersionEnum).GetEnumNames().ToList().ForEach(version =>
                {
#if DEBUG
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}");
#else
                    c.SwaggerEndpoint($"./swagger/{version}/swagger.json", $"{version}");
#endif
                });
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseIdentityServer();
            DbContextSeed.SeedAsync(app.ApplicationServices).Wait();//启动初始化数据
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
