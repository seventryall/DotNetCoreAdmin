using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace Jun.Admin.EntityFramework
{
   public class RoleMenuFuncRepository: AdminRepositoryBase<Sys_Role_Menu_Function>,IRoleMenuFuncRepository
    {
        public RoleMenuFuncRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Sys_Role_Menu_Function> GetAllRoleMenuFunc()
        {
            return GetMany(rmf=>rmf.IsDelete==false||rmf.IsDelete==null);
        }

        public IEnumerable<Sys_Role_Menu_Function> GetUserAuthMenuFunc(string userID)
        {
            var sql = @"select distinct(Menu_ID,Function_ID) from sys_role_memu_function
                        where exists 
                        (select roleid from sys_user_role where userid=@userId)";
            return FromSql(sql, new SqlParameter("userId", userID));
        }

        public IEnumerable<AuthMenuFuncView> GetUserAuthMenuFuncView(string userID)
        {
            var q = from x in db.Sys_Menu
                    join y in db.Sys_Role_Menu_Function
                    on x.ID equals y.MenuID
                    join z in db.Sys_Function
                    on y.FunctionID equals z.ID
                    where
                    (from u in db.Sys_User_Role where u.UserID == userID select u.RoleID).Contains(y.RoleID)
                    && (x.IsDelete == null || x.IsDelete == false) && (z.IsDelete == null || z.IsDelete == false)
                    select new AuthMenuFuncView { Menu = x, Function = z };
            return q.Distinct();
                  


  



        }
       
    }
}
