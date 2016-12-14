using FewMain.Model.CurrentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewMain.Common;
using FewMain.Common.Cache;
using FewMain.Common.Cache.NetCache;

namespace FewMain.WebHelper.CurrentContext
{
    /// <summary>
    /// 网站用户登录信息
    /// </summary>
  public  class CurrentUserContext
    {
        private static CurrentUserContext _current;
        /// <summary>
        /// 当前用户上下文对象
        /// </summary>
        public static CurrentUserContext Current
        {
            get
            {
                lock (typeof(CurrentUserContext))
                {
                    if (_current==null)
                    {
                        _current=new CurrentUserContext();
                    }
                    return _current;
                }
            }
        }

        private object lockObj=new object();
        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private UserModel Setting
        {
            get
            {
                lock (lockObj)
                {
                  string cookieVal=  CacheHelper.Cookie.Get(BaseConfig.CookieLoginUserInfo) as string;
                    if (cookieVal.IsNullOrEmpty())
                    {
                        return null;
                    }
                    var model = JsonHelper.ParseJSON<UserModel>(EncryptHelper.Decrypt(cookieVal));
                    return model;
                }
            }
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IsLogin
        {
            get
            {
                return UserId > 0;
            }
        }
        /// <summary>
        /// 用户UserId int 类型
        /// </summary>
        public int UserId
        {
            get
            {
                return Setting.UserId == null ? 0 : EncryptHelper.Decrypt(Setting.UserId).ToInt();
            }
        }
        /// <summary>
        /// 账户名称
        /// </summary>
        public string UserName
        {
            get
            {
                return this.Setting == null ? "" : this.Setting.Name.ToUrlDecode();
            }
        }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName
        {
            get
            {
                return this.Setting == null ? "" : this.Setting.NickName.ToUrlDecode();
            }
        }

    }
}
