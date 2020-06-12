using MediatR;
using Microsoft.AspNetCore.Identity;
using Project.Core.Domain.Identity;
using Project.Web.Application.UserApp.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Application.UserApp
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                NickName = request.NickName,
                Avatar = request.Avatar,
            };
            var rolenames = request.RoleNames.ToList();
            await _userManager.CreateAsync(user, request.Passsword ?? "123456789");
            await _userManager.AddToRolesAsync(user, rolenames);
            return new Unit();
        }
    }
}
