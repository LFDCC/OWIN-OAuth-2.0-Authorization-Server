using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ResourceServer.Model
{
    public class HttpResult<T>
    {
        /// <summary>
        /// 响应编码
        /// </summary>
        [JsonIgnore]
        public HttpStateCode code { get; set; }

        /// <summary>
        /// 响应编码
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
        /// 数据集
        /// </summary>
        public T data { get; set; }
    }
}