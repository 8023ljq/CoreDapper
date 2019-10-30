using CoreDapperCommon.CommonConfig;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CoreDapperCommon.CommonJson
{
    /// <summary>
    /// Author：Geek Dog  Content：JSON帮助类 AddTime：2019-10-30 14:18:43  
    /// </summary>
    public static class JosnHelp
    {
        #region 格式转换

        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }

        #endregion

        #region 读取josn文件

        /// <summary>
        /// 获取JSON文件并返回对应返回值
        /// </summary>
        /// <param name="Key">错误编号</param>
        /// <param name="Language">语言类型</param>
        /// <returns></returns>
        public static string Readjson(object Key, string Language)
        {
            string jsonfile = String.Empty;
            try
            {
                string WebUrl = Directory.GetCurrentDirectory();
                if (Language == LanguageConfig.CN)
                {
                    jsonfile = GetConfigFileData.CNJsonAddress;//JSON文件路径
                }
                else
                {
                    jsonfile = GetConfigFileData.ENJsonAddress;//JSON文件路径
                }

                string url = WebUrl + jsonfile;

                using (System.IO.StreamReader file = System.IO.File.OpenText(url))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        //JObject jObject = (JObject)JToken.ReadFrom(reader);
                        //var value = jObject[Key].ToString();

                        var jObject = JToken.ReadFrom(reader);
                        var value = jObject[Key].ToString();
                        return value;
                    }
                }
            }
            catch (Exception)
            {
                return jsonfile = "未找到错误编码文字码,请检查ENUM与JSON是否一一对应";
            }
        }

        #endregion
    }
}
