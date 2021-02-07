using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Core;
using Project.Core.Tools;
using Project.Web.Application.Common.Sms;
using Project.Web.Application.Common.Sms.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project.Web.Controllers.Common
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SmsController : BaseController
    {
        private readonly ISmsService _smsService;
        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }
        /// <summary>
        /// 短信验证码 (阿里云) 
        /// </summary>
        /// <param name="smsTemplate"></param>
        /// <returns></returns>
        [HttpPost("send")]
        public async Task<IActionResult> AlibabaSMSAuthorize(SmsRequest request)
        {
            var authCode = Helper.GetSmsCode();
            var response = await _smsService.SendSmsAsync(request.Phone, authCode);
            var responseResult = (SmsResponseResult)JsonConvert.DeserializeObject(response.Data, typeof(SmsResponseResult));
            ///发送失败
            if (responseResult.Code != "Ok")
            {
                return Error("短信服务错误", new SmsResponse(responseResult.Msg, responseResult.Code));
            }
            ///发送短信成功，存code到redis
            await RedisHelper.SetAsync(request.Phone, authCode, 3000);//5分钟过期
            return Success(new SmsResponse(responseResult.Msg, responseResult.Code));
        }
    }
}
