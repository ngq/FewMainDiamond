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
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetImg(string id)
        {
           
            string code = string.Empty;
            byte[] bytes = ValidateCode.CreateValidateGraphic(out code);
            if (id == "register")
            {
                CacheHelper.Session["registercode"] = code;
            }
            else if (id == "login")
            {
                CacheHelper.Session["logincode"] = code;
            }
           
            return File(bytes,  @"image/jpeg");
        }
    }
}