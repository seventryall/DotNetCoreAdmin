using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jun.Admin.EntityFramework
{
   public class UserRoleRepository: AdminRepositoryBase<Sys_User_Role>,IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Sys_Role> GetUserRoles(string userID)
        {
            var q = from r in db.Sys_Role
                    join ur in db.Sys_User_Role
                    on r.ID equals ur.RoleID
                    where ur.UserID == userID &&(r.IsDelete==null||r.IsDelete==false)
                    select r;
            return q.ToList();
        }
    }
}
