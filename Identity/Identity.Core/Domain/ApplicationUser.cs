using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
    }
}
