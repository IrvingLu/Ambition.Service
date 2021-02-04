using System.Threading.Tasks;

namespace Project.Web.Application.File
{
    /// <summary>
    /// 功能描述    ：oss服务接口
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public interface IOssService
    {
        Task<string> UploadAsync(byte[] data, string fileName, UploadType type);
    }
}
