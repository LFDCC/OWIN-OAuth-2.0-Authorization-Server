using System.Web.Routing;
using Auth.DbRepository;
using Auth.Infrastructure.Ioc;

namespace Auth.Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoFacMvcConfig.RegisterContainer();
            DbData.Initial();
        }
    }
}