
using System;
using System.Linq;
using System.Runtime.Caching;

namespace FewMain.Common.Cache.NetCache
{
    #region ------MemoryCache 缓存(缓存在服务端)
    /// <summary>
    /// MemoryCache 缓存(缓存在服务端)
    /// </summary>
    public class MemoryCacheHelper
    {

        public object this[string key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                this.Set(key, value);
            }
        }
        /// <summary>
        /// 设置一个缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, object value)
        {
            try
            {
                MemoryCache chache = MemoryCache.Default;
                // CacheItem item = chache.GetCacheItem(Key);
                CacheItemPolicy policy = new CacheItemPolicy();
                //policy.Priority = CacheItemPriority.NotRemovable;
                //Set方法首先会检查Key是否在缓存中存在，如果存在，更新value，不存在则创建新的
                chache.Set(key, value, policy);
            }
            catch (Exception e)
            {
                //Pfhoo.Common.LogHelper.Info("设置缓存报错了" + e.Message);
            }
        }
        /// <summary>
        /// 设置一个缓存
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <param name="Minutes">过期日期，单位分钟</param>
        public void Set(string key, object value, double minutes)
        {
            try
            {
                MemoryCache chache = MemoryCache.Default;
                // CacheItem item = chache.GetCacheItem(Key);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(minutes);
                //Set方法首先会检查Key是否在缓存中存在，如果存在，更新value，不存在则创建新的
                chache.Set(key, value, policy);
            }
            catch (Exception e)
            {
                //Pfhoo.Common.LogHelper.Info("设置缓存报错了" + e.Message);
            }
        }
        /// <summary>
        /// 获取一个缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            try
            {
                return MemoryCache.Default.GetCacheItem(key).Value;

            }
            catch (Exception)
            {
                return null;
            }
        }
        public T Get<T>(string key) where T : class
        {
            try
            {
                return MemoryCache.Default.GetCacheItem(key).Value as T;

            }
            catch (Exception e)
            {
                string str = "";
                foreach (var item in MemoryCache.Default.ToList())
                {
                    str += item.Key;
                    str += ",";
                }
                //Pfhoo.Common.LogHelper.Info("获取缓存报错了" + Key + ",缓存的信息:" + str + "--报错信息:" + e.Message);
                return null;
            }
        }

        public bool CheckCaceh(string key, bool isContains = false)
        {
            int count = 0;
            if (isContains)
            {
                count = MemoryCache.Default.Where(b => b.Key.Contains(key)).Count();
            }
            else {
                count = MemoryCache.Default.Where(b => b.Key == key).Count();
            }
            
            return count > 0;
        }

        /// <summary>
        /// 删除一个缓存对象
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            try
            {

                MemoryCache.Default.Remove(key);
            }
            catch { }
        }
        /// <summary>
        /// 删除包含Key的缓存对象
        /// </summary>
        /// <param name="key"></param>
        public void RemoveByContainsKey(string key)
        {
            try
            {
                var cacheList = MemoryCache.Default.Where(b => b.Key.Contains(key)).ToList();
                foreach (var item in cacheList)
                {
                    MemoryCache.Default.Remove(item.Key);
                }
            }
            catch { }
        }
    }
    #endregion
}
