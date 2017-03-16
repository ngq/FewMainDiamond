using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FewMain.Common;
using FewMain.Model;
using FewMain.Model.ParamModel;
using FewMain.Model.ViewModel;

namespace FewMain.Service
{
    public partial class FewMainProductServices
    {
        public List<ProductListViewModel.FtingsRemove> FtingsRemoveList = new List<ProductListViewModel.FtingsRemove>();
        /// <summary>
        /// 获取产品列表的分页数据
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public ProductListViewModel GetProduct(ProSearchParam parms)
        {
            ProductListViewModel model = new ProductListViewModel();
            var query = BaseContext.FewMainProduct.Where(t => true);
            #region 进行筛选
            //关键字
            if (!parms.Keyword.IsNullOrEmpty())
            {
                query = query.Where(t => t.ProName.Contains(parms.Keyword));
            }
            //材质暂时设定 每个戒指都有
            if (parms.Material > 0)
            {
                query = query.Where(t => true);
            }
            if (parms.MinPrice > 0)
            {
                query = query.Where(t => t.Price >= parms.MinPrice);
            }
            if (parms.MaxPrice > 0)
            {
                query = query.Where(t => t.Price <= parms.MaxPrice);
            }
            if (parms.Series > 0)
            {
                query = query.Where(t => t.ProSeriesId == parms.Series);
            }
            if (parms.Shape > 0)
            {
                query = query.Where(t => t.ShapeId == parms.Shape);
            }
            if (parms.Type.IsNullOrEmpty())
            {
                query = query.Where(t => t.ProTypeName == parms.Type);
            }
            if (parms.TypeId > 0)
            {
                query = query.Where(t => t.ProTypeId == parms.TypeId);
            }
            //款式暂时不用
            if (parms.Style.IsNullOrEmpty())
            {

            }
            //1=销售量 2=添加时间 3=价格
            if (parms.Sort > 0)
            {
                if (parms.Sort == 1)
                {
                    query = query.OrderByDescending(t => t.AddTime);
                }
                else if (parms.Sort == 2)
                {
                    query = query.OrderByDescending(t => t.SaleCount);
                }
                else if (parms.Sort == 3)
                {
                    query = query.OrderByDescending(t => t.Price);
                }
                else
                {//默认排序
                    query = query.OrderByDescending(t => t.Sort);
                }
            }
            #endregion

            #region 数据分页
            var proCount = query.Count().ToDecimal();
            model.PageCount = Math.Ceiling(proCount / parms.PageSize).ToInt();
            model.ProductList = query.OrderByDescending(t => t.Sort).Skip((parms.Page - 1) * parms.PageSize).Select(t => new Product() { ProId = t.Id, ProName = t.ProName, ProImgSrc = t.MainImg, Price = t.Price }).ToList();

            #endregion


            #region 搜索列表
            //系列
            var series = BaseContext.FewMainSeries.Where(t => t.IsShow == 1).Select(t => new ProductListViewModel.SearchInit() { Id = t.Id, IsChoose = false, Name = t.SeriesName }).ToList(); ;
            //分类
            var cat = BaseContext.FewMainProType.Where(t => t.IsShow == 1 && t.ParentId == 4)
                .Select(t => new ProductListViewModel.SearchInit() { Id = t.Id, IsChoose = false, Name = t.TypeName }).ToList();
            //材质
            var marital = BaseContext.FewMainMaterial.Select(t => new ProductListViewModel.SearchInit() { Id = t.Id, IsChoose = false, Name = t.Material }).ToList();
            //形状
            var shape = BaseContext.FewMainShape.Where(t => t.IsShow == 1).Select(t => new ProductListViewModel.SearchInit() { Id = t.Id, IsChoose = false, Name = t.ShapeName }).ToList();
            model.Series = GetSearchInit(series, parms.Url, parms.Series > 0 ? new List<int>() { parms.Series } : new List<int>(), "Series");
            model.CatList = GetSearchInit(cat, parms.Url, parms.TypeId > 0 ? new List<int>() { parms.TypeId } : new List<int>(), "typeid");
            model.Material = GetSearchInit(marital, parms.Url, parms.Material > 0 ? new List<int>() { parms.Material } : new List<int>(), "Material");
            model.Shape = GetSearchInit(shape, parms.Url,
                parms.Shape > 0 ? new List<int>() {parms.Shape} : new List<int>(), "shape");
             
            #endregion
            return model;
        }

        /// <summary>
        /// 分类URL数据整理
        /// </summary>
        /// <param name="catList"></param>
        /// <param name="url"></param>
        /// <param name="chooseCat">当前被选中项</param>

        /// <param name="parmsType"></param>
        /// <returns></returns>
        public List<ProductListViewModel.SearchInit> GetSearchInit(List<ProductListViewModel.SearchInit> catList, string url, List<int> chooseCat, string parmsType)
        {

            foreach (var cat in catList)
            {
                var list = new List<int>();

                chooseCat = chooseCat == null ? new List<int>() : chooseCat;

                foreach (var chooseId in chooseCat)
                {
                    list.Add(chooseId);
                }

                //是否是已经被选择分类
                bool isChoose = false;

                if (chooseCat != null)
                    isChoose = chooseCat.Where(p => p == cat.Id).Count() > 0;

                string catStr = "";
                if (isChoose)
                {
                    //如果当前分类被选择 当前分类的 Url的URL的拼接要剔除这个分类ID 例如: catstr=1,2,3,4
                    catStr = string.Join(",", chooseCat.Where(p => p != cat.Id).ToList());
                    //设置当前子类为选中项
                    cat.IsChoose = true;

                    var remove = new ProductListViewModel.FtingsRemove();
                    remove.Name = "分类";
                    remove.Value = cat.Name;
                    remove.Url = WebHelper.InsertParam(url, parmsType, catStr);
                    FtingsRemoveList.Add(remove);
                }
                else
                {
                    //未被选择的分类的url=被选择的分类+当前分类的ID 拼接成URL
                    //chooseCat.Add(cat.Id); //多选时进行处理
                    var li = new List<int>() { cat.Id };
                    catStr = string.Join(",", li);
                }
                chooseCat = list;//此位置始终保持chooseCat是被选择的分类
                cat.Url = WebHelper.InsertParam(url, parmsType, catStr);




            }

            return catList;
        }

    }
}
