using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ResourceServer.Filter
{
    public class CustomAuthorized : IAuthorizationFilter
    {
        public bool AllowMultiple => true;

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> userNames;
            if (!actionContext.Request.Headers.TryGetValues("UserName", out userNames))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            string userName = userNames.First();
            if (userName == "admin")
            {
                return await continuation();
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}