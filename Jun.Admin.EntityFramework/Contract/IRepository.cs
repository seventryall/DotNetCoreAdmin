using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jun.Admin.EntityFramework
{
    public interface IRepository<T> where T : class
    {
         Task AddAsync(T Entity);
         void Add(T entity);

        void Delete(T Entity);

         void Update(T Entity);

        T GetByKey(object key);

        T Get(Expression<Func<T, bool>> exp);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> exp);

        IQueryable<T> QueryMany(Expression<Func<T, bool>> where);


        IEnumerable<T> GetForPaging<S>(int pageIndex, int pageSize, bool isDesc, Expression<Func<T, bool>> exp,
            Expression<Func<T, S>> orderByExpression, out int count);



    }
}
