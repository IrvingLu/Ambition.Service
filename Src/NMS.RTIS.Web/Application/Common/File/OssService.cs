using Aliyun.OSS;
using Project.Core.Configuration;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace Project.Web.Application.File
{
    /// <summary>
    /// 功能描述    ：oss相关服务
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class OssService : IOssService
    {
        private readonly OssClient _ossClient;
        private readonly OssClientConfig _ossClientConfig;
        public OssService(OssClientConfig ossClientConfig)
        {
            _ossClientConfig = ossClientConfig;
            _ossClient = new OssClient(_ossClientConfig.EndPoint, _ossClientConfig.AccessKeyId, _ossClientConfig.AccessKeySecret);
        }
        public async Task<string> UploadAsync(byte[] data, string fileName, UploadType type)
        {
            using var requestContent = new MemoryStream(data);
            string filepath = "";
            switch (type)
            {
                case UploadType.avatar:
                    ///用户头像
                    filepath = $"user/avatar/{fileName}";
                    _ossClient.PutObject(_ossClientConfig.BucketName, filepath, requestContent);
                    break;
                default:
                    ///其他文件
                    filepath = $"other/{fileName}";
                    _ossClient.PutObject(_ossClientConfig.BucketName, filepath, requestContent);
                    break;
            }
            return await Task.FromResult("/" + filepath);

        }

    }

    public enum UploadType
    {
        [Description("用户头像")]
        avatar

    }
}
