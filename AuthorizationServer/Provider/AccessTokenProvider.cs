using System.Threading.Tasks;
using Microsoft.Owin.Security.Infrastructure;

namespace AuthorizationServer.Provider
{
    /// <summary>
    /// 创建Access_Token
    /// </summary>
    public class AccessTokenProvider : AuthenticationTokenProvider
    {
        public override Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            return base.CreateAsync(context);
        }
    }
}