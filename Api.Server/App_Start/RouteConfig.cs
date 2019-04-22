using System.Web.Mvc;
using System.Web.Routing;

namespace Api.Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Help", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Api.Server.Areas.HelpPage.Controllers" }
            ).DataTokens.Add("area", "HelpPage"); ;
        }
    }
}