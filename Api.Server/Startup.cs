using Microsoft.Owin;

using Owin;

[assembly: OwinStartup(typeof(Api.Server.Startup))]

namespace Api.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}