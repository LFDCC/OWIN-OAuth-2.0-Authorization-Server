using Microsoft.Owin.Security.OAuth2;

using Owin;

using Api.Server.Provider;

namespace Api.Server
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
            {
                Provider = new QueryStringBearerProvider("token"),
                AccessTokenProvider = new AccessTokenProvider()
            });
        }
    }
}