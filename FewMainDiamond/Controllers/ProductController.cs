using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FewMainDiamond.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 款式欣赏
        /// </summary>
        /// <returns></returns>
        public ActionResult Style()
        {
            return View();
        }
    }
}