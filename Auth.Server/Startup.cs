using Microsoft.Owin;

using Owin;

[assembly: OwinStartup(typeof(Auth.Server.Startup))]

namespace Auth.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}