using System.Threading.Tasks;
using Auth.Dto;
using Auth.Infrastructure.Extension;
using Auth.Service.Interface;
using ResourceServer.Filter;
using ResourceServer.Model;

namespace ResourceServer.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [CustomAuthorized]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        /// <summary>
        ///构造函数注入
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResult<UserDto>> Get()
        {
            var user = await userService.GetUserAsync(User.Identity.Name.To<int>());
            if (user != null)
            {
                return Success(user);
            }
            else
            {
                return Fail<UserDto>();
            }
        }
    }
}