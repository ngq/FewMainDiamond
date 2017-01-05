using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FewMain.IService;

namespace FewMainDiamond.Controllers
{
    public class HomeController : Controller
    {
        
        private IFewMainUsersServices users;
        
        public HomeController(IFewMainUsersServices users)
        {
            this.users = users;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
         
            return View();
        }

         
    }
}