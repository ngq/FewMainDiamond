using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using FewMain.Common;
using FewMain.Model;
using FewMain.Model.ParamModel;
using FewMain.Model.ViewModel;

namespace FewMainDiamond.Controllers
{
    public class DiamondController : Controller
    {

        public static HttpClient HttpClient { get; set; }

        // GET: Diamond
        public ActionResult Index()
        {
            HttpClient = Login();
            return View();
        }

        public ActionResult GetDiamondData(SearchParam parms)
        {
           string url= DiamondHelper.CustomUrl(parms);
            return null;
        }


        #region 构造Url

         
        #endregion

        #region 获取远程数据
        /// <summary>
        /// 登录远程网站
        /// </summary>
        public static HttpClient Login()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Add("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.8,zh-TW;q=0.6");
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
            httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            httpClient.DefaultRequestHeaders.Add("Host", "www.888gia.com");
            httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            httpClient.DefaultRequestHeaders.Add("Cookie", "kcdg_sessid=46qt3f3cmn5h67p7jsehnqntr2; kc_broadcast=1483774728; kcdg_kcdg_last=c4e32z3lDsvuZui7kYLy%2FNcZV3%2B9RmbRO%2BVo82SOHEDxBTMpGlFr");
            httpClient.DefaultRequestHeaders.Add("Origin", "http://www.888gia.com");
            httpClient.DefaultRequestHeaders.Add("Referer", "http://www.888gia.com/login");
            httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            httpClient.BaseAddress = new Uri("http://www.888gia.com/login");
            var uri = "http://www.888gia.com/login";

            var content = new FormUrlEncodedContent(new Dictionary<string, string>()
           {
               {"user_name", "nieq"},
               {"user_pwd", "ngq123456A"}
           });
            var response = httpClient.PostAsync(uri, content).Result;
            return httpClient;
            #region 注释

            //var data = response.Headers.ToDictionary(t => t.Key);
            //data["Set-Cookie"].Value.First();//获取cookie 
            //string responseString = response.Content.ReadAsStringAsync().Result;
            // return httpClient;

            #endregion

        }
        /// <summary>
        /// 根据链接获取当前页的字符串数据
        /// </summary>
        /// <param name="url">请求链接</param>
        /// <returns></returns>
        private static string GetHtml(string url)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            HttpClient.DefaultRequestHeaders.Referrer = new Uri("http://www.888gia.com/diamond/");
            response = HttpClient.GetAsync(new Uri(url)).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
        /// <summary>
        /// 获取当前页的数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private SKUSearchModel GetDiamondData(string url)
        {

            var PageInfo = GetHtml(url);
            #region 获取钻石数据
            string RegexStr =
                    "<tr class=\"list\"[\\w\\W]*?><td[\\w\\W]*?>(?<check>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<mark>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<onsale>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<datePro>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<shape>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<weight>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<clo>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<jingdu>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<cut>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<paoguang>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<duichen>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<yingguang>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<zhijing>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<gia>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<pic>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<shipin>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<meijin>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<zhekou>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<rmb>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<kase>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<naise>[\\w\\W]*?)</td><td[\\w\\W]*?>(?<xuangou>[\\w\\W]*?)</td></tr>";
            SKUSearchModel model = new SKUSearchModel();
            List<SKUViewModel> list = new List<SKUViewModel>();

            PageInfo = PageInfo.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace("\\", "").Replace("<!-- 转换字段图片 -->", "").Replace("<!--                                管理员端                            -->", "");
            MatchCollection mc = Regex.Matches(PageInfo, RegexStr,
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            foreach (Match item in mc)
            {
                list.Add(new SKUViewModel()
                {
                    #region 整理成数据
                    Shape = item.Groups["shape"].Value,
                    Weight = Convert.ToDecimal(StripHTMLToTEXT(item.Groups["weight"].Value)),
                    Color = item.Groups["clo"].Value,
                    Cut = item.Groups["cut"].Value,
                    Clarity = item.Groups["jingdu"].Value,
                    Polishing = item.Groups["paoguang"].Value,
                    Symmetry = item.Groups["duichen"].Value,
                    Fluorescence = item.Groups["yingguang"].Value,
                    SKUNo = "",
                    Price = Convert.ToDecimal(StripHTMLToTEXT(item.Groups["rmb"].Value)),
                    Milk = item.Groups["naise"].Value,
                    Coffee = item.Groups["kase"].Value,
                    #endregion
                });

            }
            #endregion

            #region 获取数量信息

            string regexProInfo = "";
            #endregion
            model.PageList = list;
            return model;

        }

        public static string StripHTMLToTEXT(string strHtml)
        {
            //All the regular expression for matching html, javascript, style elements and others.
            string[] aryRegex ={@"<%=[\w\W]*?%>",    @"<script[\w\W]*?</script>",     @"<style[\w\W]*?</style>",   @"<[/]?[\w\W]*?>",   @"([\r\n])[\s]+",
                                    @"&(nbsp|#160);",    @"&(iexcl|#161);",               @"&(cent|#162);",            @"&(pound|#163);",   @"&(copy|#169);",
                                   @"&#(\d+);",         @"-->",                          @"<!--.*\n"};
            //Corresponding replacment to the regular expressions.
            //string[] aryReplacment = { "", "", "", "", "", " ", "\xa1", "\xa2", "\xa3", "\xa9", "", "\r\n", "" };
            string[] aryReplacment = { "", "", "", "", "", " ", "", "", "", "", "", "", "" };
            string strStripped = strHtml;
            //Loop to replacing.
            for (int i = 0; i < aryRegex.Length; i++)
            {
                Regex regex = new Regex(aryRegex[i], RegexOptions.IgnoreCase);
                strStripped = regex.Replace(strStripped, aryReplacment[i]);
            }
            //Replace "\r\n" to an empty character.
            strStripped.Replace("\r\n", "");
            strStripped.Replace("\t", "");
            //Return stripped string.
            return strStripped;
        }
        #endregion
    }
}
