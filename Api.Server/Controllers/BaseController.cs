using System.Web.Http;

using Api.Server.Model;

namespace Api.Server.Controllers
{
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public IHttpActionResult Fail<T>()
        {
            var result = new HttpResult<T>
            {
                code = HttpStateCode.Fail
            };
            return Json(result);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        [NonAction]
        public IHttpActionResult Fail<T>(string msg)
        {
            var result = new HttpResult<T>
            {
                code = HttpStateCode.Fail,
                msg = msg
            };
            return Json(result);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public IHttpActionResult Success<T>()
        {
            var result = new HttpResult<T>
            {
                code = HttpStateCode.Success
            };
            return Json(result);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        [NonAction]
        public IHttpActionResult Success<T>(string msg)
        {
            var result = new HttpResult<T>
            {
                code = HttpStateCode.Success,
                msg = msg
            };
            return Json(result);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据集</param>
        /// <returns></returns>
        [NonAction]
        public IHttpActionResult Success<T>(T data)
        {

            var result = new HttpResult<T>
            {
                code = HttpStateCode.Success,
                data = data
            };
            return Json(result);
        }
    }
}