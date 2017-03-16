using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewMain.Common;
using FewMain.Common.Cache;
using FewMain.Model;
using FewMain.Model.CurrentModel;
using FewMain.Model.ParamModel;

namespace FewMain.Service
{
    public partial class FewMainUsersServices
    {
        #region 登录相关
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool Login(LoginParam parms)
        {
           
            parms.Password = EncryptHelper.GetMD5(parms.Password);
            var user = Query(t => t.UserName == parms.UserName && t.Password == parms.Password).FirstOrDefault();
            if (user != null)
            {
                UserModel currentModel = new UserModel();
                currentModel.UserId = user.ID.ToString();
                currentModel.Name = user.UserName;
                currentModel.NickName = user.NickName;
                string json = JsonHelper.ToJSON(currentModel);
                //缓存登录信息
                CacheHelper.Cookie.Set(BaseConfig.CookieLoginUserInfo, EncryptHelper.Encryption(json), 1440);
            }
            return user == null ? false : true;
        }
        #endregion

        #region 注册相关
        public bool Register(RegisterParam parms)
        {
            try
            {
                   var model = new FewMainUsers() { AddTime = DateTime.Now, Email = parms.Email, Mobile = parms.Mobile, Password = EncryptHelper.GetMD5( parms.Password), UserName = parms.UserName, Weixin = parms.Weixin };
                Add(model);
                return SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
           
           
        }

        /// <summary>
        /// 检验账号是否被占用
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool CheckUserAccount(string account)
        {
            if (Query(t => t.UserName == account).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 检验手机号是否被占用
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool CheckMobile(string mobile)
        {
            if (Query(t => t.UserName == mobile).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 验证Email是否可用
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmail(string email)
        {
            if (Query(t => t.UserName == email).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 验证微信号是否存在
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        public bool CheckWeixin(string weixin)
        {
            if (Query(t => t.UserName == weixin).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
