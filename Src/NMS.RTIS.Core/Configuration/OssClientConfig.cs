namespace NMS.RTIS.Core.Configuration
{
    /// <summary>
    /// 功能描述    ：OssClientConfig  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 13:38:43 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 13:38:43 
    /// </summary>
    public class OssClientConfig
    {
        public string EndPoint { get; set; }
        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }
        public string BucketName { get; set; }
    }
}
