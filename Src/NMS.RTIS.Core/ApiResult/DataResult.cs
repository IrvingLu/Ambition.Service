/**********************************************************************
* 命名空间：NMS.RTIS.Core.ApiResult
*
* 功  能：api数据封装
* 类  名：DataResult
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

namespace NMS.RTIS.Core.ApiResult
{
    public class DataResult : BaseResult
    {
        public object Data { get; set; }

        public DataResult()
        {

        }
        public DataResult(int code, string message, object data) : base(code, message)
        {
            Code = code;
            Msg = message;
            Data = data;
        }
    }
    public class DataListResult : DataResult
    {
        public int TotalCount { get; set; }

        public DataListResult()
        {

        }
        public DataListResult(int code, string message, object data, int count) : base(code, message, data)
        {
            Code = code;
            Msg = message;
            Data = data;
            TotalCount = count;
        }
    }
}
