/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：Sfan.Core.Domain.Identity
/// 文件名称    ：ApplicationUser.cs
/// =================================
/// 创 建 者    ：鲁岩奇
/// 创建日期    ：2020/4/13 11:30:25 
/// 功能描述    ：
/// 使用说明    ：
/// =================================
/// 修改者    ：
/// 修改日期    ：
/// 修改内容    ：
/// =================================
///
/// ***********************************************************************

using Microsoft.AspNetCore.Identity;

namespace Sfan.Core.Domain.Identity
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
