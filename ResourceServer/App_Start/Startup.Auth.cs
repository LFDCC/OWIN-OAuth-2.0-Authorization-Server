using Microsoft.Owin.Security.OAuth2;

using Owin;
using ResourceServer.Provider;

namespace ResourceServer
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions() {                
                 AccessTokenProvider=new AccessTokenProvider()
            });
        }
    }
}