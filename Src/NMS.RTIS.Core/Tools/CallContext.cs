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
