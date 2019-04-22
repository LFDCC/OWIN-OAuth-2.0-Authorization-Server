using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Server.Model;
using Auth.Dto;
using Auth.Infrastructure.Extension;
using Auth.Service.Interface;

namespace Api.Server.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
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
        [ResponseType(typeof(HttpResult<UserDto>))]
        public async Task<IHttpActionResult> Get()
        {
            var user = await userService.GetUserAsync(User.Identity.Name.To<int>());
            if (user != null)
            {
                return Success(user);
            }
            else
            {
                return Fail<UserDto>("用户不存在");
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(HttpResult<UserDto>))]
        public async Task<IHttpActionResult> GetUser(int uid)
        {
            if (uid != User.Identity.Name.To<int>())
            {
                return Fail<UserDto>("uid异常");
            }
            else
            {
                var user = await userService.GetUserAsync(User.Identity.Name.To<int>());
                if (user != null)
                {
                    return Success(user);
                }
                else
                {
                    return Fail<UserDto>("用户不存在");
                }
            }
        }
    }
}