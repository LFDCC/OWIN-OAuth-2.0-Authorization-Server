using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Auth.Infrastructure.Extension;
using Auth.Infrastructure.Tools.Encrypt;
using Auth.Service.Interface;

using AuthorizationServer.Constant;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace AuthorizationServer.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager signInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<ActionResult> Login()
        {
            if (Request.HttpMethod == "POST")
            {
                var ticket = await signInManager.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationType);
                if (!string.IsNullOrEmpty(Request.Form.Get("submit.Signin")))
                {
                    var username = Request.Form["username"];
                    var password = Request.Form["password"];
                    if (username.IsNullOrWhiteSpace() || password.IsNullOrWhiteSpace())
                    {
                        ViewBag.msg = "用户名或密码为空！";
                    }
                    else
                    {
                        password = MD5.Encrypt(password).ToUpper();
                        var userDto = await userService.GetUserAsync(username, password);
                        if (userDto != null)
                        {
                            ///id验证
                            var identity = new ClaimsIdentity(new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, userDto.UserId.ToString())
                            }, CookieAuthenticationDefaults.AuthenticationType);

                            signInManager.SignIn(new AuthenticationProperties(), identity);
                        }
                        else
                        {
                            ViewBag.msg = "用户名或密码错误！";
                        }
                    }
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            signInManager.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            signInManager.Challenge(CookieAuthenticationDefaults.AuthenticationType);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login_External(string username, string password)
        {
            if (username.IsNullOrWhiteSpace() || password.IsNullOrWhiteSpace())
            {
                return await Task.FromResult(new JsonResult()
                {
                    Data = new
                    {
                        code = "666666",
                        msg = "用户名或密码为空！"
                    }
                });
            }
            else
            {
                password = MD5.Encrypt(password).ToUpper();
                var userDto = await userService.GetUserAsync(username, password);
                if (userDto != null)
                {
                    ///id验证
                    var identity = new ClaimsIdentity(new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, userDto.UserId.ToString())
                            }, CookieAuthenticationDefaults.AuthenticationType);

                    signInManager.SignIn(new AuthenticationProperties(), identity);

                    HttpCookie cookie = Request.Cookies[ParamsDefault.CookieName];

                    if (cookie != null)
                    {
                        return await Task.FromResult(new JsonResult()
                        {
                            Data = new
                            {
                                code = "000000",
                                msg = "登录成功！",
                                data = cookie
                            }
                        });
                    }
                    else
                    {
                        return await Task.FromResult(new JsonResult()
                        {
                            Data = new
                            {
                                code = "666666",
                                msg = "登录失败！"
                            }
                        });
                    }
                }
                else
                {
                    return await Task.FromResult(new JsonResult()
                    {
                        Data = new
                        {
                            code = "666666",
                            msg = "用户名或密码错误！"
                        }
                    });
                }
            }
        }
    }
}