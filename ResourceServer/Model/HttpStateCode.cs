namespace ResourceServer.Model
{
    /// <summary>
    /// 返回状态
    /// </summary>
    public class HttpStateCode
    {
        /// <summary>
        /// 000000 成功
        /// </summary>
        public static string Success { get; } = "000000";

        /// <summary>
        /// 失败 666666
        /// </summary>
        public static string Fail { get; } = "666666";

        /// <summary>
        /// 警告 999999
        /// </summary>
        public static string Warn { get; } = "999999";
    }
}