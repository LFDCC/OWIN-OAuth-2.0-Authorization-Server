using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using Microsoft.Owin.Security.Infrastructure;

namespace AuthorizationServer.Provider
{
    public class AuthorizationCodeProvider : AuthenticationTokenProvider
    {
        private readonly ConcurrentDictionary<string, string> _authenticationCodes = new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        /// <summary>
        /// 生成 authorization_code
        /// </summary>
        public override Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var code = Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n");
            context.SetToken(code);
            _authenticationCodes[context.Token] = context.SerializeTicket();//把当前用户信息序列化作为access_token
            return Task.FromResult(0);
        }

        /// <summary>
        /// 由 authorization_code 解析成 access_token
        /// 使用完就移除掉code
        /// </summary>
        public override Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            string value;
            if (_authenticationCodes.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
            return Task.FromResult(0);
        }
    }
}