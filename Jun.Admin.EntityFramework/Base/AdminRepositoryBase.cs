using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun.Admin.EntityFramework
{
   public class AdminRepositoryBase<T>:EFRepositoryBase<T> where T:class
    {
        public AdminRepositoryBase(AppDbContext dbContext)
            : base(dbContext)
        {
        }

        public override void Add(T entity)
        {
            base.Add(entity);
        }

        public override Task AddAsync(T Entity)
        {
            return base.AddAsync(Entity);
        }

        public override void Update(T Entity)
        {
            base.Update(Entity);
        }

        public async Task<int> ExecSqlCommandAsync(string sql, params object[] parameters)
        {
            return await db.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public IQueryable<T> FromSql(string sql, params object[] parameters)
        {
            return db.Set<T>().FromSql(sql, parameters);
        }

       
    }
}
