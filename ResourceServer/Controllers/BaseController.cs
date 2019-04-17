﻿using System.Web.Http;
using ResourceServer.Model;

namespace ResourceServer.Controllers
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
        public HttpResult<T> Fail<T>()
        {
            return new HttpResult<T>
            {
                code = HttpStateCode.失败
            };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        [NonAction]
        public HttpResult<T> Fail<T>(string msg)
        {
            return new HttpResult<T>
            {
                code = HttpStateCode.失败,
                msg = msg
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public HttpResult<T> Success<T>()
        {
            return new HttpResult<T>
            {
                code = HttpStateCode.成功
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        [NonAction]
        public HttpResult<T> Success<T>(string msg)
        {
            return new HttpResult<T>
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
        [NonAction]
        public HttpResult<T> Success<T>(T data)
        {
            return new HttpResult<T>
            {
                code = HttpStateCode.成功,
                data = data
            };
        }
    }
}