using Identity.Web.Identity.Validator;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using NMS.RTIS.Core.Configuration;
using NMS.RTIS.Web.Identity;
using System;
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
        /// <summary>
        /// settings配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureStartupConfig<MongodbHostConfig>(configuration.GetSection("MongodbHostConfig"));
            services.ConfigureStartupConfig<OssClientConfig>(configuration.GetSection("OssClientConfig"));
            services.ConfigureStartupConfig<AlibabaSmsConfig>(configuration.GetSection("AlibabaSmsConfig"));
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
        /// 资源服务器注入
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
                options.Authority = "http://10.13.37.15:5000";
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
                //// 不使用驼峰
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
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
