using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FewMainDiamond.Controllers
{
    public class LayoutController : Controller
    {
        /// <summary>
        /// 布局通用公共部分
        /// </summary>
        /// <returns></returns>
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 头部
        /// </summary>
        /// <returns></returns>
        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Head()
        {
            return PartialView();
        }
        /// <summary>
        /// 导航
        /// </summary>
        /// <returns></returns>
        public ActionResult Nav()
        {

            return PartialView();
        }
        /// <summary>
        /// 底部
        /// </summary>
        /// <returns></returns>
        public ActionResult Footer()
        {
            return PartialView();
        }
        /// <summary>
        /// 右侧导航
        /// </summary>
        /// <returns></returns>
        public ActionResult RightFooterNav()
        {
            return PartialView();
        }

        
    }
}