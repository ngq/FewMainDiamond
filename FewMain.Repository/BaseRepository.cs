using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FewMain.IRepository;
using FewMain.Model;

namespace FewMain.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region 1.0 实例化EF的上下文容器
        //1.0 实例化EF的上下文容器
        //由于我们每个仓储子类的实例化都会导致新实例化一个EF的上下文容器，所以不能这样写
        //BaseDbContext db = new BaseDbContext();

        //解决方案：在每一次http请求到达服务器的时候，在第一个请求达到的时候创建EF的上下文容器对象
        //在此线程的其他代码执行的时候公用第一次创建好的ef上下文容器，保证了一个HTTP的子线程只有一份
        //EF的上下文容器对象
        public BaseDbContext BaseContext
        {
            get
            {
                //1.0 先从当前线程的缓存中获取BaseDbContext的对象
                BaseDbContext dbcontext = CallContext.GetData(typeof(BaseDbContext).FullName) as BaseDbContext;
                //2.0 如果在当前线程中没有获取当前上下文的对象实例
                if (dbcontext == null)
                {
                    //3.0 重写实例化一个EF上下文对象实例
                    BaseDbContext _db = new BaseDbContext();
                    dbcontext = _db;
                    //4.0 将_db 存入当前的线程缓存中
                    CallContext.SetData(typeof(BaseDbContext).FullName, _db);
                }
                return dbcontext;
            }
        }

        #endregion

        #region 2.0 定义私有成员_dbset 被构造函数初始化
        //2.0 定义私有成员_dbset 被构造函数初始化
        DbSet<TEntity> _dbset;
        //2.0 定义一个构造函数处理DbSet<TEntity>
        public BaseRepository()
        {
            _dbset = BaseContext.Set<TEntity>();
        }
        #endregion

        #region 3.0 将_dbset以只读属性暴露给外部调用
        //3.0 将_dbset以只读属性暴露给外部调用
        public DbSet<TEntity> DbSet
        {
            get
            {
                return _dbset;
            }
        }
        #endregion

        #region 4.0 查询

        /// <summary>
        /// 根据条件进行数据的查询，以List泛型集合返回
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }


        /// <summary>
        /// 连表查询方法
        /// </summary>
        /// <param name="predicate">lambda条件表达式</param>
        /// <param name="tableNamas">链表的表名称,一定是和TEntity所对应实体表有主外键关系的</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, params string[] tableNamas)
        {
            //1.0 将dbSet 赋值给父类DbQuery
            DbQuery<TEntity> query = _dbset;
            //2.0 遍历链接表数组，一一与TEntity对应的主表进行join操作
            if (tableNamas != null && tableNamas.Length > 0)
            {
                foreach (var tbname in tableNamas)
                {
                    query = query.Include(tbname);
                }
            }
            //3.0 将查询条件追加
            return query.Where(predicate).ToList();
        }

        /// <summary>
        /// 用于分页查询
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalcount">符合查询条件的总条数</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryListByPage(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> keySelector, int pageIndex, int pageSize, out int totalcount)
        {
            totalcount = 0;

            //1.0 计算出满足条件的总条数
            totalcount = _dbset.Count(predicate);

            //2.0 根据条件和分页参数进行分页数据的获取
            return _dbset.Where(predicate).OrderByDescending(keySelector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        #endregion

        #region 5.0 新增

        /// <summary>
        /// 由于Add方法所接收的TEntity实体是自定义的实体，所以不可能被EF容器追加
        /// 注意点：TEntity的实体一定是程序员new出的
        /// </summary>
        /// <param name="model"></param>
        public virtual void Add(TEntity model)
        {
            if (model == null)
            {
                throw new Exception("Add方法参数model不能为空");
            }

            //1.0 调用dbset中的Add方法将model追加到EF容器并且将其的状态修改成added
            _dbset.Add(model);
        }

        #endregion

        #region 6.0 编辑

        /// <summary>
        ///Edit中 TEntity 对于的实体 是程序员自定义的（new 出的）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertyNames"></param>
        public virtual void Edit(TEntity model, params string[] propertyNames)
        {
            //1.0 参数合法性验证
            if (propertyNames == null || propertyNames.Length == 0)
            {
                throw new Exception("edit方法参数propertyNames至少要有一个值");
            }

            if (model == null)
            {
                throw new Exception("edit方法参数model不能为空");
            }

            //2.0 利用BaseContext.Entry()将model追加到EF容器中
            DbEntityEntry entry = BaseContext.Entry(model);

            //3.0 将代理类的状态修改成 unchanged
            entry.State = EntityState.Unchanged;

            //4.0 遍历当前属性数组中的值，将其的IsModified 设置成true
            foreach (var item in propertyNames)
            {
                entry.Property(item).IsModified = true;
            }
        }

        #endregion

        #region 7.0 删除

        /// <summary>
        /// 负责根据实体进行数据的物理删除
        /// </summary>
        /// <param name="model">表示要删除的实体</param>
        /// <param name="isAddedToDbContext">true：当前传入方法的model已经追加到EF上下文容器</param>
        public virtual void Delete(TEntity model, bool isAddedToDbContext)
        {
            //1.0 参数合法性验证
            if (model == null)
            {
                throw new Exception("Delete方法参数model不能为空");
            }

            if (isAddedToDbContext == false)
            {
                //DbEntityEntry entry = BaseContext.Entry(model);
                //entry.State = System.Data.EntityState.Deleted;
                _dbset.Attach(model);
            }
            _dbset.Remove(model);
        }


        #endregion

        #region 8.0 负责根据程序员传入的自定义实例，执行sql语句返回指定自定义实例的集合

        /// <summary>
        /// 负责执行一段sql语句或者存储过程 传入相应的参数
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="sql">代表sql语句 或者存储过程的名称， Usp_ddd @uid </param>
        /// <param name="parameters">   System.Data.SqlClient.SqlParameter 的数组 </param>
        /// <returns></returns>
        public List<TSource> QuerySql<TSource>(string sql, params object[] parameters)
        {
            return BaseContext.Database.SqlQuery<TSource>(sql, parameters).ToList();
        }

        #endregion

        #region 8.0 统一操作db

        public virtual int SaveChanges()
        {
            //关闭实体属性的验证
            BaseContext.Configuration.ValidateOnSaveEnabled = false;
            
            return BaseContext.SaveChanges();
        }

        #endregion
    }
}
