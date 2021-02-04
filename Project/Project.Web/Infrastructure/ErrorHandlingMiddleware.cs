using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Project.Core;
using System;
using System.Threading.Tasks;

namespace Project.Web.Infrastructure
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
        private readonly ILog _log;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next; 
            _log = LogManager.GetLogger(typeof(ErrorHandlingMiddleware));
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                var statusCode = 800;
                if (ex is ArgumentException)
                {
                    statusCode = 801;
                }
                await HandleExceptionAsync(context, statusCode, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";
                switch (statusCode)
                {
                    case 401:
                        msg = "未授权,请登录";
                        break;
                    case 404:
                        msg = "未找到服务";
                        break;
                    case 502:
                        msg = "请求错误";
                        break;
                    case 204:
                        msg = "204";
                        break;
                    default:
                        {
                            if (statusCode != 200)
                            {
                                msg = "未知错误";
                            }

                            break;
                        }
                }
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }
        //异常错误信息捕获，将错误信息用Json方式返回
        private static Task HandleExceptionAsync(HttpContext context, int statusCode, string msg)
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
