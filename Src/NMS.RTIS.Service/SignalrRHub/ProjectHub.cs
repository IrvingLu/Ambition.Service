/**********************************************************************
* 命名空间：NMS.RTIS.Service.SignalrRHub
*
* 功  能：signalr
* 类  名：ProjectHub
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace NMS.RTIS.Service.SignalrRHub
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
