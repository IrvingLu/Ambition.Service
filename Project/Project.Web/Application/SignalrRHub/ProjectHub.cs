using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Project.Web.Appliccation.SignalrRHub
{
    /// <summary>
    /// 功能描述    ：signalr hub
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class ProjectHub : Hub
    {
        public ProjectHub()
        {

        }
        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <returns></returns>

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();

        }

        /// <summary>
        /// 客户端连接断开
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
