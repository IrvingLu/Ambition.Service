using Microsoft.AspNetCore.Identity;

namespace Project.Core.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

    }
}
