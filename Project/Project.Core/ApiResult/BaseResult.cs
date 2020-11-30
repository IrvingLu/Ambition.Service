namespace Project.Infrastructure.Core.ApiResult
{
    public class BaseResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        public BaseResult()
        {

        }

        public BaseResult(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
