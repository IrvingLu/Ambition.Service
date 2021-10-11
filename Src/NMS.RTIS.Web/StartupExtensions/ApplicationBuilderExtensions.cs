/**********************************************************************
* 命名空间：NMS.RTIS.Web.StartupExtensions
*
* 功  能：ApplicationBuilder扩展
* 类  名：ApplicationBuilderExtensions
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.AspNetCore.Builder;
using NMS.RTIS.Core.Enums;
using NMS.RTIS.Core.Middleware;
using NMS.RTIS.Infrastructure;
using NMS.RTIS.Service.SignalrRHub;
using System.Linq;

namespace NMS.RTIS.Web.StartupExtensions
{
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
        /// <summary>
        /// Swagger文档配置
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerInfo(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                typeof(ApiVersionEnum).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}");
                });
            });
        }
        /// <summary>
        /// api处理中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
