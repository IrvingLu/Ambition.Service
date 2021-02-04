using System;
using System.Security.Claims;

namespace Project.Core.Extensions
{
    /// <summary>
    /// 功能描述    ：Claims 扩展方法
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return principal.FindFirst(c => c.Type == "Id")?.Value;
        }

    }
}
