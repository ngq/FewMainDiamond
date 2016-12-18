using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FewMain.Common;
using FewMain.Common.Cache;

namespace FewMainDiamond.Controllers
{
    /// <summary>
    /// 通用方法调用
    /// </summary>
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 生成验证码,把验证信息存放的session中
        /// </summary>
        /// <returns></returns>
        public ActionResult GetImgCode(string id)
        {
           
            string code = string.Empty;
            byte[] bytes = ValidateCode.CreateValidateGraphic(out code);
            if (id == "register")
            {
                CacheHelper.Session["registercode"] = code.ToLower();
            }
            else if (id == "login")
            {
                CacheHelper.Session["logincode"] = code.ToLower();
            }
           
            return File(bytes,  @"image/jpeg");
        }
    }
}