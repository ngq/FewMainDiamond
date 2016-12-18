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
        public ActionResult Login( LoginParam userModel)
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
        #region 检验登录验证码
        /// <summary>
        /// 校验登录验证码
        /// </summary>
        /// <param name="codeVal"></param>
        /// <returns></returns>
        public ActionResult CheckLoginValidate(string codeVal)
        {
            if (CacheHelper.Session["logincode"].ToString() != codeVal.ToLower())
            {
                return Content("false");

            }
            else
            {
                return Content("true");
            }

        }
        #endregion
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
            }else if (CacheHelper.Session["registercode"].ToString() != parms.ValidateCode)
            {
                result = new ResultModel()
                {
                    IsSuccess = false,
                    Msg = "图片验证码错误"
                };
            }
            var isRegister = userBll.Register(parms);
            if (isRegister)
            {
                userBll.Login(new LoginParam() {Password = parms.Password, UserName = parms.UserName});
                //注册成功跳转到首页
                return RedirectToAction("Index", "Home");
            }
            else
            {
                result = new ResultModel()
                {
                    IsSuccess = false,
                    Msg = "注册失败"
                };
                return Json(result);
            }

            
        }

        #region 1.0 检验注册验证码
        /// <summary>
        /// 校验注册验证码
        /// </summary>
        /// <param name="codeVal"></param>
        /// <returns></returns>
        public ActionResult CheckRegisterValidate(string codeVal)
        {
            if (CacheHelper.Session["registercode"].ToString()!= codeVal.ToLower())
            {
                return Content("false");

            }
            else
            {
                return Content("true");
            }

        }
        #endregion

        #region 2.0 账号验证
        /// <summary>
        /// 校验注册验证码
        /// </summary>
        /// <param name="codeVal">被验证信息</param>
        /// <returns></returns>
        public ActionResult CheckUserAccount(string codeVal)
        {
            if (userBll.CheckUserAccount(codeVal))
            {
                return Content("false");

            }
            else
            {
                return Content("true");
            }

        }
        #endregion

        #region 3.0 邮箱验证
        /// <summary>
        /// 校验注册验证码
        /// </summary>
        /// <param name="codeVal">被验证信息</param>
        /// <returns></returns>
        public ActionResult CheckEmail(string codeVal)
        {
            if (userBll.CheckEmail(codeVal))
            {
                return Content("false");

            }
            else
            {
                return Content("true");
            }

        }
        #endregion

        #region 4.0 手机号验证
        /// <summary>
        /// 校验注册验证码
        /// </summary>
        /// <param name="codeVal">被验证信息</param>
        /// <returns></returns>
        public ActionResult CheckMobile(string codeVal)
        {
            if (userBll.CheckMobile(codeVal))
            {
                return Content("false");

            }
            else
            {
                return Content("true");
            }

        }
        #endregion

        #region 5.0 微信验证
        /// <summary>
        /// 校验注册验证码
        /// </summary>
        /// <param name="codeVal">被验证信息</param>
        /// <returns></returns>
        public ActionResult CheckWeixin(string codeVal)
        {
            if (userBll.CheckWeixin(codeVal))
            {
                return Content("false");

            }
            else
            {
                return Content("true");
            }

        }
        #endregion

        #endregion

        #region 忘记密码

        public ActionResult Forget()
        {
           return View();
        }
        #endregion

    }
}