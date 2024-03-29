/**********************************************************************
* 命名空间：NMS.RTIS.Web
*
* 功  能：启动配置
* 类  名：Startup
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NMS.RTIS.Web.Infrastructure;
using NMS.RTIS.Web.StartupExtensions;

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
            services.AddServices(Configuration);
        }
        /// <summary>
        /// 中间件管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseConfig();
           
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
