using System.Web.Http;
using ResourceServer.Model;

namespace ResourceServer.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public HttpResult Fail()
        {
            return new HttpResult
            {
                code = HttpStateCode.失败
            };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public HttpResult Fail(string msg)
        {
            return new HttpResult
            {
                code = HttpStateCode.失败,
                msg = msg
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public HttpResult Success()
        {
            return new HttpResult
            {
                code = HttpStateCode.成功
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public HttpResult Success(string msg)
        {
            return new HttpResult
            {
                code = HttpStateCode.成功,
                msg = msg
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据集</param>
        /// <returns></returns>
        public HttpResult Success(object data)
        {
            return new HttpResult
            {
                code = HttpStateCode.成功,
                data = data
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="format">DateTime格式</param>
        /// <returns></returns>
        public HttpResult Success(object data, string format)
        {
            return new HttpResult
            {
                code = HttpStateCode.成功,
                data = data,
                format = format
            };
        }
    }
}