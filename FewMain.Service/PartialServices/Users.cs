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
    public partial class UsersServices
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool Login(UsersLoginParam parms)
        {
            parms.Password = EncryptHelper.GetMD5(parms.Password);
            var user= Query(t=>t.UserName==parms.UserName&&t.Password==parms.Password).FirstOrDefault();
            if (user!=null)
            {
                UserModel  currentModel=new UserModel();
                currentModel.UserId = user.ID.ToString();
                currentModel.Name = user.UserName;
                currentModel.NickName = user.NickName;
                string json = JsonHelper.ToJSON(currentModel);
                //缓存登录信息
                CacheHelper.Cookie.Set(BaseConfig.CookieLoginUserInfo, EncryptHelper.Encryption(json),1440);
            }
            return user==null?false:true;
        }

        #region 注册相关
        public bool Register(RegisterParam parms)
        {
            return false;
        }
        /// <summary>
        /// 检验手机号是否被占用
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool CheckMobile(RegisterParam parms)
        {
            return false;
        }
        /// <summary>
        /// 验证Email是否可用
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool CheckEmail(RegisterParam parms)
        {
            return false;
        }
        /// <summary>
        /// 验证微信号是否存在
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public bool CheckWeixin(RegisterParam parms)
        {
            return false;
        }
        #endregion
    }
}
