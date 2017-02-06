using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model.ParamModel
{
    public class SearchParam
    {
        #region 八大属性集合
        /// <summary>
        /// 颜色
        /// </summary>
        public List<int> Color { get; set; }

        public string StrColor { get; set; }
        /// <summary>
        /// 净度
        /// </summary>
        public List<int> Clarity { get; set; }

        public string StrClarity { get; set; }
        /// <summary>
        /// 切工
        /// </summary>
        public List<int> Cut { get; set; }

        public string  StrCut { get; set; }
        /// <summary>
        /// 形状
        /// </summary>
        public List<int> Shape { get; set; }

        public string StrShape { get; set; }
        /// <summary>
        /// 抛光
        /// </summary>
        public List<int> Polishing { get; set; }

        public string StrPolishing { get; set; }
        /// <summary>
        /// 对称
        /// </summary>
        public List<int> Symmetry { get; set; }

        public string StrSymmetry { get; set; }
        /// <summary>
        /// 荧光
        /// </summary>
        public List<int> Fluorescence { get; set; }

        public string StrFluorescence { get; set; }
        /// <summary>
        /// 证书
        /// </summary>
        public List<int> Credentials { get; set; }

        public string StrCredentials { get; set; }
        #endregion

        #region 参数拼接
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
        public bool NoMilky { get; set; }
        /// <summary>
        /// 浅咖不奶
        /// </summary>
        public bool NoMilkyShade { get; set; }
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
        public bool OutSide { get; set; }
        /// <summary>
        /// 在香港
        /// </summary>
        public bool InSideHK { get; set; }
        /// <summary>
        /// 在国内
        /// </summary>
        public bool InChina { get; set; }
        /// <summary>
        /// 现货
        /// </summary>
        public bool IsStock { get; set; }
        /// <summary>
        /// 实时
        /// </summary>
        public bool IsLive { get; set; } 
        #endregion
    }
}
