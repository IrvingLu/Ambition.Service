using Newtonsoft.Json;
using Project.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Core.Extensions
{
    /// <summary>
    /// httpclient扩展封装
    /// </summary>
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
