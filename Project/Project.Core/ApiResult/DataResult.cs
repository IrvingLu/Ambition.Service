namespace Project.Core
{
    /// <summary>
    /// 功能描述    ：返回数据封装
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/4 9:40:56 
    /// </summary>
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
