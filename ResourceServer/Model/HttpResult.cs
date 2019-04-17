using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ResourceServer.Model
{
    /// <summary>
    /// 返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResult<T>
    {
        /// <summary>
        /// 编码
        /// </summary>
        [JsonIgnore]
        public HttpStateCode code { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [JsonProperty("code")]
        private string _code
        {
            get
            {
                var t = typeof(HttpStateCode);
                var f = t.GetField(code.ToString());
                DescriptionAttribute desc = (DescriptionAttribute)Attribute.GetCustomAttribute(f, typeof(DescriptionAttribute), false);

                return desc != null && !string.IsNullOrEmpty(desc.Description) ? desc.Description : "999999";
            }
        }

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