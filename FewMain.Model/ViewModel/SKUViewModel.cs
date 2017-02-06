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
        public decimal Weight { get; set; }
        public string Shape { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public string Cut { get; set; }
        public string Polishing { get; set; }
        public string Symmetry { get; set; }
        public string Fluorescence { get; set; }
        public decimal Price { get; set; }
        public string Coffee { get; set; }
        public string Milk { get; set; }
        public string ProNoType { get; set; }

        /// <summary>
        /// 证书编号
        /// </summary>
        public string ProNo { get; set; }
    }
}
