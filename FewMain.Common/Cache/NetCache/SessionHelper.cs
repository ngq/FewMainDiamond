
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FewMain.Common.Cache.NetCache
{
    #region ------ 定义缓存操作(针对Session)
    /// <summary>
    /// 定义缓存操作
    /// </summary>
    public class SessionHelper : ICache
    {
        public object this[string key]
        {
            get
            {
                return HttpContext.Current.Session[key];
            }
            set
            {
                HttpContext.Current.Session[key] = value;
            }
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, object value)
        {
            this[key] = value;
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minute">过期日期(单位分钟)</param>
        public void Set(string key, object value, double minute)
        {
            HttpContext.Current.Session.Timeout = Convert.ToInt32(minute);
            HttpContext.Current.Session.Add(key, value);
        }
        /// <summary>
        /// 通过Cookie获取Session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return HttpContext.Current.Session[key];
        }
        /// <summary>
        /// 获取cookie值
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">key值</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            var t = HttpContext.Current.Session[key] as T;
            return t;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

    }
    #endregion
}
