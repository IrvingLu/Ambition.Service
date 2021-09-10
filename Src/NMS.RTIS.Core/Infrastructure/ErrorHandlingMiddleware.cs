using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NMS.RTIS.Core.ApiResult;
using System;
using System.Threading.Tasks;

namespace NMS.RTIS.Core.Infrastructure
{
    /// <summary>
    /// 功能描述    ：全剧异常处理中间件
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (!context.Response.HasStarted)
                {
                    await _next.Invoke(context);
                }
            }
            //内部可识别逻辑异常
            catch (InternalException ex)
            {
                var statusCode = 800;
                await HandleExceptionAsync(context, statusCode, ex.Message);
            }
            //代码异常
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                var statusCode = 500;
                await HandleExceptionAsync(context, statusCode, "Server Error");
            }
        }
        //异常错误信息捕获，将错误信息用Json方式返回
        private static Task HandleExceptionAsync(HttpContext context, int statusCode, string msg = "")
        {
            var response = context.Response;
            if (response.StatusCode == 204) return Task.CompletedTask;
            var setting = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var result = JsonConvert.SerializeObject(new BaseResult(statusCode, msg), Formatting.None, setting);
            response.ContentType = "application/json;charset=utf-8";
            response.WriteAsync(result);
            return Task.CompletedTask;
        }
    }
}
