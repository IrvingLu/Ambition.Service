﻿/**********************************************************************
* 命名空间：NMS.RTIS.Web.IdentityServer.Validator
*
* 功  能：手机验证码登录
* 类  名：PhoneSmsValidator
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Web.IdentityServer;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.IdentityServer.Validator
{
    public class PhoneSmsValidator : IExtensionGrantValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public string GrantType => "phone";

        public PhoneSmsValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var phone = context.Request.Raw.Get("phone");//手机号
            var code = context.Request.Raw.Get("code");//验证码
            var smsCode = await RedisHelper.GetAsync(phone);//获取手机的短信验证码
            if (string.IsNullOrEmpty(smsCode))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "验证码过期或者未发送验证码");
                return;
            }
            //判断验证码与传过来的验证码是否争取
            if (smsCode != code)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "验证码错误");
                return;
            }
            //判断此手机号是否存在
            var user = await _userManager.Users.Where(c => c.PhoneNumber == phone).FirstOrDefaultAsync();
            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), GrantType, IdentityConfig.GetUserClaim(user));
                await RedisHelper.DelAsync(phone);//登录成功删除验证码
            }
            //不存在则创建用户，并返回token
            else
            {
                var newUser = new ApplicationUser
                {
                    UserName = phone,
                    PhoneNumber = phone,
                };
                var result = await _userManager.CreateAsync(newUser, phone);
                if (result.Succeeded)
                {
                    context.Result = new GrantValidationResult(user.Id.ToString(), GrantType, IdentityConfig.GetUserClaim(newUser));
                    await RedisHelper.DelAsync(phone);//登录成功删除验证码
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "创建默认用户失败");
                }
            }
        }
    }
}
