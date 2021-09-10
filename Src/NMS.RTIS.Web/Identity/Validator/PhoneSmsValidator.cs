using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Web.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Identity.Validator
{
    /// <summary>
    /// 功能描述    ：手机验证码登录
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
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
            var phone = context.Request.Raw.Get("phone");///手机号
            var code = context.Request.Raw.Get("code");///验证码
            var smsCode = await RedisHelper.GetAsync(phone);///获取手机的短信验证码
            if (string.IsNullOrEmpty(smsCode))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "验证码过期或者未发送验证码");
                return;
            }
            ///判断验证码与传过来的验证码是否争取
            if (smsCode != code)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "验证码错误");
                return;
            }
            ///判断此手机号是否存在
            var user = await _userManager.Users.Where(c => c.PhoneNumber == phone).FirstOrDefaultAsync();
            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), GrantType, IdentityConfig.GetUserClaim(user));
                await RedisHelper.DelAsync(phone);///登录成功删除验证码
            }
            ///不存在则创建用户，并返回token
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
                    await RedisHelper.DelAsync(phone);///登录成功删除验证码
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "创建默认用户失败");
                }
            }
        }
    }
}
