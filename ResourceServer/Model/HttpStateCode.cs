using System.ComponentModel;

namespace ResourceServer.Model
{
    public enum HttpStateCode
    {
        [Description("000000")]
        成功,

        [Description("666666")]
        失败,

        [Description("999999")]
        警告
    }
}