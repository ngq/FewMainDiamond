using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace FewMain.Common
{
    /// <summary>
    /// 反序列化JSON字符串时，对字符串属性进行Trim操作
    /// </summary>
    public class StringTrimConverter : JsonConverter
    {
        /// <summary>
        /// 是否允许转换
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return objectType.FullName == "System.String";
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.String)
            {
                return "";//reader.Value.ToString().TryTrim();  //修改过
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
