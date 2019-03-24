using Jun.Admin.Entity;
using Jun.Admin.EntityFramework.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework
{
    public class UserRepository : AdminRepositoryBase<Sys_User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Sys_User GetUser(string userName, string userPwd)
        {
            return Get(x => x.UserName == userName && x.UserPwd == userPwd && (x.IsDelete == false || x.IsDelete == null));
        }

        public IEnumerable<Sys_User> GetAllUsers()
        {
            return GetMany(u => u.IsDelete == null || u.IsDelete == false);
        }
    }
}
