/**********************************************************************
* �����ռ䣺NMS.RTIS.Web
*
* ��  �ܣ��������
* ��  ����Program
* ��  �ڣ�2021/10/11 14:44:32
* �����ˣ�lu-shuai
*
* ��Ȩ���У���˾
*
**********************************************************************/

using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Reflection;

namespace NMS.RTIS.Web
{
    public class Program
    {
       private static readonly IConfigurationRoot configuration  = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",optional: true)
              .Build();
        public static void Main(string[] args)
        {
            ConfigureLogging();
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(configuration["ApplicationConfiguration:Url"]);
                })
            .UseSerilog()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory());

        #region log����
        /// <summary>
        /// elk��־����
        /// </summary>
        private static void ConfigureLogging()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
                .Enrich.WithProperty("Environment", environment)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        /// <summary>
        /// ����elk����
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
        {
            return new ElasticsearchSinkOptions(new Uri(configuration["ApplicationConfiguration:ElkAddress"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                MinimumLogEventLevel= LogEventLevel.Error
            };
        }
        #endregion
    }
}
