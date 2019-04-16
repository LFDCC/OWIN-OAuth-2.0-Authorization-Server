using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ResourceServer.Model
{
    public class HttpResult
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
        public object data { get; set; }

        /// <summary>
        /// 默认处理所有的Datetime格式为：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [JsonIgnore]
        public string format { get; set; }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatString = string.IsNullOrWhiteSpace(format) ? "yyyy-MM-dd HH:mm:ss" : format,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore//忽略循环引用，如果设置为Error，则遇到循环引用的时候报错（建议设置为Error，这样更规范）
                                                                    //ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()//json中属性开头字母小写的驼峰命名
            };
            var json = JsonConvert.SerializeObject(this, settings);

            return json;
        }
    }
}