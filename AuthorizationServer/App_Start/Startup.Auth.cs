using System;
using AuthorizationServer.Provider;

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
            // 启用Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = "OAuth.Cookie",
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,//Cookies
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/Logout")
            });

            // 启动授权服务器
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                ApplicationCanDisplayErrors = true,//显示自定义的错误页面
                AllowInsecureHttp = true,//允许客户端以http协议请求；
                AuthenticationMode = AuthenticationMode.Active,
                AuthorizeEndpointPath = new PathString("/OAuth/Authorize"),
                TokenEndpointPath = new PathString("/OAuth/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),

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