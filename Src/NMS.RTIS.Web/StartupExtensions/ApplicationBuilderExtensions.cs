using Microsoft.AspNetCore.Builder;
using NMS.RTIS.Core.Infrastructure;

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
