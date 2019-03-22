using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework
{
   public class MenuFuncRepository: AdminRepositoryBase<Sys_Menu_Function>,IMenuFuncRepository
    {
        public MenuFuncRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Sys_Menu_Function> GetAllMenuFunc()
        {
            return GetMany(mf=>mf.IsDelete==false||mf.IsDelete==null);
        }
    }
}
