using IdentityModel.Client;
using MediatR;

namespace NMS.RTIS.Web.Application.Auth.Command
{
    /// <summary>
    /// 功能描述    ：用户名密码登录
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
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
