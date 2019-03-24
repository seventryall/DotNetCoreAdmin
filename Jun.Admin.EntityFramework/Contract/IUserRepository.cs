using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework.Contract
{
    public interface IUserRepository
    {
        Sys_User GetUser(string userName, string userPwd);

        IEnumerable<Sys_User> GetAllUsers();
    }
}
