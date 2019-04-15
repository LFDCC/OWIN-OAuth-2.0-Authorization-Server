using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Constants;
using Microsoft.Owin.Security.OAuth2;

namespace AuthorizationServer.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 验证客户端
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
                context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                if (clientId == Clients.Client1.Id && clientSecret == Clients.Client1.Secret)
                {
                    context.Validated();
                }
                else if (clientId == Clients.Client2.Id && clientSecret == Clients.Client2.Secret)
                {
                    context.Validated();
                }
                else
                {
                    context.SetError("invalid_client", "客户端验证失败！");
                }
            }
            return Task.FromResult(0);
        }

        #region 授权码模式

        /// <summary>
        /// 验证客户端RedirectUrl是否一致
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == Clients.Client1.Id)
            {
                context.Validated(Clients.Client1.RedirectUrl);
            }
            else if (context.ClientId == Clients.Client2.Id)
            {
                context.Validated(Clients.Client2.RedirectUrl);
            }
            else
            {
                context.SetError("invalid_client", "RedirectUrl错误！");
            }
            return Task.FromResult(0);
        }

        #endregion 授权码模式

        #region 密码授权模式

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(context.UserName, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);

            return Task.FromResult(0);
        }

        #endregion 密码授权模式
    }
}