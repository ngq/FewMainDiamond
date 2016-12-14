using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FewMain.Common.Cache.NetCache
{
    #region ------ 定义缓存操作(针对Cookie)
    /// <summary>
    /// 定义缓存操作
    /// </summary>
    public class CookieHelper : ICache
    {
        public object this[string Key]
        {
            get
            {
                return HttpContext.Current.Request.Cookies[Key];
            }
            set
            {
                HttpContext.Current.Request.Cookies[Key].Value = value.ToString();
            }
        }
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void Set(string Key, object Value)
        {
            HttpCookie cook = new HttpCookie(Key, Value.ToString());
            HttpContext.Current.Response.Cookies.Add(cook);
        }
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <param name="Minute">过期日期(单位:分钟)</param>
        public void Set(string Key, object Value, double Minute)
        {
            HttpCookie cook = new HttpCookie(Key, Value.ToString());
            cook.Expires = DateTime.Now.AddMinutes(Minute);
            HttpContext.Current.Response.Cookies.Add(cook);
        }
        /// <summary>
        /// 通过key获取Cookie
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public object Get(string Key)
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[Key];
            return cook == null ? null : cook.Value;
        }
        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[key];
            if (cook != null)
            {
                cook.Expires = DateTime.Now.AddDays(-99);
                HttpContext.Current.Response.Cookies.Add(cook);
            }
        }
        /// <summary>
        /// 未定义
        /// </summary>
        public void Clear()
        {

        }

        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <typeparam name="T">T类型</typeparam>
        /// <param name="Key">key值</param>
        /// <returns></returns>
        public T Get<T>(string Key) where T : class
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[Key];
            return cook == null ? null : JsonHelper.ParseJSON<T>(cook.Value);
        }
    }

    #endregion
}
