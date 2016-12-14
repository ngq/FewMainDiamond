using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FewMain.Common.Cache;
using FewMain.IService;
using FewMain.Model;
using FewMain.Model.ParamModel;

namespace FewMainDiamond.Controllers
{
    /// <summary>
    /// 账号相关
    /// </summary>
    public class AccountController : Controller
    {
        private IUsersServices userBll;

        public AccountController(IUsersServices users)
        {
            this.userBll = users;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        #region  登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 登录信息
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UsersLoginParam userModel)
        {
            string returnUrl = Request["returnUrl"];
            if (userModel.UserName.IsNullOrEmpty())
            {
                return Json(new ResultModel() { Data = "", IsSuccess = false, Msg = "请输入用户名" });
            }
            else if (userModel.Password.IsNullOrEmpty())
            {
                return Json(new ResultModel() { Data = "", IsSuccess = false, Msg = "请输入密码" });
            }
            else
            {
                var result = userBll.Login(userModel);
                if (!result)
                {
                    return Json(new ResultModel() { Data = "", IsSuccess = false, Msg = "登录失败,用户名或密码错误" });
                }
                else
                {
                    return Json(new ResultModel() { Data = returnUrl.IsNullOrEmpty() ? " / " : returnUrl, IsSuccess = true, Msg = "登录成功" });
                }
            }
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterParam parms)
        {
           var result=new ResultModel();
            if (parms.Password!=parms.RePassword)
            {
                result=new ResultModel()
                {
                    IsSuccess = false,
                    Msg = "两次密码不一致"
                };
            }else if (CacheHelper.Session["imgcode"].ToString() != parms.ValidateCode)
            {
                result = new ResultModel()
                {
                    IsSuccess = false,
                    Msg = "图片验证码错误"
                };
            }

             
            return new ContentResult();
        }
        #endregion

        #region 忘记密码

        public ActionResult Forget()
        {
           return View();
        }
        #endregion

    }
}