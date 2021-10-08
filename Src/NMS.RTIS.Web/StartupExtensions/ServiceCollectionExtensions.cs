using Identity.Web.IdentityServer.Validator;
using IdentityServer4.AccessTokenValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NMS.RTIS.Core.Configuration;
using NMS.RTIS.Core.Enums;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Infrastructure.Core;
using NMS.RTIS.Infrastructure.EntityFrameworkCore;
using NMS.RTIS.Service;
using NMS.RTIS.Web.IdentityServer;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.StartupExtensions
{
    /// <summary>
    /// 功能描述    ：服务配置
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureStartupConfig<MongodbHostConfig>(configuration.GetSection("MongodbHostConfig"));
            services.ConfigureStartupConfig<OssClientConfig>(configuration.GetSection("OssClientConfig"));
            services.ConfigureStartupConfig<AlibabaSmsConfig>(configuration.GetSection("AlibabaSmsConfig"));
            RedisHelper.Initialization(new CSRedis.CSRedisClient(configuration.GetConnectionString("CsRedisCachingConnectionString")));  //redis配置
            services.AddScoped<IUnitOfWork>(m => m.GetService<ApplicationDbContext>());
            //services.AddDbContext<ApplicationDbContext>();
            services.AddCorsConfig();//跨域配置
            services.AddIdentityOptions();//身份认证配置
            services.AddAutoMapper(typeof(ServiceStartup));//automapper
            services.AddMediatR(typeof(ServiceStartup));//CQRS
            services.AddHealthChecks();//健康检查
            services.AddSignalR();//SignalR
            services.AddController();//api控制器
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();//Identity 注入
            services.AddAuthService(configuration);//认证服务
            services.AddSwaggerInfo();
            return services;
        }

        /// <summary>
        /// Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerInfo(this IServiceCollection services) {

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
        /// 跨域
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsConfig(this IServiceCollection services)
        {
            //跨域配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSameDomain",
                    policy => policy.SetIsOriginAllowed(origin => true)
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials());
            });
        }
        /// <summary>
        /// 身份认证配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddIdentityOptions(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // 密码配置
                options.Password.RequireDigit = false;//是否需要数字(0-9).
                options.Password.RequiredLength = 6;//设置密码长度最小为6
                options.Password.RequireNonAlphanumeric = false;//是否包含非字母或数字字符。
                options.Password.RequireUppercase = false;//是否需要大写字母(A-Z).
                options.Password.RequireLowercase = false;//是否需要小写字母(a-z).
                // 锁定设置
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//账户锁定时长30分钟
                options.Lockout.MaxFailedAccessAttempts = 10;//10次失败的尝试将账户锁定
                options.Lockout.AllowedForNewUsers = false;
                // 用户设置
                options.User.RequireUniqueEmail = false; //是否Email地址必须唯一
            });
        }
        /// <summary>
        /// 认证服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static void AddAuthService(this IServiceCollection services, IConfiguration configuration)
        {
            //认证服务器配置
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                    .AddInMemoryApiResources(IdentityConfig.GetApiResources())
                    .AddInMemoryApiScopes(IdentityConfig.GetApiScope())
                    .AddInMemoryClients(IdentityConfig.GetClients())
                    .AddResourceOwnerValidator<PasswordValidator>()
                    .AddProfileService<ProfileService>();
            //资源服务器配置
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddIdentityServerAuthentication(options =>
            {
                options.Authority = configuration["ApplicationConfiguration:Url"];
                options.RequireHttpsMetadata = false;
                options.ApiName = "api";
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Query.TryGetValue("token", out StringValues token))
                        {
                            context.Token = token;
                        }
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        var te = context.Exception;
                        return Task.CompletedTask;
                    }
                };
            });
        }
        /// <summary>
        /// 控制器注入
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddController(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // 忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // 设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
        }

        private static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            //创建配置
            var config = new TConfig();
            //绑定
            configuration.Bind(config);
            //注册
            services.AddSingleton(config);
            return config;
        }
    }
}
