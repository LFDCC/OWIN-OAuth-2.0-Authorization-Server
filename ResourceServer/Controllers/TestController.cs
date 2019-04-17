using System.Threading.Tasks;
using System.Web.Http;
using Auth.Dto;
using Auth.Infrastructure.Extension;
using Auth.Service.Interface;
using ResourceServer.Model;

namespace ResourceServer.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    public class TestController : BaseController
    {
        private readonly IUserService userService;

        /// <summary>
        ///构造函数注入
        /// </summary>
        /// <param name="userService"></param>
        public TestController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResult<UserDto>> GetTest(string a, string b)
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

        /// <summary>
        /// 获取Result
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResult<string> GetResult(UserDto userDto)
        {
            return Fail<string>();
        }
    }
}