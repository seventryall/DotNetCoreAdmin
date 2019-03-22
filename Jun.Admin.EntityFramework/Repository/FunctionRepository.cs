using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework
{
   public class FunctionRepository: AdminRepositoryBase<Sys_Function>,IFunctionRepository
    {
        public FunctionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Sys_Function> GetAllFunction()
        {
            return GetMany(f => f.IsDelete == false || f.IsDelete == null);
        }
    }
}
