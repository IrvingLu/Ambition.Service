/**********************************************************************
* 命名空间：NMS.RTIS.Web.IdentityServer.Validator
*
* 功  能：用户名密码登录认证
* 类  名：PasswordValidator
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Web.IdentityServer;
using System;
using System.Threading.Tasks;

namespace Identity.Web.IdentityServer.Validator
{
    public class PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public PasswordValidator(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(context.UserName);
                //判断用户是否存在
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(context.UserName, context.Password, false, lockoutOnFailure: false);
                    //判断验证是否成功
                    if (result.Succeeded)
                    {
                        bool islocked = await _userManager.GetLockoutEnabledAsync(user);
                        //验证用户是否锁定
                        if (islocked)
                        {
                            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户已锁定，请联系管理员解锁");
                            return;
                        }
                        else
                        {
                            //重新计算失败次数
                            await _userManager.ResetAccessFailedCountAsync(user);
                            //认证成功，返回token
                            context.Result = new GrantValidationResult(user.Id.ToString(), user.UserName, IdentityConfig.GetUserClaim(user));
                        }
                    }
                    else
                    {
                        //记录失败次数
                        await _userManager.AccessFailedAsync(user);
                        int accessFailedCount = await _userManager.GetAccessFailedCountAsync(user);
                        //输入5次错误密码锁定账户
                        if (accessFailedCount == 5)
                        {
                            await _userManager.AccessFailedAsync(user);
                            await _userManager.SetLockoutEnabledAsync(user, true);
                        }
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户密码错误");
                        return;
                    }
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "此用户名不存在");
                    return;
                }
            }
            catch (Exception)
            {
                //验证失败
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
                throw;
            }
        }

    }
}
