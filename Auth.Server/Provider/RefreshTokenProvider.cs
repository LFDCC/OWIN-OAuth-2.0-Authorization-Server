using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using Microsoft.Owin.Security.Infrastructure;

namespace Auth.Server.Provider
{
    /// <summary>
    /// 刷新Token的实现类
    /// </summary>
    public class RefreshTokenProvider : AuthenticationTokenProvider
    {
        private readonly ConcurrentDictionary<string, string> _refreshTokens = new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        /// <summary>
        /// 生成 refresh_token
        /// </summary>
        public override Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            context.Ticket.Properties.IssuedUtc = DateTime.Now;
            context.Ticket.Properties.ExpiresUtc = DateTime.Now.AddMonths(2);
            context.SetToken(context.SerializeTicket());
            return Task.FromResult(0);
        }

        /// <summary>
        /// 由 refresh_token 解析成 access_token
        /// </summary>
        public override Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
            return Task.FromResult(0);
        }
    }
}