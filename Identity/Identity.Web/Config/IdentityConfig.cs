using Identity.Web.Domain;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.Web.Config
{
    /// <summary>
    /// 功能描述    ：认证服务器配置文件
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/4 9:40:56 
    /// </summary>
    public class IdentityConfig
    {
        /// <summary>
        /// Claim编辑
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static Claim[] GetUserClaim(ApplicationUser userInfo)
        {
            var claims = new Claim[] {
                new Claim("Id", userInfo.Id),
                new Claim("Name", userInfo.UserName)
            };
            return claims;
        }
        
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        /// <summary>
        /// api范围
        /// </summary>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "api"){
                    Scopes={ "api"}
                }
            };
        }
        /// <summary>
        /// id4 4.x版本新增
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApiScope()
        {
            return new List<ApiScope>
            {
                new ApiScope("api")
            };
        }
        /// <summary>
        /// 客户端配置
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                  //客户端模式
                 new Client
                 {
                    //客户端Id
                     ClientId="client",
                     //客户端授权类型，ClientCredentials:客户端凭证方式
                     AllowedGrantTypes=GrantTypes.ClientCredentials,
                     //用于认证的密码
                     ClientSecrets={new Secret("secret".Sha256()) },
                     // 客户端有权访问的范围（Scopes）
                     AllowedScopes={"api"}
                 },
                 //密码模式
                 new Client
                 {
                    ClientId = "password",
                    //用户密码凭证方式
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword ,
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 3600 * 2400, //2400小时
                    SlidingRefreshTokenLifetime = 1296000, //15天
                    // 用于认证的密码
                    ClientSecrets ={new Secret("secret".Sha256())},
                    // 客户端有权访问的范围（Scopes）
                    AllowedScopes = { "api" }
                 },
                 //手机号验证码模式，自定义
                 new Client
                 {
                    ClientId = "phone_sms",
                    //用户密码凭证方式
                    AllowedGrantTypes = {"phone_sms" },
                    // 用于认证的密码
                    ClientSecrets ={new Secret("secret".Sha256())},
                    // 客户端有权访问的范围（Scopes）
                    AllowedScopes = { "api" }
                 },
            };
        }
    }
}
