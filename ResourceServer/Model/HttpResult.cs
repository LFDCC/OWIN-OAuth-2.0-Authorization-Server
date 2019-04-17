using System.ComponentModel.DataAnnotations;

namespace ResourceServer.Model
{
    /// <summary>
    /// 返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResult<T>
    {
        /// <summary>
        /// 返回代码（000000 成功 666666 失败 999999 警告）
        /// </summary>        
        public string code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public T data { get; set; }
    }
}