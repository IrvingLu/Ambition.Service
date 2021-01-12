namespace Project.Core
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
            Message = message;
            Data = data;
        }
    }

    public class DataListResult : BaseResult
    {
        public object Data { get; set; }
        public int Count { get; set; }

        public DataListResult()
        {

        }
        public DataListResult(int code, string message, object data, int count) : base(code, message)
        {
            Code = code;
            Message = message;
            Data = data;
            Count = count;
        }
    }
}
