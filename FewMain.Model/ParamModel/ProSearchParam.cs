using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FewMain.Model.CommonModel;

namespace FewMain.Model.ParamModel
{
    /// <summary>
    /// 产品列表传入参数实体
    /// </summary>
    public class ProSearchParam: Pager
    {
       /// <summary>
       /// 产品分类ID
       /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 产品分类名称
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 形状
        /// </summary>
        public int Shape { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public int Material { get; set; }
        /// <summary>
        /// 款式
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public int Weight  { get; set; }
        /// <summary>
        /// 系列
        /// </summary>
        public int Series { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
       
        /// <summary>
        /// 当前用户的URL
        /// </summary>
        public string Url { get; set; }
    }
}
