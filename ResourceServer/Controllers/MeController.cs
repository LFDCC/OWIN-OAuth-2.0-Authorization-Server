using System.Threading.Tasks;
using Auth.Infrastructure.Extension;
using Auth.Service.Interface;
using ResourceServer.Filter;
using ResourceServer.Model;

namespace ResourceServer.Controllers
{
    [CustomAuthorized]
    public class MeController : BaseController
    {
        private readonly IUserService userService;

        public MeController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<HttpResult> Get()
        {
            var user = await userService.GetUserAsync(User.Identity.Name.To<int>());
            if (user != null)
            {
                return Success(user);
            }
            else
            {
                return Fail();
            }
        }
    }
}