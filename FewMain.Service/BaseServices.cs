using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FewMain.IRepository;
using FewMain.IService;

namespace FewMain.Service
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        protected IBaseRepository<TEntity> _dal;

        public DbSet<TEntity> DbSet
        {
            get
            {
                return _dal.DbSet;
            }
        }

        public BaseDbContext BaseContext
        {
            get { return _dal.BaseContext; }
        }

        public virtual List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _dal.Query(predicate);
        }

        public virtual List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, params string[] tableNamas)
        {
            return _dal.QueryJoin(predicate, tableNamas);
        }

        public virtual List<TEntity> QueryListByPage(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> keySelector, int pageIndex, int pageSize, out int totalcount)
        {
            return _dal.QueryListByPage(predicate, keySelector, pageIndex, pageSize, out totalcount);
        }

        public virtual void Add(TEntity model)
        {
            _dal.Add(model);
        }

        public virtual void Edit(TEntity model, params string[] propertyNames)
        {
            _dal.Edit(model, propertyNames);
        }

        public virtual void Delete(TEntity model, bool isAddedToDbContext)
        {
            _dal.Delete(model, isAddedToDbContext);
        }


        public virtual List<TSource> QuerySql<TSource>(string sql, params object[] parameters)
        {
            return _dal.QuerySql<TSource>(sql, parameters);
        }


        public int SaveChanges()
        {
            return _dal.SaveChanges();
        }
    }
}
