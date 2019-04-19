using System;

using AuthorizationServer.Constant;
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
                CookieName = ParamsDefault.CookieName,
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,//Cookies
                LoginPath = new PathString(ParamsDefault.LoginPath),
                LogoutPath = new PathString(ParamsDefault.LogoutPath)
            });

            // 启动授权服务器
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                ApplicationCanDisplayErrors = true,//显示自定义的错误页面
                AllowInsecureHttp = true,//允许客户端以http协议请求；
                AuthenticationMode = AuthenticationMode.Active,
                AuthorizeEndpointPath = new PathString(ParamsDefault.AuthorizeEndpointPath),
                TokenEndpointPath = new PathString(ParamsDefault.TokenEndpointPath),
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