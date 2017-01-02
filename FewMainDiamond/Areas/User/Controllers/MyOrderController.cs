using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FewMainDiamond.Areas.User.Controllers
{
    public class MyOrderController : Controller
    {
        // GET: User/Order
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 我的评价
        /// </summary>
        /// <returns></returns>
        public ActionResult Appraise()
        {
            return View();
        }
    }
}