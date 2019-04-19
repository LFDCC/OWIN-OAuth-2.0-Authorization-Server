using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Auth.Infrastructure.Extension;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace AuthorizationServer.Controllers
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
                var PlatUrl = ConfigurationManager.AppSettings["PlatUrl"];
                if (PlatUrl.IsNullOrWhiteSpace())
                {
                    authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
                    authentication.Challenge(CookieAuthenticationDefaults.AuthenticationType);
                    return new HttpUnauthorizedResult();
                }
                else
                {
                    var RedirectUrl = HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
                    Response.Redirect(PlatUrl + "?RedirectUrl=" + RedirectUrl, true);
                }
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