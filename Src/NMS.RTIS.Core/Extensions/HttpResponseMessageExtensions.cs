/**********************************************************************
* 命名空间：NMS.RTIS.Core.Extensions
*
* 功  能：HttpResponse扩展方法
* 类  名：HttpResponse
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NMS.RTIS.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// 将结果转为json格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        public async static Task<T> AsJson<T>(this HttpResponseMessage httpResponseMessage)
        {
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// 将结果转为json格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpResponseMessage"></param>
        /// <returns></returns>
        public async static Task<JObject> AsJson(this HttpResponseMessage httpResponseMessage)
        {
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            return JObject.Parse(json);
        }
    }
}
