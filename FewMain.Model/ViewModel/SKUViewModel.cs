using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model.ViewModel
{
    public class SKUSearchModel
    {
        public List<SKUViewModel> PageList { get; set; }
        /// <summary>
        /// 总页码
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 当前总数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 查询出的数量
        /// </summary>
        public int ShowCount { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal Rate { get; set; }

        public string DiamondInfo { get; set; }
    }

    public class SKUViewModel
    {
        public int Id { get; set; }
        public string SKUNo { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 形状
        /// </summary>
        public string Shape { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 净度
        /// </summary>
        public string Clarity { get; set; }
        /// <summary>
        /// 切工
        /// </summary>
        public string Cut { get; set; }
        /// <summary>
        /// 抛光
        /// </summary>
        public string Polishing { get; set; }
        /// <summary>
        /// 对称
        /// </summary>
        public string Symmetry { get; set; }
        /// <summary>
        /// 荧光
        /// </summary>
        public string Fluorescence { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 咖色
        /// </summary>
        public string Coffee { get; set; }
        /// <summary>
        /// 奶色
        /// </summary>
        public string Milk { get; set; }
        /// <summary>
        /// 证书类型
        /// </summary>
        public string ProNoType { get; set; }
        /// <summary>
        /// 钻石尺寸
        /// </summary>
        public string DiaSize { get; set; }

        /// <summary>
        /// 证书编号
        /// </summary>
        public string ProNo { get; set; }

        public string Delivery { get; set; }

        public string  State { get; set; }
    }
}
