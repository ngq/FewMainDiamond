using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FewMainDiamond.Areas.User.Controllers
{
    public class CollectionController : Controller
    {
        // GET: User/Collection
        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}