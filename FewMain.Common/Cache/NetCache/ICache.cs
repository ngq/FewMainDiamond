namespace FewMain.Common.Cache.NetCache
{
    /// <summary>
    /// 服务端缓存操作接口
    /// </summary>
    public interface ICache
    {
        object this[string key] { get; set; }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        void Set(string key, object value);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        /// <param name="minute">过期日期(单位分钟)</param>
        void Set(string key, object value, double minute);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Get(string key);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">T类型</typeparam>
        /// <param name="key">keey值</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        void Remove(string key);
    }
}
