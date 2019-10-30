using Microsoft.Extensions.Configuration;

namespace CoreDapperCommon.CommonConfig
{
    /// <summary>
    /// 获取配置文件数据
    /// </summary>
    public class GetConfigFileData
    {
        #region ConnectionStrings

        /// <summary>
        /// 读数据库
        /// </summary>
        public static string WriteDataLink = ReadConfigFile.Configuration.GetConnectionString("WriteDataLink");

        /// <summary>
        /// 写数据库
        /// </summary>
        public static string ReadDataLink = ReadConfigFile.Configuration.GetConnectionString("ReadDataLink");

        /// <summary>
        /// Reids链接字符串
        /// </summary>
        public static string RedisDataLink = ReadConfigFile.Configuration.GetConnectionString("RedisDataLink");

        #endregion

        #region AppSettings

        /// <summary>
        /// Redis前缀
        /// </summary>
        public static string RedisPrefix = ReadConfigFile.Configuration["Appsettings:RedisPrefix"];

        /// <summary>
        /// 中文josn地址
        /// </summary>
        public static string CNJsonAddress = ReadConfigFile.Configuration["Appsettings:CNJsonAddress"];

        /// <summary>
        /// 英文文josn地址
        /// </summary>
        public static string ENJsonAddress = ReadConfigFile.Configuration["Appsettings:ENJsonAddress"];


        #endregion
    }
}
