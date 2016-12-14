using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace System
{
   public static class ObjectConvert
    {
        #region 判断对象是否为null
        /// <summary>
        /// 判断对象是否为null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
        #endregion

        #region 对类型进行DBNull.Value判断
        /// <summary>
        /// 对类型进行DBNull.Value判断
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToIsDBNull(this object obj)
        {
            return obj == DBNull.Value;
        }
        #endregion

        #region  判断一个字符是否空
        /// <summary>
        /// 判断一个字符是否空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        #endregion

        #region 是否int,返回转换值
        /// <summary>
        /// 是否int,返回转换值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(this string s)
        {
            int a;
            return int.TryParse(s, out a);
        }
        #endregion

        #region  转换成数字

        /// <summary>
        /// 转换成数字,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this double s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 转换成数字,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this decimal s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 把字符串转换成数字,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this float s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 把字符串转换成数字,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this object s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region  把对象转换成double类型,异常返回0
        /// <summary>
        /// 把对象转换成double类型,异常返回0
        /// </summary>
        /// <returns></returns>
        public static double ToDouble(this string s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 把对象转换成double类型,异常返回0
        /// </summary>
        /// <returns></returns>
        public static double ToDouble(this decimal s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 把对象转换成double类型,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToDouble(this object s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region    对象串转decimal类型,异常返回0
        /// <summary>
        /// 对象串转decimal类型,异常返回0
        /// </summary>
        /// <returns></returns>
        public static decimal ToDecimal(this string s)
        {
            try
            {
                return Convert.ToDecimal(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 对象串转decimal类型,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this double s)
        {
            try
            {
                return Convert.ToDecimal(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 对象串转decimal类型,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this int s)
        {
            try
            {
                return Convert.ToDecimal(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// 对象串转decimal类型,异常返回0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object s)
        {
            try
            {
                return Convert.ToDecimal(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region   字符串转时间类型,异常返回最小日期
        /// <summary>
        /// 字符串转时间类型,异常返回最小日期
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDataTime(this string s)
        {
            try
            {
                return Convert.ToDateTime(s);
            }
            catch (Exception)
            {

                return DateTime.MinValue;
            }
        }

        #endregion

        #region 时间类型转string
        /// <summary>
        /// 时间类型转string
        /// </summary>
        /// <param name="obj">日期</param>
        /// <param name="format">格式,如yyyy-MM-dd hh:mm:ss.......</param>
        /// <returns></returns>
        public static string ToDateTimeStr(this DateTime obj, string format)
        {
            return obj.ToString(format);
        }
        #endregion

        #region    截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Length">长度</param>
        /// <param name="AddStr">是否追加....</param>
        /// <returns></returns>
        public static string ToSubstring(this string obj, int Length, bool AddStr)
        {
            try
            {
                if (obj.Length > Length)
                    return obj.Substring(0, Length) + (AddStr ? "......" : "");
                else
                    return obj;
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
        /// <summary>
        /// 从Html代码中正则出文本
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string StripHTMLToTEXT(this string strHtml)
        {
            //All the regular expression for matching html, javascript, style elements and others.
            string[] aryRegex ={@"<%=[\w\W]*?%>",    @"<script[\w\W]*?</script>",     @"<style[\w\W]*?</style>",   @"<[/]?[\w\W]*?>",   @"([\r\n])[\s]+",
                                    @"&(nbsp|#160);",    @"&(iexcl|#161);",               @"&(cent|#162);",            @"&(pound|#163);",   @"&(copy|#169);",
                                   @"&#(\d+);",         @"-->",                          @"<!--.*\n"};
            //Corresponding replacment to the regular expressions.
            //string[] aryReplacment = { "", "", "", "", "", " ", "\xa1", "\xa2", "\xa3", "\xa9", "", "\r\n", "" };
            string[] aryReplacment = { "", "", "", "", "", " ", "", "", "", "", "", "", "" };
            string strStripped = strHtml;
            //Loop to replacing.
            for (int i = 0; i < aryRegex.Length; i++)
            {
                Regex regex = new Regex(aryRegex[i], RegexOptions.IgnoreCase);
                strStripped = regex.Replace(strStripped, aryReplacment[i]);
            }
            //Replace "\r\n" to an empty character.
            strStripped.Replace("\r\n", "");
            strStripped.Replace("\t", "");
            //Return stripped string.
            return strStripped;
        }

        #region    判断是字符串否符匹配正则表示
        /// <summary>
        /// 判断是字符串否符匹配正则表示
        /// </summary>
        /// <param name="s">字符</param>
        /// <param name="pattern">正则</param>
        /// <returns></returns>
        public static bool IsMatch(this string s, string pattern)
        {
            if (s == null) return false;
            else return Regex.IsMatch(s, pattern);
        }
        #endregion

        #region    通过正则获取字符串
        /// <summary>
        /// 通过正则获取字符串
        /// </summary>
        /// <param name="s">字符</param>
        /// <param name="pattern">正则</param>
        /// <returns></returns>
        public static string Match(this string s, string pattern)
        {
            if (s == null) return "";
            return Regex.Match(s, pattern).Value;
        }
        #endregion

        #region 转全角(SBC case)
        /// <summary>
        /// 转全角(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        #endregion

        #region 转半角(DBC case)
        /// <summary>
        /// 转半角(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region  GB2312转换成UTF-8
        /// <summary>
        /// GB2312转换成UTF-8
        /// </summary>
        /// <param name="gbInfo"></param>
        /// <returns></returns>
        public static string ToUTF8(this string gbInfo)
        {
            string Info = string.Empty;
            System.Text.Encoding gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            System.Text.Encoding utf_8 = System.Text.Encoding.GetEncoding("UTF-8");
            byte[] unicodeBytes = gb2312.GetBytes(gbInfo);
            byte[] asciiBytes = System.Text.Encoding.Convert(gb2312, utf_8, unicodeBytes);
            char[] asciiChars = new char[utf_8.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            utf_8.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string info = new string(asciiChars);
            return info;
        }
        #endregion

        #region 对字符串进行URL编码
        /// <summary>
        /// 对字符串进行URL编码
        /// </summary>
        /// <param name="Tex"></param>
        /// <returns></returns>
        public static string ToUrlEncode(this string Tex)
        {
            try
            {
                return HttpContext.Current.Server.UrlEncode(Tex);
            }
            catch (Exception)
            {
                return "";
                throw;
            }
        }
        #endregion

        #region 对字符串进行URL解码
        /// <summary>
        /// 对字符串进行URL解码
        /// </summary>
        /// <param name="Tex"></param>
        /// <returns></returns>
        public static string ToUrlDecode(this string Tex)
        {
            try
            {
                return HttpContext.Current.Server.UrlDecode(Tex);
            }
            catch (Exception)
            {
                return "";
                throw;
            }
        }
        #endregion

        #region 对字符串进行html 解码
        /// <summary>
        /// 对字符串进行html 解码
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToHtmlConvertStr(this string obj)
        {
            return HttpContext.Current.Server.HtmlDecode(obj);
        }
        #endregion

        #region DataTable转对象
        /// <summary>
        /// DataTable转成 List
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        [Obsolete("该方法已放弃,请不要在调用.")]
        public static List<T> ToDataTableToList<T>(this DataTable dataTable) where T : class, new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T t = new T();
                var propertis = t.GetType().GetProperties().ToList();

                foreach (DataColumn ItemColumn in dataTable.Columns)
                {
                    var properinfo = propertis.FirstOrDefault(b => b.Name == ItemColumn.ColumnName);
                    if (properinfo != null)
                    {
                        try
                        {
                            var value = row[properinfo.Name];
                            if (value != null && value != DBNull.Value)
                            {
                                properinfo.SetValue(t, row[properinfo.Name], null);
                            }
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }
        /// <summary>
        /// DataTable转成 Moudel
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static T ToDataTableToMoudel<T>(this DataTable dataTable) where T : class, new()
        {
            if (dataTable.Rows.Count <= 0)
            {
                return null;
            }
            T t = new T();
            var propertis = t.GetType().GetProperties().ToList();
            var row = dataTable.Rows[0];
            foreach (DataColumn ItemColumn in dataTable.Columns)
            {
                var properinfo = propertis.FirstOrDefault(b => b.Name == ItemColumn.ColumnName);
                if (properinfo != null)
                {
                    try
                    {
                        var value = row[properinfo.Name];
                        if (value != null)
                        {
                            Type ty = properinfo.PropertyType;
                            if (ty.Name.Contains("Single"))
                            {
                                properinfo.SetValue(t, row[properinfo.Name].ToDouble(), null);
                            }
                            else
                            {
                                properinfo.SetValue(t, row[properinfo.Name], null);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            return t;
        }
        #endregion

        #region 枚举转换List对象
        /// <summary>
        /// 枚举转换List对象
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<EnumModel> EnumToDiction<TEnum>()
        {
            List<EnumModel> list = new List<EnumModel>();
            Type e = typeof(TEnum);
            var eVlaus = Enum.GetValues(e);
            foreach (Enum item in eVlaus)
            {
                EnumModel model = new EnumModel();
                string name = Enum.GetName(e, item);
                int val = item.ToInt();
                model.Name = name;
                model.Value = val;
                model.Desc = item.ToEnumDesc();
                list.Add(model);
            }
            return list;
        }
        #endregion

        #region 获取枚举类型值的描述信息
        /// <summary>
        /// 获取枚举类型值的描述信息
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEnumDesc(this Enum value)
        {
            var t = value.GetType();
            var m = t.GetField(value.ToString());
            if (m == null)
            {
                return "未知";
            }
            string desc = "";
            if (m.IsDefined(typeof(DescriptionAttribute), false))
            {
                object[] ds = m.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (ds != null && ds.Length > 0) desc = (ds[0] as DescriptionAttribute).Description;
            }
            if (!string.IsNullOrEmpty(desc)) return desc;
            return value.ToString();
        }

        #endregion

        #region 获取自定义特性的数据信息,返回该特性对象
        /// <summary>
        /// 获取自定义特性的数据信息,返回该特性对象
        /// </summary>
        /// <param name="proper"></param>
        /// <returns></returns>
        public static T ToCustoAttributes<T>(this PropertyInfo proper) where T : class, new()
        {
            T column = null;
            if (proper.IsDefined(typeof(T), false))
            {
                object[] ds = proper.GetCustomAttributes(typeof(T), false);
                if (ds != null && ds.Length > 0)
                {
                    column = ds[0] as T;
                }

            }
            return column;
        }

        #endregion
    }
    /// <summary>
    /// 枚举信息对象
    /// </summary>
    public class EnumModel
    {
        /// <summary>
        /// 枚举值
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 枚举描述特性
        /// </summary>
        public string Desc { get; set; }
    }
}
