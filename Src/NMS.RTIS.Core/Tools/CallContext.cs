/**********************************************************************
* 命名空间：NMS.RTIS.Core.Tools
*
* 功  能：线程变量
* 类  名：CallContext
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System.Collections.Concurrent;
using System.Threading;

namespace NMS.RTIS.Core.Tools
{
    public static class CallContext
    {
        static readonly ConcurrentDictionary<string, AsyncLocal<object>> state = new();

        public static void SetData(string name, object data) =>
            state.GetOrAdd(name, _ => new AsyncLocal<object>()).Value = data;

        public static object GetData(string name) =>
            state.TryGetValue(name, out AsyncLocal<object> data) ? data.Value : null;
    }
}
