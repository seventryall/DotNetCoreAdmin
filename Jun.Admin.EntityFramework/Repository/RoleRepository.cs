using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Jun.Admin.EntityFramework.Contract;

namespace Jun.Admin.EntityFramework
{
   public class RoleRepository: AdminRepositoryBase<Sys_Role>,IRoleRepository
    {
        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Sys_Role> GetUserRoles(string userID)
        {
            var q = from x in db.Sys_User_Role
                    join y in db.Sys_Role
                    on x.RoleID equals y.ID
                    where (x.IsDelete == false || x.IsDelete == null) && (y.IsDelete == false || y.IsDelete == null)
                    && (x.UserID == userID)
                    select y;
            return q.Select(r => new Sys_Role { ID = r.ID, Name = r.Name, Code = r.Code }).ToList();
        }

        public IEnumerable<Sys_Role> GetAllRole()
        {
            return GetMany(r => r.IsDelete == null || r.IsDelete == false);

        }
    }
}
