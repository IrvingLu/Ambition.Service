using MediatR;

namespace Sfan.Web.Application.User.Command
{
    public class CreateUserCommand:IRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Passsword { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 权限集合
        /// </summary>
        public string[] RoleNames { get; set; }

    }
}
