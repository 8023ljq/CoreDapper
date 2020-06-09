namespace CoreDapperModel.CommonModel
{
    /// <summary>
    /// 普通请求返回参数
    /// </summary>
    public class ResultMsg
    {
        public ResultMsg()
        {
            ResultData = new { };
            ResultMsgs = string.Empty;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        public object ResultCode { get; set; }

        /// <summary>
        /// 获取 消息内容
        /// </summary>
        public string ResultMsgs { get; set; }

        /// <summary>
        /// 获取 消息类型
        /// </summary>
        public string ResultType { get; set; }

        /// <summary>
        /// 获取 返回数据
        /// </summary>
        public object ResultData { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int ResultCount { get; set; }
    }
}
