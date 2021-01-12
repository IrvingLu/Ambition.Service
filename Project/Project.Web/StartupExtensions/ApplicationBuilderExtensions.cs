
using Microsoft.AspNetCore.Builder;
using System.IO;

namespace Project.Web.StartupExtensions
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
      
        public static IApplicationBuilder UseLog4net(this IApplicationBuilder app)
        {
            var logRepository = log4net.LogManager.CreateRepository(System.Reflection.Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            return app;
        }
    }
}
