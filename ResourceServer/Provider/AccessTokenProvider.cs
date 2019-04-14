using System.Threading.Tasks;

using Microsoft.Owin.Security.Infrastructure;

namespace ResourceServer.Provider
{
    public class AccessTokenProvider : AuthenticationTokenProvider
    {
        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            base.Receive(context);
        }

        public override Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            return base.ReceiveAsync(context);
        }
    }
}