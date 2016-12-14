using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FewMain.IService
{
    /// <summary>
    /// 业务逻辑父接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IBaseServices<TEntity> where TEntity : class
    {
        #region 3.0 将_dbset以只读属性暴露给外部调用
        //3.0 将_dbset以只读属性暴露给外部调用
        DbSet<TEntity> DbSet { get; }
        #endregion

        #region 4.0 查询

        /// <summary>
        /// 根据条件进行数据的查询，以List泛型集合返回
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// 连表查询方法
        /// </summary>
        /// <param name="predicate">lambda条件表达式</param>
        /// <param name="tableNamas">链表的表名称,一定是和TEntity所对应实体表有主外键关系的</param>
        /// <returns></returns>
        List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, params string[] tableNamas);


        /// <summary>
        /// 用于分页查询
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalcount">符合查询条件的总条数</param>
        /// <returns></returns>
        List<TEntity> QueryListByPage(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> keySelector, int pageIndex, int pageSize, out int totalcount);


        #endregion

        #region 5.0 新增

        /// <summary>
        /// 由于Add方法所接收的TEntity实体是自定义的实体，所以不可能被EF容器追加
        /// 注意点：TEntity的实体一定是程序员new出的
        /// </summary>
        /// <param name="model"></param>
        void Add(TEntity model);

        #endregion

        #region 6.0 编辑

        /// <summary>
        ///Edit中 TEntity 对于的实体 是程序员自定义的（new 出的）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertyNames"></param>
        void Edit(TEntity model, params string[] propertyNames);


        #endregion

        #region 7.0 删除

        /// <summary>
        /// 负责根据实体进行数据的物理删除
        /// </summary>
        /// <param name="model">表示要删除的实体</param>
        /// <param name="isAddedToDbContext">true：当前传入方法的model已经追加到EF上下文容器</param>
        void Delete(TEntity model, bool isAddedToDbContext);

        #endregion

        #region 8.0 统一执行自定义的存储过程或者sql语句
        List<TSource> QuerySql<TSource>(string sql, params object[] parameters);
        #endregion

        #region 8.0 统一操作db

        int SaveChanges();

        #endregion

    }


}
