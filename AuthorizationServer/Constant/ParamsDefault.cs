namespace AuthorizationServer.Constant
{
    public class ParamsDefault
    {
        /// <summary>
        /// Cookie
        /// </summary>
        public const string CookieName = "OAuth.Cookie";
        /// <summary>
        /// 登录页
        /// </summary>
        public const string LoginPath = "http://www.baidu.com";
        /// <summary>
        /// 登出页
        /// </summary>
        public const string LogoutPath = "/Account/Logout";
        /// <summary>
        /// 授权页
        /// </summary>
        public const string AuthorizeEndpointPath = "/OAuth/Authorize";
        /// <summary>
        /// 获取access_token
        /// </summary>
        public const string TokenEndpointPath = "/OAuth/Token";


    }
}