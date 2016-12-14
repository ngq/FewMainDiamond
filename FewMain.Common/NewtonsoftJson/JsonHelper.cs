using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FewMain.Common
{
    public class JsonHelper
    {
        static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            //NullValueHandling = NullValueHandling.Ignore,  //设置参数为Formatting.Indented可输出格式化后的json
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        static JsonHelper()
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            JsonSerializerSettings.Converters.Add(timeConverter);
        }

        /// <summary>
        ///  转换对象为json格式字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(object obj)
        {
            // 设置参数为Formatting.Indented可输出格式化后的json
            return JsonConvert.SerializeObject(obj, Formatting.None, JsonSerializerSettings);
        }

        /// <summary>
        /// 转换对象为json格式字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="IsNull">true 防污染,值为Null时不输出对应的json属性</param>
        /// <returns></returns>
        public static string ToJSON(object obj, bool IsNull)
        {
            /* 设置参数为Formatting.Indented可输出格式化后的json
             * 避免污染 JsonSerializerSettings 全局默认设置
             * 采用构造新对象
             */
            if (IsNull)
            {
                IsoDateTimeConverter converter = new IsoDateTimeConverter();
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                jsonSerializerSettings.Converters.Add(converter);
                return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
            }
            else
            {
                return JsonConvert.SerializeObject(obj);
            }
        }


        /// <summary>
        /// 转换json格式字符串为指定类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ParseJSON<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 转换json格式字符串为object对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ParseJSON(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }
        public static object DeserializeObject(string value, Type type)
        {
            //, params StringTrimConverter[] converters
            //if (converters == null)
            //{
            //    converters = new StringTrimConverter()[];
            //}
            return JsonConvert.DeserializeObject(value, type, new StringTrimConverter());
        }
    }
}
