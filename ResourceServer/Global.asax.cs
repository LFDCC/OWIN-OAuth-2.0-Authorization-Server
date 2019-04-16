using System.Web.Http;
using Auth.Infrastructure.Ioc;

namespace ResourceServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoFacApiConfig.RegisterContainer();
        }
    }
}