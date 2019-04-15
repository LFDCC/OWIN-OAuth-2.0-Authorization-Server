using System.Web.Http;

using ResourceServer.Filter;

namespace ResourceServer.Controllers
{
    [CustomAuthorized]
    public class MeController : ApiController
    {
        public string Get()
        {
            return this.User.Identity.Name;
        }
    }
}