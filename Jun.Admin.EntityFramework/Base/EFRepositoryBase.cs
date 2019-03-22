using Jun.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jun.Admin.EntityFramework
{
    public abstract class EFRepositoryBase<T> : IRepository<T> where T : class
    {
        protected AppDbContext db;

        public EFRepositoryBase(AppDbContext _db)
        {
            db = _db;
        }

        public virtual async Task AddAsync(T Entity)
        {

            await db.Set<T>().AddAsync(Entity);
            //return await db.SaveChangesAsync() > 0;
        }

        public virtual void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public virtual void Delete(T Entity)
        {
            db.Set<T>().Remove(Entity);
            //return await db.SaveChangesAsync() > 0;
        }

        public virtual void Update(T Entity)
        {
            db.Set<T>().Update(Entity);
            // return await db.SaveChangesAsync() > 0;
        }

        public virtual T Get(Expression<Func<T, bool>> exp)
        {
            return CompileQuerySingle(exp);
        }

        public virtual T GetByKey(object key)
        {
            return db.Set<T>().Find(key);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> exp)
        {
            return CompileQuery(exp);
        }

        public virtual IEnumerable<T> GetMany<S>(Expression<Func<T, bool>> exp,Expression<Func<T,S>> orderExp,bool isDesc)
        {
            return isDesc? CompileQuery(db.Set<T>().OrderByDescending(orderExp),exp) :
                CompileQuery(db.Set<T>().OrderBy(orderExp), exp);
        }

        public virtual IQueryable<T> QueryMany(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp);
        }

        public virtual IEnumerable<T> GetForPaging<S>(int pageIndex, int pageSize,bool isDesc, Expression<Func<T, bool>> exp, 
            Expression<Func<T, S>> orderByExpression,out int count)
        {
            count = 0;
            var orderQueryable = isDesc ? db.Set<T>().OrderByDescending(orderByExpression) : db.Set<T>().OrderBy(orderByExpression);
            count = CompileQueryCount(orderQueryable, exp);
            return CompileQueryPage(orderQueryable, exp, pageIndex, pageSize);
            //return CompileQuery(orderQueryable,exp).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        private IEnumerable<T> CompileQuery(IQueryable<T> orderQueryable, Expression<Func<T, bool>> exp)
        {
            var func = EF.CompileQuery((AppDbContext context, Expression<Func<T, bool>> exps) => orderQueryable.Where(exp));
            return func(db, exp);

        }

        private  int CompileQueryCount(IQueryable<T> orderQueryable, Expression<Func<T, bool>> exp)
        {
            var func =  EF.CompileQuery((AppDbContext context, Expression<Func<T, bool>> exps) => orderQueryable.Where(exp).Count());
            return func(db, exp);
        }

        private IEnumerable<T> CompileQueryPage(IQueryable<T> orderQueryable, Expression<Func<T, bool>> exp,int pageIndex,int pageSize)
        {
            var func = EF.CompileQuery((AppDbContext context, Expression<Func<T, bool>> exps) => orderQueryable.Where(exp).
            Skip((pageIndex - 1) * pageSize).Take(pageSize));
            return func(db, exp);
        }


        private IEnumerable<T> CompileQuery(Expression<Func<T, bool>> exp)
        {
            var func = EF.CompileQuery((AppDbContext context, Expression<Func<T, bool>> exps) => context.Set<T>().Where(exp));
            return func(db, exp);
        }

        private T CompileQuerySingle(Expression<Func<T, bool>> exp)
        {
            var func = EF.CompileQuery((AppDbContext context, Expression<Func<T, bool>> exps) => context.Set<T>().FirstOrDefault(exp));
            return func(db, exp);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await db.SaveChangesAsync() > 0;
        }

       
    }
}
