using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Project.Core.Configuration;
using System.Threading.Tasks;

namespace Project.Web.Application.Common.Sms
{
    /// <summary>
    /// 功能描述    ：阿里云短信相关服务
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class SmsService : ISmsService
    {
        private readonly AlibabaSmsConfig _alibabaSmsConfig;

        public SmsService(AlibabaSmsConfig alibabaSmsConfig)
        {
            _alibabaSmsConfig = alibabaSmsConfig;
        }

        /// <summary>
        /// 发送短信（阿里云）
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="param"></param>
        /// <param name="smsModel"></param>
        /// <returns></returns>
        public async Task<CommonResponse> SendSmsAsync(string phoneNumber, int authCode)
        {
            var param = "{\"code\":" + authCode + "}";
            string tem = "";///模板编号
            //发送短信
            IClientProfile profile = DefaultProfile.GetProfile("default", _alibabaSmsConfig.AccessKey, _alibabaSmsConfig.AccessSecret);
            var client = new DefaultAcsClient(profile);
            var request = new CommonRequest
            {
                Method = MethodType.POST,
                Domain = "dysmsapi.aliyuncs.com",
                Version = "2017-05-25",
                Action = "SendSms"
            };
            request.AddQueryParameters("PhoneNumbers", phoneNumber);
            request.AddQueryParameters("SignName", _alibabaSmsConfig.Sign);
            request.AddQueryParameters("TemplateCode", tem);
            request.AddQueryParameters("TemplateParam", param);
            var response = client.GetCommonResponse(request);
            return await Task.FromResult(response);
        }
    }
}
