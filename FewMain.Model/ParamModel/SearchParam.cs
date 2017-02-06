using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model.ParamModel
{
    public class SearchParam
    {
        /// <summary>
        /// 颜色
        /// </summary>
        public List<int> Color { get; set; }
        /// <summary>
        /// 净度
        /// </summary>
        public List<int> Clarity { get; set; }
        /// <summary>
        /// 切工
        /// </summary>
        public List<int> Cut { get; set; }
        /// <summary>
        /// 形状
        /// </summary>
        public List<int> Shape  { get; set; }
        /// <summary>
        /// 抛光
        /// </summary>
        public List<int> Polishing { get; set; }
        /// <summary>
        /// 对称
        /// </summary>
        public List<int> Symmetry { get; set; }
        /// <summary>
        /// 荧光
        /// </summary>
        public List<int> Fluorescence { get; set; }
        /// <summary>
        /// 证书
        /// </summary>
        public List<int> Credentials { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal WeightStart { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal WeightEnd { get; set; }
        /// <summary>
        /// 不奶不咖
        /// </summary>
        public int NoMilky { get; set; }
        /// <summary>
        /// 浅咖不奶
        /// </summary>
        public int NoMilkyShade { get; set; }
        /// <summary>
        /// 货号/证书号
        /// </summary>
        public string ProNoType { get; set; }
        /// <summary>
        /// 货号/证书号 值
        /// </summary>
        public string ProNoValue { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 在国外
        /// </summary>
        public int OutSide { get; set; }
        /// <summary>
        /// 在香港
        /// </summary>
        public int InSideHK { get; set; }
        /// <summary>
        /// 在国内
        /// </summary>
        public int InChina { get; set; }
        /// <summary>
        /// 现货
        /// </summary>
        public int IsStock { get; set; }
        /// <summary>
        /// 实时
        /// </summary>
        public int IsLive { get; set; }
    }
}
