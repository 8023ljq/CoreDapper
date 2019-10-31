using CoreDapperDAL.BaseDAL;
using CoreDapperHelp.DapperHelp;
using CoreDapperOtherHelp.RedisHelper;

namespace CoreDapperBLL
{
    /// <summary>
    /// 公共业务处理层
    /// </summary>
    public class BaseBLL
    {
        public BaseDAL baseDAL = new BaseDAL();

        /// <summary>
        /// 缓存管理员信息
        /// </summary>
        public RedisHelper redis = new RedisHelper(2);

        /// <summary>
        /// 缓存管理员信息
        /// </summary>
        public RedisHelper Commonredis = new RedisHelper(3);

        /// <summary>
        /// 处理事物使用
        /// </summary>
        public DapperHelps DapperHelps = new DapperHelps();
    }
}
