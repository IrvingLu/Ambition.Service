/**********************************************************************
* 命名空间：NMS.RTIS.Core.Middleware
*
* 功  能：api处理中间件
* 类  名：ErrorHandlingMiddleware
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NMS.RTIS.Core.ApiResult;
using NMS.RTIS.Core.Tools;
using System;
using System.Threading.Tasks;

namespace NMS.RTIS.Core.Middleware
{
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
                //添加线程变量
                CallContext.SetData("userName", context.User?.Identity?.Name);
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
            //并发异常，数据已经被修改
            catch (DbUpdateConcurrencyException)
            {
                var statusCode = 801;
                await HandleExceptionAsync(context, statusCode, "Data has been modified");
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
    /// <summary>
    /// 内部异常
    /// </summary>
    public class InternalException : Exception
    {
        public InternalException(string msg) : base(msg)
        {

        }
    }
}
