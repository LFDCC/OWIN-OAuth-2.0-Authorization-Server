using System;
using AuthorizationServer.Provider;
using Constants;

using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth2;

using Owin;

namespace AuthorizationServer
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable Application Sign In Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Application",
                AuthenticationMode = AuthenticationMode.Passive,
                LoginPath = new PathString(Paths.LoginPath),
                LogoutPath = new PathString(Paths.LogoutPath),
            });
            // Enable External Sign In Cookie
            app.SetDefaultSignInAsAuthenticationType("External");
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "External",
                AuthenticationMode = AuthenticationMode.Passive,
                CookieName = CookieAuthenticationDefaults.CookiePrefix + "External",
                ExpireTimeSpan = TimeSpan.FromMinutes(5),
            });

            // 启动授权服务器
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                ApplicationCanDisplayErrors = true,//显示自定义的错误页面
                AllowInsecureHttp = true,//允许客户端以http协议请求；
                AuthenticationMode = AuthenticationMode.Active,
                AuthorizeEndpointPath = new PathString(Paths.AuthorizePath),
                TokenEndpointPath = new PathString(Paths.TokenPath),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),

                // 授权服务
                Provider = new AuthorizationServerProvider(),

                //生成code
                AuthorizationCodeProvider = new AuthorizationCodeProvider(),

                // 生成refresh_token
                RefreshTokenProvider = new RefreshTokenProvider(),

                //生成access_token
                AccessTokenProvider = new AccessTokenProvider()
            });
        }
    }
}