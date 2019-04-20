using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace Auth.Server.Controllers
{
    public class OAuthController : Controller
    {
        public async Task<ActionResult> Authorize()
        {
            if (Response.StatusCode != 200)
            {
                return View("AuthorizeError");
            }

            var authentication = HttpContext.GetOwinContext().Authentication;
            var ticket = await authentication.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationType);
            var identity = ticket != null ? ticket.Identity : null;
            if (identity == null)
            {
                authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
                authentication.Challenge(CookieAuthenticationDefaults.AuthenticationType);
                return new HttpUnauthorizedResult();
            }

            var scopes = (Request.QueryString.Get("scope") ?? "").Split(' ');
            if (scopes.Contains("default"))//静默授权 用户无感知
            {
                identity = new ClaimsIdentity(identity.Claims, "Bearer", identity.NameClaimType, identity.RoleClaimType);
                foreach (var scope in scopes)
                {
                    identity.AddClaim(new Claim("urn:oauth:scope", scope));
                }
                var props = new AuthenticationProperties(new Dictionary<string, string> {
                        { "uid", identity.Name }
                    });//自定义输出参数
                authentication.SignIn(props, identity);
            }
            if (Request.HttpMethod == "POST")
            {
                if (!string.IsNullOrEmpty(Request.Form.Get("submit.Grant")))
                {
                    identity = new ClaimsIdentity(identity.Claims, "Bearer", identity.NameClaimType, identity.RoleClaimType);
                    foreach (var scope in scopes)
                    {
                        identity.AddClaim(new Claim("urn:oauth:scope", scope));
                    }
                    var props = new AuthenticationProperties(new Dictionary<string, string> {
                        { "uid", identity.Name }
                    });//自定义输出参数
                    authentication.SignIn(props, identity);
                }
            }

            return View();
        }
    }
}