/**********************************************************************
* 命名空间：NMS.RTIS.Service.Auth.Command
*
* 功  能：用户名密码登录
* 类  名：LoginCommand
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using IdentityModel.Client;
using MediatR;

namespace NMS.RTIS.Service.Auth.Command
{
    public class LoginCommand: IRequest<TokenResponse>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 认证服务地址
        /// </summary>
        public string TokenAddress { get; set; }
    }
}
