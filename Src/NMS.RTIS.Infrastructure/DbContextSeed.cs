/**********************************************************************
* 命名空间：NMS.RTIS.Infrastructure
*
* 功  能：初始化数据
* 类  名：DbContextSeed
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Infrastructure.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure
{
    public class DbContextSeed
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            var roleManager = (RoleManager<ApplicationRole>)serviceProvider.GetService(typeof(RoleManager<ApplicationRole>));
            var userManager = (UserManager<ApplicationUser>)serviceProvider.GetService(typeof(UserManager<ApplicationUser>));
            string roleAdmin = "Administrator";
            if (await context.Users.AnyAsync())
            {
                return;
            }
            await CreateDefaultRole(roleManager, roleAdmin);
            var user = await CreateDefaultUser(userManager);
            await AddDefaultRoleToDefaultUser(userManager, roleAdmin, user);
        }
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="roleManager"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        private static async Task CreateDefaultRole(RoleManager<ApplicationRole> roleManager, string role)
        {
            await roleManager.CreateAsync(new ApplicationRole { Name=role});
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="roleManager"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        private static async Task<ApplicationUser> CreateDefaultUser(UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser { Email = "neusoft@neusoft.com", UserName = "admin" };
            await userManager.CreateAsync(user, "neusoft");
            var createdUser = await userManager.FindByEmailAsync("neusoft@neusoft.com");
            return createdUser;
        }
        /// <summary>
        /// 为用户添加权限
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="role"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private static async Task AddDefaultRoleToDefaultUser(UserManager<ApplicationUser> userManager, string role, ApplicationUser user)
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}
