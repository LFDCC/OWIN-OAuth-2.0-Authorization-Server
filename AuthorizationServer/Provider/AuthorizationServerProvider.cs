using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Auth.Infrastructure.Ioc;
using Auth.Infrastructure.Tools.Encrypt;
using Auth.Service.Interface;
using Microsoft.Owin.Security.OAuth2;

namespace AuthorizationServer.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IClientService clientService = AutoFacMvcConfig.Resolve<IClientService>();
        private readonly IUserService userService = AutoFacMvcConfig.Resolve<IUserService>();

        /// <summary>
        /// 验证客户端
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthenticationAsync(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
                context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                var IfExist = await clientService.ExistAsync(clientId, clientSecret);
                if (IfExist)
                {
                    context.Validated();
                }
                else
                {
                    context.SetError("invalid_client", "客户端验证失败！");
                }
            }
        }

        #region 授权码模式/简化模式

        /// <summary>
        /// 验证客户端RedirectUrl是否一致
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientRedirectUriAsync(OAuthValidateClientRedirectUriContext context)
        {
            var client = await clientService.GetClientAsync(context.ClientId);
            if (client != null)
            {
                if (!string.IsNullOrEmpty(context.RedirectUri) &&
               string.Equals(context.RedirectUri, client.RedirectUrl, StringComparison.Ordinal))
                {
                    context.Validated();
                }
                else
                {
                    context.SetError("invalid_client_redirecturi", "RedirectUri验证失败！");
                }
            }
            else
            {
                context.SetError("invalid_client", "客户端验证失败！");
            }
        }

        #endregion 授权码模式/简化模式

        #region 密码授权模式

        public override async Task GrantResourceOwnerCredentialsAsync(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await userService.GetUserAsync(context.UserName, MD5.Encrypt(context.Password).ToUpper());
            if (user != null)
            {
                var identity = new ClaimsIdentity(new GenericIdentity(user.UserName, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_user_password", "用户名或密码无效！");
            }
        }

        #endregion 密码授权模式

        #region 客户端授权

        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(context.ClientId, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);

            return Task.FromResult(0);
        }

        #endregion 客户端授权
    }
}