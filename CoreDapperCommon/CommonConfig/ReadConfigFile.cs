using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDapperCommon.CommonConfig
{
    /// <summary>
    /// 读取配置文件数据
    /// </summary>
    public class ReadConfigFile
    {
        public static IConfiguration Configuration { get; set; }

        static ReadConfigFile()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            

            #region 方式1（ok）

            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource
                {
                    Path = "appsettings.json",
                    ReloadOnChange = true
                }).Build();

            #endregion

            #region 方式2（ok）

            //Configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json").Build();

            #endregion
        }
    }
}
