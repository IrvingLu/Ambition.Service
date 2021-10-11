/**********************************************************************
* 命名空间：NMS.RTIS.Web.IdentityServer
*
* 功  能：提供和存储有关用户生成的用户的配置文件信息的服务
* 类  名：ProfileService
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.IdentityServer
{
    public class ProfileService : IProfileService
    {
        /// <summary>
        ///  只要有关用户的身份信息单元被请求（例如在令牌创建期间或通过用户信息终点），就会调用此方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //depending on the scope accessing the user data.
                var claims = context.Subject.Claims.ToList();
                //set issued claims to return
                context.IssuedClaims = claims.ToList();
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
