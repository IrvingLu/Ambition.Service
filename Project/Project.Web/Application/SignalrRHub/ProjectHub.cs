using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Web.Appliccation.SignalrRHub
{
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
