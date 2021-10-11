/**********************************************************************
* 命名空间：NMS.RTIS.Core.Extensions
*
* 功  能：HttpClientExtensions扩展方法
* 类  名：HttpClientExtensions
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Newtonsoft.Json;
using NMS.RTIS.Core.Tools;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Core.Extensions
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// json请求
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="requestUri"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient httpClient, Uri requestUri, object data, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(requestUri, content, cancellationToken);
        }
        /// <summary>
        /// formData请求
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri"></param>
        /// <param name="formdata"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostFormDataAsync(this HttpClient httpClient, string requestUri, MultipartFormDataContent formdata, CancellationToken cancellationToken)
        {
            formdata.Headers.ContentType.MediaType = "multipart/form-data";
            return await httpClient.PostAsync(requestUri, formdata, cancellationToken);
        }
        /// <summary>
        /// get方法
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetDataAsync(this HttpClient httpClient, string requestUri, object data, CancellationToken cancellationToken)
        {
            var pramas = Helper.GetPropertyNameAndValue(data);
            requestUri += pramas;
            return await httpClient.GetAsync(requestUri, cancellationToken);
        }
    }
}
