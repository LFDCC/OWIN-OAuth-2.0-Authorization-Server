using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ResourceServer.Filter
{
    public class CustomAuthorized : FilterAttribute, IAuthorizationFilter
    {
        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                return await continuation();
            }
            else
            {
                return await Task.FromResult(new HttpResponseMessage { Content = new StringContent("{\"code\":\"999999\",\"msg\":\"令牌无效\"}", Encoding.UTF8, "application/json") });
            }
        }
    }
}