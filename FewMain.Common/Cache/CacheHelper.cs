using FewMain.Common.Cache.NetCache;

namespace FewMain.Common.Cache
{
    /// <summary>
    ///定义缓存操作
    /// </summary>
    public static class CacheHelper
    {
        private static ICache _cache;
        /// <summary>
        ///缓存操作对象Session
        /// </summary>
        public static ICache Session
        {
            get
            {
                if (_cache == null)
                {
                    _cache = new SessionHelper();
                }
                return _cache;
            }
        }

        private static ICache _cacheCookie;
        /// <summary>
        ///缓存操作对象Cookie
        /// </summary>
        public static ICache Cookie
        {
            get
            {
                if (_cacheCookie == null)
                {
                    _cacheCookie = new CookieHelper();
                }
                return _cacheCookie;
            }
        }

        private static MemoryCacheHelper _memoryCache;
        /// <summary>
        ///缓存操作对象MemoryCache
        /// </summary>
        public static MemoryCacheHelper MemoryCache
        {
            get
            {
                if (_memoryCache == null)
                {
                    _memoryCache = new MemoryCacheHelper();
                }
                return _memoryCache;
            }
        }

    }
}
