using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewMain.Model;
using FewMain.Model.ParamModel;

namespace FewMain.IService
{
    public partial interface IUsersServices
    {
        #region 1.0 登录相关
        bool Login( LoginParam userModel);
        #endregion

        #region  2.0 注册相关

        bool Register(RegisterParam parms);


        /// <summary>
        /// 检验账号是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        bool CheckUserAccount(string account);

        /// <summary>
        /// 检验手机号是否存在
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        bool CheckMobile(string mobile);

        /// <summary>
        /// 验证Email是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool CheckEmail(string email);


        /// <summary>
        /// 验证微信号是否存在
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        bool CheckWeixin(string weixin);

        #endregion

    }
}
