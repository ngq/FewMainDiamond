using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewMain.Model.ParamModel;

namespace FewMain.Common
{
    public class DiamondHelper
    {
        /// <summary>
        /// 构造请求的URL
        /// </summary>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public static string CustomUrl(SearchParam parms)
        {
            string url = "";

            #region 链接拼接

            #region 形状→ shape
            string shape = "";
            if (parms.Shape.Count > 0)
            {
                shape = string.Join("-", parms.Shape);
            }
            else
            {
                shape = "0";
            }
            #endregion

            #region 颜色→Color

            int color =0;
            if (parms.Color.Count>0)
            {
                color = parms.Color.Sum();
            }

            #endregion

            #region 净度→Clarity
            int clarity = 0;
            if (parms.Clarity.Count > 0)
            {
                clarity = parms.Clarity.Sum();
            }
            #endregion

            #region 切工→Cut

            int cut = 0;
            if (parms.Cut.Count > 0)
            {
                cut = parms.Cut.Sum();
            }
            #endregion

            #region 抛光→Polishing
            int polishing = 0;
            if (parms.Polishing.Count>0)
            {
                polishing = parms.Polishing.Sum();
            }
            #endregion

            #region 对称

            int symmetry = 0;
            if (parms.Symmetry.Count>0)
            {
                symmetry = parms.Symmetry.Sum();
            }
            #endregion

            #region 证书→Credentials

            int credentials = 0;
            if (parms.Credentials.Count>0)
            {
                credentials = parms.Credentials.Sum();
            }
            #endregion

            #region 荧光→Fluorescence

            int fluorescence = 0;
            if (parms.Fluorescence.Count>0)
            {
                fluorescence = parms.Fluorescence.Sum();
            }
            #endregion

            #endregion
            #region 参数拼接
            #region 重量参数
            if (parms.WeightStart > 0)
            {
                url += string.Format("?q_carat1={0}", parms.WeightStart);
            }
            else
            {
                url += "?q_carat1=";
            }
            if (parms.WeightEnd > 0)
            {
                url += string.Format("&q_carat2={0}", parms.WeightEnd);
            }
            else
            {
                url += "&q_carat2=";
            }
            #endregion

            #region 货号/证书号
            url += "&q_id_type=report_no&q_id=";
            #endregion

            #region 奶咖
            //不奶不咖
            if (parms.NoMilky)
            {
                url += "&q_no_milky_shade=1";
            }
            //浅奶不咖
            if (parms.NoMilkyShade)
            {
                url += "&q_shade_milky_shade=1";
            }
            #endregion

            #region 页容量
            url += "&q_perpage=50";
            #endregion

            #region 区域

            if (parms.OutSide)
            {
                url += "&q_is_outside=1";
            }
            if (parms.InSideHK)
            {
                url += "&q_is_inside=1";
            }
            if (parms.InChina)
            {
                url += "&q_is_cn=1";
            }
            #endregion

            #region 实时,现货
            if (parms.IsStock)
            {
                url += "&q_is_stock=1";
            }
            if (parms.IsLive)
            {
                url += "&q_is_live=1";
            }
            #endregion 

            #region 页码
            if (parms.PageIndex > 0)
            {
                url += "&page=" + parms.PageIndex;
            }
            else
            {
                url += "&page=1";
            }

            #endregion

            #endregion

            url = string.Format("{0}--{1}--{2}--{3}--{4}--{5}--{6}--{7}.html{8}", shape, color, clarity, cut, polishing, symmetry, credentials, fluorescence,url);

            return url;
        }
    }
}
