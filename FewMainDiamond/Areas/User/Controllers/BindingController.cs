using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FewMainDiamond.Areas.User.Controllers
{
    public class BindingController : Controller
    {
        // GET: User/Binding
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///  手机绑定
        /// </summary>
        /// <returns></returns>
        public ActionResult Mobile()
        {
            return View();
        }
        /// <summary>
        /// 邮箱绑定
        /// </summary>
        /// <returns></returns>
        public ActionResult Email()
        {
            return View();
        }
        /// <summary>
        /// 密码修改
        /// </summary>
        /// <returns></returns>
        public ActionResult ModifyPwd()
        {
            return View();
        }

    }
}