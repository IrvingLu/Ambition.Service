using Microsoft.AspNetCore.Builder;
using NMS.RTIS.Core.Enums;
using NMS.RTIS.Core.Middleware;
using NMS.RTIS.Infrastructure;
using NMS.RTIS.Service.SignalrRHub;
using System.Linq;

namespace NMS.RTIS.Web.StartupExtensions
{
    /// <summary>
    /// 功能描述    ：ApplicationBuilder扩展
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder UseConfig(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors("AllowSameDomain");//跨域
            app.UseAuthentication();//认证
            app.UseAuthorization();//授权
            app.UseHealthChecks("/health");//健康检查
            app.UseErrorHandling();//异常处理
            app.UseSwaggerInfo();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ProjectHub>("/project").RequireCors(t => t.WithOrigins(new string[] { "null" }).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            app.UseIdentityServer();
            DbContextSeed.SeedAsync(app.ApplicationServices).Wait();//启动初始化数据
            return app;
        }


        public static void UseSwaggerInfo(this IApplicationBuilder app)
        {
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
        }
        /// <summary>
        /// 异常处理中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
