using System.Web.Http;
using System.Web.Mvc;

using Auth.Infrastructure.Ioc;

namespace Api.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoFacApiConfig.RegisterContainer();
        }
    }
}