using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.Model.ViewModel
{
    public class ProductListViewModel
    {
        /// <summary>
        /// 产品分页数据
        /// </summary>
        public List<Product> ProductList { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }


        public List<SearchInit> CatList { get; set; }
        #region 列表参数
        /// <summary>
        /// 分类参数
        /// </summary>
        public partial class SearchInit
        {
            /// <summary>
            /// 分类Id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 分类名
            /// </summary>
            public string Name { get; set; }

          

            /// <summary>
            /// 链接
            /// </summary>
            public string Url { get; set; }

            /// <summary>
            /// 是否被选择
            /// </summary>
            public bool IsChoose { get; set; }

            /// <summary>
            /// 子集 对于只有二级分类来说意义不大
            /// </summary>
            public List<SearchInit> ChildList { get; set; }
        }

        #region 可移除的筛选

        /// <summary>
        /// 可以移除的筛选
        /// </summary>
        public partial class FtingsRemove
        {
            /// <summary>
            /// 筛选名
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 筛选值
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// 等待移除的筛选URL
            /// </summary>
            public string Url { get; set; }
        }

        #endregion

        /// <summary>
        /// 形状参数
        /// </summary>
        public List<SearchInit> Shape { get; set; }
        /// <summary>
        ///款式参数
        /// </summary>
        public List<SearchInit> StyleList { get; set; }
        /// <summary>
        /// 材质参数
        /// </summary>
        public List<SearchInit> Material { get; set; }
        /// <summary>
        /// 系列参数
        /// </summary>
        public List<SearchInit> Series { get; set; }
        #endregion

    }
    /// <summary>
    /// 产品数据
    /// </summary>
    public class Product
    {
        #region 产品列表分页数据
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProId { get; set; }
        /// <summary>
        /// 产品图片链接
        /// </summary>
        public string ProImgSrc { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 名称 =系列名称+款式名称 + 钻石参数
        /// </summary>
        public string ProName { get; set; }
        #endregion
    }

    
    
}
