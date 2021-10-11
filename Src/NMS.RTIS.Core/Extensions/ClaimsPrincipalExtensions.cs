/**********************************************************************
* 命名空间：NMS.RTIS.Core.Extensions
*
* 功  能：Claims 扩展方法
* 类  名：ClaimsPrincipalExtensions
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System;
using System.Security.Claims;

namespace NMS.RTIS.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return principal.FindFirst(c => c.Type == "Id")?.Value;
        }
    }
}
