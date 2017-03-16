using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FewMain.Common;
using FewMain.IService;
using FewMain.Model.ParamModel;

namespace FewMainDiamond.Controllers
{
    public class ProductController : Controller
    {

        #region 属性
        private IFewMainProductServices proData;
        public ProductController(IFewMainProductServices proData)
        {
            this.proData = proData;
        }
        #endregion
        #region 列表页
        // GET: Product

        public ActionResult Index(ProSearchParam command)
        {
            command.PageSize = 20;
            command.Url = WebHelper.RemoveParam(Request.Url.AbsoluteUri, "page");  
            var model= proData.GetProduct(command);
            return View(model);
        }
        /// <summary>
        /// 处理传入参数
        /// </summary>
        public void ProcessParam(ProSearchParam command)
        {
            
        }

        #endregion

        /// <summary>
        /// 款式欣赏
        /// </summary>
        /// <returns></returns>
        public ActionResult Style()
        {
            return View();
        }
        /// <summary>
        /// 钻戒详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult DiamondDetail()
        {
            return View();
        }
        /// <summary>
        /// 珠宝饰品详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult JeweleryDetail()
        {
            return View();
        }
    }
}