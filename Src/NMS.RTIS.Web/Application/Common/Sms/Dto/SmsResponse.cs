using Project.Core;
using Project.Core.ApiResult;

namespace Project.Web.Application.Common.Sms.Dto
{
    public class SmsResponse: BaseResult
    {
        public string SmsMsg { get; set; }
        public string SmsCode { get; set; }
        public SmsResponse(string smsMsg, string smsCode)
        {
            SmsMsg = smsMsg;
            SmsCode = smsCode;
        }

    }
}
